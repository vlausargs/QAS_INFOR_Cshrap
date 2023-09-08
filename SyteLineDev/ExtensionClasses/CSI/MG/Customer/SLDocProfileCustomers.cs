//PROJECT NAME: CustomerExt
//CLASS NAME: SLDocProfileCustomers.cs

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
	[IDOExtensionClass("SLDocProfileCustomers")]
	public class SLDocProfileCustomers : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable ProfilesCustomerStatementofAccountSp([Optional] DateTime? CutOffDate,
		                                                      [Optional] string CustNumStarting,
		                                                      [Optional] string CustNumEnding)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iProfilesCustomerStatementofAccountExt = new ProfilesCustomerStatementofAccountFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iProfilesCustomerStatementofAccountExt.ProfilesCustomerStatementofAccountSp(CutOffDate,
				                                                                                         CustNumStarting,
				                                                                                         CustNumEnding);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}


		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable ProfilesDunningReportSp([Optional] string PStartingCustomer,
		[Optional] string PEndingCustomer,
		[Optional] string PDunningGroup,
		[Optional] int? PStartingDunningStage,
		[Optional] int? PEndingDunningStage,
		[Optional] string PSiteGroup,
		[Optional, DefaultParameterValue(0)] int? PCommit,
		[Optional] DateTime? PCutoffDate,
		[Optional] int? PCutoffDateOffset,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iProfilesDunningReportExt = new ProfilesDunningReportFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iProfilesDunningReportExt.ProfilesDunningReportSp(PStartingCustomer,
				PEndingCustomer,
				PDunningGroup,
				PStartingDunningStage,
				PEndingDunningStage,
				PSiteGroup,
				PCommit,
				PCutoffDate,
				PCutoffDateOffset,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
