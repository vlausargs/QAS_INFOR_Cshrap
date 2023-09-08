//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBUMConvViews.cs

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
	[IDOExtensionClass("ESBUMConvViews")]
	public class ESBUMConvViews : CSIExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESBUMConvSp(string item)
		{
			var iCLM_ESBUMConvExt = new CLM_ESBUMConvFactory().Create(this, true);

			var result = iCLM_ESBUMConvExt.CLM_ESBUMConvSp(item);

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
