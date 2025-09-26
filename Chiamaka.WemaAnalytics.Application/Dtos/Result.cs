using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chiamaka.WemaAnalytics.Application.Dtos
{
    public class Result<T>
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public bool HasError => ErrorMessage != "" ;
        public string ErrorMessage { get; set; } = "";
        public string Message { get; set; } = "";

        public static Result<T> Success(T data, string message = "Successful")
        {
            return new Result<T>
            {
                Data = data,
                IsSuccess = true,
                Message = message
            };
        }
        public static Result<T> Failure(string errorMessage= "Failed")
        {
            return new Result<T>
            {
                Data = default,
                IsSuccess = false,
                ErrorMessage = errorMessage
            };
        }
    }
}
