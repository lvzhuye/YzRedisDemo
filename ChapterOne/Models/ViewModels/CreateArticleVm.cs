using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChapterOne.Models.ViewModels
{
    public class CreateArticleVm
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// 文章的网址
        /// </summary>
        public string link { get; set; }

        /// <summary>
        /// 发布文章的用户
        /// </summary>
        public string poster { get; set; }
    }
}