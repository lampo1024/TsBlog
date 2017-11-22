using System.Configuration;

namespace TsBlog.Repositories
{
    /// <summary>
    /// 静态配置类
    /// </summary>
    public static class Config
    {
        /// <summary>
        /// 数据库连接字符串(私有字段)
        /// </summary>
        private static readonly string _connectionString =ConfigurationManager.ConnectionStrings["TsBlogMySQLDb"].ConnectionString;
        /// <summary>
        /// 数据库连接字符串(公有属性)
        /// </summary>
        public static string ConnectionString
        {
            get { return _connectionString; }   
        }
    }
}
