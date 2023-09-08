//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBUMAltViews.cs

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
	[IDOExtensionClass("ESBUMAltViews")]
	public class ESBUMAltViews : CSIExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESBUMAlternateSp(string item)
		{
			var iCLM_ESBUMAlternateExt = new CLM_ESBUMAlternateFactory().Create(this, true);

			var result = iCLM_ESBUMAlternateExt.CLM_ESBUMAlternateSp(item);

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
