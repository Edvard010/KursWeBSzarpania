using System.Collections.Generic;

namespace HelloWorld.Models
{
    public class UserListItemViemModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public IEnumerable<string> Projects { get; set; }
    }
}