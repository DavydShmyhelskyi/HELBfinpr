
namespace FnPrDotnet
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int userStatusId { get; set; }

        public UserStatus UserStatus { get; set; }
        public ICollection<WordList> WordList { get; set; }
    }
}
