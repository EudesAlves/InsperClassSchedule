using InsperClass.Domain.Model;
using System;

namespace InsperClass.Domain.Entity
{
    public class Schedule
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int ClassId { get; set; }
        public EWeekDay WeekDay { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
