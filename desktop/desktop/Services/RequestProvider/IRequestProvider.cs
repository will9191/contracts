using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktop.Services.RequestProvider
{
    public interface IRequestProvider
    {
        Task<TResult> PostAsync<TResult, TSend>(string uri, TSend data);
        Task<TResult> GetAsync<TResult, TSend>(string uri, TSend data);
    }
}
