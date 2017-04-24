using System;

namespace RestApiTest.DTO
{
    public class SuccessResponse
    {
        public Response response { get; set; }
    }

    public class Response
    {
        public String sid { get; set; }
    }
}