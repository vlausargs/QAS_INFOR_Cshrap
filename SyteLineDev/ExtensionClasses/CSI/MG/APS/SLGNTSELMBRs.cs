//PROJECT NAME: APSExt
//CLASS NAME: SLGNTSELMBRs.cs

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
	[IDOExtensionClass("SLGNTSELMBRs")]
	public class SLGNTSELMBRs : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GntSelMbrsUpdSp(Guid? Rowp,
		string Selid,
		int? Seqnum,
		string Resid,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGntSelMbrsUpdExt = new GntSelMbrsUpdFactory().Create(appDb);
				
				var result = iGntSelMbrsUpdExt.GntSelMbrsUpdSp(Rowp,
				Selid,
				Seqnum,
				Resid,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
