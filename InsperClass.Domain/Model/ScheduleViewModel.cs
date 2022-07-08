using System;

namespace InsperClass.Domain.Model
{
    public class ScheduleViewModel
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int ClassId { get; set; }
        public EWeekDay WeekDay { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Course { get; set; }
        public string Class { get; set; }
    }
}
