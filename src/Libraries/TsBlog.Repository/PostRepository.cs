using SqlSugar;
using TsBlog.Domain;

namespace TsBlog.Repository
{

    public class DbConnectionFactory
    {
        protected static string ConnectionString { get; set; }

        static DbConnectionFactory()
        {
            ConnectionString =
                "Server=localhost;Database=TsBlog;UID=root;Password=123456;Allow User Variables=True;AllowZeroDateTime=True;ConvertZeroDateTime=True";
        }
        public static SqlSugarClient GetDbConnection(string connString = null)
        {
            var db = new SqlSugarClient(
                new ConnectionConfig()
                {
                    ConnectionString = ConnectionString,
                    DbType = DbType.MySql,
                    InitKeyType = InitKeyType.SystemTable //初始化主键和自增列信息到ORM的方式
                });
            return db;
        }
    }
    public class PostRepository
    {
        public static SqlSugarClient DbConnection
        {
            get { return DbConnectionFactory.GetDbConnection(); }
        }

        public Post Read()
        {
            using (var db = DbConnection)
            {
                var item = db.Queryable<Post>().First();
                return item;
            }
        }
    }
}
