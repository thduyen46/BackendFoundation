using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebsiteTinhThanFoundation.Helpers;
using WebsiteTinhThanFoundation.Models;
using WebsiteTinhThanFoundation.Services.Interface;

namespace WebsiteTinhThanFoundation.Areas.Admin.Controllers
{
    [Authorize]
    [Authorize(Policy = Constants.Policies.RequireAdmin)]
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly IBlogArticleService _blogArticleService;
        private readonly ILogger<BlogController> _logger;
        private readonly IUserService _userService;
        public BlogController(IBlogArticleService blogArticleService, ILogger<BlogController> logger, IUserService userService)
        {
            _blogArticleService = blogArticleService;
            _logger = logger;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var model = await _blogArticleService.GetAllAsync();
                this.AddToastrMessage("Tải dữ liệu thành công", Enums.ToastrMessageType.Success);
                return View(model);
            }catch (Exception ex)
            {
                this.AddToastrMessage("Đã có lỗi xảy ra", Enums.ToastrMessageType.Error);
                _logger.LogError
                    (ex.Message);
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BlogArticle model)
        {
            try
            {
                var user = await _userService.GetUser();
                if(user == null) {
                    this.AddToastrMessage("Vui lòng đăng nhập lại và thử lại", Enums.ToastrMessageType.Error);
                    return RedirectToAction(nameof(Create));
                }
                await _blogArticleService.Add(model, user.Id);
                return RedirectToAction(nameof(Index));
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return View(model);
        }
    }
}
