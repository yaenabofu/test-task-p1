using api.Models.DatabaseObjects;
using System.Threading.Tasks;

namespace api.Repositories.WorkerRepository
{
    public interface IWorker
    {
        Task<Worker> GetBySnils(string Snils);
    }
}
