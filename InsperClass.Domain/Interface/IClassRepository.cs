using InsperClass.Domain.Entity;
using System.Collections.Generic;

namespace InsperClass.Domain.Interface
{
    public interface IClassRepository
    {
        IEnumerable<Class> GetByCourseId(int id);
    }
}
