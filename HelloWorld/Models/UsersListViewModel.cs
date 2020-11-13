using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorld.Models
{
    public class UsersListViewModel
    {
        public IEnumerable<UsersListItemModel> Users { get; set; }
    }
}
