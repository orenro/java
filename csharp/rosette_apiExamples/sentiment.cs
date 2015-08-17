﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using rosette_api;

namespace rosette_apiExamples
{
    class sentiment
    {
        /// <summary>
        /// Example code to call Rosette API to get a document's sentiment
        /// Requires Nuget Package:
        /// rosette_api
        /// </summary>
        static void Main(string[] args)
        {
            //To use the C# API, you must provide an API key
            if (args.Length == 0)
            {
                Console.WriteLine("This example requires an API key argument in the command line");
            }
            else
            {
                CAPI SentimentCAPI = new CAPI(args[0]);

                StreamWriter sw = new StreamWriter("C:\\Test.html");
                sw.WriteLine("${sentiment_data}");
                sw.Close();

                try
                {
                    //Rosette API provides File upload options (shown here)
                    //Simply create a new RosetteFile using the path to a file
                    //The results of the API call will come back in the form of a Dictionary
                    Dictionary<string, Object> SentimentResult = SentimentCAPI.Sentiment(new RosetteFile("C:\\Test.txt"));
                    Console.WriteLine(new JavaScriptSerializer().Serialize(SentimentResult));
                }
                catch (RosetteException e)
                {
                    Console.WriteLine("Error Code " + e.Code.ToString() + ":" + e.Message);
                }
            }
        }
    }
}