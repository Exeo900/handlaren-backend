using Core.Models;

namespace Core.Ports.In;
public interface IUserDataService
{
    Task<UserData?> GetUser(Guid id);
    Task<IEnumerable<UserData>> GetUsers();
}
