//PROJECT NAME: CustomerExt
//CLASS NAME: SLShipProcs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Customer
{
	[IDOExtensionClass("SLShipProcs")]
	public class SLShipProcs : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DoNumChangeUpdateSp(int? PBatchId,
		                               string DerOldDoNum,
		                               string DerNewDoNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iDoNumChangeUpdateExt = new DoNumChangeUpdateFactory().Create(appDb);
				
				int Severity = iDoNumChangeUpdateExt.DoNumChangeUpdateSp(PBatchId,
				                                                         DerOldDoNum,
				                                                         DerNewDoNum);
				
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ValidateToBeShippedRecordSP([Optional] int? pBatchID,
		ref int? pResult,
		ref string pDoNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iValidateToBeShippedRecordExt = new ValidateToBeShippedRecordFactory().Create(appDb);
				
				var result = iValidateToBeShippedRecordExt.ValidateToBeShippedRecordSP(pBatchID,
				pResult,
				pDoNum);
				
				int Severity = result.ReturnCode.Value;
				pResult = result.pResult;
				pDoNum = result.pDoNum;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DoDefaultPackingSlipReportSp(string TPckCall,
		string Whse,
		DateTime? PackDate,
		string CoNum,
		ref int? PackNum,
		ref string Infobar,
		int? BatchId)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iDoDefaultPackingSlipReportExt = new DoDefaultPackingSlipReportFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iDoDefaultPackingSlipReportExt.DoDefaultPackingSlipReportSp(TPckCall,
				Whse,
				PackDate,
				CoNum,
				PackNum,
				Infobar,
				BatchId);
				
				int Severity = result.ReturnCode.Value;
				PackNum = result.PackNum;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
