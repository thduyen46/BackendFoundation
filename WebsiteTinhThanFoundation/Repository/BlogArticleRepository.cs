using WebsiteTinhThanFoundation.Data;
using WebsiteTinhThanFoundation.Models;
using WebsiteTinhThanFoundation.Repository.GenericRepository;
using WebsiteTinhThanFoundation.Repository.Interface;

namespace WebsiteTinhThanFoundation.Repository
{
    public class BlogArticleRepository : GenericRepository<BlogArticle>, IBlogArticleRepository
    {
        public BlogArticleRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
