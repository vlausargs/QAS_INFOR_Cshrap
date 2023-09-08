//PROJECT NAME: FSPlusCallCenterExt
//CLASS NAME: FSIncEscals.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.FieldService.CallCenter;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.FSPlusCallCenter
{
	[IDOExtensionClass("FSIncEscals")]
	public class FSIncEscals : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSIncEscalUtilSp(ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSIncEscalUtilExt = new SSSFSIncEscalUtilFactory().Create(appDb);
				
				int Severity = iSSSFSIncEscalUtilExt.SSSFSIncEscalUtilSp(ref Infobar);
				
				return Severity;
			}
		}
	}
}
