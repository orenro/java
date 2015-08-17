﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using rosette_api;

namespace rosette_apiExamples
{
    class matched_name
    {
        /// <summary>
        /// Example code to call Rosette API to get match score (similarity) for two names.
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
                CAPI MatchedNameCAPI = new CAPI(args[0]);
                try
                {
                    //The results of the API call will come back in the form of a Dictionary
                    Dictionary<string, Object> MatchedNameResult = MatchedNameCAPI.MatchedName(new Name("Elizabeth Doe", "eng", null, "PERSON"), new Name("Liz Doe", null, null, "PERSON"));
                    Console.WriteLine(new JavaScriptSerializer().Serialize(MatchedNameResult));
                }
                catch (RosetteException e)
                {
                    Console.WriteLine("Error Code " + e.Code.ToString() + ":" + e.Message);
                }
            } 
        }
    }
}
