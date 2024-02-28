using WebsiteTinhThanFoundation.Data;
using WebsiteTinhThanFoundation.Models;
using WebsiteTinhThanFoundation.ViewModels;

namespace WebsiteTinhThanFoundation.Services.Interface
{
    public interface IRegisteredvolunteerService
    {
        public Task<int> CountAsync();
        public Task Add(Registeredvolunteers model);
        public Task AcceptContact(Guid Id);
        public Task<ResponseListVM<Registeredvolunteers>> GetAllAsync(int page = 1);
        public Task<Registeredvolunteers?> GetByIdAsync(Guid? Id);
    }
}
