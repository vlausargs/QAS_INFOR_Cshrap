//PROJECT NAME: PmfExt
//CLASS NAME: PmfFormulasBase.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.ProcessManufacturing;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.PMF
{
	[IDOExtensionClass("PmfFormulasBase")]
	public class PmfFormulasBase : CSIExtensionClassBase
	{
        [IDOMethod(MethodFlags.None, "Infobar")]
		public int PmfFmGetVerSp(string fm)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPmfFmGetVerExt = new PmfFmGetVerFactory().Create(appDb);
				
				int Severity = iPmfFmGetVerExt.PmfFmGetVerSp(fm);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmfFmCreateRevision([Optional] ref string InfoBar,
		                               Guid? FromFmRp,
		                               [Optional] ref Guid? ToFmRp,
		                               [Optional] ref int? CurrRevision,
		                               [Optional] ref DateTime? FmRecordDate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPmfFmCreateRevisionExt = new PmfFmCreateRevisionFactory().Create(appDb);
				
				var result = iPmfFmCreateRevisionExt.PmfFmCreateRevisionSp(InfoBar,
				                                                           FromFmRp,
				                                                           ToFmRp,
				                                                           CurrRevision,
				                                                           FmRecordDate);
				
				int Severity = result.ReturnCode.Value;
				InfoBar = result.InfoBar;
				ToFmRp = result.ToFmRp;
				CurrRevision = result.CurrRevision;
				FmRecordDate = result.FmRecordDate;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmfFmRecalcLine([Optional] Guid? LineRp,
		                           [Optional] Guid? FmRp,
		                           [Optional] ref string Infobar,
		                           [Optional, DefaultParameterValue(0)] int? UseRecalcFlag)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPmfFMRecalcLineExt = new PmfFMRecalcLineFactory().Create(appDb);
				
				var result = iPmfFMRecalcLineExt.PmfFMRecalcLineSp(LineRp,
				                                                   FmRp,
				                                                   Infobar,
				                                                   UseRecalcFlag);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmfFmRecalc([Optional] Guid? FmRp,
		                       [Optional] ref string Infobar,
		                       [Optional, DefaultParameterValue(1)] int? RecalcLines,
		                       [Optional] ref DateTime? RecordDate,
		                       [Optional, DefaultParameterValue(0)] int? UseRecalcFlag)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPmfFmRecalcExt = new PmfFmRecalcFactory().Create(appDb);
				
				var result = iPmfFmRecalcExt.PmfFmRecalcSp(FmRp,
				                                           Infobar,
				                                           RecalcLines,
				                                           RecordDate,
				                                           UseRecalcFlag);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				RecordDate = result.RecordDate;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmfFmResize([Optional] ref string Infobar,
		                       Guid? FmRp,
		                       [Optional] string Fm,
		                       int? SizeOption,
		                       [Optional] decimal? NewSize,
		                       [Optional] string NewSizeUm,
		                       [Optional] ref decimal? Factor,
		                       [Optional, DefaultParameterValue(0)] int? GetFactorOnly)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPmfFmResizeExt = new PmfFmResizeFactory().Create(appDb);
				
				var result = iPmfFmResizeExt.PmfFmResizeSp(Infobar,
				                                           FmRp,
				                                           Fm,
				                                           SizeOption,
				                                           NewSize,
				                                           NewSizeUm,
				                                           Factor,
				                                           GetFactorOnly);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				Factor = result.Factor;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmfFmSyncJob(ref string Infobar,
		                        [Optional] Guid? FmRp,
		                        [Optional] Guid? JobRp,
		                        [Optional] decimal? Factor,
		                        [Optional] Guid? PnRp)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPmfFmSyncJobExt = new PmfFmSyncJobFactory().Create(appDb);
				
				var result = iPmfFmSyncJobExt.PmfFmSyncJobSp(Infobar,
				                                             FmRp,
				                                             JobRp,
				                                             Factor,
				                                             PnRp);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmfFmUpdFormulaFromJob(ref string Infobar,
		                                  Guid? FormulaRowPointer)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPmfFmUpdFormulaFromJobExt = new PmfFmUpdFormulaFromJobFactory().Create(appDb);
				
				var result = iPmfFmUpdFormulaFromJobExt.PmfFmUpdFormulaFromJobSp(Infobar,
				                                                                 FormulaRowPointer);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmfFmUpdWipCostBom([Optional] ref string InfoBar,
		                              [Optional] Guid? FmRp)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPmfFmUpdWipCostBomExt = new PmfFmUpdWipCostBomFactory().Create(appDb);
				
				var result = iPmfFmUpdWipCostBomExt.PmfFmUpdWipCostBomSp(InfoBar,
				                                                         FmRp);
				
				int Severity = result.ReturnCode.Value;
				InfoBar = result.InfoBar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmfFmValidateJobSync(ref string Infobar,
		                                Guid? FormulaRowPointer,
		                                [Optional, DefaultParameterValue(1)] int? CheckJobSync,
		                                [Optional, DefaultParameterValue(1)] int? CheckFormulaSync,
		                                ref string PromptMsg,
		                                ref string PromptButtons)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPmfFmValidateJobSyncExt = new PmfFmValidateJobSyncFactory().Create(appDb);
				
				var result = iPmfFmValidateJobSyncExt.PmfFmValidateJobSyncSp(Infobar,
				                                                             FormulaRowPointer,
				                                                             CheckJobSync,
				                                                             CheckFormulaSync,
				                                                             PromptMsg,
				                                                             PromptButtons);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				PromptMsg = result.PromptMsg;
				PromptButtons = result.PromptButtons;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmfRptFm([Optional] ref string InfoBar,
		                    [Optional, DefaultParameterValue(0)] int? PostProcessing,
		                    [Optional] ref Guid? SessionId,
		                    [Optional] ref int? Seq,
		                    [Optional, DefaultParameterValue(0)] int? ClearSession)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPmfRptFmExt = new PmfRptFmFactory().Create(appDb);
				
				var result = iPmfRptFmExt.PmfRptFmSp(InfoBar,
				                                     PostProcessing,
				                                     SessionId,
				                                     Seq,
				                                     ClearSession);
				
				int Severity = result.ReturnCode.Value;
				InfoBar = result.InfoBar;
				SessionId = result.SessionId;
				Seq = result.Seq;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable PmfRptSelectSessFm(Guid? SessionID,
		                                    int? Seq,
		                                    [Optional, DefaultParameterValue(0)] int? ClearSession)
		{
            var iPmfRptSelectSessFmExt = new PmfRptSelectSessFmFactory().Create(this, true);

            var result = iPmfRptSelectSessFmExt.PmfRptSelectSessFmSp(SessionID,
                Seq,
                ClearSession);

            if (result.Data is null)
                return new DataTable();
            else
            {
                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
                return recordCollectionToDataTable.ToDataTable(result.Data.Items);
            }
        }

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmfFmGetRevisionSp([Optional] ref string InfoBar,
			string Fm,
			string FmVer,
			ref int? NextRevNo)
		{
			var iPmfFmGetRevisionExt = new PmfFmGetRevisionFactory().Create(this, true);
			
			var result = iPmfFmGetRevisionExt.PmfFmGetRevisionSp(InfoBar,
				Fm,
				FmVer,
				NextRevNo);
			
			InfoBar = result.InfoBar;
			NextRevNo = result.NextRevNo;
			
			return result.ReturnCode??0;
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmfRptFmAddSp([Optional] ref string InfoBar,
		[Optional] Guid? SessionId,
		int? Seq,
		Guid? FmRp,
		string Fm,
		string FmVer)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPmfRptFmAddExt = new PmfRptFmAddFactory().Create(appDb);
				
				var result = iPmfRptFmAddExt.PmfRptFmAddSp(InfoBar,
				SessionId,
				Seq,
				FmRp,
				Fm,
				FmVer);
				
				int Severity = result.ReturnCode.Value;
				InfoBar = result.InfoBar;
				return Severity;
			}
		}
	}
}
