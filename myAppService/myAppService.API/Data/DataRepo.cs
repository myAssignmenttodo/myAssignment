using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using myAppService.API.models;

namespace myAppService.API.Data
{
    public class DataRepo : IDataRepo
    {
        private readonly DataContext _context;
        public DataRepo(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
             _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
             _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
             _context.Remove(entity);
        }

         public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

         public async Task<Train> GetTrainDetails(int Id)
        {
             var train = await _context.Train.FirstOrDefaultAsync(u => u.Id == Id);

            return train;
        }
          public async Task<List<Train>> GetListOfTrains()
        {
             var trainList = await _context.Train.ToListAsync();

            return trainList;
        }
       public async Task<List<Scheduler>> GetScheduleList()
        {
             var trainSchedulesList = await _context.Schedulers.ToListAsync();

            return trainSchedulesList;
        }
        public async Task<Scheduler> GetScheduleDetails(int Id)
        {
             var Scheduler = await _context.Schedulers.FirstOrDefaultAsync(u => u.Id == Id);

            return Scheduler;
        }

          public async Task<List<Train>> GetTrainSchedules()
        {
             var trainList = await _context.Train.Include(a => a.lstScheduler).ToListAsync();
            //  foreach (var train in trainList)
            //  {
            //      train.lstScheduler =   _context.Schedulers.ToListAsync(u => u.TrainId ==train.Id);
            //  }
            //   var schedulerList = await _context.Schedulers.FirstOrDefaultAsync();

             
            return trainList;
        }
        
    }
}