using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WaterIntakeCalc.Const;

namespace WaterIntakeCalc.Results
{
    public class ResponseContent<T>
    {
        private ResponseContent(bool status, string message, T result)
        {
            this.Status = status;
            this.Message = message;
            this.Result = result;
        }

        public bool Status;
        public string Message;
        public T Result;

        public static ResponseContent<T> SuccessResult(T result)
        {
            return new ResponseContent<T>(true, ResponseMessages.SUCCESS, result);
        }

        public static ResponseContent<T> SuccessResult()
        {
            return new ResponseContent<T>(true, ResponseMessages.SUCCESS, default(T));
        }

        public static ResponseContent<T> Failure(string message)
        {
            return new ResponseContent<T>(false, message, default(T));
        }
    }
}