//PROJECT NAME: CustomerExt
//CLASS NAME: SLShipItems.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Customer
{
	[IDOExtensionClass("SLShipItems")]
	public class SLShipItems : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int UpdateShipItemSp(string CoNum,
		int? CoLine,
		int? CoRelease,
		int? Active,
		ref string Infobar,
		int? BatchId,
		int? DoLine)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iUpdateShipItemExt = new UpdateShipItemFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iUpdateShipItemExt.UpdateShipItemSp(CoNum,
				CoLine,
				CoRelease,
				Active,
				Infobar,
				BatchId,
				DoLine);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
