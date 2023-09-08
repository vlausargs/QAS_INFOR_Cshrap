//PROJECT NAME: PmfExt
//CLASS NAME: PmfUMClassBase.cs

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
	[IDOExtensionClass("PmfUMClassBase")]
	public class PmfUMClassBase : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmfRefreshItemUm([Optional] string Item,
		                            [Optional] string UMClass,
		                            [Optional] ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPmfRefreshItemUmExt = new PmfRefreshItemUmFactory().Create(appDb);
				
				var result = iPmfRefreshItemUmExt.PmfRefreshItemUmSp(Item,
				                                                     UMClass,
				                                                     Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
