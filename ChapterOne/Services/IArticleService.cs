using ChapterOne.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapterOne.Services
{
    public interface IArticleService
    {
        void CreateArticle(CreateArticleVm createArticleVm);
    }
}
