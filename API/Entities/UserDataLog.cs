namespace API.Entities
{
    public class UserDataLog
    {
        public string key { get; set; }
        public List<string> adsWatched { get; set; } = new List<string>();
        public List<float> timePlayed { get; set; } = new List<float>();
    }
}
