using SqlSugar;
using System;

namespace TsBlog.Domain.Entities
{
    [SugarTable("tb_user")]
    public class User
    {
        [SugarColumn(IsIdentity = true, IsPrimaryKey = true)]
        public int Id { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string RealName { get; set; }
        public string EmailAddress { get; set; }
        public string Avatar { get; set; }
        public int Status { get; set; }
        public string Telephone { get; set; }
        public string Qq { get; set; }
        public string WebsiteUrl { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedIp { get; set; }
        public int LoginCount { get; set; }
        public DateTime? LatestLoginDate { get; set; }
        public string LatestLoginIp { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int Type { get; set; }
    }
}
