//PROJECT NAME: MG
//CLASS NAME: ESBTrainingViews.cs

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
	[IDOExtensionClass("ESBTrainingViews")]
	public class ESBTrainingViews : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESBTrainingSp(string EmpNum)
		{
			var iCLM_ESBTrainingExt = new CLM_ESBTrainingFactory().Create(this, true);

			var result = iCLM_ESBTrainingExt.CLM_ESBTrainingSp(EmpNum);

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
