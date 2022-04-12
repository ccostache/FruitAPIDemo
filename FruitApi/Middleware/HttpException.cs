using System;

namespace FruitApi.Middleware
{
    public class HttpException : Exception
    {
        private readonly int httpStatusCode;

        public HttpException()
        {
        }

        public HttpException(string message) : base(message)
        {
        }

        public HttpException (int httpStatusCode)
        {
            this.httpStatusCode = httpStatusCode;
        }

        public HttpException(int httpStatusCode, string message, Exception inner) : base(message, inner)
        {
            this.httpStatusCode = httpStatusCode;
        }

        public int StatusCode
        {
            get { return this.httpStatusCode; }
        }
    }
}
