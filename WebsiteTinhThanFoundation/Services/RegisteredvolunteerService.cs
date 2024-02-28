using Microsoft.EntityFrameworkCore.Internal;
using WebsiteTinhThanFoundation.Models;
using WebsiteTinhThanFoundation.Repository.UnitOfWork;
using WebsiteTinhThanFoundation.Services.Interface;
using WebsiteTinhThanFoundation.ViewModels;

namespace WebsiteTinhThanFoundation.Services
{
    public class RegisteredvolunteerService : IRegisteredvolunteerService
    {
        public IUnitOfWork _unitOfWork { get; set; }
        public RegisteredvolunteerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task AcceptContact(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task Add(Registeredvolunteers model)
        {
            _unitOfWork.RegisteredVolunteerRepository.Add(model);
            await _unitOfWork.CommitAsync();
        }

        public async Task<int> CountAsync()
            => await _unitOfWork.RegisteredVolunteerRepository.CountAsync();

        public async Task<ResponseListVM<Registeredvolunteers>> GetAllAsync(int page = 1)
        {
            var data = await _unitOfWork.RegisteredVolunteerRepository.GetAllAsync();
            ResponseListVM<Registeredvolunteers> model = new();
            model.ObjectListData = data.ToList();
            return model;
        }

        public async Task<Registeredvolunteers?> GetByIdAsync(Guid? Id)
            => await _unitOfWork.RegisteredVolunteerRepository.GetAsync(x => x.Id == Id);
    }
}
