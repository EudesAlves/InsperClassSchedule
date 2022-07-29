using Dapper;
using InsperClass.Domain.Entity;
using InsperClass.Domain.Interface;
using InsperClass.Domain.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace InsperClass.Data.Repository
{
    public class ScheduleRepository : BaseRepository, IScheduleRepository
    {
        public ScheduleRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public IEnumerable<ScheduleViewModel> GetViewModel()
        {
            IEnumerable<ScheduleViewModel> schedules;
            using (var conn = new SqlConnection(this._connString))
            {
                try
                {
                    var sql = @"SELECT s.Id, s.CourseId, s.ClassId, s.WeekDay, s.StartTime, s.EndTime, co.Name AS 'Course', cl.Name AS 'Class'
                                FROM Schedule s
                                INNER JOIN Course co ON co.Id = s.CourseId
                                INNER JOIN Class cl ON cl.Id = s.ClassId
                                WHERE s.Active = 1";
                    schedules = conn.Query<ScheduleViewModel>(sql);
                    return schedules;
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public IEnumerable<Schedule> Get()
        {
            IEnumerable<Schedule> schedules;
            using (var conn = new SqlConnection(this._connString))
            {
                try
                {
                    var sql = @"SELECT s.Id, s.CourseId, s.ClassId, s.WeekDay, s.StartTime, s.EndTime, co.Id, co.Name, cl.Id, cl.Name
                                FROM Schedule s
                                INNER JOIN Course co ON co.Id = s.CourseId
                                INNER JOIN Class cl ON cl.Id = s.ClassId
                                WHERE s.Active = 1";
                    schedules = conn.Query<Schedule, Course, Class, Schedule>(sql, (s,co,cl) =>
                    {
                        s.Course = co;
                        s.Class = cl;
                        return s;
                    },
                    splitOn: "Id, Id");
                    return schedules;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public void Add(Schedule schedule)
        {
            using (var conn = new SqlConnection(_connString))
            {
                try
                {
                    var sql = $"INSERT INTO Schedule(CourseId, ClassId, WeekDay, StartTime, EndTime) VALUES(@CourseId, @ClassId, {(int)schedule.WeekDay}, @StartTime, @EndTime);";
                    conn.Execute(sql, schedule);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public ScheduleViewModel GetViewModelById(int id)
        {
            using (var conn = new SqlConnection(this._connString))
            {
                try
                {
                    var sql = $@"SELECT s.Id, s.CourseId, s.ClassId, s.WeekDay, s.StartTime, s.EndTime, co.Name AS 'Course', cl.Name AS 'Class'
                                FROM Schedule s
                                INNER JOIN Course co ON co.Id = s.CourseId
                                INNER JOIN Class cl ON cl.Id = s.ClassId
                                WHERE s.Active = 1
                                AND s.Id = {id}";
                    var schedule = conn.Query<ScheduleViewModel>(sql).FirstOrDefault();
                    return schedule;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public void Delete(int id)
        {
            using (var conn = new SqlConnection(_connString))
            {
                try
                {
                    var sql = $"DELETE FROM Schedule WHERE Id = {id};";
                    conn.Execute(sql);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
