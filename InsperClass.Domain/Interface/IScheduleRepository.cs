using InsperClass.Domain.Entity;
using InsperClass.Domain.Model;
using System.Collections.Generic;

namespace InsperClass.Domain.Interface
{
    public interface IScheduleRepository
    {
        IEnumerable<ScheduleViewModel> GetViewModel();
        IEnumerable<Schedule> Get();
        void Add(Schedule schedule);
        ScheduleViewModel GetViewModelById(int id);
        void Delete(int id);
    }
}
