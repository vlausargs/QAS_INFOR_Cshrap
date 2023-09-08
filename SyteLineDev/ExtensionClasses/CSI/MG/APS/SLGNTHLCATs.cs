//PROJECT NAME: APSExt
//CLASS NAME: SLGNTHLCATs.cs

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
	[IDOExtensionClass("SLGNTHLCATs")]
	public class SLGNTHLCATs : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ApsGntDeleteHighlightSp(string PUsername,
		string PHighlight,
		int? PCritOnly)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iApsGntDeleteHighlightExt = new ApsGntDeleteHighlightFactory().Create(appDb);
				
				var result = iApsGntDeleteHighlightExt.ApsGntDeleteHighlightSp(PUsername,
				PHighlight,
				PCritOnly);
				
				int Severity = result.Value;
				return Severity;
			}
		}
	}
}
