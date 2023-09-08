//PROJECT NAME: VendorExt
//CLASS NAME: SLPochanges.cs

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
	[IDOExtensionClass("SLPochanges")]
	public class SLPochanges : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetPoChangeInfoSp(string PoNum,
		ref int? ChgNum,
		ref DateTime? ChgDate,
		ref string Stat,
		ref decimal? UserId)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetPoChangeInfoExt = new GetPoChangeInfoFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetPoChangeInfoExt.GetPoChangeInfoSp(PoNum,
				ChgNum,
				ChgDate,
				Stat,
				UserId);
				
				int Severity = result.ReturnCode.Value;
				ChgNum = result.ChgNum;
				ChgDate = result.ChgDate;
				Stat = result.Stat;
				UserId = result.UserId;
				return Severity;
			}
		}
	}
}
