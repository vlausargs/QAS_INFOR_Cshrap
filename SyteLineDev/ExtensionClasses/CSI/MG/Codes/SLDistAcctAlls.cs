//PROJECT NAME: CodesExt
//CLASS NAME: SLDistAcctAlls.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Codes;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Codes
{
	[IDOExtensionClass("SLDistAcctAlls")]
	public class SLDistAcctAlls : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_PerTotByProdcodeSp([Optional] string FilterString,
        [Optional] string SiteGroup)
        {
            var iCLM_PerTotByProdcodeExt = new CLM_PerTotByProdcodeFactory().Create(this, true);

            var result = iCLM_PerTotByProdcodeExt.CLM_PerTotByProdcodeSp(FilterString,
            SiteGroup);

            IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

            DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
            return dt;
        }
    }
}
