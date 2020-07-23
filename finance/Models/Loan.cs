using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Test.Models
{

    public class loans 
    {
        [Key]
        public Guid LoanID { get; set; }
        public int LoanNumber { get; set; }
        [Display(Name = "Loan Type")]
        public string LoanType { get; set; }
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Intrest Rate")]
        public decimal IntrestRate { get; set; }
        [Display(Name = "Loan Value")]
        public decimal Value { get; set; }
        public int Duration { get; set; }

        public bool IsInactive { get; set; }
        public int LoanOriginatedBy { get; set; }

        public customer customer { get; set; }
        public string CustomerForeName { get; set; }
        public string CustomerSurName { get; set; }

        public DateTime? DateOfBirth { get; set; }


    }
}