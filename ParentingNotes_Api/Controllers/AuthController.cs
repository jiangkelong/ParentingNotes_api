using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ParentingNotes_Api.Common;
using ParentingNotes_Api.Models;
using ParentingNotes_Api.Models.ViewModels;
using ParentingNotes_Api.Services.Interfaces;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ParentingNotes_Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
        //private readonly IDecryptService _decryptService;
        /// <summary>
        /// 
        /// </summary>
        public AuthController(ITokenService tokenService, IUserService userService)
        {
            _tokenService = tokenService;
            _userService = userService;
            //_decryptService = decryptService;
        }
        public async Task<IActionResult> wxLogin(DecryptUserInfoViewModel data)
        {
            string param = $"?appid={WxConfig.APPID}&secret={WxConfig.APPSECRET}&js_code={data.code}&grant_type=authorization_code";
            string url = "https://api.weixin.qq.com/sns/jscode2session" + param;
            var res = new ApiResult<WeXinLoginReponseViewModel>() { statusCode = 200 };
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
            using (var http = new HttpClient(handler))
            {
                //await异步等待回应
                var response = await http.GetAsync(url);
                //确保HTTP成功状态值
                response.EnsureSuccessStatusCode();
                var a = response.StatusCode;

                //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                string responseContent = await response.Content.ReadAsStringAsync();
                var resultModel = JsonConvert.DeserializeObject<WeXinLoginResultViewModel>(responseContent);
                /**
                 * 通过openID判断用户是否存在
                 * 如果存在，更新nickname、avatarUrl
                 * 否则，解密获取unionId，插入用户
                 * 生成token
                */
                var user = new User();
                user.openId = resultModel.OpenId;
                user.nickname = data.nickname;
                user.avatarUrl = data.avatarUrl;
                if (await _userService.existAsync(resultModel.OpenId))
                {
                    await _userService.ModifyAsync(user);
                }
                else
                {
                    //解码
                    //user.unionId = _decryptService.DecryptByAesBytes(data.encryptedData, resultModel.Session_Key, data.iv);
                    await _userService.AddAsync(user);
                }
                var _response = new WeXinLoginReponseViewModel
                {
                    openId = resultModel.OpenId,
                    token = await _tokenService.GetToken(resultModel.OpenId)
                };
                res.data= _response;
                //返回结果
                return Ok(res);
            }
        }
        /// <summary>
        /// 刷新Token
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>s
        public async Task<IActionResult> RefreshToken(string openid)
        {
            var res = new ApiResult<string>() { statusCode = 200 };
            res.data = await _tokenService.GetToken(openid);
            return Ok(res);
        }
    }
}