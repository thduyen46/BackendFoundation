using Microsoft.EntityFrameworkCore.Query;
using WebsiteTinhThanFoundation.Models;
using WebsiteTinhThanFoundation.Repository.UnitOfWork;
using WebsiteTinhThanFoundation.Services.Interface;

namespace WebsiteTinhThanFoundation.Services
{
    public class TagService : ITagService
    {
        public IUnitOfWork _unitOfWork { get; set; }
        public TagService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task Add(Tag model, string userId)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid? Id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Tag>> GetAllAsync(Func<IQueryable<Tag>, IIncludableQueryable<Tag, object>>? includes = null)
            => await _unitOfWork.TagRepository.GetAllAsync(null, include: includes);

        public async Task<Tag?> GetByAsync(Guid? Id)
            => await _unitOfWork.TagRepository.GetAsync(x => x.Id == Id);

        public Tag? GetById(Guid? Id)
            => _unitOfWork.TagRepository.Get(x => x.Id == Id);

        public Task Update(Tag model)
        {
            throw new NotImplementedException();
        }
    }
}
