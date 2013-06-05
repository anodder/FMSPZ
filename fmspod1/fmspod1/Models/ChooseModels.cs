using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace fmspod1.Models
{
    public class ChooseModels
    {
        
        [Display(Name = "podaj kod")]
        public string kod { get; set; }
    }
}