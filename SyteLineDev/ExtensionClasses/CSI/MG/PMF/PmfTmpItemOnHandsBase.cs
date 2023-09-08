//PROJECT NAME: PmfExt
//CLASS NAME: PmfTmpItemOnHandsBase.cs

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
	[IDOExtensionClass("PmfTmpItemOnHandsBase")]
	public class PmfTmpItemOnHandsBase : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmfPopulateOhWrk([Optional] ref string InfoBar,
		                            [Optional, DefaultParameterValue(100)] int? RowLimit,
		                            [Optional] string Item,
		                            [Optional] string Whse,
		                            [Optional] string Function,
		                            [Optional, DefaultParameterValue(0)] int? ExpiredFlag,
		                            [Optional, DefaultParameterValue(0)] int? LockedForPickFlag,
		                            [Optional, DefaultParameterValue(1)] int? ExcludeOtherPnInv,
		                            [Optional] Guid? PnRp,
		                            [Optional] Guid? JobRp,
		                            [Optional, DefaultParameterValue(0)] int? AddNegInv,
		                            [Optional] decimal? QtyReq,
		                            [Optional] string QtyUm,
		                            [Optional] string Ref,
		                            [Optional] Guid? SessionId)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPmfPopulateOhWrkExt = new PmfPopulateOhWrkFactory().Create(appDb);
				
				var result = iPmfPopulateOhWrkExt.PmfPopulateOhWrkSp(InfoBar,
				                                                     RowLimit,
				                                                     Item,
				                                                     Whse,
				                                                     Function,
				                                                     ExpiredFlag,
				                                                     LockedForPickFlag,
				                                                     ExcludeOtherPnInv,
				                                                     PnRp,
				                                                     JobRp,
				                                                     AddNegInv,
				                                                     QtyReq,
				                                                     QtyUm,
				                                                     Ref,
				                                                     SessionId);
				
				int Severity = result.ReturnCode.Value;
				InfoBar = result.InfoBar;
				return Severity;
			}
		}
	}
}
