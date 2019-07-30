using Autofac;
using Autofac.Features.ResolveAnything;
using Autofac.Integration.Mvc;
using System.Linq;
using System.Reflection;
using System.Web.Compilation;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac.Integration.WebApi;
using TsBlog.AutoMapperConfig;
using TsBlog.Repositories;

namespace TsBlog.Frontend
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            
            //BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutofacRegister();

            AutoMapperRegister();
        }

        private void AutofacRegister()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //注册MvcApplication程序集中所有的控制器
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

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

            //注册过滤器
            builder.RegisterFilterProvider();
            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());

            

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // OPTIONAL: Register the Autofac model binder provider.
            builder.RegisterWebApiModelBinderProvider();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

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
