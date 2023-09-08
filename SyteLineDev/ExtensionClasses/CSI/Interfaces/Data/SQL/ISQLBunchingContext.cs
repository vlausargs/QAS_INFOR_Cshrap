using CSI.Data.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.Data.SQL
{
    public interface ISQLBunchingContext
    {
        bool EnableBookmark { get; set; } //Coding standard Violation.
        string Bookmark { get; set; } //Coding standard Violation.
        int RecordCap { get; set; } //Coding standard Violation.
        LoadType LoadType { get; }
    }
}
