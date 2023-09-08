//PROJECT NAME: VendorExt
//CLASS NAME: SLGrnHdrs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Vendor;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Vendor
{
	[IDOExtensionClass("SLGrnHdrs")]
	public class SLGrnHdrs : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetGRNInfoSp(string VendNum,
		                        string GrnNum,
		                        ref string GrnStat,
		                        ref DateTime? GrnHdrDate,
		                        ref DateTime? GrnShippedDate,
		                        ref string VendName,
		                        ref string Whse,
		                        ref string WhseName,
		                        ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetGRNInfoExt = new GetGRNInfoFactory().Create(appDb);
				
				int Severity = iGetGRNInfoExt.GetGRNInfoSp(VendNum,
				                                           GrnNum,
				                                           ref GrnStat,
				                                           ref GrnHdrDate,
				                                           ref GrnShippedDate,
				                                           ref VendName,
				                                           ref Whse,
				                                           ref WhseName,
				                                           ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GrnallocSp(string CurGrnNum,
		                      string CurVendNum,
		                      ref int? ProcessLevel,
		                      ref string PromptMsg,
		                      ref string Buttons,
		                      ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGrnallocExt = new GrnallocFactory().Create(appDb);
				
				int Severity = iGrnallocExt.GrnallocSp(CurGrnNum,
				                                       CurVendNum,
				                                       ref ProcessLevel,
				                                       ref PromptMsg,
				                                       ref Buttons,
				                                       ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GrnDelUtilSp(string GrnStat,
		                        string StartGrnNum,
		                        string EndGrnNum,
		                        string StartVendNum,
		                        string EndVendNum,
		                        ref int? GrnsDeleted,
		                        ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGrnDelUtilExt = new GrnDelUtilFactory().Create(appDb);
				
				int Severity = iGrnDelUtilExt.GrnDelUtilSp(GrnStat,
				                                           StartGrnNum,
				                                           EndGrnNum,
				                                           StartVendNum,
				                                           EndVendNum,
				                                           ref GrnsDeleted,
				                                           ref Infobar);
				
				return Severity;
			}
		}



		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_LCDomCurrSp(string CurrCode1,
		                                 [Optional, DefaultParameterValue((byte)0)] byte? UseBuyRate,
		[Optional] decimal? TRate1,
		[Optional] DateTime? PossibleDate,
		[Optional] decimal? V1Amount1,
		[Optional] decimal? V1Amount2,
		[Optional] decimal? V1Amount3,
		[Optional] decimal? V1Amount4,
		[Optional] decimal? V1Amount5,
		string CurrCode2,
		[Optional] decimal? TRate2,
		[Optional] decimal? V2Amount1,
		[Optional] decimal? V2Amount2,
		[Optional] decimal? V2Amount3,
		[Optional] decimal? V2Amount4,
		[Optional] decimal? V2Amount5,
		string CurrCode3,
		[Optional] decimal? TRate3,
		[Optional] decimal? V3Amount1,
		[Optional] decimal? V3Amount2,
		[Optional] decimal? V3Amount3,
		[Optional] decimal? V3Amount4,
		[Optional] decimal? V3Amount5,
		string CurrCode4,
		[Optional] decimal? TRate4,
		[Optional] decimal? V4Amount1,
		[Optional] decimal? V4Amount2,
		[Optional] decimal? V4Amount3,
		[Optional] decimal? V4Amount4,
		[Optional] decimal? V4Amount5,
		[Optional] decimal? V4Amount6,
		[Optional] decimal? V4Amount7,
		[Optional] decimal? V4Amount8,
		[Optional] decimal? V4Amount9,
		[Optional] decimal? V4Amount10,
		[Optional] decimal? V4Amount11,
		string CurrCode5,
		[Optional] decimal? TRate5,
		[Optional] decimal? V5Amount1,
		[Optional] decimal? V5Amount2,
		[Optional] decimal? V5Amount3,
		[Optional] decimal? V5Amount4,
		[Optional] decimal? V5Amount5,
		string CurrCode6,
		[Optional] decimal? TRate6,
		[Optional] decimal? V6Amount1,
		[Optional] decimal? V6Amount2,
		[Optional] decimal? V6Amount3,
		[Optional] decimal? V6Amount4,
		[Optional] decimal? V6Amount5,
		[Optional] string PoNum,
		[Optional] string GrnNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_LCDomCurrExt = new CLM_LCDomCurrFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_LCDomCurrExt.CLM_LCDomCurrSp(CurrCode1,
				                                               UseBuyRate,
				                                               TRate1,
				                                               PossibleDate,
				                                               V1Amount1,
				                                               V1Amount2,
				                                               V1Amount3,
				                                               V1Amount4,
				                                               V1Amount5,
				                                               CurrCode2,
				                                               TRate2,
				                                               V2Amount1,
				                                               V2Amount2,
				                                               V2Amount3,
				                                               V2Amount4,
				                                               V2Amount5,
				                                               CurrCode3,
				                                               TRate3,
				                                               V3Amount1,
				                                               V3Amount2,
				                                               V3Amount3,
				                                               V3Amount4,
				                                               V3Amount5,
				                                               CurrCode4,
				                                               TRate4,
				                                               V4Amount1,
				                                               V4Amount2,
				                                               V4Amount3,
				                                               V4Amount4,
				                                               V4Amount5,
				                                               V4Amount6,
				                                               V4Amount7,
				                                               V4Amount8,
				                                               V4Amount9,
				                                               V4Amount10,
				                                               V4Amount11,
				                                               CurrCode5,
				                                               TRate5,
				                                               V5Amount1,
				                                               V5Amount2,
				                                               V5Amount3,
				                                               V5Amount4,
				                                               V5Amount5,
				                                               CurrCode6,
				                                               TRate6,
				                                               V6Amount1,
				                                               V6Amount2,
				                                               V6Amount3,
				                                               V6Amount4,
				                                               V6Amount5,
				                                               PoNum,
				                                               GrnNum);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_GrnChgStatSp(string OldGrnStat,
		                                  string NewGrnStat,
		                                  string StartVendNum,
		                                  string EndVendNum,
		                                  string StartGrnNum,
		                                  string EndGrnNum,
		                                  byte? PProcess,
		                                  ref int? GrnsChanged,
		                                  ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iGrnChgStatExt = new GrnChgStatFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iGrnChgStatExt.GrnChgStatSp(OldGrnStat,
				                                         NewGrnStat,
				                                         StartVendNum,
				                                         EndVendNum,
				                                         StartGrnNum,
				                                         EndGrnNum,
				                                         PProcess,
				                                         GrnsChanged,
				                                         Infobar);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				GrnsChanged = result.GrnsChanged;
				Infobar = result.Infobar;
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int VerifyPoRcptForGRNExistsSp(string GrnNum,
		string VendNum,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iVerifyPoRcptForGRNExistsExt = new VerifyPoRcptForGRNExistsFactory().Create(appDb);
				
				var result = iVerifyPoRcptForGRNExistsExt.VerifyPoRcptForGRNExistsSp(GrnNum,
				VendNum,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
