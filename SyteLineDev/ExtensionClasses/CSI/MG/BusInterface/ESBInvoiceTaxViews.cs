//PROJECT NAME: MG
//CLASS NAME: ESBInvoiceTaxViews.cs

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
	[IDOExtensionClass("ESBInvoiceTaxViews")]
	public class ESBInvoiceTaxViews : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESBInvoiceTaxSp(string InvNum,
		int? InvSeq)
		{
			var iCLM_ESBInvoiceTaxExt = new CLM_ESBInvoiceTaxFactory().Create(this, true);
			
			var result = iCLM_ESBInvoiceTaxExt.CLM_ESBInvoiceTaxSp(InvNum,
			InvSeq);
			
			IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
			
			DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
			return dt;
		}
	}
}
