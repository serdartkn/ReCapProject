using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Result.Concrete
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {
        }

        public ErrorDataResult(T data) : base(data, false)
        {
        }

        public ErrorDataResult(string message) : base(default, true, message)
        {

        }

        public ErrorDataResult() : base(default, true) //Burada kullanılan default'un anlamı parametre olarak hiç bir şey gönderilmese dahi dafault veri türü döner.
        {

        }
    }
}
