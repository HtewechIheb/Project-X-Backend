﻿using Microsoft.EntityFrameworkCore;
using Project_X.Database;
using Project_X.Models;
using Project_X.Repositories.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_X.Repositories.Implementations
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AppDbContext _appDbContext;

        public CompanyRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Company>> GetCompanies()
        {
            return await _appDbContext.Companies.ToListAsync();
        }

        public async Task<Company> GetCompanyById(long id)
        {
            return await _appDbContext.Companies.FindAsync(id);
        }

        public async Task<bool> AddCompany(Company candidate)
        {
            await _appDbContext.Companies.AddAsync(candidate);
            int added = await _appDbContext.SaveChangesAsync();
            return added > 0;
        }

        public async Task<bool> UpdateCompany(Company candidate)
        {
            _appDbContext.Companies.Update(candidate);
            int updated = await _appDbContext.SaveChangesAsync();
            return updated > 0;
        }

        public async Task<bool> DeleteCompany(long id)
        {
            Company candidate = await _appDbContext.Companies.FindAsync(id);
            _appDbContext.Companies.Remove(candidate);
            int deleted = await _appDbContext.SaveChangesAsync();
            return deleted > 0;
        }
    }
}
