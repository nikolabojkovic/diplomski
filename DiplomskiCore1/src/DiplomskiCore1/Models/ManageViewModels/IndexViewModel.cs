using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace DiplomskiCore1.Models.ManageViewModels
{
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }

        public IList<UserLoginInfo> Logins { get; set; }

        public string PhoneNumber { get; set; }

        public bool TwoFactor { get; set; }

        public bool BrowserRemembered { get; set; }

        //[Required(ErrorMessage = "Please Upload a Valid Image File. Only jpg format allowed")]
        //[DataType(DataType.Upload)]
        //[Display(Name = "Upload Product Image")]
        //[FileExtensions(Extensions = "jpg")]
        //public IFormFile Image { get; set; }
    }
}
