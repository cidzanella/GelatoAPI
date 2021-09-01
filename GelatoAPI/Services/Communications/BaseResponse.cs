using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GelatoAPI.Services.Communications
{
    public abstract class BaseResponse
    {
        public bool Success { get; protected set; }
        public int HttpResponseCode { get; protected set; }
        public string Message { get; protected set; }

        public BaseResponse(bool success, int httpResponseCode, string message)
        {
            Success = success;
            HttpResponseCode = httpResponseCode;
            Message = message;
        }
    }
}
