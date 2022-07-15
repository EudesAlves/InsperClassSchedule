using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace InsperClass.Data.Repository
{
    public class BaseRepository
    {
        public string _connString;
        public BaseRepository(IConfiguration configuration)
        {
            //_connString = configuration.GetSection("ConnectionStrings").GetSection("InsperDatabase").Value;
            var workingDir = Environment.CurrentDirectory;
            var projectDir = Directory.GetParent(workingDir).FullName;
            _connString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename =" + projectDir + "\\InsperClass.Data\\DataBase\\InsperDatabase.mdf; Integrated Security = True";
        }
    }
}
