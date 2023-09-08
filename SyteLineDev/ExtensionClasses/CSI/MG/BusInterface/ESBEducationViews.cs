//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBEducationViews.cs

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
	[IDOExtensionClass("ESBEducationViews")]
	public class ESBEducationViews : CSIExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESBEducationSp(string EmpNum)
		{
			var iCLM_ESBEducationExt = new CLM_ESBEducationFactory().Create(this, true);

			var result = iCLM_ESBEducationExt.CLM_ESBEducationSp(EmpNum);

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
