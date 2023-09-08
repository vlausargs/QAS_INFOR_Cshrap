//PROJECT NAME: RSQCSExt
//CLASS NAME: RS_QCPhaseds.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.Quality;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.RSQCS
{
	[IDOExtensionClass("RS_QCPhaseds")]
	public class RS_QCPhaseds : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_CanClosePhaseSp(string flow_num,
		int? i_seq,
		ref string can_close)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_CanClosePhaseExt = new RSQC_CanClosePhaseFactory().Create(appDb);
				
				var result = iRSQC_CanClosePhaseExt.RSQC_CanClosePhaseSp(flow_num,
				i_seq,
				can_close);
				
				int Severity = result.ReturnCode.Value;
				can_close = result.can_close;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_GetUser3Sp(ref string o_user,
			ref string Infobar)
		{
			var iRSQC_GetUser3Ext = new RSQC_GetUser3Factory().Create(this, true);
			
			var result = iRSQC_GetUser3Ext.RSQC_GetUser3Sp(o_user,
				Infobar);
			
			o_user = result.o_user;
			Infobar = result.Infobar;
			
			return result.ReturnCode??0;
		}

	}
}
