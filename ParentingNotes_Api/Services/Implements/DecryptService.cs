using Newtonsoft.Json;
using ParentingNotes_Api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ParentingNotes_Api.Services.Implements
{
    public class DecryptService : IDecryptService
    {
        public string DecryptByAesBytes(string encryptedData, string sessionKey, string iv)
        {
            string unionid = "";
            try
            {
                //非空验证
                if (!string.IsNullOrWhiteSpace(encryptedData) && !string.IsNullOrWhiteSpace(sessionKey) && !string.IsNullOrWhiteSpace(iv))
                {
                    var decryptBytes = Convert.FromBase64String(encryptedData.Replace(' ', '+'));
                    var keyBytes = Convert.FromBase64String(sessionKey.Replace(' ', '+'));
                    var ivBytes = Convert.FromBase64String(iv.Replace(' ', '+'));

                    var aes = new AesCryptoServiceProvider
                    {
                        Key = keyBytes,
                        IV = ivBytes,
                        Mode = CipherMode.CBC,
                        Padding = PaddingMode.PKCS7
                    };

                    var outputBytes = aes.CreateDecryptor().TransformFinalBlock(decryptBytes, 0, decryptBytes.Length);

                    var decryptResult = Encoding.UTF8.GetString(outputBytes);
                    dynamic decryptData = JsonConvert.DeserializeObject(decryptResult, new { unionid = "" }.GetType());
                    unionid =  decryptData.unionid;
                }
                else
                {
                    return "";
                }
            }
            catch (Exception e)
            {
                
            }
            return unionid;
        }
    }
}
