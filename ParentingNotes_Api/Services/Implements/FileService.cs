using Microsoft.AspNetCore.Http;
using ParentingNotes_Api.Common;
using ParentingNotes_Api.Services.Interfaces;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ParentingNotes_Api.Services.Implements
{
    public class FileService : DbContext, IFileService
    {
        public async Task<ApiResult<string>> UploadAvatar(IFormFile file)
        {
            var res = new ApiResult<string>();
            if (file == null || file.Length <= 0)
            {
                res.message = "图片无效";
                res.statusCode = (int)ApiEnum.Error;
            }
            else
            {
                try
                {
                    string webRootPath = Config._iHostingEnvironment.WebRootPath; // wwwroot 文件夹
                    string uploadPath = Path.Combine("uploads", "avatar");
                    string dirPath = Path.Combine(webRootPath, uploadPath);
                    if (!Directory.Exists(dirPath))
                    {
                        Directory.CreateDirectory(dirPath);
                    }
                    string fileExt = Path.GetExtension(file.FileName).Trim('.'); //文件扩展名，不含“.”
                    string newFileName = Guid.NewGuid().ToString().Replace("-", "") + "." + fileExt; //随机生成新的文件名
                    var filePath = Path.Combine(dirPath, newFileName);

                    using (FileStream fs = File.Create(filePath))
                    {
                        await file.CopyToAsync(fs);
                        fs.Flush();
                    }
                    res.data = "uploads/avatar/" + newFileName;
                }
                catch (Exception ex)
                {
                    res.statusCode = (int)ApiEnum.Error;
                    res.message = "上传失败：" + ex.Message;
                }
            }
            return res;
        }
    }
}
