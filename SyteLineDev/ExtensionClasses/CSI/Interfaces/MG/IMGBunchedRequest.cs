using System;
using System.Collections.Generic;
using System.Text;
using CSI.Data.Cache;

namespace CSI.MG
{
    public interface IMGBunchedRequest
    {
        bool EnableBookmark { get; set; } //Coding standard Violation.
        string Bookmark { get; set; } //Coding standard Violation.
        int RecordCap { get; set; } //Coding standard Violation.
        LoadType LoadType { get; }
    }
}
