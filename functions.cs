using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Text;
using System.Web;

namespace PurityMail.RTLDS.Handlers
{

    class functions
    {
        public static void captureRequestData(HttpRequest req)
        {
            int loop1, loop2;
            NameValueCollection coll;

            // Incoming Request Body
            Stream body = null;

            // Incoming Encoding Type
            Encoding encoding = null;

            // StreamReader
            StreamReader sr = null;

            // Input Stream String
            String inStr = null;

            string logFile = @"c:\program files\rtlds\logfiles\debugging\rtlds_debuginfo_" + DateTime.Now.ToString("yyyyMMddhhmmssffffff") + ".log";

            if (File.Exists(logFile))
            {
                StreamWriter sw = new StreamWriter(logFile, true);

                // Load ServerVariable collection into NameValueCollection object.
                coll = req.ServerVariables;

                // Get names of all keys into a string array. 
                String[] arr1 = coll.AllKeys;
                for (loop1 = 0; loop1 < arr1.Length; loop1++)
                {
                    sw.WriteLine("Key: " + arr1[loop1]);
                    String[] arr2 = coll.GetValues(arr1[loop1]);
                    for (loop2 = 0; loop2 < arr2.Length; loop2++)
                    {
                        sw.WriteLine("Value " + loop2 + ": " + arr2[loop2]);
                    }
                }

                sw.WriteLine("*************************************");
                sw.WriteLine("Contents of Incoming HTTP Entity Body");
                sw.WriteLine("*************************************");

                body = req.InputStream;
                encoding = req.ContentEncoding;

                sr = new StreamReader(body, encoding);

                if (body != null)
                    body.Close();

                if (sr != null)
                    sr.Close();

                sw.Flush();
                sw.Close();
            }
            else
            {
                StreamWriter sw = new StreamWriter(logFile, true);
                sw.WriteLine("******* New Debugging Session Data ********");

                // Load ServerVariable collection into NameValueCollection object.
                coll = req.ServerVariables;

                // Get names of all keys into a string array. 
                String[] arr1 = coll.AllKeys;
                for (loop1 = 0; loop1 < arr1.Length; loop1++)
                {
                    sw.WriteLine("Key: " + arr1[loop1]);
                    String[] arr2 = coll.GetValues(arr1[loop1]);
                    for (loop2 = 0; loop2 < arr2.Length; loop2++)
                    {
                        sw.WriteLine("Value " + loop2 + ": " + arr2[loop2]);
                    }
                }

                sw.WriteLine();
                sw.WriteLine("*************************************");
                sw.WriteLine("Contents of Incoming HTTP Entity Body");
                sw.WriteLine("*************************************");
                sw.WriteLine();

                body = req.InputStream;
                encoding = req.ContentEncoding;

                sr = new StreamReader(body, encoding);
                inStr = sr.ReadToEnd();
                sw.WriteLine(inStr);

                if (body != null)
                    body.Close();

                if (sr != null)
                    sr.Close();

                sw.Flush();
                sw.Close();
            }
        }
    }
}