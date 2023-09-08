//PROJECT NAME: EmployeeExt
//CLASS NAME: SLEmpSelfServPrtrxps.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Employee;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using Microsoft.Extensions.DependencyInjection;

namespace CSI.MG.Employee
{
	[IDOExtensionClass("SLEmpSelfServPrtrxps")]
	public class SLEmpSelfServPrtrxps : CSIExtensionClassBase
    {
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetMostRecentEmployeeCheckSp(string EmpNum,
		                                        ref DateTime? CheckDate,
		                                        short? Seq,
		                                        ref int? CheckNum,
		                                        ref Guid? RowPointer,
		                                        ref DateTime? PerStart,
		                                        ref DateTime? PerEnd,
		                                        ref decimal? GrossPay,
		                                        ref decimal? NetPay,
		                                        ref decimal? TotalTaxes,
		                                        ref decimal? TotalDed,
		                                        ref decimal? DirectDep,
		                                        ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetMostRecentEmployeeCheckExt = new GetMostRecentEmployeeCheckFactory().Create(appDb);
				
				int Severity = iGetMostRecentEmployeeCheckExt.GetMostRecentEmployeeCheckSp(EmpNum,
				                                                                           ref CheckDate,
				                                                                           Seq,
				                                                                           ref CheckNum,
				                                                                           ref RowPointer,
				                                                                           ref PerStart,
				                                                                           ref PerEnd,
				                                                                           ref GrossPay,
				                                                                           ref NetPay,
				                                                                           ref TotalTaxes,
				                                                                           ref TotalDed,
				                                                                           ref DirectDep,
				                                                                           ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetEmpTotalHrsAndPaySp(DateTime? StartingCheckDate,
		                                  DateTime? EndingCheckDate,
		                                  ref decimal? TotRegHrs,
		                                  ref decimal? TotRegPay,
		                                  ref decimal? TotOTHrs,
		                                  ref decimal? TotOTPay,
		                                  ref decimal? TotDTHrs,
		                                  ref decimal? TotDTPay,
		                                  ref decimal? TotHolHrs,
		                                  ref decimal? TotHolPay,
		                                  ref decimal? TotSickHrs,
		                                  ref decimal? TotSickPay,
		                                  ref decimal? TotVacHrs,
		                                  ref decimal? TotVacPay,
		                                  ref decimal? TotOthHrs,
		                                  ref decimal? TotOthPay,
		                                  ref decimal? TotHrs,
		                                  ref decimal? TotPay,
		                                  ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetEmpTotalHrsAndPayExt = new GetEmpTotalHrsAndPayFactory().Create(appDb);
				
				int Severity = iGetEmpTotalHrsAndPayExt.GetEmpTotalHrsAndPaySp(StartingCheckDate,
				                                                               EndingCheckDate,
				                                                               ref TotRegHrs,
				                                                               ref TotRegPay,
				                                                               ref TotOTHrs,
				                                                               ref TotOTPay,
				                                                               ref TotDTHrs,
				                                                               ref TotDTPay,
				                                                               ref TotHolHrs,
				                                                               ref TotHolPay,
				                                                               ref TotSickHrs,
				                                                               ref TotSickPay,
				                                                               ref TotVacHrs,
				                                                               ref TotVacPay,
				                                                               ref TotOthHrs,
				                                                               ref TotOthPay,
				                                                               ref TotHrs,
				                                                               ref TotPay,
				                                                               ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_PayCheckEarningsSp(DateTime? CheckDate,
			Guid? CheckRowPointer,
			string EmpNum)
		{
			var iCLM_PayCheckEarningsExt = this.GetService<ICLM_PayCheckEarnings>();

			var result = iCLM_PayCheckEarningsExt.CLM_PayCheckEarningsSp(CheckDate,
				CheckRowPointer,
				EmpNum);
			
			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_PayCheckTaxesAndDeductionsSp(DateTime? CheckDate,
		Guid? CheckRowPointer,
		string EmpNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_PayCheckTaxesAndDeductionsExt = new CLM_PayCheckTaxesAndDeductionsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_PayCheckTaxesAndDeductionsExt.CLM_PayCheckTaxesAndDeductionsSp(CheckDate,
				CheckRowPointer,
				EmpNum);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_PayrollCheckDateChartSp(string EmpNum)
		{
            var iCLM_PayrollCheckDateChartExt = this.GetService<ICLM_PayrollCheckDateChart>();

			var result = iCLM_PayrollCheckDateChartExt.CLM_PayrollCheckDateChartSp(EmpNum);

            if (result.Data is null)
                return new DataTable();
            else
            {
                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
                return recordCollectionToDataTable.ToDataTable(result.Data.Items);
            }
        }

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_PayrollCheckDateListingSp(string EmpNum)
		{
			var iCLM_PayrollCheckDateListingExt = this.GetService<ICLM_PayrollCheckDateListing>();

			var result = iCLM_PayrollCheckDateListingExt.CLM_PayrollCheckDateListingSp(EmpNum);
			
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
