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
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Course Course { get; set; }
        public Class Class { get; set; }
    }
}
