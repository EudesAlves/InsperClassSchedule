using InsperClass.Domain.Entity;
using InsperClass.Domain.Model;
using System.Collections.Generic;

namespace InsperClass.Domain.Interface
{
    public interface IScheduleRepository
    {
        IEnumerable<ScheduleViewModel> GetViewModel();
        void Add(Schedule schedule);
    }
}
