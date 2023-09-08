//PROJECT NAME: PmfExt
//CLASS NAME: PmfMfgSpecsBase.cs

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
	[IDOExtensionClass("PmfMfgSpecsBase")]
	public class PmfMfgSpecsBase : ExtensionClassBase
	{



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmfRptMfSpecSp([Optional] ref string InfoBar,
		                          [Optional, DefaultParameterValue(0)] int? PostProcessing,
		[Optional] ref Guid? SessionId,
		[Optional] ref int? Seq,
		[Optional, DefaultParameterValue(0)] int? ClearSession)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPmfRptMfSpecExt = new PmfRptMfSpecFactory().Create(appDb);
				
				var result = iPmfRptMfSpecExt.PmfRptMfSpecSp(InfoBar,
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
		public DataTable PmfRptSelectSessSpecSp(Guid? SessionId,
		                                        int? Seq,
		                                        [Optional, DefaultParameterValue(0)] int? ClearSess)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iPmfRptSelectSessSpecExt = new PmfRptSelectSessSpecFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iPmfRptSelectSessSpecExt.PmfRptSelectSessSpecSp(SessionId,
				                                                             Seq,
				                                                             ClearSess);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmfRptSpecAdd([Optional] ref string InfoBar,
		                         [Optional] Guid? SessionId,
		                         int? Seq,
		                         Guid? MfSpecRp)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPmfRptSpecAddExt = new PmfRptSpecAddFactory().Create(appDb);
				
				var result = iPmfRptSpecAddExt.PmfRptSpecAddSp(InfoBar,
				                                               SessionId,
				                                               Seq,
				                                               MfSpecRp);
				
				int Severity = result.ReturnCode.Value;
				InfoBar = result.InfoBar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmfSpecBalanceWip()
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPmfSpecBalanceWipExt = new PmfSpecBalanceWipFactory().Create(appDb);
				
				var result = iPmfSpecBalanceWipExt.PmfSpecBalanceWipSp();
				
				
				return result.Value;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmfSpecUpdWipCostBom([Optional] ref string InfoBar,
		                                [Optional] Guid? SpecRp,
		                                [Optional, DefaultParameterValue(0)] int? AddWipIfMissing)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPmfSpecUpdWipCostBomExt = new PmfSpecUpdWipCostBomFactory().Create(appDb);
				
				var result = iPmfSpecUpdWipCostBomExt.PmfSpecUpdWipCostBomSp(InfoBar,
				                                                             SpecRp,
				                                                             AddWipIfMissing);
				
				int Severity = result.ReturnCode.Value;
				InfoBar = result.InfoBar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmfSpecValidate()
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPmfSpecValidateExt = new PmfSpecValidateFactory().Create(appDb);
				
				var result = iPmfSpecValidateExt.PmfSpecValidateSp();
				
				
				return result.Value;
			}
		}
	}
}
