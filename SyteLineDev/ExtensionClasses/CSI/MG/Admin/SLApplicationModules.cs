//PROJECT NAME: AdminExt
//CLASS NAME: SLApplicationModules.cs

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
	[IDOExtensionClass("SLApplicationModules")]
	public class SLApplicationModules : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ApsResyncAllSp([Optional] int? TaskNumber)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iApsResyncAllExt = new ApsResyncAllFactory().Create(appDb);
				
				var result = iApsResyncAllExt.ApsResyncAllSp(TaskNumber);
				
				int Severity = result.Value;
				return Severity;
			}
		}
	}
}
