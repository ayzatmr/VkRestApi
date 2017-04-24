using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;

namespace RestApiTest.Common
{
    public class Helper
    {
        public static NameValueCollection SetParams(String firstName, String lastName, String phone, String password,
            String sex)
        {
            NameValueCollection queryStringParameters = new NameValueCollection();
            queryStringParameters.Add("client_id", "5994949");
            queryStringParameters.Add("client_secret", "byirmWk9QA71k4Zb8E2n");
            queryStringParameters.Add("first_name", firstName);
            queryStringParameters.Add("last_name", lastName);
            queryStringParameters.Add("phone", phone);
            queryStringParameters.Add("sex", sex);
            queryStringParameters.Add("password", password);
            queryStringParameters.Add("test_mode", "1");

            return queryStringParameters;
        }

        public static string DoGET(Uri URL, NameValueCollection QueryStringParameters = null,
            NameValueCollection RequestHeaders = null)
        {
            string ResponseText = String.Empty;
            using (WebClient client = new WebClient())
            {
                try
                {
                    if (RequestHeaders != null)
                    {
                        if (RequestHeaders.Count > 0)
                        {
                            foreach (string header in RequestHeaders.AllKeys)
                                client.Headers.Add(header, RequestHeaders[header]);
                        }
                    }
                    if (QueryStringParameters != null)
                    {
                        if (QueryStringParameters.Count > 0)
                        {
                            foreach (string parm in QueryStringParameters.AllKeys)
                                client.QueryString.Add(parm, QueryStringParameters[parm]);
                        }
                    }
                    byte[] ResponseBytes = client.DownloadData(URL);
                    ResponseText = Encoding.UTF8.GetString(ResponseBytes);
                }
                catch (WebException exception)
                {
                    if (exception.Response != null)
                    {
                        var responseStream = exception.Response.GetResponseStream();

                        if (responseStream != null)
                        {
                            using (var reader = new StreamReader(responseStream))
                            {
                                ResponseText = reader.ReadToEnd();
                            }
                        }
                    }
                }
            }
            return ResponseText;
        }
    }
}