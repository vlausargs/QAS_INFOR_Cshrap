using CSI.MG;
using Mongoose.IDO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Logistics.Vendor;
using System.Data;
using Mongoose.IDO.Protocol;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Vendor
{
    [IDOExtensionClass("SLPreqitems")]
    public class SLPreqitems : CSIExtensionClassBase
    {
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CheckItemCostSp(string PItem,
			string PWhse,
			ref string PromptMsg,
			ref string PromptButtons)
		{
			var iCheckItemCostExt = new CheckItemCostFactory().Create(this, true);
			
			var result = iCheckItemCostExt.CheckItemCostSp(PItem,
				PWhse,
				PromptMsg,
				PromptButtons);
			
			PromptMsg = result.PromptMsg;
			PromptButtons = result.PromptButtons;
			
			return result.ReturnCode??0;
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DoStatusChangeSp(byte? PCanApprove,
		                            string PReqNum,
		                            short? PReqLine,
		                            string PType,
		                            string POldStat,
		                            string PNewStat,
		                            decimal? PQtyOrdered,
		                            string PUser,
		                            ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iDoStatusChangeExt = new DoStatusChangeFactory().Create(appDb);
				
				int Severity = iDoStatusChangeExt.DoStatusChangeSp(PCanApprove,
				                                                   PReqNum,
				                                                   PReqLine,
				                                                   PType,
				                                                   POldStat,
				                                                   PNewStat,
				                                                   PQtyOrdered,
				                                                   PUser,
				                                                   ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PreqitemValidateUMSp(string PUM,
		                                string PItem,
		                                decimal? PQtyOrdered,
		                                decimal? PPlanCost,
		                                ref string PVendNum,
		                                ref decimal? PPlanCostConv,
		                                ref decimal? TcAmtExtCost,
		                                ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPreqitemValidateUMExt = new PreqitemValidateUMFactory().Create(appDb);
				
				int Severity = iPreqitemValidateUMExt.PreqitemValidateUMSp(PUM,
				                                                           PItem,
				                                                           PQtyOrdered,
				                                                           PPlanCost,
				                                                           ref PVendNum,
				                                                           ref PPlanCostConv,
				                                                           ref TcAmtExtCost,
				                                                           ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable ChgPoReqLineStatSp(string ProcSel,
		                                    string PreqitemFStat,
		                                    string PreqitemTStat,
		                                    string PreqFrom,
		                                    string PreqTo,
		                                    short? PreqFromLine,
		                                    short? PreqToLine,
		                                    string PreqSApprover,
		                                    string PreqEApprover,
		                                    string PreqitemSVendor,
		                                    string PreqitemEVendor,
		                                    DateTime? PreqSRequest,
		                                    DateTime? PreqERequest,
		                                    DateTime? PreqitemSDue,
		                                    DateTime? PreqitemEDue,
		                                    ref string Infobar,
		                                    [Optional] short? StartRequestDateOffset,
		                                    [Optional] short? EndRequestDateOffset,
		                                    [Optional] short? StartDueDateOffset,
		                                    [Optional] short? EndDueDateOffset,
		                                    [Optional] string BGUser)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iChgPoReqLineStatExt = new ChgPoReqLineStatFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iChgPoReqLineStatExt.ChgPoReqLineStatSp(ProcSel,
				                                                     PreqitemFStat,
				                                                     PreqitemTStat,
				                                                     PreqFrom,
				                                                     PreqTo,
				                                                     PreqFromLine,
				                                                     PreqToLine,
				                                                     PreqSApprover,
				                                                     PreqEApprover,
				                                                     PreqitemSVendor,
				                                                     PreqitemEVendor,
				                                                     PreqSRequest,
				                                                     PreqERequest,
				                                                     PreqitemSDue,
				                                                     PreqitemEDue,
				                                                     Infobar,
				                                                     StartRequestDateOffset,
				                                                     EndRequestDateOffset,
				                                                     StartDueDateOffset,
				                                                     EndDueDateOffset,
				                                                     BGUser);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DeletePoRequisitionLinesSp(string BegReqNum,
		                                      string EndReqNum,
		                                      short? BegReqLine,
		                                      short? EndReqLine,
		                                      string BegRequester,
		                                      string EndRequester,
		                                      string BegApprover,
		                                      string EndApprover,
		                                      DateTime? BegReqDate,
		                                      DateTime? EndReqDate,
		                                      ref int? LinesDeleted,
		                                      ref string Infobar,
		                                      [Optional] short? StartRequestDateOffset,
		                                      [Optional] short? EndRequestDateOffset)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iDeletePoRequisitionLinesExt = new DeletePoRequisitionLinesFactory().Create(appDb);
				
				var result = iDeletePoRequisitionLinesExt.DeletePoRequisitionLinesSp(BegReqNum,
				                                                                     EndReqNum,
				                                                                     BegReqLine,
				                                                                     EndReqLine,
				                                                                     BegRequester,
				                                                                     EndRequester,
				                                                                     BegApprover,
				                                                                     EndApprover,
				                                                                     BegReqDate,
				                                                                     EndReqDate,
				                                                                     LinesDeleted,
				                                                                     Infobar,
				                                                                     StartRequestDateOffset,
				                                                                     EndRequestDateOffset);
				
				int Severity = result.ReturnCode.Value;
				LinesDeleted = result.LinesDeleted;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PreqitemValidateItemSp(string PReqNum,
		                                  string PItem,
		                                  string POldItem,
		                                  string PWhse,
		                                  decimal? PQtyOrdered,
		                                  string Stat,
		                                  DateTime? EffectiveDate,
		                                  [Optional] int? CalledFromESS,
		                                  ref string ItemItem,
		                                  ref string PUM,
		                                  ref DateTime? PDueDate,
		                                  ref string PBuyer,
		                                  ref string PVendNum,
		                                  ref string PNonInvAcct,
		                                  ref string PNonInvAcctUnit1,
		                                  ref string PNonInvAcctUnit2,
		                                  ref string PNonInvAcctUnit3,
		                                  ref string PNonInvAcctUnit4,
		                                  ref string PItemDesc,
		                                  ref decimal? TPlanCostConv,
		                                  ref byte? EnableUM,
		                                  ref byte? EnableAcct,
		                                  ref string Infobar,
		                                  ref byte? AcctIsControl)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPreqitemValidateItemExt = new PreqitemValidateItemFactory().Create(appDb);
				
				var result = iPreqitemValidateItemExt.PreqitemValidateItemSp(PReqNum,
				                                                             PItem,
				                                                             POldItem,
				                                                             PWhse,
				                                                             PQtyOrdered,
				                                                             Stat,
				                                                             EffectiveDate,
				                                                             CalledFromESS,
				                                                             ItemItem,
				                                                             PUM,
				                                                             PDueDate,
				                                                             PBuyer,
				                                                             PVendNum,
				                                                             PNonInvAcct,
				                                                             PNonInvAcctUnit1,
				                                                             PNonInvAcctUnit2,
				                                                             PNonInvAcctUnit3,
				                                                             PNonInvAcctUnit4,
				                                                             PItemDesc,
				                                                             TPlanCostConv,
				                                                             EnableUM,
				                                                             EnableAcct,
				                                                             Infobar,
				                                                             AcctIsControl);
				
				int Severity = result.ReturnCode.Value;
				ItemItem = result.ItemItem;
				PUM = result.PUM;
				PDueDate = result.PDueDate;
				PBuyer = result.PBuyer;
				PVendNum = result.PVendNum;
				PNonInvAcct = result.PNonInvAcct;
				PNonInvAcctUnit1 = result.PNonInvAcctUnit1;
				PNonInvAcctUnit2 = result.PNonInvAcctUnit2;
				PNonInvAcctUnit3 = result.PNonInvAcctUnit3;
				PNonInvAcctUnit4 = result.PNonInvAcctUnit4;
				PItemDesc = result.PItemDesc;
				TPlanCostConv = result.TPlanCostConv;
				EnableUM = result.EnableUM;
				EnableAcct = result.EnableAcct;
				Infobar = result.Infobar;
				AcctIsControl = result.AcctIsControl;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CalPReqCostSp(string ReqNum,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCalPReqCostExt = new CalPReqCostFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCalPReqCostExt.CalPReqCostSp(ReqNum,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CheckForUmDteUpdateSp(string PReqNum,
		string PVendNum,
		string POldVendNum,
		string PItem,
		string PUM,
		DateTime? PDueDate,
		string PRefType,
		ref string PNewUM,
		ref DateTime? PNewDte,
		ref string PromptMsg,
		ref string PromptButtons)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCheckForUmDteUpdateExt = new CheckForUmDteUpdateFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCheckForUmDteUpdateExt.CheckForUmDteUpdateSp(PReqNum,
				PVendNum,
				POldVendNum,
				PItem,
				PUM,
				PDueDate,
				PRefType,
				PNewUM,
				PNewDte,
				PromptMsg,
				PromptButtons);
				
				int Severity = result.ReturnCode.Value;
				PNewUM = result.PNewUM;
				PNewDte = result.PNewDte;
				PromptMsg = result.PromptMsg;
				PromptButtons = result.PromptButtons;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ConvertPoReqPreProcessSp(string PPoNum,
		string PReqNum,
		int? PPreqFromLine,
		int? PPreqToLine,
		string PPoType,
		ref int? PPoChangeFlag,
		[Optional] ref string PromptMsg,
		[Optional] ref string PromptButtons,
		[Optional] ref string PoChgPromptMsg,
		[Optional] ref string PoChgPromptButtons,
		[Optional] ref string VendReqPromptMsg,
		[Optional] ref string VendReqPromptButtons,
		[Optional] ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iConvertPoReqPreProcessExt = new ConvertPoReqPreProcessFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iConvertPoReqPreProcessExt.ConvertPoReqPreProcessSp(PPoNum,
				PReqNum,
				PPreqFromLine,
				PPreqToLine,
				PPoType,
				PPoChangeFlag,
				PromptMsg,
				PromptButtons,
				PoChgPromptMsg,
				PoChgPromptButtons,
				VendReqPromptMsg,
				VendReqPromptButtons,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				PPoChangeFlag = result.PPoChangeFlag;
				PromptMsg = result.PromptMsg;
				PromptButtons = result.PromptButtons;
				PoChgPromptMsg = result.PoChgPromptMsg;
				PoChgPromptButtons = result.PoChgPromptButtons;
				VendReqPromptMsg = result.VendReqPromptMsg;
				VendReqPromptButtons = result.VendReqPromptButtons;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable ConvertPoReqSp(string ProcSel,
		string PreqNum,
		int? PreqFromLine,
		int? PreqToLine,
		int? CopyText,
		string PoType,
		string PoNum,
		int? PoChangeFlag,
		ref string Infobar,
		[Optional] string CostCode)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iConvertPoReqExt = new ConvertPoReqFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iConvertPoReqExt.ConvertPoReqSp(ProcSel,
				PreqNum,
				PreqFromLine,
				PreqToLine,
				CopyText,
				PoType,
				PoNum,
				PoChangeFlag,
				Infobar,
				CostCode);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ConvertToDomesticSp(string PVendNum,
		string PCurrCode,
		ref decimal? PPlanCostDom,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iConvertToDomesticExt = new ConvertToDomesticFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iConvertToDomesticExt.ConvertToDomesticSp(PVendNum,
				PCurrCode,
				PPlanCostDom,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				PPlanCostDom = result.PPlanCostDom;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CostsAutomaticSp(string NewPoItem,
		string Whse,
		string PVendNum,
		decimal? InPoQty,
		string PUM,
		DateTime? EffectiveDate,
		ref decimal? TcCprMatCostConv,
		ref decimal? TcCprBrokerageCostConv,
		ref decimal? TcCprDutyCostConv,
		ref decimal? TcCprFreightCostConv,
		ref decimal? TcCprInsuranceCostConv,
		ref decimal? TcCprLocFrtCostConv,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCostsAutomaticExt = new CostsAutomaticFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCostsAutomaticExt.CostsAutomaticSp(NewPoItem,
				Whse,
				PVendNum,
				InPoQty,
				PUM,
				EffectiveDate,
				TcCprMatCostConv,
				TcCprBrokerageCostConv,
				TcCprDutyCostConv,
				TcCprFreightCostConv,
				TcCprInsuranceCostConv,
				TcCprLocFrtCostConv,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				TcCprMatCostConv = result.TcCprMatCostConv;
				TcCprBrokerageCostConv = result.TcCprBrokerageCostConv;
				TcCprDutyCostConv = result.TcCprDutyCostConv;
				TcCprFreightCostConv = result.TcCprFreightCostConv;
				TcCprInsuranceCostConv = result.TcCprInsuranceCostConv;
				TcCprLocFrtCostConv = result.TcCprLocFrtCostConv;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetVendorParmSp(string VendNum,
		ref string VendPriceBy)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetVendorParmExt = new GetVendorParmFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetVendorParmExt.GetVendorParmSp(VendNum,
				VendPriceBy);
				
				int Severity = result.ReturnCode.Value;
				VendPriceBy = result.VendPriceBy;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PreqitemValidateVendNumSp(string PVendNum,
		string POldVendNum,
		string PItem,
		ref string PAcct,
		ref string PAcctUnit1,
		ref string PAcctUnit2,
		ref string PAcctUnit3,
		ref string PAcctUnit4,
		ref decimal? PPlanCostConv,
		ref string PVendCurrCode,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPreqitemValidateVendNumExt = new PreqitemValidateVendNumFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPreqitemValidateVendNumExt.PreqitemValidateVendNumSp(PVendNum,
				POldVendNum,
				PItem,
				PAcct,
				PAcctUnit1,
				PAcctUnit2,
				PAcctUnit3,
				PAcctUnit4,
				PPlanCostConv,
				PVendCurrCode,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				PAcct = result.PAcct;
				PAcctUnit1 = result.PAcctUnit1;
				PAcctUnit2 = result.PAcctUnit2;
				PAcctUnit3 = result.PAcctUnit3;
				PAcctUnit4 = result.PAcctUnit4;
				PPlanCostConv = result.PPlanCostConv;
				PVendCurrCode = result.PVendCurrCode;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ValidateAndSetVendorSp(string PVendNum,
		string POldVendNum,
		string PItem,
		string PReqNum,
		string PUM,
		DateTime? PDueDate,
		string PRefType,
		decimal? InPoQty,
		DateTime? EffectiveDate,
		ref string PAcct,
		ref string PAcctUnit1,
		ref string PAcctUnit2,
		ref string PAcctUnit3,
		ref string PAcctUnit4,
		ref decimal? PPlanCostConv,
		ref string PVendCurrCode,
		ref string PNewUM,
		ref DateTime? PNewDte,
		ref string PromptMsg,
		ref string PromptButtons,
		ref string VendPriceBy,
		ref decimal? TcCprMatCostConv,
		ref decimal? TcCprBrokerageCostConv,
		ref decimal? TcCprDutyCostConv,
		ref decimal? TcCprFreightCostConv,
		ref decimal? TcCprInsuranceCostConv,
		ref decimal? TcCprLocFrtCostConv,
		ref string Infobar)
		{
			var iValidateAndSetVendorExt = new ValidateAndSetVendorFactory().Create(this, true);
			
			var result = iValidateAndSetVendorExt.ValidateAndSetVendorSp(PVendNum,
			POldVendNum,
			PItem,
			PReqNum,
			PUM,
			PDueDate,
			PRefType,
			InPoQty,
			EffectiveDate,
			PAcct,
			PAcctUnit1,
			PAcctUnit2,
			PAcctUnit3,
			PAcctUnit4,
			PPlanCostConv,
			PVendCurrCode,
			PNewUM,
			PNewDte,
			PromptMsg,
			PromptButtons,
			VendPriceBy,
			TcCprMatCostConv,
			TcCprBrokerageCostConv,
			TcCprDutyCostConv,
			TcCprFreightCostConv,
			TcCprInsuranceCostConv,
			TcCprLocFrtCostConv,
			Infobar);
			
			int Severity = result.ReturnCode.Value;
			PAcct = result.PAcct;
			PAcctUnit1 = result.PAcctUnit1;
			PAcctUnit2 = result.PAcctUnit2;
			PAcctUnit3 = result.PAcctUnit3;
			PAcctUnit4 = result.PAcctUnit4;
			PPlanCostConv = result.PPlanCostConv;
			PVendCurrCode = result.PVendCurrCode;
			PNewUM = result.PNewUM;
			PNewDte = result.PNewDte;
			PromptMsg = result.PromptMsg;
			PromptButtons = result.PromptButtons;
			VendPriceBy = result.VendPriceBy;
			TcCprMatCostConv = result.TcCprMatCostConv;
			TcCprBrokerageCostConv = result.TcCprBrokerageCostConv;
			TcCprDutyCostConv = result.TcCprDutyCostConv;
			TcCprFreightCostConv = result.TcCprFreightCostConv;
			TcCprInsuranceCostConv = result.TcCprInsuranceCostConv;
			TcCprLocFrtCostConv = result.TcCprLocFrtCostConv;
			Infobar = result.Infobar;
			return Severity;
		}

    }
}
