using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        public void LogData(UserDataLog data)
        {
            _firebaseService.StoreUserData(data);
        }
    }
}