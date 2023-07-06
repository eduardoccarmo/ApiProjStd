using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Api.Proj.Std.Domain.Models
{
    public class Product
    {
        #region Constructors
        public Product()
        {

        }
        #endregion

        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Category { get; set; }
        public double Price { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        #endregion
    }
}
