//PROJECT NAME: FSPlusSROExt
//CLASS NAME: FSSROOpers.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.FieldService.Requests;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.FSPlusSRO
{
    [IDOExtensionClass("FSSROOpers")]
    public class FSSROOpers : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSFSSROOperCalcDurationSp(string SRONum,
                                              int? SROLine,
                                              int? SROOper,
                                              ref decimal? Duration,
                                              ref string DurationUnits,
                                              ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSFSSROOperCalcDurationExt = new SSSFSSROOperCalcDurationFactory().Create(appDb);

                FixedHoursType oDuration = Duration;
                FSDurationTypeType oDurationUnits = DurationUnits;
                Infobar oInfobar = Infobar;

                int Severity = iSSSFSSROOperCalcDurationExt.SSSFSSROOperCalcDurationSp(SRONum,
                                                                                       SROLine,
                                                                                       SROOper,
                                                                                       ref oDuration,
                                                                                       ref oDurationUnits,
                                                                                       ref oInfobar);

                Duration = oDuration;
                DurationUnits = oDurationUnits;
                Infobar = oInfobar;


                return Severity;
            }
        }
        



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSROOperDefaultsSp(string SRONum,
		                                  int? SROLine,
		                                  ref string ProductCode,
		                                  ref string Whse,
		                                  ref string BillCode,
		                                  ref string BillType,
		                                  ref string Stat,
		                                  ref string CGSLabor,
		                                  ref string CGSMatl,
		                                  ref string CGSMisc,
		                                  ref byte? AccumWIP,
		                                  ref byte? PlanTransReq,
		                                  ref byte? UsePlanPricing,
		                                  ref string PartnerId,
		                                  ref string Pricecode,
		                                  ref byte? ExtendMatl,
		                                  ref byte? ExtendLbr,
		                                  ref byte? ExtendMisc,
		                                  ref string TaxCode1,
		                                  ref string TaxCode2,
		                                  ref string Dept,
		                                  ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSSROOperDefaultsExt = new SSSFSSROOperDefaultsFactory().Create(appDb);
				
				int Severity = iSSSFSSROOperDefaultsExt.SSSFSSROOperDefaultsSp(SRONum,
				                                                               SROLine,
				                                                               ref ProductCode,
				                                                               ref Whse,
				                                                               ref BillCode,
				                                                               ref BillType,
				                                                               ref Stat,
				                                                               ref CGSLabor,
				                                                               ref CGSMatl,
				                                                               ref CGSMisc,
				                                                               ref AccumWIP,
				                                                               ref PlanTransReq,
				                                                               ref UsePlanPricing,
				                                                               ref PartnerId,
				                                                               ref Pricecode,
				                                                               ref ExtendMatl,
				                                                               ref ExtendLbr,
				                                                               ref ExtendMisc,
				                                                               ref TaxCode1,
				                                                               ref TaxCode2,
				                                                               ref Dept,
				                                                               ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSroClose([Optional, DefaultParameterValue(null)] string SRONum,
		[Optional] int? SROLine,
		[Optional] int? SROOper,
		[Optional, DefaultParameterValue((byte)0)] byte? BillComplete,
		[Optional, DefaultParameterValue((byte)0)] byte? LinesShipped,
		[Optional, DefaultParameterValue((byte)0)] byte? MatlShipped,
		ref string Status,
		ref string infoBar,
		[Optional, DefaultParameterValue((byte)0)] byte? PlannedTransPosted,
		[Optional, DefaultParameterValue((byte)0)] byte? StatCodeClose)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSSroCloExt = new SSSFSSroCloFactory().Create(appDb);
				
				var result = iSSSFSSroCloExt.SSSFSSroClose(SRONum,
				                                           SROLine,
				                                           SROOper,
				                                           BillComplete,
				                                           LinesShipped,
				                                           MatlShipped,
				                                           Status,
				                                           infoBar,
				                                           PlannedTransPosted,
				                                           StatCodeClose);
				
				int Severity = result.ReturnCode.Value;
				Status = result.Status;
				infoBar = result.infoBar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSSroCloseLoad([Optional, DefaultParameterValue(null)] string StartSRONum,
		[Optional, DefaultParameterValue(null)] string EndSRONum,
		[Optional, DefaultParameterValue(null)] string StartSROType,
		[Optional, DefaultParameterValue(null)] string EndSROType,
		[Optional, DefaultParameterValue(null)] string StartBillMgr,
		[Optional, DefaultParameterValue(null)] string EndBillMgr,
		[Optional] DateTime? StartDate,
		[Optional] DateTime? EndDate,
		[Optional, DefaultParameterValue((byte)0)] byte? BillComplete,
		[Optional, DefaultParameterValue((byte)0)] byte? LinesShipped,
		[Optional, DefaultParameterValue((byte)0)] byte? MatlShipped,
		[Optional] DateTime? CloseDate,
		[Optional, DefaultParameterValue((byte)0)] byte? ExcludeWip,
		[Optional, DefaultParameterValue(null)] string infoBar,
		[Optional, DefaultParameterValue((byte)0)] byte? PlannedTransPosted,
		[Optional, DefaultParameterValue((byte)0)] byte? StatCodeClose)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iSSSFSSroCloseLoExt = new SSSFSSroCloseLoFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iSSSFSSroCloseLoExt.SSSFSSroCloseLoad(StartSRONum,
				                                                   EndSRONum,
				                                                   StartSROType,
				                                                   EndSROType,
				                                                   StartBillMgr,
				                                                   EndBillMgr,
				                                                   StartDate,
				                                                   EndDate,
				                                                   BillComplete,
				                                                   LinesShipped,
				                                                   MatlShipped,
				                                                   CloseDate,
				                                                   ExcludeWip,
				                                                   infoBar,
				                                                   PlannedTransPosted,
				                                                   StatCodeClose);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSSroCopyUseItem(string iTemplateSroNum,
		                                     int? iTemplateSroLine,
		                                     string iItem,
		                                     byte? ChkShowAllOper,
		                                     string iSerNum,
		                                     string Infobar,
		                                     [Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iSSSFSSroCopyUseItExt = new SSSFSSroCopyUseItFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iSSSFSSroCopyUseItExt.SSSFSSroCopyUseItem(iTemplateSroNum,
				                                                       iTemplateSroLine,
				                                                       iItem,
				                                                       ChkShowAllOper,
				                                                       iSerNum,
				                                                       Infobar,
				                                                       FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSROOperValidSROSp(string SRONum,
		                                  int? Level,
		                                  ref string SRODesc,
		                                  ref string SROCustNum,
		                                  ref int? SROCustSeq,
		                                  ref string SROCustName,
		                                  ref byte? SROAllowPartial,
		                                  ref string SROStat,
		                                  ref int? SROLine,
		                                  ref string LineUnit,
		                                  ref string LineStat,
		                                  ref string LineItem,
		                                  ref decimal? LineQtyConv,
		                                  ref string LineUM,
		                                  ref string ProductCode,
		                                  ref string Whse,
		                                  ref string BillCode,
		                                  ref string BillType,
		                                  ref string Stat,
		                                  ref string CGSLabor,
		                                  ref string CGSMatl,
		                                  ref string CGSMisc,
		                                  ref byte? AccumWIP,
		                                  ref byte? PlanTransReq,
		                                  ref byte? UsePlanPricing,
		                                  ref string PartnerId,
		                                  ref string Pricecode,
		                                  ref byte? ExtendMatl,
		                                  ref byte? ExtendLbr,
		                                  ref byte? ExtendMisc,
		                                  ref string TaxCode1,
		                                  ref string TaxCode2,
		                                  ref string Dept,
		                                  ref string Infobar,
		                                  [Optional] ref string SROBillCustName)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSSROOperValidSROExt = new SSSFSSROOperValidSROFactory().Create(appDb);
				
				var result = iSSSFSSROOperValidSROExt.SSSFSSROOperValidSROSp(SRONum,
				                                                             Level,
				                                                             SRODesc,
				                                                             SROCustNum,
				                                                             SROCustSeq,
				                                                             SROCustName,
				                                                             SROAllowPartial,
				                                                             SROStat,
				                                                             SROLine,
				                                                             LineUnit,
				                                                             LineStat,
				                                                             LineItem,
				                                                             LineQtyConv,
				                                                             LineUM,
				                                                             ProductCode,
				                                                             Whse,
				                                                             BillCode,
				                                                             BillType,
				                                                             Stat,
				                                                             CGSLabor,
				                                                             CGSMatl,
				                                                             CGSMisc,
				                                                             AccumWIP,
				                                                             PlanTransReq,
				                                                             UsePlanPricing,
				                                                             PartnerId,
				                                                             Pricecode,
				                                                             ExtendMatl,
				                                                             ExtendLbr,
				                                                             ExtendMisc,
				                                                             TaxCode1,
				                                                             TaxCode2,
				                                                             Dept,
				                                                             Infobar,
				                                                             SROBillCustName);
				
				int Severity = result.ReturnCode.Value;
				SRODesc = result.SRODesc;
				SROCustNum = result.SROCustNum;
				SROCustSeq = result.SROCustSeq;
				SROCustName = result.SROCustName;
				SROAllowPartial = result.SROAllowPartial;
				SROStat = result.SROStat;
				SROLine = result.SROLine;
				LineUnit = result.LineUnit;
				LineStat = result.LineStat;
				LineItem = result.LineItem;
				LineQtyConv = result.LineQtyConv;
				LineUM = result.LineUM;
				ProductCode = result.ProductCode;
				Whse = result.Whse;
				BillCode = result.BillCode;
				BillType = result.BillType;
				Stat = result.Stat;
				CGSLabor = result.CGSLabor;
				CGSMatl = result.CGSMatl;
				CGSMisc = result.CGSMisc;
				AccumWIP = result.AccumWIP;
				PlanTransReq = result.PlanTransReq;
				UsePlanPricing = result.UsePlanPricing;
				PartnerId = result.PartnerId;
				Pricecode = result.Pricecode;
				ExtendMatl = result.ExtendMatl;
				ExtendLbr = result.ExtendLbr;
				ExtendMisc = result.ExtendMisc;
				TaxCode1 = result.TaxCode1;
				TaxCode2 = result.TaxCode2;
				Dept = result.Dept;
				Infobar = result.Infobar;
				SROBillCustName = result.SROBillCustName;
				return Severity;
			}
		}

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable SSSFSSearchRRLoadSp(int? MaxResults,
        string SearchOperator,
        string SearchString,
        int? SearchKbase,
        int? SearchIncDesc,
        int? SearchIncNotes,
        int? SearchIncReasons,
        int? SearchIncResolutions,
        int? SearchSRODesc,
        int? SearchSRONotes,
        int? SearchSROLines,
        int? SearchSROLineNotes,
        int? SearchSROOperations,
        int? SearchSROOperNotes,
        int? SearchSROReasons,
        int? SearchSROResolutions,
        DateTime? SearchStartDate,
        DateTime? SearchEndDate,
        string SearchSerNumRR,
        [Optional] string FilterString)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iSSSFSSearchRRLoExt = new SSSFSSearchRRLoFactory().Create(appDb, bunchedLoadCollection);

                var result = iSSSFSSearchRRLoExt.SSSFSSearchRRLoad(MaxResults,
                SearchOperator,
                SearchString,
                SearchKbase,
                SearchIncDesc,
                SearchIncNotes,
                SearchIncReasons,
                SearchIncResolutions,
                SearchSRODesc,
                SearchSRONotes,
                SearchSROLines,
                SearchSROLineNotes,
                SearchSROOperations,
                SearchSROOperNotes,
                SearchSROReasons,
                SearchSROResolutions,
                SearchStartDate,
                SearchEndDate,
                SearchSerNumRR,
                FilterString);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSroCopyLinesSp(string iSROCopyLevel,
		string iSROCopyCalledFrom,
		string iSroCopyTransFrom,
		string iSroCopyTransTo,
		string iSroCopyFromKey,
		string iToSroNum,
		string iTemplateSroNum,
		int? iTemplateSroLine,
		string iSelectedOpers,
		DateTime? iDate,
		string iSerNum,
		string iItem,
		string iUM,
		decimal? iQty,
		string iLineDesc,
		string iChkShowAllOper,
		string iLeadPartner,
		string iCompItem,
		decimal? iCompQtyOrd,
		ref int? oSROLine,
		ref int? oSROOper,
		ref string Infobar,
		[Optional, DefaultParameterValue((byte)0)] byte? iKeepOperNums,
		[Optional, DefaultParameterValue((byte)0)] byte? iUseSroWhse,
		[Optional] int? iConfigCompId,
		[Optional] string iFromRefType,
		[Optional] string iFromRefNum,
		[Optional] int? iFromRefLine,
		[Optional] int? iFromRefRelease,
		[Optional, DefaultParameterValue((byte)0)] byte? iKeepLineNums,
		[Optional, DefaultParameterValue((byte)0)] byte? iUseAllOpers,
		[Optional] string iToSite,
		[Optional, DefaultParameterValue(0)] int? iSeq,
		[Optional] DateTime? iStartDate,
		[Optional] string iCustItem,
		[Optional, DefaultParameterValue((byte)0)] byte? iCopyLineTrans)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSSroCopyLinesExt = new SSSFSSroCopyLinesFactory().Create(appDb);
				
				var result = iSSSFSSroCopyLinesExt.SSSFSSroCopyLinesSp(iSROCopyLevel,
				iSROCopyCalledFrom,
				iSroCopyTransFrom,
				iSroCopyTransTo,
				iSroCopyFromKey,
				iToSroNum,
				iTemplateSroNum,
				iTemplateSroLine,
				iSelectedOpers,
				iDate,
				iSerNum,
				iItem,
				iUM,
				iQty,
				iLineDesc,
				iChkShowAllOper,
				iLeadPartner,
				iCompItem,
				iCompQtyOrd,
				oSROLine,
				oSROOper,
				Infobar,
				iKeepOperNums,
				iUseSroWhse,
				iConfigCompId,
				iFromRefType,
				iFromRefNum,
				iFromRefLine,
				iFromRefRelease,
				iKeepLineNums,
				iUseAllOpers,
				iToSite,
				iSeq,
				iStartDate,
				iCustItem,
				iCopyLineTrans);
				
				int Severity = result.ReturnCode.Value;
				oSROLine = result.oSROLine;
				oSROOper = result.oSROOper;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSroCopyOperSp(string iSROCopyLevel,
		string iSROCopyCalledFrom,
		string iSroCopyTransFrom,
		string iSroCopyTransTo,
		string iToSroNum,
		int? iToSroLine,
		string iTemplateSroNum,
		int? iTemplateSroLine,
		string iSelectedOpers,
		DateTime? iDate,
		string iLeadPartner,
		string iCompItem,
		decimal? iCompQtyOrd,
		ref int? oSROOper,
		ref string Infobar,
		[Optional] string iSroCopyFromKey,
		[Optional, DefaultParameterValue((byte)0)] byte? iKeepOperNums,
		[Optional, DefaultParameterValue((byte)0)] byte? iUseSroWhse,
		[Optional] int? iConfigCompId,
		[Optional, DefaultParameterValue((byte)0)] byte? iUseAllOpers,
		[Optional] DateTime? iStartDate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSSroCopyOperExt = new SSSFSSroCopyOperFactory().Create(appDb);
				
				var result = iSSSFSSroCopyOperExt.SSSFSSroCopyOperSp(iSROCopyLevel,
				iSROCopyCalledFrom,
				iSroCopyTransFrom,
				iSroCopyTransTo,
				iToSroNum,
				iToSroLine,
				iTemplateSroNum,
				iTemplateSroLine,
				iSelectedOpers,
				iDate,
				iLeadPartner,
				iCompItem,
				iCompQtyOrd,
				oSROOper,
				Infobar,
				iSroCopyFromKey,
				iKeepOperNums,
				iUseSroWhse,
				iConfigCompId,
				iUseAllOpers,
				iStartDate);
				
				int Severity = result.ReturnCode.Value;
				oSROOper = result.oSROOper;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSroCopyTransSp(string iSroCopyLevel,
		string iSroCopyCalledFrom,
		string iSroCopyTransFrom,
		string iSroCopyTransTo,
		string iToSroNum,
		int? iToSroLine,
		int? iToSroOper,
		string iTemplateSroNum,
		int? iTemplateSroLine,
		int? iTemplateSroOper,
		string iCompItem,
		decimal? iCompQtyOrd,
		ref string Infobar,
		[Optional, DefaultParameterValue((byte)0)] byte? iUseSroWhse,
		[Optional] int? iConfigCompId)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSSroCopyTransExt = new SSSFSSroCopyTransFactory().Create(appDb);
				
				var result = iSSSFSSroCopyTransExt.SSSFSSroCopyTransSp(iSroCopyLevel,
				iSroCopyCalledFrom,
				iSroCopyTransFrom,
				iSroCopyTransTo,
				iToSroNum,
				iToSroLine,
				iToSroOper,
				iTemplateSroNum,
				iTemplateSroLine,
				iTemplateSroOper,
				iCompItem,
				iCompQtyOrd,
				Infobar,
				iUseSroWhse,
				iConfigCompId);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
