using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class WeightLogService
    {
        private readonly StoreContext _context;

        public WeightLogService(StoreContext context)
        {
            _context = context;
        }

        public async Task<List<WeightLog>> GetWeightLogsByUserIdAsync(int id)
        {
            return await _context.WeightLogs.Where(wl => wl.UserId == id).ToListAsync();
        }
        
        public async Task<WeightLog> GetWeightLogByIdAsync(int id)
        {
            return await _context.WeightLogs.FindAsync(id);
        }

        public async Task<WeightLog> CreateWeightLogAsync(WeightLog weightLog)
        {
            object value = _context.WeightLogs.Add(weightLog);
            await _context.SaveChangesAsync();
            return weightLog;
        }

        public async Task<WeightLog> UpdateWeightLogAsync(WeightLog weightLog)
        {
            _context.WeightLogs.Update(weightLog);
            await _context.SaveChangesAsync();
            return weightLog;
        }

        public async Task<WeightLog> DeleteWeightLogAsync(int id)
        {
            var weightLog = await _context.WeightLogs.FindAsync(id);
            _context.WeightLogs.Remove(weightLog);
            await _context.SaveChangesAsync();
            return weightLog;
        }
        
    }
}