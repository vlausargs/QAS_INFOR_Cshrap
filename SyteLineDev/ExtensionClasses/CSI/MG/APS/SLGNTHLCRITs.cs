//PROJECT NAME: APSExt
//CLASS NAME: SLGNTHLCRITs.cs

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
	[IDOExtensionClass("SLGNTHLCRITs")]
	public class SLGNTHLCRITs : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GntHlCritInsSp(string Highlightid,
		string Username,
		int? Seqnum,
		int? Type,
		int? Comparison,
		string Param,
		int? Color,
		int? CmpSubstr,
		int? CmpStart,
		int? CmpLength,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGntHlCritInsExt = new GntHlCritInsFactory().Create(appDb);
				
				var result = iGntHlCritInsExt.GntHlCritInsSp(Highlightid,
				Username,
				Seqnum,
				Type,
				Comparison,
				Param,
				Color,
				CmpSubstr,
				CmpStart,
				CmpLength,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GntHlCritUpdSp(Guid? Rowp,
		int? Seqnum,
		int? Type,
		int? Comparison,
		string Param,
		int? Color,
		int? CmpSubstr,
		int? CmpStart,
		int? CmpLength,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGntHlCritUpdExt = new GntHlCritUpdFactory().Create(appDb);
				
				var result = iGntHlCritUpdExt.GntHlCritUpdSp(Rowp,
				Seqnum,
				Type,
				Comparison,
				Param,
				Color,
				CmpSubstr,
				CmpStart,
				CmpLength,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
