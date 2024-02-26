using Microsoft.EntityFrameworkCore.Query;
using WebsiteTinhThanFoundation.Helpers;
using WebsiteTinhThanFoundation.Models;
using WebsiteTinhThanFoundation.Repository.UnitOfWork;
using WebsiteTinhThanFoundation.Services.Interface;

namespace WebsiteTinhThanFoundation.Services
{
    public class BlogArticleService : IBlogArticleService
    {
        public IUnitOfWork _unitOfWork;
        public BlogArticleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Add(BlogArticle model, string userId)
        {
            model.UserId = userId;
            model.UserUpdateId = userId;
            model.CreatedOn = DateTime.UtcNow.ToTimeZone();
            model.DateUpdate = DateTime.UtcNow.ToTimeZone();
            _unitOfWork.BlogArticleRepository.Add(model);
            await _unitOfWork.CommitAsync();
        }

        public Task Delete(Guid? Id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<BlogArticle>> GetAllAsync(Func<IQueryable<BlogArticle>, IIncludableQueryable<BlogArticle, object>>? includes = null)
            => await _unitOfWork.BlogArticleRepository.GetAllAsync(null, includes);

        public async Task<BlogArticle?> GetByAsync(Guid? Id)
            => await _unitOfWork.BlogArticleRepository.GetAsync(x => x.Id == Id);

        public BlogArticle? GetById(Guid? Id)
            => _unitOfWork.BlogArticleRepository.Get(x => x.Id == Id);

        public Task Update(BlogArticle model)
        {
            throw new NotImplementedException();
        }
    }
}
