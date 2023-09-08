//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBShipmentScheduleViews.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.BusInterface;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.BusInterface
{
	[IDOExtensionClass("ESBShipmentScheduleViews")]
	public class ESBShipmentScheduleViews : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBCoitemPostSaveSp(ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadESBCoitemPostSaveExt = new LoadESBCoitemPostSaveFactory().Create(appDb);
				
				int Severity = iLoadESBCoitemPostSaveExt.LoadESBCoitemPostSaveSp(ref Infobar);
				
				return Severity;
			}
		}
	}
}
