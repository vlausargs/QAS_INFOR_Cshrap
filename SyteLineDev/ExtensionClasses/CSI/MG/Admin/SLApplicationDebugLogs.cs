//PROJECT NAME: AdminExt
//CLASS NAME: SLApplicationDebugLogs.cs

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
	[IDOExtensionClass("SLApplicationDebugLogs")]
	public class SLApplicationDebugLogs : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ApplicationDebugLogSp([Optional, DefaultParameterValue("")] string SourceType,
		[Optional, DefaultParameterValue("")] string SourceName,
		[Optional, DefaultParameterValue("")] string MessageName,
		[Optional, DefaultParameterValue("")] string MessageDetail,
		[Optional, DefaultParameterValue(0)] int? ProcID,
		[Optional, DefaultParameterValue(0)] int? PurgeData,
		[Optional, DefaultParameterValue("")] ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iApplicationDebugLogExt = new ApplicationDebugLogFactory().Create(appDb);
				
				var result = iApplicationDebugLogExt.ApplicationDebugLogSp(SourceType,
				SourceName,
				MessageName,
				MessageDetail,
				ProcID,
				PurgeData,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
