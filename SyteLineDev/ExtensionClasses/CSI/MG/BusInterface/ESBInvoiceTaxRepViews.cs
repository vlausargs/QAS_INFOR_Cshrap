//PROJECT NAME: MG
//CLASS NAME: ESBInvoiceTaxRepViews.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.BusInterface;
using CSI.MG;
using CSI.Data.RecordSets;
using System.Runtime.InteropServices;

namespace CSI.MG.BusInterface
{
	[IDOExtensionClass("ESBInvoiceTaxRepViews")]
	public class ESBInvoiceTaxRepViews : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESBInvoiceTaxRepSp(string InvNum,
		int? InvSeq)
		{
            var iCLM_ESBInvoiceTaxRepExt = new CLM_ESBInvoiceTaxRepFactory().Create(this, true);

            var result = iCLM_ESBInvoiceTaxRepExt.CLM_ESBInvoiceTaxRepSp(InvNum,
                InvSeq);

            if (result.Data is null)
                return new DataTable();
            else
            {
                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
                return recordCollectionToDataTable.ToDataTable(result.Data.Items);
            }
        }
	}
}
