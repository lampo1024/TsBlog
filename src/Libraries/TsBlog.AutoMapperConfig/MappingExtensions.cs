using TsBlog.Domain.Entities;
using TsBlog.ViewModel.Post;
using TsBlog.ViewModel.User;

namespace TsBlog.AutoMapperConfig
{
    /// <summary>
    /// 数据库表-实体映射静态扩展类
    /// </summary>
    public static class MappingExtensions
    {
        public static TDestination MapTo<TSource, TDestination>(this TSource source)
        {
            return AutoMapperConfiguration.Mapper.Map<TSource, TDestination>(source);
        }

        public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
        {
            return AutoMapperConfiguration.Mapper.Map(source, destination);
        }

        #region Post
        public static PostViewModel ToModel(this Post entity)
        {
            return entity.MapTo<Post, PostViewModel>();
        }

        public static Post ToEntity(this PostViewModel model)
        {
            return model.MapTo<PostViewModel, Post>();
        }

        #endregion

        #region User
        public static UserViewModel ToModel(this User entity)
        {
            return entity.MapTo<User, UserViewModel>();
        }

        public static User ToEntity(this UserViewModel model)
        {
            return model.MapTo<UserViewModel, User>();
        }

        #endregion

    }
}