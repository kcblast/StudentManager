using Application_API_Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application_API_Core.ViewModels
{
   public class RegisterStudentDto
    {
        //public Guid ID { get; set; } = Guid.NewGuid();
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string MatricNumber { get; set; }
        [Required]
        public string StudentLevel { get; set; }

    }
}
