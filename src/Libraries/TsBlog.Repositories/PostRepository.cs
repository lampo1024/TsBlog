using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using TsBlog.Domain.Entities;

namespace TsBlog.Repositories
{
    /// <summary>
    /// POST表的数据库操作类
    /// </summary>
    public class PostRepository
    {

        /// <summary>
        /// 根据ID查询
        /// </summary>
        /// <param name="id">Post ID</param>
        /// <returns></returns>
        public Post FindById(int id)
        {
            var ds = MySqlHelper.Query("SELECT * FROM tb_post WHERE Id=@Id", new MySqlParameter("@Id",id));
            var entity = ds.Tables[0].ToList<Post>().FirstOrDefault();
            return entity;
        }

        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        public List<Post> FindAll()
        {
            var ds = MySqlHelper.Query("SELECT * FROM tb_post");
            return ds.Tables[0].ToList<Post>();
        }
    }
}