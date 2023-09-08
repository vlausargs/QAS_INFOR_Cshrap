//PROJECT NAME: MG
//CLASS NAME: SLTHATransactionNumberPrefixes.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.THLOC;
using CSI.MG;
using CSI.Data.RecordSets;
using System.Runtime.InteropServices;

namespace CSI.MG.THLOC
{
	[IDOExtensionClass("SLTHATransactionNumberPrefixes")]
	public class SLTHATransactionNumberPrefixes : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int THANextTransactionNumberSp(string DocumentType,
		string Prefix,
		DateTime? Date,
		int? KeyLength,
		ref string Key,
		ref string Infobar)
		{
			var iTHANextTransactionNumberExt = new THANextTransactionNumberFactory().Create(this, true);
			
			var result = iTHANextTransactionNumberExt.THANextTransactionNumberSp(DocumentType,
			Prefix,
			Date,
			KeyLength,
			Key,
			Infobar);
			
			int Severity = result.ReturnCode.Value;
			Key = result.Key;
			Infobar = result.Infobar;
			return Severity;
		}
	}
}
