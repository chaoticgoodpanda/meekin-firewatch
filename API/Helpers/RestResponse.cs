using System;

namespace API.Helpers
{
    public class RestResponse
    {
        private int _statusCode;
        private string _responseData;

        public RestResponse(int statusCode, string responseData)
        {
            _statusCode = statusCode;
            _responseData = responseData;
        }

        public int StatusCode
        {
            get
            {
                return _statusCode;
            }
            
    }

        public string ResponseContent
        {
            get
            {
                return _responseData;
            }
        }

        public override string ToString()
        {
            return String.Format("StatusCode : {0} ResponseData: {1}", _statusCode, _responseData);
        }
    }
}