//PROJECT NAME: MG
//CLASS NAME: ESBItemCategoryViews.cs

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
	[IDOExtensionClass("ESBItemCategoryViews")]
	public class ESBItemCategoryViews : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESBItemCategorySp(string item)
		{
			var iCLM_ESBItemCategoryExt = new CLM_ESBItemCategoryFactory().Create(this, true);

			var result = iCLM_ESBItemCategoryExt.CLM_ESBItemCategorySp(item);

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
