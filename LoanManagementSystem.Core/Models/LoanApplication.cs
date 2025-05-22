using System;
using System.ComponentModel.DataAnnotations;

namespace LoanManagementSystem.Core.Models
{
    public class LoanApplication
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Applicant name is required")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string ApplicantName { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Loan amount is required")]
        [Range(1000, 1000000, ErrorMessage = "Loan amount must be between $1,000 and $1,000,000")]
        public decimal LoanAmount { get; set; }
        
        [Required(ErrorMessage = "Loan term is required")]
        [Range(6, 360, ErrorMessage = "Loan term must be between 6 and 360 months")]
        public int LoanTerm { get; set; } // In months
        
        [Required(ErrorMessage = "Interest rate is required")]
        [Range(0.1, 30, ErrorMessage = "Interest rate must be between 0.1% and 30%")]
        public decimal InterestRate { get; set; }
        
        public LoanStatus LoanStatus { get; set; } = LoanStatus.Pending;
        
        public DateTime ApplicationDate { get; set; } = DateTime.Now;
    }

    public enum LoanStatus
    {
        Pending,
        Approved,
        Rejected
    }
}
