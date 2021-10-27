using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPalBack.ViewModels.APIBase
{
    public class ApiResonse
    {
        public ApiResonse(int status, string message, object result)
        {
            Status = status;
            Message = message;
            Result = result;
        }

        public int Status { get; set; }

        public string Message { get; set; }

        public object Result { get; set; }


    }

    public static class APIStatus
    {
        public const int Success = 0;
        public const int Fail = 1;
        public const int DataError = 99;
    }
}
