﻿using Microsoft.EntityFrameworkCore;
using Project_X.Database;
using Project_X.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_X.Services
{
    public class ApplicationService: IApplicationService
    {
        private readonly AppDbContext _appDbContext;

        public ApplicationService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Application>> GetApplications()
        {
            return await _appDbContext.Applications.ToListAsync();

        }

        public async Task<IEnumerable<Application>> GetApplicationsByCandidateId(long id)
        {
            return await _appDbContext.Applications.Where(application => application.CandidateId == id).ToListAsync();
        }

        public async Task<IEnumerable<Application>> GetApplicationsByOfferId(long id)
        {
            return await _appDbContext.Applications.Where(application => application.OfferId == id).ToListAsync();
        }

        public async Task<Application> GetApplicationByCandidateIdAndOfferId(long candidateId, long offerId)
        {
            return await _appDbContext.Applications.SingleOrDefaultAsync(application => application.CandidateId == candidateId && application.OfferId == offerId);
        }

        public async Task<bool> AddApplication(Application application)
        {
            await _appDbContext.Applications.AddAsync(application);
            int added = await _appDbContext.SaveChangesAsync();
            return added > 0;
        }

        public async Task<bool> UpdateApplication(Application application)
        {
            _appDbContext.Applications.Update(application);
            int updated = await _appDbContext.SaveChangesAsync();
            return updated > 0;
        }

        public async Task<bool> DeleteApplication(long id)
        {
            Application application = await _appDbContext.Applications.FindAsync(id);
            _appDbContext.Applications.Remove(application);
            int deleted = await _appDbContext.SaveChangesAsync();
            return deleted > 0;
        }

    }
}