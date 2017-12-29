using System.Security.Cryptography;
using System.Text;

namespace TsBlog.Core.Security
{
    /// <summary>
    /// 加密静态类
    /// </summary>
    public static class Encryptor
    {
        //MD5加密一个字符串
        public static string Md5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(Encoding.ASCII.GetBytes(text));

            var result = md5.Hash;

            var strBuilder = new StringBuilder();
            foreach (var t in result)
            {
                strBuilder.Append(t.ToString("x2"));
            }

            return strBuilder.ToString();
        }
    }
}
