//PROJECT NAME: CustomerExt
//CLASS NAME: SLSlsmans.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using Microsoft.Extensions.DependencyInjection;

namespace CSI.MG.Customer
{
	[IDOExtensionClass("SLSlsmans")]
	public class SLSlsmans : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetSalesmanAddressSp(string RefNum,
		                                byte? Outside,
		                                ref string SalesmanAddress,
		                                ref string Infobar,
                                        ref string UserName)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetSalesmanAddressExt = new GetSalesmanAddressFactory().Create(appDb);
				
				int Severity = iGetSalesmanAddressExt.GetSalesmanAddressSp(RefNum,
				                                                           Outside,
				                                                           ref SalesmanAddress,
				                                                           ref Infobar,
                                                                           ref UserName);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int Home_GetTodaysKeySalespersonValuesSp(ref decimal? CommissionAmount,
		                                                ref decimal? BookingAmount,
		                                                ref decimal? EstimateAmount)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iHome_GetTodaysKeySalespersonValuesExt = new Home_GetTodaysKeySalespersonValuesFactory().Create(appDb);
				
				int Severity = iHome_GetTodaysKeySalespersonValuesExt.Home_GetTodaysKeySalespersonValuesSp(ref CommissionAmount,
				                                                                                           ref BookingAmount,
				                                                                                           ref EstimateAmount);
				
				return Severity;
			}
		}



		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_SlsmanReports(string UserName,
		                                   [Optional, DefaultParameterValue(0)] int? DisplayLevel)
		{
			var iCLM_SlsmanReportsExt = this.GetService<ICLM_SlsmanReports>();

			var result = iCLM_SlsmanReportsExt.CLM_SlsmanReportsSp(UserName,
				DisplayLevel);

			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SalesPersonFromUsername(string UserName,
		                                   ref string SalesPerson)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSalesPersonFromUsernameExt = new SalesPersonFromUsernameFactory().Create(appDb);
				
				var result = iSalesPersonFromUsernameExt.SalesPersonFromUsernameSp(UserName,
				                                                                   SalesPerson);
				
				int Severity = result.ReturnCode.Value;
				SalesPerson = result.SalesPerson;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ValidateSalesPersonNumSp(string Slsman,
		ref string PromptMsg,
		ref string PromptButtons,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iValidateSalesPersonNumExt = new ValidateSalesPersonNumFactory().Create(appDb);
				
				var result = iValidateSalesPersonNumExt.ValidateSalesPersonNumSp(Slsman,
				PromptMsg,
				PromptButtons,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				PromptMsg = result.PromptMsg;
				PromptButtons = result.PromptButtons;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CLM_SlsmanDirectReportsSp(string SlsmanID,
		int? IncludeDirectReports,
		ref string SlsManList)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_SlsmanDirectReportsExt = new CLM_SlsmanDirectReportsFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_SlsmanDirectReportsExt.CLM_SlsmanDirectReportsSp(SlsmanID,
				IncludeDirectReports,
				SlsManList);
				
				int Severity = result.ReturnCode.Value;
				SlsManList = result.SlsManList;
				return Severity;
			}
		}
    }
}
