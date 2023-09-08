//PROJECT NAME: VendorExt
//CLASS NAME: SLPoitemLogs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Vendor;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.Vendor
{
	[IDOExtensionClass("SLPoitemLogs")]
	public class SLPoitemLogs : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DeletePOLineItemLogEntriesSp([Optional] DateTime? SActivityDate,
        [Optional] DateTime? EActivityDate,
		[Optional, DefaultParameterValue(null)] string SPoNum,
		[Optional, DefaultParameterValue(null)] string EPoNum,
        [Optional] short? SPoLine,
        [Optional] short? EPoLine,
        [Optional] short? SPoRelease,
		[Optional] short? EPoRelease,
		[Optional, DefaultParameterValue((short)0)] short? CreateInitial,
		[Optional, DefaultParameterValue(null)] ref string Infobar,
		[Optional] short? StartingActivityDateOffset,
		[Optional] short? EndingActivityDateOffset)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iDeletePOLineItemLogEntriesExt = new DeletePOLineItemLogEntriesFactory().Create(appDb);
				
				var result = iDeletePOLineItemLogEntriesExt.DeletePOLineItemLogEntriesSp(SActivityDate,
				                                                                         EActivityDate,
				                                                                         SPoNum,
				                                                                         EPoNum,
				                                                                         SPoLine,
				                                                                         EPoLine,
				                                                                         SPoRelease,
				                                                                         EPoRelease,
				                                                                         CreateInitial,
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
