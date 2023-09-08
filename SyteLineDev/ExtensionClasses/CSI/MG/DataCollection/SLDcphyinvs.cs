//PROJECT NAME: DataCollectionExt
//CLASS NAME: SLDcphyinvs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.DataCollection;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.DataCollection
{
	[IDOExtensionClass("SLDcphyinvs")]
	public class SLDcphyinvs : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DcAPhysinSerialSp(Guid? PPhyinvRowPointer,
		string PSerNum,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iDcAPhysinSerialExt = new DcAPhysinSerialFactory().Create(appDb);
				
				var result = iDcAPhysinSerialExt.DcAPhysinSerialSp(PPhyinvRowPointer,
				PSerNum,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DcAPhysinSp(string TTermId,
		string TEmpNum,
		DateTime? TTransDate,
		string TItem,
		string TCurWhse,
		string TLocation,
		string TLot,
		decimal? TQty,
		int? PTagNum,
		int? PSheetNum,
		string PEmpCount,
		string PEmpCheck,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iDcAPhysinExt = new DcAPhysinFactory().Create(appDb);
				
				var result = iDcAPhysinExt.DcAPhysinSp(TTermId,
				TEmpNum,
				TTransDate,
				TItem,
				TCurWhse,
				TLocation,
				TLot,
				TQty,
				PTagNum,
				PSheetNum,
				PEmpCount,
				PEmpCheck,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
