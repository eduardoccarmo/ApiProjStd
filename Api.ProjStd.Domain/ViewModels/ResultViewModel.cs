using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Proj.Std.Domain.ViewModels
{
    public class ResultViewModel<T>
    {
        public T Data { get; set; }
        public List<string> Errors { get; set; } = new(); 

        public ResultViewModel(T data, List<string> errors)
        {
            Data = data;
            Errors = errors;
        }

        public ResultViewModel(List<string> errors)
        {
            Errors = errors;
        }

        public ResultViewModel(T data)
        {
            Data = data;
        }

        public ResultViewModel(string errors)
        {
            Errors.Add(errors);
        }
    }
}
