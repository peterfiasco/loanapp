using System.Collections.Generic;
using System.Threading.Tasks;
using LoanManagementSystem.Core.Models;

namespace LoanManagementSystem.Core.Interfaces
{
    public interface ILoanApplicationService
    {
        Task<List<LoanApplication>> GetAllLoanApplicationsAsync();
        Task<LoanApplication?> GetLoanApplicationByIdAsync(int id);
        Task<LoanApplication> CreateLoanApplicationAsync(LoanApplication loanApplication);
        Task<LoanApplication> UpdateLoanApplicationAsync(LoanApplication loanApplication);
        Task<bool> DeleteLoanApplicationAsync(int id);
        Task<LoanApplication> ApproveLoanAsync(int id);
        Task<LoanApplication> RejectLoanAsync(int id);
    }
}
