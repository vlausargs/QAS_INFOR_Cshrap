//PROJECT NAME: PmfExt
//CLASS NAME: PmfPnBatchsBase.cs

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
	[IDOExtensionClass("PmfPnBatchsBase")]
	public class PmfPnBatchsBase : CSIExtensionClassBase
    {
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmfGetNextContainerNum(string Whse,
		                                  string Loc,
		                                  string Job,
		                                  short? Suffix,
		                                  byte? CreateContainer,
		                                  ref string ContainerNum,
		                                  ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPmfGetNextContainerNumExt = new PmfGetNextContainerNumFactory().Create(appDb);
				
				var result = iPmfGetNextContainerNumExt.PmfGetNextContainerNumSp(Whse,
				                                                                 Loc,
				                                                                 Job,
				                                                                 Suffix,
				                                                                 CreateContainer,
				                                                                 ContainerNum,
				                                                                 InfoBar);
				
				int Severity = result.ReturnCode.Value;
				ContainerNum = result.ContainerNum;
				InfoBar = result.InfoBar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmfPnAutoIssueWip([Optional] ref string InfoBar,
		                             Guid? PnRp,
		                             [Optional, DefaultParameterValue((short)0)] short? FromSuffix,
		                             string WipItem,
		                             [Optional, DefaultParameterValue(0)] int? AutoReceive,
		                             [Optional, DefaultParameterValue(1)] int? IssueAll,
		                             [Optional, DefaultParameterValue(0)] int? IssueMethod)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPmfPnAutoIssueWipExt = new PmfPnAutoIssueWipFactory().Create(appDb);
				
				var result = iPmfPnAutoIssueWipExt.PmfPnAutoIssueWipSp(InfoBar,
				                                                       PnRp,
				                                                       FromSuffix,
				                                                       WipItem,
				                                                       AutoReceive,
				                                                       IssueAll,
				                                                       IssueMethod);
				
				int Severity = result.ReturnCode.Value;
				InfoBar = result.InfoBar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmfPnAutoReceive([Optional] ref string InfoBar,
		                            Guid? PnRp,
		                            [Optional, DefaultParameterValue(1)] int? ReceiveMethod,
		                            [Optional] int? Suffix,
		                            [Optional, DefaultParameterValue(0)] int? OpComplete)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPmfPnAutoReceiveExt = new PmfPnAutoReceiveFactory().Create(appDb);
				
				var result = iPmfPnAutoReceiveExt.PmfPnAutoReceiveSp(InfoBar,
				                                                     PnRp,
				                                                     ReceiveMethod,
				                                                     Suffix,
				                                                     OpComplete);
				
				int Severity = result.ReturnCode.Value;
				InfoBar = result.InfoBar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmfPnBalanceWip([Optional] ref string InfoBar,
		                           Guid? PnRp,
		                           [Optional, DefaultParameterValue((short)0)] short? FromSuffix,
		                           [Optional, DefaultParameterValue(0)] int? Backward,
		                           [Optional, DefaultParameterValue(0)] int? UseActualProd)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPmfPnBalanceWipExt = new PmfPnBalanceWipFactory().Create(appDb);
				
				var result = iPmfPnBalanceWipExt.PmfPnBalanceWipSp(InfoBar,
				                                                   PnRp,
				                                                   FromSuffix,
				                                                   Backward,
				                                                   UseActualProd);
				
				int Severity = result.ReturnCode.Value;
				InfoBar = result.InfoBar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmfPnClose([Optional] ref string InfoBar,
		                      Guid? PnRp)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPmfPnCloseExt = new PmfPnCloseFactory().Create(appDb);
				
				var result = iPmfPnCloseExt.PmfPnCloseSp(InfoBar,
				                                         PnRp);
				
				int Severity = result.ReturnCode.Value;
				InfoBar = result.InfoBar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmfPnMatIssued(Guid? job_RowPointer,
		                          int? op_complete,
		                          ref string warning)
		{
            var iPmfPnMatIssuedExt = new PmfPnMatIssuedFactory().Create(this, true);

            var result = iPmfPnMatIssuedExt.PmfPnMatIssuedSp(job_RowPointer,
                op_complete,
                warning);

            warning = result.warning;

            return result.ReturnCode ?? 0;
        }

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmfPnMatPostWrk([Optional] ref string InfoBar,
		                           [Optional] Guid? SessId,
		                           [Optional] DateTime? TranDate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPmfPnMatPostWrkExt = new PmfPnMatPostWrkFactory().Create(appDb);
				
				var result = iPmfPnMatPostWrkExt.PmfPnMatPostWrkSp(InfoBar,
				                                                   SessId,
				                                                   TranDate);
				
				int Severity = result.ReturnCode.Value;
				InfoBar = result.InfoBar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmfPnProcessWip([Optional] ref string InfoBar,
		                           Guid? PnRp,
		                           [Optional, DefaultParameterValue(0)] int? ReceiveMethod,
		                           [Optional, DefaultParameterValue(1)] int? IssueAll,
		                           [Optional, DefaultParameterValue(0)] int? IssueMethod)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPmfPnProcessWipExt = new PmfPnProcessWipFactory().Create(appDb);
				
				var result = iPmfPnProcessWipExt.PmfPnProcessWipSp(InfoBar,
				                                                   PnRp,
				                                                   ReceiveMethod,
				                                                   IssueAll,
				                                                   IssueMethod);
				
				int Severity = result.ReturnCode.Value;
				InfoBar = result.InfoBar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmfPnProdPost([Optional] ref string InfoBar,
		                         [Optional] Guid? PnRp,
		                         Guid? JobRp,
		                         DateTime? TranDate,
		                         [Optional] ref string Lot,
		                         [Optional] ref string Loc,
		                         [Optional] ref decimal? Qty,
		                         [Optional] ref string Um,
		                         [Optional] ref string ContainerNum,
		                         [Optional] string DocNum,
		                         [Optional] string EmpNum,
		                         [Optional] int? OpComplete,
		                         [Optional] ref int? TransNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPmfPnProdPostExt = new PmfPnProdPostFactory().Create(appDb);
				
				var result = iPmfPnProdPostExt.PmfPnProdPostSp(InfoBar,
				                                               PnRp,
				                                               JobRp,
				                                               TranDate,
				                                               Lot,
				                                               Loc,
				                                               Qty,
				                                               Um,
				                                               ContainerNum,
				                                               DocNum,
				                                               EmpNum,
				                                               OpComplete,
				                                               TransNum);
				
				int Severity = result.ReturnCode.Value;
				InfoBar = result.InfoBar;
				Lot = result.Lot;
				Loc = result.Loc;
				Qty = result.Qty;
				Um = result.Um;
				ContainerNum = result.ContainerNum;
				TransNum = result.TransNum;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmfPnReOpen([Optional] ref string InfoBar,
			Guid? PnRp)
		{
			var iPmfPnReOpenExt = new PmfPnReOpenFactory().Create(this, true);
			
			var result = iPmfPnReOpenExt.PmfPnReOpenSp(InfoBar,
				PnRp);
			
			InfoBar = result.InfoBar;
			
			return result.ReturnCode??0;
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmfPnSizeByMatlAvail(ref string InfoBar,
		                                string job,
		                                short? suffix)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPmfPnSizeByMatlAvailExt = new PmfPnSizeByMatlAvailFactory().Create(appDb);
				
				var result = iPmfPnSizeByMatlAvailExt.PmfPnSizeByMatlAvailSp(InfoBar,
				                                                             job,
				                                                             suffix);
				
				int Severity = result.ReturnCode.Value;
				InfoBar = result.InfoBar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmfPnSizeProd([Optional] ref string Infobar,
		                         Guid? JobRp,
		                         [Optional] decimal? NewQty)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPmfPnSizeProdExt = new PmfPnSizeProdFactory().Create(appDb);
				
				var result = iPmfPnSizeProdExt.PmfPnSizeProdSp(Infobar,
				                                               JobRp,
				                                               NewQty);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmfPnSizeProdToWip([Optional] ref string Infobar,
		                              Guid? PnRp,
		                              [Optional, DefaultParameterValue(0)] int? UseActualWip)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPmfPnSizeProdToWipExt = new PmfPnSizeProdToWipFactory().Create(appDb);
				
				var result = iPmfPnSizeProdToWipExt.PmfPnSizeProdToWipSp(Infobar,
				                                                         PnRp,
				                                                         UseActualWip);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmfPnValidateClose([Optional] ref string InfoBar,
		                              Guid? PnRp,
		                              ref string PromptMsg,
		                              ref string PromptButtons)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPmfPnValidateCloseExt = new PmfPnValidateCloseFactory().Create(appDb);
				
				var result = iPmfPnValidateCloseExt.PmfPnValidateCloseSp(InfoBar,
				                                                         PnRp,
				                                                         PromptMsg,
				                                                         PromptButtons);
				
				int Severity = result.ReturnCode.Value;
				InfoBar = result.InfoBar;
				PromptMsg = result.PromptMsg;
				PromptButtons = result.PromptButtons;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmfRptPnAdd([Optional] ref string InfoBar,
		                       [Optional] Guid? SessionId,
		                       int? Seq,
		                       Guid? PnRp)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPmfRptPnAddExt = new PmfRptPnAddFactory().Create(appDb);
				
				var result = iPmfRptPnAddExt.PmfRptPnAddSp(InfoBar,
				                                           SessionId,
				                                           Seq,
				                                           PnRp);
				
				int Severity = result.ReturnCode.Value;
				InfoBar = result.InfoBar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmfRptPn([Optional] ref string InfoBar,
		                    [Optional, DefaultParameterValue(0)] int? PostProcessing,
		                    [Optional] ref Guid? SessionId,
		                    [Optional] ref int? Seq,
		                    [Optional, DefaultParameterValue(0)] int? ClearSession)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPmfRptPnExt = new PmfRptPnFactory().Create(appDb);
				
				var result = iPmfRptPnExt.PmfRptPnSp(InfoBar,
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
	}
}
