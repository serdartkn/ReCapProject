using Core.Utilities.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Result.Concrete
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data, bool success, string messeage):base(success,messeage)
        {
            Data = data;
        }

        public DataResult(T data, bool success) : base(success)
        {
            Data = data;
        }
        public T Data { get; }
    }
}
