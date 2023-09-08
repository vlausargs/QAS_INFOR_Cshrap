//PROJECT NAME: RSQCSExt
//CLASS NAME: RS_QCMrrDisps.cs

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
    [IDOExtensionClass("RS_QCMrrDisps")]
    public class RS_QCMrrDisps : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_CreateMrrDispositionEsigSp(Guid? RcvrRowpointer,
		string UserName,
		string ReasonCode,
		Guid? EsigRowpointer,
		string RefType,
		string InspNum,
		decimal? Qty_Accepted,
		string AcceptReason,
		string AcceptDisp,
		decimal? Qty_Rejected,
		string RejectReason,
		string RejectDisp,
		string RejectCause)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_CreateMrrDispositionEsigExt = new RSQC_CreateMrrDispositionEsigFactory().Create(appDb);
				
				var result = iRSQC_CreateMrrDispositionEsigExt.RSQC_CreateMrrDispositionEsigSp(RcvrRowpointer,
				UserName,
				ReasonCode,
				EsigRowpointer,
				RefType,
				InspNum,
				Qty_Accepted,
				AcceptReason,
				AcceptDisp,
				Qty_Rejected,
				RejectReason,
				RejectDisp,
				RejectCause);
				
				int Severity = result.Value;
				return Severity;
			}
		}
    }
}
