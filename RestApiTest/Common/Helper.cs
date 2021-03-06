﻿using System;
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

        public static string DoGet(Uri URL, NameValueCollection queryStringParameters = null,
            NameValueCollection requestHeaders = null)
        {
            string responseText = String.Empty;
            using (WebClient client = new WebClient())
            {
                try
                {
                    if (requestHeaders != null)
                    {
                        if (requestHeaders.Count > 0)
                        {
                            foreach (string header in requestHeaders.AllKeys)
                                client.Headers.Add(header, requestHeaders[header]);
                        }
                    }
                    if (queryStringParameters != null)
                    {
                        if (queryStringParameters.Count > 0)
                        {
                            foreach (string parm in queryStringParameters.AllKeys)
                                client.QueryString.Add(parm, queryStringParameters[parm]);
                        }
                    }
                    byte[] responseBytes = client.DownloadData(URL);
                    responseText = Encoding.UTF8.GetString(responseBytes);
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
                                responseText = reader.ReadToEnd();
                            }
                        }
                    }
                }
            }
            return responseText;
        }
    }
}