using System.Text.RegularExpressions;

namespace TsBlog.Core
{
    public static class HtmlHelper
    {
        #region 去掉HTML中的所有标签,只留下纯文本
        /// <summary>
        /// 去掉HTML中的所有标签,只留下纯文本
        /// </summary>
        /// <param name="strHtml"></param>
        /// <returns></returns>
        public static string CleanHtml(this string strHtml)
        {
            if (string.IsNullOrEmpty(strHtml)) return strHtml;
            //删除脚本
            strHtml = Regex.Replace(strHtml, "(\\<script(.+?)\\</script\\>)|(\\<style(.+?)\\</style\\>)", "", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            //删除标签
            var r = new Regex(@"<\/?[^>]*>", RegexOptions.IgnoreCase);
            Match m;
            for (m = r.Match(strHtml); m.Success; m = m.NextMatch())
            {
                strHtml = strHtml.Replace(m.Groups[0].ToString(), "");
            }
            return strHtml.Trim();
        }

        #endregion
    }
}
