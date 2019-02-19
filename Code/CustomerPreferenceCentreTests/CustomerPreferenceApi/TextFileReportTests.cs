using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using CustomerPreferenceCentre.Core;
using Shouldly;

namespace CustomerPreferenceCentreTests.CustomerPreferenceApi
{
    class TextFileReportTests
    {
        [Test]
        public void FileShouldContainAllDatesWithCorrespondingNames()
        {
            var input = new Dictionary<DateTime, List<string>>
            {
                { DateTime.Now, new List<string> {"a", "b"} },
                { DateTime.Now.AddDays(1), new List<string> {"c", "d"} }
            };

            new TextFileReport().CreateReport(input);

            using (var readText = new StreamReader("report.txt"))
            {
                var reportLine1 = readText.ReadLine();
                reportLine1.ShouldBe($"{DateTime.Now.ToShortDateString()} a,b");
                var reportLine2 = readText.ReadLine();
                reportLine2.ShouldBe($"{DateTime.Now.AddDays(1).ToShortDateString()} c,d");
            }
            
        }
    }
}
