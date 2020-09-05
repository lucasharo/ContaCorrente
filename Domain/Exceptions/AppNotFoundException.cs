using Domain.Enums;
using System;

namespace Domain.Exceptions
{
    public class AppNotFoundException : Exception
    {
        public int Code { get; set; }

        public AppNotFoundException(string message) : base(message)
        {
        }

        public AppNotFoundException(int code, string message) : base(message)
        {
            this.Code = code;
        }

        public AppNotFoundException(int code, string message, Exception ex) : base(message, ex)
        {
            this.Code = code;
        }

        public AppNotFoundException(StatusResponse code, string message) : base(message)
        {
            this.Code = (int)code;
        }

        public AppNotFoundException(StatusResponse code, string message, Exception ex) : base(message, ex)
        {
            this.Code = (int)code;
        }
    }
}
