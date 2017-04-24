using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RestApiTest.DTO
{
    public class ErrorResponse

    {
        public Error error { get; set; }
    }

    public class Error
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public ResponseErrorCodes error_code { get; set; }

        public String error_msg { get; set; }

        public List<RequestParams> request_params { get; set; }
    }
}