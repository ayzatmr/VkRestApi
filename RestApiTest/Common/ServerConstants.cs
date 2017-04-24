using System;

namespace RestApiTest.Common
{
    public class ServerConstants
    {
        private static readonly String _host = @"https://api.vk.com/method";
        private static readonly String _signUp = @"/auth.signup";

        public static String BaseActiveServerUri { get; } = _host;
        public static String SignUp { get; } = _signUp;
    }
}