using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebsiteTinhThanFoundation.Models;
using WebsiteTinhThanFoundation.Services.Interface;
using WebsiteTinhThanFoundation.ViewModels;
using X.PagedList;

namespace WebsiteTinhThanFoundation.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogArticleService _blogArticleService;
        private readonly ITagService _tagService;
        public BlogController(IBlogArticleService blogArticleService, ITagService tagService)
        {
            _blogArticleService = blogArticleService;
            _tagService = tagService;
        }

        public async Task<IActionResult> Index(string? keyword, string? tagname ,int? page)
        {
            int pagesize = 10;
            int pagenumber = page == null || page < 0 ? 1 : page.Value;
            var blogs = await _blogArticleService.GetAllAsync(keyword, tagname);
            var taglist = await _tagService.GetFeatureAsync(12);
            var bloglist = new PagedList<BlogArticle>(blogs, pagenumber, pagesize);
            var blogFeature = await _blogArticleService.GetFeatureAsync();
            BlogArticleList model = new ()
            {
                BlogArticles = bloglist,
                Tags = taglist,
                BlogFeature = blogFeature
            };
            return View(model);
        }

        public async Task<IActionResult> Article(string? permalink)
        {
            var blog = await _blogArticleService.GetByPermalink(permalink, x => x.Include(t => t.Tags).ThenInclude(q => q.Tag!));
            var blogFeature = await _blogArticleService.GetFeatureAsync();
            BlogDetailVM model = new()
            {
                BlogDetail = blog ?? new BlogArticle(),
                BlogFeature = blogFeature
            };
            return View(model);
        }    
    }
}
