//PROJECT NAME: APSExt
//CLASS NAME: SLGNTSELCATs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.APS;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.APS
{
	[IDOExtensionClass("SLGNTSELCATs")]
	public class SLGNTSELCATs : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ApsGntDeleteSelectionSp(string PUsername,
		string PSelection,
		int? PMbrsOnly)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iApsGntDeleteSelectionExt = new ApsGntDeleteSelectionFactory().Create(appDb);
				
				var result = iApsGntDeleteSelectionExt.ApsGntDeleteSelectionSp(PUsername,
				PSelection,
				PMbrsOnly);
				
				int Severity = result.Value;
				return Severity;
			}
		}
	}
}
