//PROJECT NAME: MaterialExt
//CLASS NAME: SLItemPortalPrices.cs

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
	[IDOExtensionClass("SLItemPortalPrices")]
	public class SLItemPortalPrices : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ItemPortalPriceSp(string StartingItem,
		string EndingItem,
		[Optional] ref string Infobar,
		[Optional] int? BGTaskID)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iItemPortalPriceExt = new ItemPortalPriceFactory().Create(appDb);
				
				var result = iItemPortalPriceExt.ItemPortalPriceSp(StartingItem,
				EndingItem,
				Infobar,
				BGTaskID);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
