//PROJECT NAME: CustomerExt
//CLASS NAME: SLOpportunities.cs

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
    [IDOExtensionClass("SLOpportunities")]
    public class SLOpportunities : ExtensionClassBase
    {




		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_GetOppsmobiSp(string Slsman,
		                                   [Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_GetOppsmobiExt = new CLM_GetOppsmobiFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_GetOppsmobiExt.CLM_GetOppsmobiSp(Slsman,
				                                                   FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_PipelineByStageSP([Optional] string OppStage,
		                                       [Optional] int? PageNum,
		                                       [Optional] int? EntriesPerPage,
		                                       [Optional] string SiteRef)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_PipelineByStageExt = new CLM_PipelineByStageFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_PipelineByStageExt.CLM_PipelineByStageSP(OppStage,
				                                                           PageNum,
				                                                           EntriesPerPage,
				                                                           SiteRef);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_PipelineByTerritorySP([Optional] string TerritoryCode,
		                                           byte? ChanceToClose,
		                                           [Optional] int? PageNum,
		                                           [Optional] int? EntriesPerPage,
		                                           [Optional] string SiteRef)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_PipelinebyTerritoryExt = new CLM_PipelinebyTerritoryFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_PipelinebyTerritoryExt.CLM_PipelinebyTerritorySp(TerritoryCode,
				                                                                   ChanceToClose,
				                                                                   PageNum,
				                                                                   EntriesPerPage,
				                                                                   SiteRef);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_SalespersonOppsClosed()
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_SalespersonOppsClosedExt = new CLM_SalespersonOppsClosedFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_SalespersonOppsClosedExt.CLM_SalespersonOppsClosedSP();
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_SalespersonPipeline()
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_SalespersonPipelineExt = new CLM_SalespersonPipelineFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_SalespersonPipelineExt.CLM_SalespersonPipelineSP();
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SalespersonHomeAlertsSp(string Slsman,
		ref int? PastDueOpps,
		ref int? PastDueOppTasks,
		ref int? EstimatesToExpire,
		ref int? NumberOfUserTasks,
		ref int? NumberOfEventMessages)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSalespersonHomeAlertsExt = new SalespersonHomeAlertsFactory().Create(appDb);
				
				var result = iSalespersonHomeAlertsExt.SalespersonHomeAlertsSp(Slsman,
				PastDueOpps,
				PastDueOppTasks,
				EstimatesToExpire,
				NumberOfUserTasks,
				NumberOfEventMessages);
				
				int Severity = result.ReturnCode.Value;
				PastDueOpps = result.PastDueOpps;
				PastDueOppTasks = result.PastDueOppTasks;
				EstimatesToExpire = result.EstimatesToExpire;
				NumberOfUserTasks = result.NumberOfUserTasks;
				NumberOfEventMessages = result.NumberOfEventMessages;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_SalesForecastOpportunitiesSp(string Slsman,
		string SalesPeriodId,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_SalesForecastOpportunitiesExt = new CLM_SalesForecastOpportunitiesFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_SalesForecastOpportunitiesExt.CLM_SalesForecastOpportunitiesSp(Slsman,
				SalesPeriodId,
				Infobar);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetOppInfoSp(string CustNum,
		string ProspectID,
		ref string Slsperson,
		ref string TerritoryCode,
		ref string TerritoryDesc,
		ref string CurrencyID,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetOppInfoExt = new GetOppInfoFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetOppInfoExt.GetOppInfoSp(CustNum,
				ProspectID,
				Slsperson,
				TerritoryCode,
				TerritoryDesc,
				CurrencyID,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Slsperson = result.Slsperson;
				TerritoryCode = result.TerritoryCode;
				TerritoryDesc = result.TerritoryDesc;
				CurrencyID = result.CurrencyID;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
