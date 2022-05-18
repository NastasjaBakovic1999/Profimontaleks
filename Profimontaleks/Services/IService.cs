using System.Collections.Generic;

namespace Profimontaleks.Services
{
    public interface IService<T> where T : class
    {
        List<T> GetAll();
    }
}
