//PROJECT NAME: RSQCSExt
//CLASS NAME: RS_QCRcvrs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.Quality;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.IDOExtensions.Production.QualityExt
{
    [IDOExtensionClass("RS_QCRcvrs")]
    public class RS_QCRcvrs : CSIExtensionClassBase
    {

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_RcvrUpdateSp([Optional] int? RcvrNum,
		[Optional] decimal? Qty,
		[Optional] int? Complete,
		ref string Infobar)
		{
			var iRSQC_RcvrUpdateExt = new RSQC_RcvrUpdateFactory().Create(this, true);
			
			var result = iRSQC_RcvrUpdateExt.RSQC_RcvrUpdateSp(RcvrNum,
			Qty,
			Complete,
			Infobar);
			
			int Severity = result.ReturnCode.Value;
			Infobar = result.Infobar;
			return Severity;
		}

    }
}
