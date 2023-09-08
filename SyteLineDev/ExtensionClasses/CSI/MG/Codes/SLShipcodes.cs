//PROJECT NAME: CodesExt
//CLASS NAME: SLShipcodes.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Codes;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.Codes
{
	[IDOExtensionClass("SLShipcodes")]
	public class SLShipcodes : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CARaSShipViaExtractionSp(string StartShipCode,
		                                          string EndShipCode)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCARaSShipViaExtractionExt = new CARaSShipViaExtractionFactory().Create(appDb, bunchedLoadCollection);
				
				DataTable dt = iCARaSShipViaExtractionExt.CARaSShipViaExtractionSp(StartShipCode,
				                                                                   EndShipCode);
				
				return dt;
			}
		}
	}
}
