using System;
using System.Collections.Generic;
using System.Text;
using InsperClass.Domain.Entity;
using InsperClass.Domain.Model;

namespace InsperClass.Domain.Interface.Service
{
    public interface IScheduleService
    {
        IEnumerable<ScheduleViewModel> Get();
        void Add(ScheduleViewModel scheduleModel);
        ScheduleViewModel GetById(int id);
        void Delete(int id);
    }
}
