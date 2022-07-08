using InsperClass.Domain.Entity;
using System.Collections.Generic;

namespace InsperClass.Domain.Interface
{
    public interface ICourseRepository
    {
        IEnumerable<Course> Get();
    }
}
