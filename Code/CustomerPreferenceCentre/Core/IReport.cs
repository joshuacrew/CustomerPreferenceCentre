using System;
using System.Collections.Generic;

namespace CustomerPreferenceCentre.Core
{
    public interface IReport
    {
        void CreateReport(Dictionary<DateTime, List<string>> report);
    }
}