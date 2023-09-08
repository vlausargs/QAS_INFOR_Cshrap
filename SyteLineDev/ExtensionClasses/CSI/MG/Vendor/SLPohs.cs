//PROJECT NAME: VendorExt
//CLASS NAME: SLPohs.cs

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
	[IDOExtensionClass("SLPohs")]
	public class SLPohs : ExtensionClassBase
	{



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

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PoDelSp(string StartingPONum,
		                   string EndingPONum,
		                   DateTime? StartingPODate,
		                   DateTime? EndingPODate,
		                   string StartingVendNum,
		                   string EndingVendNum,
		                   int? DeleteHistPOReqs,
		                   ref int? POsDeleted,
		                   ref string Infobar,
		                   [Optional] short? StartOrderDateOffset,
		                   [Optional] short? EndOrderDateOffset)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPoDelExt = new PoDelFactory().Create(appDb);
				
				var result = iPoDelExt.PoDelSp(StartingPONum,
				                               EndingPONum,
				                               StartingPODate,
				                               EndingPODate,
				                               StartingVendNum,
				                               EndingVendNum,
				                               DeleteHistPOReqs,
				                               POsDeleted,
				                               Infobar,
				                               StartOrderDateOffset,
				                               EndOrderDateOffset);
				
				int Severity = result.ReturnCode.Value;
				POsDeleted = result.POsDeleted;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable PoandPohSp()
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPoandPohExt = new PoandPohFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPoandPohExt.PoandPohSp();
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
