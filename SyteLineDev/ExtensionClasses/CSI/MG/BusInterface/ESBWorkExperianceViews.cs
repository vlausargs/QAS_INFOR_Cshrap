//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBWorkExperianceViews.cs

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
	[IDOExtensionClass("ESBWorkExperianceViews")]
	public class ESBWorkExperianceViews : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESBWorkExperianceSp(string EmpNum)
		{
			var iCLM_ESBWorkExperianceExt = new CLM_ESBWorkExperianceFactory().Create(this, true);

			var result = iCLM_ESBWorkExperianceExt.CLM_ESBWorkExperianceSp(EmpNum);

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
