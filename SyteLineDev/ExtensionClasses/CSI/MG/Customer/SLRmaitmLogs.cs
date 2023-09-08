//PROJECT NAME: CustomerExt
//CLASS NAME: SLRmaitmLogs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.Customer
{
	[IDOExtensionClass("SLRmaitmLogs")]
	public class SLRmaitmLogs : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ILogDelSp(DateTime? StartingDate,
		                     DateTime? EndingDate,
		                     string StartingRma,
		                     string EndingRma,
		                     short? StartingLine,
		                     short? EndingLine,
		                     [Optional, DefaultParameterValue((byte)0)] byte? CreateInitRmaLog,
		ref string Infobar,
		[Optional] short? StartingActivityDateOffset,
		[Optional] short? EndingActivityDateOffset)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iILogDelExt = new ILogDelFactory().Create(appDb);
				
				var result = iILogDelExt.ILogDelSp(StartingDate,
				                                   EndingDate,
				                                   StartingRma,
				                                   EndingRma,
				                                   StartingLine,
				                                   EndingLine,
				                                   CreateInitRmaLog,
				                                   Infobar,
				                                   StartingActivityDateOffset,
				                                   EndingActivityDateOffset);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
