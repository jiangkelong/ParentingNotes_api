using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParentingNotes_Api.Services.Interfaces
{
    /// <summary>
    /// AES解密
    /// </summary>
    /// <param name="encryptedData">待解密的字节数组</param>
    /// <param name="sessionKey">解密密钥字节数组</param>
    /// <param name="iv">IV初始化向量字节数组</param>
    /// <returns></returns>
    public interface IDecryptService
    {
        string DecryptByAesBytes(string encryptedData, string sessionKey, string iv);
    }
}
