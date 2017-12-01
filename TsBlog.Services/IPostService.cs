using System.Collections.Generic;
using TsBlog.Domain.Entities;

namespace DunxPay.Services
{
    public interface IPostService
    {
        /// <summary>
        /// 根据ID查询单条数据
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        Post FindById(int id);
        /// <summary>
        /// 查询所有数据(无分页,大数量时请慎用)
        /// </summary>
        /// <returns></returns>
        IEnumerable<Post> FindAll();

        /// <summary>
        /// 写入实体数据
        /// </summary>
        /// <param name="entity">博文实体类</param>
        /// <returns></returns>
        int Insert(Post entity);

        /// <summary>
        /// 更新实体数据
        /// </summary>
        /// <param name="entity">博文实体类</param>
        /// <returns></returns>
        bool Update(Post entity);

        /// <summary>
        /// 根据实体删除一条数据
        /// </summary>
        /// <param name="entity">博文实体类</param>
        /// <returns></returns>
        bool Delete(Post entity);

        /// <summary>
        /// 删除指定ID的数据
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        bool DeleteById(object id);

        /// <summary>
        /// 删除指定ID集合的数据(批量删除)
        /// </summary>
        /// <param name="ids">主键ID集合</param>
        /// <returns></returns>
        bool DeleteByIds(object[] ids);
    }
}
