using API.Entities;
using API.Interfaces;
using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace API.Services
{
    public class FirebaseService : IFirebaseService
    {
        FirebaseClient firebaseClient;
        public FirebaseService()
        {
            var auth = "1idKB3QV2l6RoviN980uo37KWmEumUSCbBfNS5xK";//Environment.GetEnvironmentVariable("FirebaseAuthToken");
            var url = "https://infin8-75991678-default-rtdb.firebaseio.com/";//Environment.GetEnvironmentVariable("FirebaseBasePath");

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