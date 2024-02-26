using Microsoft.EntityFrameworkCore.Query;
using WebsiteTinhThanFoundation.Models;

namespace WebsiteTinhThanFoundation.Services.Interface
{
    public interface IBlogArticleService
    {
        public Task<BlogArticle?> GetByAsync(Guid? Id);
        public BlogArticle? GetById(Guid? Id);
        public Task<ICollection<BlogArticle>> GetAllAsync(Func<IQueryable<BlogArticle>, IIncludableQueryable<BlogArticle, object>>? includes = null);
        public Task Add(BlogArticle model, string userId);
        public Task Update(BlogArticle model);
        public Task Delete(Guid? Id);

    }
}
