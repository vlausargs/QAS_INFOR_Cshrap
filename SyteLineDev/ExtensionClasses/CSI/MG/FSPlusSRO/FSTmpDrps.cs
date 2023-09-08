//PROJECT NAME: FSPlusSROExt
//CLASS NAME: FSTmpDrps.cs

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
	[IDOExtensionClass("FSTmpDrps")]
	public class FSTmpDrps : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSDrpProcessSp(ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSDrpProcessExt = new SSSFSDrpProcessFactory().Create(appDb);
				
				int Severity = iSSSFSDrpProcessExt.SSSFSDrpProcessSp(ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSDrpClearSp(ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSDrpClearExt = new SSSFSDrpClearFactory().Create(appDb);
				
				int Severity = iSSSFSDrpClearExt.SSSFSDrpClearSp(ref Infobar);
				
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSFSDrpSetLowLevelSp(string FormCaption,
        int? BgTaskID,
        ref string Infobar,
        [Optional] string BGUser)
        {
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSDrpSetLowLevelExt = new SSSFSDrpSetLowLevelFactory().Create(appDb);
				
				int Severity = iSSSFSDrpSetLowLevelExt.SSSFSDrpSetLowLevelSp(FormCaption,
				                                                             BgTaskID,
				                                                             ref Infobar,
				                                                             BGUser);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSDrpLoadSp(string iWhseStarting,
		string iWhseEnding,
		string iItemStarting,
		string iItemEnding,
		int? iDaysToPlan,
		byte? iInclPurchased,
		byte? iInclTransferred,
		ref string Infobar,
		[Optional] string iBuyer,
		[Optional] string iPlannerCode)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSDrpLoadExt = new SSSFSDrpLoadFactory().Create(appDb);
				
				var result = iSSSFSDrpLoadExt.SSSFSDrpLoadSp(iWhseStarting,
				iWhseEnding,
				iItemStarting,
				iItemEnding,
				iDaysToPlan,
				iInclPurchased,
				iInclTransferred,
				Infobar,
				iBuyer,
				iPlannerCode);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSDrpGenSp(string FormCaption,
		int? BgTaskID,
		ref string Infobar,
		[Optional, DefaultParameterValue(0)] int? kDebugLevel,
		[Optional, DefaultParameterValue(0)] int? kDebugQty,
		[Optional] string StartingItem,
		[Optional] string EndingItem)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSDrpGenExt = new SSSFSDrpGenFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSDrpGenExt.SSSFSDrpGenSp(FormCaption,
				BgTaskID,
				Infobar,
				kDebugLevel,
				kDebugQty,
				StartingItem,
				EndingItem);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
