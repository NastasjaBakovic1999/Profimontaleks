using System.Collections.Generic;

namespace Profimontaleks.DataAccess
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
    }
}
