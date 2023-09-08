//PROJECT NAME: MG
//CLASS NAME: ESBItemLangViews.cs

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
	[IDOExtensionClass("ESBItemLangViews")]
	public class ESBItemLangViews : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESBItemLangSp(string item)
		{
			var iCLM_ESBItemLangExt = new CLM_ESBItemLangFactory().Create(this, true);

			var result = iCLM_ESBItemLangExt.CLM_ESBItemLangSp(item);

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
