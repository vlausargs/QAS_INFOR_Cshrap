//PROJECT NAME: PmfExt
//CLASS NAME: PmfRecallDetsBase.cs

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
	[IDOExtensionClass("PmfRecallDetsBase")]
	public class PmfRecallDetsBase : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmfGetLotRp(string item,
		                       string lot,
		                       ref Guid? rp)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPmfGetLotRpExt = new PmfGetLotRpFactory().Create(appDb);
				
				var result = iPmfGetLotRpExt.PmfGetLotRpSp(item,
				                                           lot,
				                                           rp);
				
				int Severity = result.ReturnCode.Value;
				rp = result.rp;
				return Severity;
			}
		}
	}
}
