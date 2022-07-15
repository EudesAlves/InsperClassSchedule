using Dapper;
using InsperClass.Domain.Entity;
using InsperClass.Domain.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace InsperClass.Data.Repository
{
    public class CourseRepository : BaseRepository, ICourseRepository
    {
        public CourseRepository(IConfiguration configuration) : base(configuration)
        {
        }
        public IEnumerable<Course> Get()
        {
            IEnumerable<Course> courses;
            using (var conn = new SqlConnection(_connString))
            {
                try
                {
                    var sql = "SELECT * FROM Course WHERE Active = 1";
                    courses = conn.Query<Course>(sql);
                    return courses;
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
