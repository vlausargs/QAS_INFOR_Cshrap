//PROJECT NAME: AdminExt
//CLASS NAME: SLLockableFunctions.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Admin;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Admin
{
    [IDOExtensionClass("SLLockableFunctions")]
    public class SLLockableFunctions : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SLServerRestartSp([Optional, DefaultParameterValue((byte)1)] byte? pServerRestart,
		[Optional, DefaultParameterValue((byte)1)] byte? pClearSessionInformation,
		[Optional, DefaultParameterValue((byte)1)] byte? pUnlockFunctions,
		[Optional, DefaultParameterValue((byte)1)] byte? pUnlockJournals)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSLServerRestartExt = new SLServerRestartFactory().Create(appDb);
				
				var result = iSLServerRestartExt.SLServerRestartSp(pServerRestart,
				                                                   pClearSessionInformation,
				                                                   pUnlockFunctions,
				                                                   pUnlockJournals);
				
				
				return result.Value;
			}
		}
    }
}