using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao.Api
{
    public interface IApi
    {
        public Task<T> GetDataAsync<T>(string endpoint);
    }
}
