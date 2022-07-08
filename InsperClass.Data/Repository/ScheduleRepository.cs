﻿using Dapper;
using InsperClass.Domain.Entity;
using InsperClass.Domain.Interface;
using InsperClass.Domain.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace InsperClass.Data.Repository
{
    public class ScheduleRepository : IScheduleRepository
    {
        string _connString;
        public ScheduleRepository(IConfiguration configuration)
        {
            _connString = configuration.GetSection("ConnectionStrings").GetSection("InsperDatabase").Value;
        }

        public IEnumerable<ScheduleViewModel> GetViewModel()
        {
            IEnumerable<ScheduleViewModel> schedules;
            using (var conn = new SqlConnection(_connString))
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
    }
}