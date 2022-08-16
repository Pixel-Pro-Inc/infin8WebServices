using API.Entities;

namespace API.Interfaces
{
    public interface IFirebaseService
    {
        public void StoreUserData(UserDataLog data);
        public Task<List<UserDataLog>> RetrieveUserData();
    }
}
