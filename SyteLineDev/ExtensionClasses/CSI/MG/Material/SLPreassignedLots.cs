//PROJECT NAME: MaterialExt
//CLASS NAME: SLPreassignedLots.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Material;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Material
{
    [IDOExtensionClass("SLPreassignedLots")]
    public class SLPreassignedLots : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PreassignWarningCheckSp(string RefType,
		                                   string RefNum,
		                                   short? RefLineSuf,
		                                   short? RefRelease,
		                                   byte? CheckForLot,
		                                   ref byte? PreassignExists)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPreassignWarningCheckExt = new PreassignWarningCheckFactory().Create(appDb);
				
				var result = iPreassignWarningCheckExt.PreassignWarningCheckSp(RefType,
				                                                               RefNum,
				                                                               RefLineSuf,
				                                                               RefRelease,
				                                                               CheckForLot,
				                                                               PreassignExists);
				
				int Severity = result.ReturnCode.Value;
				PreassignExists = result.PreassignExists;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int UpdatePreassignedLotSp(int? Select,
		string Lot,
		string sQtyRec,
		string RefType,
		string RefNum,
		int? RefLineSuf,
		int? RefRelease,
		string Item,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iUpdatePreassignedLotExt = new UpdatePreassignedLotFactory().Create(appDb);
				
				var result = iUpdatePreassignedLotExt.UpdatePreassignedLotSp(Select,
				Lot,
				sQtyRec,
				RefType,
				RefNum,
				RefLineSuf,
				RefRelease,
				Item,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
