using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPNET_MVC_EF_EXAMPLE.Models
{
    public class PersonelViewModel
    {
        public Personels Personel { get; set; }

        public IEnumerable<Departments> Departments { get; set; }
    }
}