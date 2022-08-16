using API.Entities;
using API.Interfaces;
using Firebase.Database;
using Firebase.Database.Query;

namespace API.Services
{
    public class FirebaseService : IFirebaseService
    {
        FirebaseClient firebaseClient;
        public FirebaseService()
        {
            var auth = Environment.GetEnvironmentVariable("FirebaseAuthToken");
            var url = Environment.GetEnvironmentVariable("FirebaseBasePath");

            firebaseClient = new FirebaseClient(url,
              new FirebaseOptions
              {
                  AuthTokenAsyncFactory = () => Task.FromResult(auth)
              });
        }

        public async Task<List<UserDataLog>> RetrieveUserData()
        {
            var result = await firebaseClient.Child("UserEvents").OnceAsync<UserDataLog>();

            return new List<UserDataLog>();//result.ToList();
        }

        public async void StoreUserData(UserDataLog data)
        {
            string userId = data.key.ToString();

            var oldData = (await firebaseClient.Child("UserEvents").Child(userId).OnceSingleAsync<UserDataLog>());

            if(oldData != null)
            {
                oldData.timePlayed.AddRange(data.timePlayed);
                oldData.adsWatched.AddRange(data.adsWatched);
                oldData.key = data.key;
            }

            if (oldData == null)
                oldData = data;

            await firebaseClient.Child("UserEvents").Child(userId).PutAsync(oldData);
        }
    }
}