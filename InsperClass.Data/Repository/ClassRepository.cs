using Dapper;
using InsperClass.Domain.Entity;
using InsperClass.Domain.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace InsperClass.Data.Repository
{
    public class ClassRepository : BaseRepository, IClassRepository
    {
        public ClassRepository(IConfiguration configuration) : base(configuration)
        {
        }
        public IEnumerable<Class> GetByCourseId(int id)
        {
            IEnumerable<Class> classes;
            using (var conn = new SqlConnection(_connString))
            {
                try
                {
                    var sql = @$"SELECT * FROM Class
                                WHERE Active = 1
                                AND CourseId = {id}";
                    classes = conn.Query<Class>(sql);
                    return classes;
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
