//PROJECT NAME: PmfExt
//CLASS NAME: PmfTmpPnBatchMatlsBase.cs

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
	[IDOExtensionClass("PmfTmpPnBatchMatlsBase")]
	public class PmfTmpPnBatchMatlsBase : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmfPopulatePnReqWrk([Optional] ref string InfoBar,
		                               [Optional] Guid? PnRp,
		                               [Optional] Guid? JobRp,
		                               [Optional, DefaultParameterValue(0)] int? BackflushBomReq,
		                               [Optional] Guid? SessionId,
		                               [Optional, DefaultParameterValue(0)] int? PopulateCompleteJobs)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPmfPopulatePnReqWrkExt = new PmfPopulatePnReqWrkFactory().Create(appDb);
				
				var result = iPmfPopulatePnReqWrkExt.PmfPopulatePnReqWrkSp(InfoBar,
				                                                           PnRp,
				                                                           JobRp,
				                                                           BackflushBomReq,
				                                                           SessionId,
				                                                           PopulateCompleteJobs);
				
				int Severity = result.ReturnCode.Value;
				InfoBar = result.InfoBar;
				return Severity;
			}
		}
	}
}
