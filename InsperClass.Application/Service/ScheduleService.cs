using AutoMapper;
using InsperClass.Domain.Entity;
using InsperClass.Domain.Interface;
using InsperClass.Domain.Interface.Service;
using InsperClass.Domain.Model;
using System.Collections.Generic;

namespace InsperClass.Application.Service
{
    public class ScheduleService : IScheduleService
    {
        private readonly IMapper _mapper;
        IScheduleRepository _scheduleRepository;

        public ScheduleService(IScheduleRepository scheduleRepository, IMapper mapper)
        {
            _scheduleRepository = scheduleRepository;
            _mapper = mapper;
        }
        public void Add(ScheduleViewModel scheduleModel)
        {
            Schedule schedule = new Schedule();
            schedule = _mapper.Map<Schedule>(scheduleModel);
            _scheduleRepository.Add(schedule);
        }

        public void Delete(int id)
        {
            _scheduleRepository.Delete(id);
        }

        public ScheduleViewModel GetById(int id)
        {
            return _scheduleRepository.GetViewModelById(id);
        }

        public IEnumerable<ScheduleViewModel> Get()
        {
            var schedule = _scheduleRepository.Get();
            return _mapper.Map<List<ScheduleViewModel>>(schedule);
        }
    }
}
