using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers
{
    public class EventLogController: BaseApiController
    {
        private readonly IFirebaseService _firebaseService;
        public EventLogController(IFirebaseService firebaseService)
        {
            _firebaseService = firebaseService;
        }

        [HttpPost("log")]
        public void LogData([FromForm] string data)
        {
            var _data = JsonConvert.DeserializeObject<UserDataLog>(data);

            _firebaseService.StoreUserData(_data);
        }
    }
}