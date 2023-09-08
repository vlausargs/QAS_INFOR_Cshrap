//PROJECT NAME: PmfExt
//CLASS NAME: PmfRecallsBase.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.ProcessManufacturing;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.PMF
{
	[IDOExtensionClass("PmfRecallsBase")]
	public class PmfRecallsBase : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmfRecallGenSp([Optional] ref string InfoBar,
		                          Guid? RecallRp,
		                          [Optional, DefaultParameterValue(10)] int? MaxLevels)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPmfRecallGenExt = new PmfRecallGenFactory().Create(appDb);
				
				var result = iPmfRecallGenExt.PmfRecallGenSp(InfoBar,
				                                             RecallRp,
				                                             MaxLevels);
				
				int Severity = result.ReturnCode.Value;
				InfoBar = result.InfoBar;
				return Severity;
			}
		}
	}
}
