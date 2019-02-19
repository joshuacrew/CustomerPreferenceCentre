using System;
using System.Collections.Generic;
using System.IO;

namespace CustomerPreferenceCentre.Core
{
    public class TextFileReport : IReport
    {
        public void CreateReport(Dictionary<DateTime, List<string>> report)
        {
            using (var file = new StreamWriter("report.txt"))
                foreach (var (date, names) in report)
                {
                    file.WriteLine("{0} {1}", date.ToShortDateString(), string.Join(",", names));
                }
        }
    }
}
