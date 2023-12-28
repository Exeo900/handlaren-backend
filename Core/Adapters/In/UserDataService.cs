using Core.Models;
using Core.Ports.In;
using Core.Ports.Out;

namespace Core.Adapters.In;
public class UserDataService : IUserDataService
{
    public readonly IDataAccess _dataAccess;

    public UserDataService(IDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public async Task<UserData?> GetUser(Guid id)
    {
       return await _dataAccess.GetUserData(id);
    }

    public async Task<IEnumerable<UserData>> GetUsers()
    {
        return await _dataAccess.GetUsersData();
    }
}
