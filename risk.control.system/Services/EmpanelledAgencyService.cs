﻿using Microsoft.EntityFrameworkCore;
using risk.control.system.Data;
using risk.control.system.Models.ViewModel;

namespace risk.control.system.Services
{
    public interface IEmpanelledAgencyService
    {
        Task<CaseInvestigationVendorsModel> GetEmpanelledVendors(long selectedcase);

    }

    public class EmpanelledAgencyService : IEmpanelledAgencyService
    {
        private readonly ApplicationDbContext _context;

        public EmpanelledAgencyService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<CaseInvestigationVendorsModel> GetEmpanelledVendors(long selectedcase)
        {
            var claimsInvestigation = await _context.Investigations
                .Include(c => c.PolicyDetail)
                .Include(c => c.ClientCompany)
                .Include(c => c.PolicyDetail)
                .ThenInclude(c => c.CaseEnabler)
                .Include(c => c.PolicyDetail)
                .ThenInclude(c => c.CostCentre)
                .Include(c => c.CustomerDetail)
                .ThenInclude(c => c.Country)
                .Include(c => c.CustomerDetail)
                .ThenInclude(c => c.District)
                .Include(c => c.PolicyDetail)
                .ThenInclude(c => c.InvestigationServiceType)
                .Include(c => c.CustomerDetail)
                .ThenInclude(c => c.PinCode)
                .Include(c => c.CustomerDetail)
                .ThenInclude(c => c.State)
                .FirstOrDefaultAsync(m => m.Id == selectedcase);
            var claimCase = _context.BeneficiaryDetail
               .Include(c => c.PinCode)
               .Include(c => c.BeneficiaryRelation)
               .Include(c => c.District)
               .Include(c => c.State)
               .Include(c => c.Country)
               .FirstOrDefault(c => c.InvestigationTaskId == selectedcase);
            return new CaseInvestigationVendorsModel
            {
                Location = claimCase,
                //Vendors = vendorWithCaseCounts, 
                ClaimsInvestigation = claimsInvestigation
            };
        }
    }
}