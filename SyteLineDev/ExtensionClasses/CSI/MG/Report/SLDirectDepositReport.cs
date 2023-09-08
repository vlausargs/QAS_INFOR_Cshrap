//PROJECT NAME: ReportExt
//CLASS NAME: SLDirectDepositReport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Reporting;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Report
{
    [IDOExtensionClass("SLDirectDepositReport")]
    public class SLDirectDepositReport : CSIExtensionClassBase
    {
       

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_DirectDepositSp([Optional] DateTime? StartingTransDate,
		                                     [Optional] DateTime? EndingTransDate,
		                                     [Optional] string StartingEmpNum,
		                                     [Optional] string EndingEmpNum,
		                                     [Optional, DefaultParameterValue((byte)0)] byte? ExOptdfDispPrenot,
											 [Optional, DefaultParameterValue((byte)0)] byte? ExOptdfDispPRec,
											 [Optional] string ExOptdfEmplType,
											 [Optional] short? StartDateOffset,
											 [Optional] short? EndDateOffset,
											 [Optional, DefaultParameterValue((byte)1)] byte? PDisplayHeader,
											 [Optional] string StartEmpCategory,
											 [Optional] string EndEmpCategory,
											 [Optional] string pSite)
		{
			var iRpt_DirectDepositExt = new Rpt_DirectDepositFactory().Create(this, true);

			var result = iRpt_DirectDepositExt.Rpt_DirectDepositSp(StartingTransDate,
				EndingTransDate,
				StartingEmpNum,
				EndingEmpNum,
				ExOptdfDispPrenot,
				ExOptdfDispPRec,
				ExOptdfEmplType,
				StartDateOffset,
				EndDateOffset,
				PDisplayHeader,
				StartEmpCategory,
				EndEmpCategory,
				pSite);

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
