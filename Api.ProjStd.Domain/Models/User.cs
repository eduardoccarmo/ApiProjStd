using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Proj.Std.Domain.Models
{
    public class User
    {
        #region Constructors
        public User()
        {
             
        }
        #endregion

        #region Properties
        public int Id { get; set; }

        public string Name { get; set; }

        public string NickName { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Gender { get; set; }

        #endregion
    }
}
