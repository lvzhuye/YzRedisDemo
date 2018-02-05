using ChapterOne.Models.ViewModels;
using ChapterOne.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChapterOne.Controllers
{
    public class ArticleController : Controller
    {
        //
        // GET: /Article/
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 创建文章
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateArticle()
        {
            IArticleService articleService = new ArticleService();
            var createArticleVm = new CreateArticleVm
            {
                title="testTitle",
                link="www.baidu.com",
                poster=""
            };
            articleService.CreateArticle(createArticleVm);
            return null;
        }
	}
}