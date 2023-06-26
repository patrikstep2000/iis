using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace iis_web.Models
{
    public class SubmitModel
    {
        [Required(ErrorMessage = "Please enter the search term.")]
        public string Term { get; set; }
    }
}