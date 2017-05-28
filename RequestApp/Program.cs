﻿using System;
using USMarcLibrary;
using USMarcLibrary.BibEAttributes;
using USMarcLibrary.Parsers;
using USMarcLibrary.Writers;
using USMarcLibrary.Z3950;

namespace RequestApp
{
    class Program
    {
        static void Main()
        {
            Request();

            Console.WriteLine("COMPLETE!");
            Console.ReadLine();

        }

        private static void Request()
        {
            Console.WriteLine("Performing Request ( z39.50 )");

            try
            {
                // Create the Z39.50 endpoint
                //var endpoint = new Z3950_Endpoint("vsu", "z3950.lib.vsu.ru", 210, "automat");
                var endpoint = new Z3950Endpoint("Library of Congress", "z3950.ssu.samara.ru", 210, "books");
                //var endpoint = new Z3950Endpoint("Library of Congress", "z3950.loc.gov", 7090, "VOYAGER");
                //var endpoint = new Z3950_Endpoint("Canadian National Catalogue", "142.78.200.109", 210, "NL");

                var manager = new MarcRecordZ3950Manager();
                var records = manager.GetRecords(endpoint, Bib1Attr.Title, "\"sql\"");

                var i = 0;
                foreach (var marcRecord in records)
                    marcRecord.Save_MARC_XML("record" + ++i + ".xml");
            }
            catch (Exception ee)
            {
                Console.WriteLine("EXCEPTION. ( " + ee.Message + " )");
            }

        }

    }
}
