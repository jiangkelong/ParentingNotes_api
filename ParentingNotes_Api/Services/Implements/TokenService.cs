﻿using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ParentingNotes_Api.Common;
using ParentingNotes_Api.Services.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ParentingNotes_Api.Services.Implements
{
    public class TokenService : ITokenService
    {
        private readonly JwtSetting _jwtSetting;
        private readonly IUserService _userService;
        public TokenService(IOptions<JwtSetting> option, IUserService iUserService)
        {
            _jwtSetting = option.Value;
            _userService = iUserService;
        }
        public async Task<string> GetToken(string openid)
        {
            var user = await _userService.GetByOpenIdAsync(openid);
            //创建用户身份标识,这里可以随意加入自定义的参数，key可以自己随便起
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Nbf,$"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}") ,
                new Claim (JwtRegisteredClaimNames.Exp,$"{new DateTimeOffset(DateTime.Now.AddMinutes(30)).ToUnixTimeSeconds()}"),
                new Claim("userId", user.id.ToString())
            };
            //sign the token using a secret key.This secret will be shared between your API and anything that needs to check that the token is legit.
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSetting.SecurityKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            //.NET Core’s JwtSecurityToken class takes on the heavy lifting and actually creates the token.
            var token = new JwtSecurityToken(
                //颁发者
                issuer: _jwtSetting.Issuer,
                //接收者
                audience: _jwtSetting.Audience,
                //过期时间
                expires: DateTime.Now.AddMinutes(30),
                //签名证书
                signingCredentials: creds,
                //自定义参数
                claims: claims
                );
            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return jwtToken;
        }
    }
}
