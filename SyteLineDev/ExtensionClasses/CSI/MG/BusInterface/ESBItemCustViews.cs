//PROJECT NAME: MG
//CLASS NAME: ESBItemCustViews.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.BusInterface;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.BusInterface
{
	[IDOExtensionClass("ESBItemCustViews")]
	public class ESBItemCustViews : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESBItemCustSp(string item)
		{
			var iCLM_ESBItemCustExt = new CLM_ESBItemCustFactory().Create(this, true);

			var result = iCLM_ESBItemCustExt.CLM_ESBItemCustSp(item);

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
