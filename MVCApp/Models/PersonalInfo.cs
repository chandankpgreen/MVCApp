using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCApp.Models
{
    public class PersonalInfo
    {
        [Required]
        public string FirstName { get; set; }
        [EmailAddress]
        [ReadOnly(true)]
        public string Email { get; set; }
        public string LastName { get; set; }
        public DateTime Date { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public int PersonId { get; set; }

    }

    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class MaxValidationAttribute : ValidationAttribute
    {

    }
}