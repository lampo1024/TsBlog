namespace TsBlog.AutoMapperConfig
{
    /// <summary>
    /// AutoMapper初始化类
    /// </summary>
    public class AutoMapperStartupTask 
    {
        public void Execute()
        {
            AutoMapperConfiguration.Init();
        }
    }
}