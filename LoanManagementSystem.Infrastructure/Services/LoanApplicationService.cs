using LoanManagementSystem.Core.Interfaces;
using LoanManagementSystem.Core.Models;
using LoanManagementSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoanManagementSystem.Infrastructure.Services
{
    public class LoanApplicationService : ILoanApplicationService
    {
        private readonly LoanDbContext _context;
        private readonly ILogger<LoanApplicationService> _logger;

        public LoanApplicationService(LoanDbContext context, ILogger<LoanApplicationService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<LoanApplication>> GetAllLoanApplicationsAsync()
        {
            return await _context.LoanApplications.ToListAsync();
        }

        public async Task<LoanApplication?> GetLoanApplicationByIdAsync(int id)
        {
            return await _context.LoanApplications.FindAsync(id);
        }

        public async Task<LoanApplication> CreateLoanApplicationAsync(LoanApplication loanApplication)
        {
            loanApplication.ApplicationDate = DateTime.Now;
            loanApplication.LoanStatus = LoanStatus.Pending;
            
            _context.LoanApplications.Add(loanApplication);
            await _context.SaveChangesAsync();
            
            _logger.LogInformation("Created new loan application for {ApplicantName}", loanApplication.ApplicantName);
            
            return loanApplication;
        }

        public async Task<LoanApplication> UpdateLoanApplicationAsync(LoanApplication loanApplication)
        {
            _context.Entry(loanApplication).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            
            _logger.LogInformation("Updated loan application {Id}", loanApplication.Id);
            
            return loanApplication;
        }

        public async Task<bool> DeleteLoanApplicationAsync(int id)
        {
            var loanApplication = await _context.LoanApplications.FindAsync(id);
            if (loanApplication == null)
            {
                return false;
            }

            _context.LoanApplications.Remove(loanApplication);
            await _context.SaveChangesAsync();
            
            _logger.LogInformation("Deleted loan application {Id}", id);
            
            return true;
        }

        public async Task<LoanApplication> ApproveLoanAsync(int id)
        {
            var loan = await _context.LoanApplications.FindAsync(id);
            if (loan == null)
            {
                throw new KeyNotFoundException($"Loan application with ID {id} not found");
            }

            loan.LoanStatus = LoanStatus.Approved;
            await _context.SaveChangesAsync();
            
            _logger.LogInformation("Approved loan application {Id}", id);
            
            return loan;
        }

        public async Task<LoanApplication> RejectLoanAsync(int id)
        {
            var loan = await _context.LoanApplications.FindAsync(id);
            if (loan == null)
            {
                throw new KeyNotFoundException($"Loan application with ID {id} not found");
            }

            loan.LoanStatus = LoanStatus.Rejected;
            await _context.SaveChangesAsync();
            
            _logger.LogInformation("Rejected loan application {Id}", id);
            
            return loan;
        }
    }
}
