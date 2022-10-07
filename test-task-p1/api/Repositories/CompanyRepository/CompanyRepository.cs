using api.Models.DatabaseObjects;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Repositories.CompanyRepository
{
    public class CompanyRepository : IRepository<Company>
    {
        private readonly DatabaseContext _databaseContext;
        public CompanyRepository(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }
        public async Task<Company> Create(Company obj)
        {
            await _databaseContext.Companies.AddAsync(obj);
            await _databaseContext.SaveChangesAsync();

            return obj;
        }

        public async Task<bool> Delete(int id)
        {
            Company obj = await _databaseContext.Companies.FindAsync(id);

            if (obj != null)
            {
                _databaseContext.Companies.Remove(obj);
                await _databaseContext.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<IEnumerable<Company>> Get()
        {
            return await _databaseContext.Companies.ToListAsync();
        }

        public async Task<Company> Get(int id)
        {
            return await _databaseContext.Companies.FindAsync(id);
        }

        public async Task<Company> Update(Company оbj)
        {
            _databaseContext.Entry(оbj).State = EntityState.Modified;
            await _databaseContext.SaveChangesAsync();
            return оbj;
        }
    }
}
