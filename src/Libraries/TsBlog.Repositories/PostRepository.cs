using System.Collections.Generic;
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
            #region Ado.net读取方式
            //var ds = MySqlHelper.Query("SELECT * FROM tb_post WHERE Id=@Id", new MySqlParameter("@Id",id));
            //var entity = ds.Tables[0].ToList<Post>().FirstOrDefault();
            //return entity; 
            #endregion


            #region SqlSugar读取方式
            using (var db = DbFactory.GetSqlSugarClient())
            {
                var entity = db.Queryable<Post>().Single(x => x.Id == id);
                return entity;
            } 
            #endregion
        }

        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        public List<Post> FindAll()
        {
            #region Ado.net读取方式
            //var ds = MySqlHelper.Query("SELECT * FROM tb_post");
            //return ds.Tables[0].ToList<Post>(); 
            #endregion

            #region SqlSugar读取方式
            using (var db = DbFactory.GetSqlSugarClient())
            {
                var list = db.Queryable<Post>().ToList();
                return list;
            } 
            #endregion
        }
    }
}