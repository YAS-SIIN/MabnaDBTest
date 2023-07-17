﻿
using System.ComponentModel.DataAnnotations;

namespace MabnaDBTest.Common.Enums;

 
    public enum EnumBaseStatus : short
    {

        [Display(Name = "Deactive")]
        Deactive = 0,

        [Display(Name = "Active")]
        Active = 1,

        [Display(Name = "Deleted")]
        Deleted = 3
    }     