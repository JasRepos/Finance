using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public enum Title { Mr, Ms, Mrs, Miss, Dr }
    public class customer
    {
        [Key]
        public Guid CustomerID { get; set; }
        public Title? Title { get; set; }
        public string ForeName { get; set; }
        public string MiddleInitial { get; set; }
        public string SurName { get; set; }
        [Display(Name = "Date of Birth")]
        public DateTime? DateofBirth { get; set; }
        public bool Status { get; set; }

    }
}