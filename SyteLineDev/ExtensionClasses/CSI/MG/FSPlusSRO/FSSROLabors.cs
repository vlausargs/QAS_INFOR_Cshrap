//PROJECT NAME: FSPlusSROExt
//CLASS NAME: FSSROLabors.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.FieldService.Requests;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.ExternalContracts.FactoryTrack;
using CSI.Data.RecordSets;
using CSI.ExternalContracts.Portals;

namespace CSI.MG.FSPlusSRO
{
    [IDOExtensionClass("FSSROLabors")]
    public class FSSROLabors : ExtensionClassBase, IExtFTFSSROLabors, IFSSROLabors
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSFSSROLaborDCValidSp(string Level,
                                          string PartnerID,
                                          string WorkCode,
                                          DateTime? TransDate,
                                          string SRONum,
                                          ref int? SROLine,
                                          ref int? SROOper,
                                          ref string SroDesc,
                                          ref string LineItem,
                                          ref string OperDesc,
                                          ref string BillCode,
                                          ref decimal? UnitCost,
                                          ref decimal? UnitRate,
                                          ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSFSSROLaborDCValidExt = new SSSFSSROLaborDCValidFactory().Create(appDb);

                FSSROLineType oSROLine = SROLine;
                FSSROOperType oSROOper = SROOper;
                DescriptionType oSroDesc = SroDesc;
                ItemType oLineItem = LineItem;
                DescriptionType oOperDesc = OperDesc;
                FSSROBillCodeType oBillCode = BillCode;
                CostPrcType oUnitCost = UnitCost;
                CostPrcType oUnitRate = UnitRate;
                InfobarType oInfobar = Infobar;

                int Severity = iSSSFSSROLaborDCValidExt.SSSFSSROLaborDCValidSp(Level,
                                                                               PartnerID,
                                                                               WorkCode,
                                                                               TransDate,
                                                                               SRONum,
                                                                               ref oSROLine,
                                                                               ref oSROOper,
                                                                               ref oSroDesc,
                                                                               ref oLineItem,
                                                                               ref oOperDesc,
                                                                               ref oBillCode,
                                                                               ref oUnitCost,
                                                                               ref oUnitRate,
                                                                               ref oInfobar);

                SROLine = oSROLine;
                SROOper = oSROOper;
                SroDesc = oSroDesc;
                LineItem = oLineItem;
                OperDesc = oOperDesc;
                BillCode = oBillCode;
                UnitCost = oUnitCost;
                UnitRate = oUnitRate;
                Infobar = oInfobar;


                return Severity;
            }
        }
        


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSPortalGetNewSROTransInfoSp(string SroNum,
		                                           string CustNum,
		                                           int? CustSeq,
		                                           string Username,
		                                           ref string SroDescription,
		                                           ref string ShpToName,
		                                           ref string SiteSiteName,
		                                           ref int? SroLine,
		                                           ref string LnSerNum,
		                                           ref string LnItem,
		                                           ref string LnDescription,
		                                           ref int? SroOper,
		                                           ref string OperCode,
		                                           ref string OperDescription,
		                                           ref string PartnerID,
		                                           ref string PartnerName,
		                                           ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSPortalGetNewSROTransInfoExt = new SSSFSPortalGetNewSROTransInfoFactory().Create(appDb);
				
				int Severity = iSSSFSPortalGetNewSROTransInfoExt.SSSFSPortalGetNewSROTransInfoSp(SroNum,
				                                                                                 CustNum,
				                                                                                 CustSeq,
				                                                                                 Username,
				                                                                                 ref SroDescription,
				                                                                                 ref ShpToName,
				                                                                                 ref SiteSiteName,
				                                                                                 ref SroLine,
				                                                                                 ref LnSerNum,
				                                                                                 ref LnItem,
				                                                                                 ref LnDescription,
				                                                                                 ref SroOper,
				                                                                                 ref OperCode,
				                                                                                 ref OperDescription,
				                                                                                 ref PartnerID,
				                                                                                 ref PartnerName,
				                                                                                 ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSPortalValidateSROLaborSp(string SroNum,
		                                         int? SroLine,
		                                         int? SroOper,
		                                         string PartnerID,
		                                         DateTime? TransDate,
		                                         string CustNum,
		                                         string CustSeq,
		                                         string Username,
		                                         string WorkCode,
		                                         ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSPortalValidateSROLaborExt = new SSSFSPortalValidateSROLaborFactory().Create(appDb);
				
				int Severity = iSSSFSPortalValidateSROLaborExt.SSSFSPortalValidateSROLaborSp(SroNum,
				                                                                             SroLine,
				                                                                             SroOper,
				                                                                             PartnerID,
				                                                                             TransDate,
				                                                                             CustNum,
				                                                                             CustSeq,
				                                                                             Username,
				                                                                             WorkCode,
				                                                                             ref Infobar);
				
				return Severity;
			}
		}

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSFSSROLaborCostSp(string iTransType,
                                       string iSroNum,
                                       int? iSroLine,
                                       int? iSroOper,
                                       string iPartnerId,
                                       string iWorkCode,
                                       DateTime? iTransDate,
                                       ref decimal? oUnitCost,
                                       ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSFSSROLaborCostExt = new SSSFSSROLaborCostFactory().Create(appDb);

                int Severity = iSSSFSSROLaborCostExt.SSSFSSROLaborCostSp(iTransType,
                                                                         iSroNum,
                                                                         iSroLine,
                                                                         iSroOper,
                                                                         iPartnerId,
                                                                         iWorkCode,
                                                                         iTransDate,
                                                                         ref oUnitCost,
                                                                         ref Infobar);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSFSSroLaborRateSp(string iTransType,
                                       string iSroNum,
                                       int? iSroLine,
                                       int? iSroOper,
                                       string iBillCode,
                                       DateTime? iTransDate,
                                       string iPartnerId,
                                       string iWorkCode,
                                       decimal? iUnitCost,
                                       decimal? iHrsWorked,
                                       decimal? iHrsBilled,
                                       ref decimal? oUnitPrice,
                                       ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSFSSroLaborRateExt = new SSSFSSroLaborRateFactory().Create(appDb);

                int Severity = iSSSFSSroLaborRateExt.SSSFSSroLaborRateSp(iTransType,
                                                                         iSroNum,
                                                                         iSroLine,
                                                                         iSroOper,
                                                                         iBillCode,
                                                                         iTransDate,
                                                                         iPartnerId,
                                                                         iWorkCode,
                                                                         iUnitCost,
                                                                         iHrsWorked,
                                                                         iHrsBilled,
                                                                         ref oUnitPrice,
                                                                         ref Infobar);

                return Severity;
            }
        }


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSroTransPostLaborSp(Guid? iRowPointer,
		                                    string iMode,
		                                    ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSSroTransPostLaborExt = new SSSFSSroTransPostLaborFactory().Create(appDb);
				
				int Severity = iSSSFSSroTransPostLaborExt.SSSFSSroTransPostLaborSp(iRowPointer,
				                                                                   iMode,
				                                                                   ref Infobar);
				
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSInspSignOffSp(string Type,
		                              Guid? RowPointer,
		                              ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSInspSignOffExt = new SSSFSInspSignOffFactory().Create(appDb);
				
				int Severity = iSSSFSInspSignOffExt.SSSFSInspSignOffSp(Type,
				                                                       RowPointer,
				                                                       ref Infobar);
				
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSPortalCreateSROLaborSp(string SroNum,
		                                       int? SroLine,
		                                       int? SroOper,
		                                       string PartnerID,
		                                       DateTime? TransDate,
		                                       string CustNum,
		                                       string CustSeq,
		                                       string Username,
		                                       string WorkCode,
		                                       decimal? HrsWorked,
		                                       decimal? HrsToBill,
		                                       string NoteContent,
		                                       [Optional, DefaultParameterValue((byte)0)] byte? Validate,
		ref Guid? RowPointer,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSPortalCreateSROLaborExt = new SSSFSPortalCreateSROLaborFactory().Create(appDb);
				
				var result = iSSSFSPortalCreateSROLaborExt.SSSFSPortalCreateSROLaborSp(SroNum,
				                                                                       SroLine,
				                                                                       SroOper,
				                                                                       PartnerID,
				                                                                       TransDate,
				                                                                       CustNum,
				                                                                       CustSeq,
				                                                                       Username,
				                                                                       WorkCode,
				                                                                       HrsWorked,
				                                                                       HrsToBill,
				                                                                       NoteContent,
				                                                                       Validate,
				                                                                       RowPointer,
				                                                                       Infobar);
				
				int Severity = result.ReturnCode.Value;
				RowPointer = result.RowPointer;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSROLaborDCCheckSp(string PartnerId,
		                                  ref string SroNum,
		                                  ref int? SroLine,
		                                  ref int? SroOper,
		                                  ref DateTime? StartDate,
		                                  [Optional] ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSSROLaborDCCheckExt = new SSSFSSROLaborDCCheckFactory().Create(appDb);
				
				var result = iSSSFSSROLaborDCCheckExt.SSSFSSROLaborDCCheckSp(PartnerId,
				                                                             SroNum,
				                                                             SroLine,
				                                                             SroOper,
				                                                             StartDate,
				                                                             Infobar);
				
				int Severity = result.ReturnCode.Value;
				SroNum = result.SroNum;
				SroLine = result.SroLine;
				SroOper = result.SroOper;
				StartDate = result.StartDate;
				Infobar = result.Infobar;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSROLaborDCStartSp(string PartnerId,
		                                  string Type,
		                                  Guid? RowPointer,
		                                  [Optional] ref string Infobar,
		                                  [Optional] string SroNum,
		                                  [Optional] int? SroLine,
		                                  [Optional] int? SroOper,
		                                  DateTime? StartDate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSSROLaborDCStartExt = new SSSFSSROLaborDCStartFactory().Create(appDb);
				
				var result = iSSSFSSROLaborDCStartExt.SSSFSSROLaborDCStartSp(PartnerId,
				                                                             Type,
				                                                             RowPointer,
				                                                             Infobar,
				                                                             SroNum,
				                                                             SroLine,
				                                                             SroOper,
				                                                             StartDate);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}




		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSROLaborDCFinishSp(string PartnerId,
		string SroNum,
		int? SroLine,
		int? SroOper,
		string WorkCode,
		decimal? HrsWorked,
		decimal? HrsToBill,
		DateTime? EndDate,
		string NoteContent,
		[Optional] ref string Infobar,
		[Optional] string BillCode,
		[Optional] decimal? UnitCost,
		[Optional] decimal? UnitRate,
		[Optional, DefaultParameterValue(0)] int? LogTran,
		[Optional] Guid? DcRowPointer)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSSROLaborDCFinishExt = new SSSFSSROLaborDCFinishFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSSROLaborDCFinishExt.SSSFSSROLaborDCFinishSp(PartnerId,
				SroNum,
				SroLine,
				SroOper,
				WorkCode,
				HrsWorked,
				HrsToBill,
				EndDate,
				NoteContent,
				Infobar,
				BillCode,
				UnitCost,
				UnitRate,
				LogTran,
				DcRowPointer);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSroPlanTransPostLaborSp(Guid? iRowPointer,
		string iMode,
		string iPartnerId,
		string iDept,
		string iWhse,
		DateTime? iTransDate,
		DateTime? iPostDate,
		decimal? iPstHrsWorked,
		decimal? iPstHrsToBill,
		decimal? iMatlCost,
		decimal? iLbrCost,
		decimal? iFovhdCost,
		decimal? iVovhdCost,
		decimal? iOutCost,
		string UpdateStatus,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSSroPlanTransPostLaborExt = new SSSFSSroPlanTransPostLaborFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSSroPlanTransPostLaborExt.SSSFSSroPlanTransPostLaborSp(iRowPointer,
				iMode,
				iPartnerId,
				iDept,
				iWhse,
				iTransDate,
				iPostDate,
				iPstHrsWorked,
				iPstHrsToBill,
				iMatlCost,
				iLbrCost,
				iFovhdCost,
				iVovhdCost,
				iOutCost,
				UpdateStatus,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSROTransLaborCstPrcTaxSp(string SroNum,
		int? SroLine,
		int? SroOper,
		string WorkCode,
		string BillCode,
		DateTime? TransDate,
		string PartnerId,
		decimal? HrsWorked,
		decimal? HrsToBill,
		ref decimal? DefCost,
		ref decimal? DefPrice,
		ref string TaxCode1,
		ref string TaxCode2,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSSROTransLaborCstPrcTaxExt = new SSSFSSROTransLaborCstPrcTaxFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSSROTransLaborCstPrcTaxExt.SSSFSSROTransLaborCstPrcTaxSp(SroNum,
				SroLine,
				SroOper,
				WorkCode,
				BillCode,
				TransDate,
				PartnerId,
				HrsWorked,
				HrsToBill,
				DefCost,
				DefPrice,
				TaxCode1,
				TaxCode2,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				DefCost = result.DefCost;
				DefPrice = result.DefPrice;
				TaxCode1 = result.TaxCode1;
				TaxCode2 = result.TaxCode2;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSROTransValidSROLaborSp(string Table,
		string Level,
		string SRONum,
		ref int? SROLine,
		ref int? SROOper,
		ref DateTime? TransDate,
		ref DateTime? PostDate,
		ref string PartnerID,
		ref int? PartnerReimbLabor,
		ref string Dept,
		ref string Whse,
		ref string BillCode,
		ref string WorkCode,
		ref string WorkCodeDesc,
		ref decimal? UnitCost,
		ref decimal? UnitRate,
		ref string TaxCode1,
		ref string TaxCode2,
		ref string VatLabel,
		ref string PriceCurrCode,
		ref string Prompt,
		ref string PromptButtons,
		ref decimal? Disc,
		ref string Infobar,
		ref string CurAmtFormat,
		ref string CurCstPrcFormat,
		[Optional, DefaultParameterValue("A")] string Type,
		[Optional] ref string ReimbTaxCode1,
		[Optional] ref string ReimbTaxCode2,
		[Optional] ref string ReimbMethod)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSSROTransValidSROLaborExt = new SSSFSSROTransValidSROLaborFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSSROTransValidSROLaborExt.SSSFSSROTransValidSROLaborSp(Table,
				Level,
				SRONum,
				SROLine,
				SROOper,
				TransDate,
				PostDate,
				PartnerID,
				PartnerReimbLabor,
				Dept,
				Whse,
				BillCode,
				WorkCode,
				WorkCodeDesc,
				UnitCost,
				UnitRate,
				TaxCode1,
				TaxCode2,
				VatLabel,
				PriceCurrCode,
				Prompt,
				PromptButtons,
				Disc,
				Infobar,
				CurAmtFormat,
				CurCstPrcFormat,
				Type,
				ReimbTaxCode1,
				ReimbTaxCode2,
				ReimbMethod);
				
				int Severity = result.ReturnCode.Value;
				SROLine = result.SROLine;
				SROOper = result.SROOper;
				TransDate = result.TransDate;
				PostDate = result.PostDate;
				PartnerID = result.PartnerID;
				PartnerReimbLabor = result.PartnerReimbLabor;
				Dept = result.Dept;
				Whse = result.Whse;
				BillCode = result.BillCode;
				WorkCode = result.WorkCode;
				WorkCodeDesc = result.WorkCodeDesc;
				UnitCost = result.UnitCost;
				UnitRate = result.UnitRate;
				TaxCode1 = result.TaxCode1;
				TaxCode2 = result.TaxCode2;
				VatLabel = result.VatLabel;
				PriceCurrCode = result.PriceCurrCode;
				Prompt = result.Prompt;
				PromptButtons = result.PromptButtons;
				Disc = result.Disc;
				Infobar = result.Infobar;
				CurAmtFormat = result.CurAmtFormat;
				CurCstPrcFormat = result.CurCstPrcFormat;
				ReimbTaxCode1 = result.ReimbTaxCode1;
				ReimbTaxCode2 = result.ReimbTaxCode2;
				ReimbMethod = result.ReimbMethod;
				return Severity;
			}
		}
    }
}
