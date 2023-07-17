using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MabnaDBTest.Domain.Enums
{    
    public enum EnumDBContextType
    {

        [Display(Name = "MAIN MabnaDBTest DBContext")]
        MAIN_MabnaDBContext = 0,

        [Display(Name = "READ MabnaDBTest DBContext")]
        READ_MabnaDBContext = 1, 

        [Display(Name = "WRITE MabnaDBTest DBContext")]
        WRITE_MabnaDBContext = 2,
    }

}
