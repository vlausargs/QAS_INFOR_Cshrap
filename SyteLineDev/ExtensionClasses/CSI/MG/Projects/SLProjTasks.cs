//PROJECT NAME: ProjectsExt
//CLASS NAME: SLProjTasks.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.Projects;
using CSI.MG;
using System.Runtime.InteropServices;
using OfficeIntegration = CSI.ExternalContracts.OfficeIntegration.Project;
using CSI.Data.RecordSets;

namespace CSI.MG.Projects
{
	[IDOExtensionClass("SLProjTasks")]
	public class SLProjTasks : ExtensionClassBase, OfficeIntegration.ISLProjTasks
    {
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetAvgHrsSp(ref decimal? AvgHrs)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetAvgHrsExt = new GetAvgHrsFactory().Create(appDb);
				
				int Severity = iGetAvgHrsExt.GetAvgHrsSp(ref AvgHrs);
				
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int NextProjTaskSp(string ProjNum,
		                          ref int? ProjTaskNum,
		                          ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iNextProjTaskExt = new NextProjTaskFactory().Create(appDb);
				
				int Severity = iNextProjTaskExt.NextProjTaskSp(ProjNum,
				                                               ref ProjTaskNum,
				                                               ref Infobar);
				
				return Severity;
			}
		}




		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable ProjCopyProjectSp(string FromType,
		                                   string ToType,
		                                   string FromProj,
		                                   string ToProj,
		                                   int? StartTask,
		                                   int? EndTask,
		                                   string CopyOption,
		                                   int? RunMode,
		                                   byte? CopyTasks,
		                                   byte? CopyResources,
		                                   byte? CopyRevMilestones,
		                                   byte? CopyInvMilestones,
		                                   ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iProjCopyProjectExt = new ProjCopyProjectFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iProjCopyProjectExt.ProjCopyProjectSp(FromType,
				                                                   ToType,
				                                                   FromProj,
				                                                   ToProj,
				                                                   StartTask,
				                                                   EndTask,
				                                                   CopyOption,
				                                                   RunMode,
				                                                   CopyTasks,
				                                                   CopyResources,
				                                                   CopyRevMilestones,
				                                                   CopyInvMilestones,
				                                                   Infobar);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SetProjectTaskTreeOutlineSp(string ProjNum,
		int? TaskNum,
		int? ParentTaskNum,
		[Optional, DefaultParameterValue("INDENT")] string IndentOrOutdent,
		ref string OutLineNumber,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSetProjectTaskTreeOutlineExt = new SetProjectTaskTreeOutlineFactory().Create(appDb);
				
				var result = iSetProjectTaskTreeOutlineExt.SetProjectTaskTreeOutlineSp(ProjNum,
				TaskNum,
				ParentTaskNum,
				IndentOrOutdent,
				OutLineNumber,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				OutLineNumber = result.OutLineNumber;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int VerifyFromProj(string FromType,
		string FromProj,
		ref int? StartTask,
		ref int? EndTask,
		ref int? NoTask,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iVerifyFromPrExt = new VerifyFromPrFactory().Create(appDb);
				
				var result = iVerifyFromPrExt.VerifyFromProj(FromType,
				FromProj,
				StartTask,
				EndTask,
				NoTask,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				StartTask = result.StartTask;
				EndTask = result.EndTask;
				NoTask = result.NoTask;
				Infobar = result.Infobar;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int StartEndDateSp(string RefNum,
		int? RefLineSuf,
		ref DateTime? StartDate,
		ref DateTime? EndDate,
		ref int? RowCount)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iStartEndDateExt = new StartEndDateFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iStartEndDateExt.StartEndDateSp(RefNum,
				RefLineSuf,
				StartDate,
				EndDate,
				RowCount);
				
				int Severity = result.ReturnCode.Value;
				StartDate = result.StartDate;
				EndDate = result.EndDate;
				RowCount = result.RowCount;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int POItemSp(string RefNum,
		int? RefLineSuf,
		ref DateTime? DueDate,
		ref int? RowsCount)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPOItemExt = new POItemFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPOItemExt.POItemSp(RefNum,
				RefLineSuf,
				DueDate,
				RowsCount);
				
				int Severity = result.ReturnCode.Value;
				DueDate = result.DueDate;
				RowsCount = result.RowsCount;
				return Severity;
			}
		}
	}
}
