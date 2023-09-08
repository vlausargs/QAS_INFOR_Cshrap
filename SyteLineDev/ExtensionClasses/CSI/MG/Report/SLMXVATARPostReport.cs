//PROJECT NAME: ReportExt
//CLASS NAME: SLMXVATARPostReport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Reporting;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using Microsoft.Extensions.DependencyInjection;

namespace CSI.MG.Report
{
    [IDOExtensionClass("SLMXVATARPostReport")]
    public class SLMXVATARPostReport : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Rpt_MXVATARPostSp()
        {
            var iRpt_MXVATARPostExt = this.GetService<IRpt_MXVATARPost>();

            var result = iRpt_MXVATARPostExt.Rpt_MXVATARPostSp();

            return result.Data.ToDataTable();
        }
    }
}