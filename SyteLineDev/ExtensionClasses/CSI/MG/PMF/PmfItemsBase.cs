//PROJECT NAME: PmfExt
//CLASS NAME: PmfItemsBase.cs

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
	[IDOExtensionClass("PmfItemsBase")]
	public class PmfItemsBase : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmfRefreshCnv([Optional] ref string InfoBar,
		                         [Optional] string Item,
		                         [Optional] string Um,
		                         [Optional, DefaultParameterValue(0)] int? RecalcFlagOnly)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPmfRefreshCnvExt = new PmfRefreshCnvFactory().Create(appDb);
				
				var result = iPmfRefreshCnvExt.PmfRefreshCnvSp(InfoBar,
				                                               Item,
				                                               Um,
				                                               RecalcFlagOnly);
				
				int Severity = result.ReturnCode.Value;
				InfoBar = result.InfoBar;
				return Severity;
			}
		}

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
