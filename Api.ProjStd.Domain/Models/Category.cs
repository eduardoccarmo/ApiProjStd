using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Proj.Std.Domain.Models
{
    public class Category
    {
        #region Constructors
        public Category()
        {
               
        }
        #endregion

        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime RegisterDate { get; set; }
        #endregion
    }
}
