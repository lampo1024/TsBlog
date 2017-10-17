using SqlSugar;

namespace TsBlog.Domain
{
    public class Post
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string CleanContent { get; set; }
    }
}
