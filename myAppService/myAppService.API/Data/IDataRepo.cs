using System.Collections.Generic;
using System.Threading.Tasks;
using myAppService.API.models;
namespace myAppService.API.Data
{
    public interface IDataRepo
    {
         void Add<T>(T entity) where T: class;

        void Update<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();
         Task<List<Train>> GetListOfTrains();
         Task<Train> GetTrainDetails(int Id);
         Task<List<Scheduler>> GetScheduleList();
         Task<Scheduler> GetScheduleDetails(int Id);
         Task<List<Train>> GetTrainSchedules();


    }
}