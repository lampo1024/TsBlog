using Autofac;
using Autofac.Features.ResolveAnything;
using Autofac.Integration.Mvc;
using System.Linq;
using System.Reflection;
using System.Web.Compilation;
using System.Web.Mvc;
using System.Web.Routing;
using TsBlog.AutoMapperConfig;
using TsBlog.Repositories;

namespace TsBlog.Frontend
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutofacRegister();

            AutoMapperRegister();
        }

        private void AutofacRegister()
        {
            var builder = new ContainerBuilder();

            //注册MvcApplication程序集中所有的控制器
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            ////注册仓储层服务
            ////builder.RegisterType<PostRepository>().As<IPostRepository>();
            ////注册基于接口约束的实体
            //var assembly = AppDomain.CurrentDomain.GetAssemblies();
            //builder.RegisterAssemblyTypes(assembly)
            //    .Where(
            //        t => t.GetInterfaces()
            //            .Any(i => i.IsAssignableFrom(typeof(IDependency)))
            //    )
            //    .AsImplementedInterfaces()
            //    .InstancePerDependency();

            //注册仓储层服务
            //builder.RegisterType<PostRepository>().As<IPostRepository>();
            //注册基于接口约束的实体
            //var assembly = AppDomain.CurrentDomain.GetAssemblies();
            var assemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>()
                .Where(
                    assembly =>
                        assembly.GetTypes().FirstOrDefault(type => type.GetInterfaces().Contains(typeof(IDependency))) !=
                        null
                );

            builder.RegisterAssemblyTypes(assemblies.ToArray())
                .AsImplementedInterfaces()
                .InstancePerDependency();

            //builder.RegisterGeneric(typeof(GenericRepository<>))
            //    .As(typeof(IRepository<>));
            //builder.RegisterGeneric(typeof(GenericService<>))
            //    .As(typeof(IService<>));

            //builder.RegisterGeneric(typeof(GenericRepository<>));
            //builder.RegisterGeneric(typeof(GenericService<>));

            //注册服务层服务
            //builder.RegisterType<PostService>().As<IPostService>();

            //注册过滤器
            builder.RegisterFilterProvider();
            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());
            var container = builder.Build();

            //设置依赖注入解析器
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }

        /// <summary>
        /// AutoMapper的配置初始化
        /// </summary>
        private void AutoMapperRegister()
        {
            new AutoMapperStartupTask().Execute();
        }
    }
}
