//PROJECT NAME: ProjectsExt
//CLASS NAME: SLProjLabrs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.Projects;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using CSI.ExternalContracts.FactoryTrack;

namespace CSI.MG.Projects
{
	[IDOExtensionClass("SLProjLabrs")]
	public class SLProjLabrs : ExtensionClassBase, IExtFTSLProjLabrs
	{

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ProjlabrDeleteSp(Guid? PSessionID)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iProjlabrDeleteExt = new ProjlabrDeleteFactory().Create(appDb);
				
				int Severity = iProjlabrDeleteExt.ProjlabrDeleteSp(PSessionID);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ProjLabrEmpNumValidSp(string EmpNum,
		                                 ref string EmpName,
		                                 ref string Shift,
		                                 ref decimal? TotalAHours,
		                                 ref string Infobar,
		                                 ref string PromptMessage,
		                                 ref string PromptButtons)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iProjLabrEmpNumValidExt = new ProjLabrEmpNumValidFactory().Create(appDb);
				
				int Severity = iProjLabrEmpNumValidExt.ProjLabrEmpNumValidSp(EmpNum,
				                                                             ref EmpName,
				                                                             ref Shift,
				                                                             ref TotalAHours,
				                                                             ref Infobar,
				                                                             ref PromptMessage,
				                                                             ref PromptButtons);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ProjLabrInitialRateSp(string EmpNum,
		                                 string PayType,
		                                 string Shift,
		                                 DateTime? TransDate,
		                                 ref decimal? PrRate,
		                                 ref decimal? ProjRate,
		                                 ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iProjLabrInitialRateExt = new ProjLabrInitialRateFactory().Create(appDb);
				
				int Severity = iProjLabrInitialRateExt.ProjLabrInitialRateSp(EmpNum,
				                                                             PayType,
				                                                             Shift,
				                                                             TransDate,
				                                                             ref PrRate,
				                                                             ref ProjRate,
				                                                             ref Infobar);
				
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ProjLabrVerifyCloseFormSp(Guid? PSessionID,
		                                     ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iProjLabrVerifyCloseFormExt = new ProjLabrVerifyCloseFormFactory().Create(appDb);
				
				int Severity = iProjLabrVerifyCloseFormExt.ProjLabrVerifyCloseFormSp(PSessionID,
				                                                                     ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_PostProjectLaborTransSp([Optional] string ProjectStarting,
		                                             [Optional] string ProjectEnding,
		                                             [Optional] DateTime? TransactionDateStarting,
		                                             [Optional] DateTime? TransactionDateEnding,
		                                             [Optional] string EmployeeStarting,
		                                             [Optional] string EmployeeEnding,
		                                             [Optional] short? DateStartingOffSET,
		                                             [Optional] short? DateEndingOffSET,
		                                             Guid? PSessionId)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_PostProjectLaborTransExt = new CLM_PostProjectLaborTransFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_PostProjectLaborTransExt.CLM_PostProjectLaborTransSp(ProjectStarting,
				                                                                       ProjectEnding,
				                                                                       TransactionDateStarting,
				                                                                       TransactionDateEnding,
				                                                                       EmployeeStarting,
				                                                                       EmployeeEnding,
				                                                                       DateStartingOffSET,
				                                                                       DateEndingOffSET,
				                                                                       PSessionId);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ProjlabrPostSp(string FromProjNum,
		                          string ToProjNum,
		                          DateTime? FromTransDate,
		                          DateTime? ToTransDate,
		                          string FromEmpNum,
		                          string ToEmpNum,
		                          ref string Infobar,
		                          [Optional] short? StartingDateOffset,
		                          [Optional] short? EndingDateOffset,
		                          Guid? PSessionID)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iProjlabrPostExt = new ProjlabrPostFactory().Create(appDb);
				
				var result = iProjlabrPostExt.ProjlabrPostSp(FromProjNum,
				                                             ToProjNum,
				                                             FromTransDate,
				                                             ToTransDate,
				                                             FromEmpNum,
				                                             ToEmpNum,
				                                             Infobar,
				                                             StartingDateOffset,
				                                             EndingDateOffset,
				                                             PSessionID);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
