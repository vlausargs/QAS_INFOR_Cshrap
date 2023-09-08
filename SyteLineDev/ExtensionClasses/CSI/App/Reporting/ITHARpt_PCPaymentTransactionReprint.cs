//PROJECT NAME: Reporting
//CLASS NAME: ITHARpt_PCPaymentTransactionReprint.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ITHARpt_PCPaymentTransactionReprint
	{
		(ICollectionLoadResponse Data, int? ReturnCode) THARpt_PCPaymentTransactionReprintSp(string PSessionID,
		string FormID,
		string PPayCode,
		string PSBankCode,
		string PEBankCode,
		string PSortNameNum,
		int? DisplayHeader = null,
		int? PDistDetail = null,
		string PStartingVendNum = null,
		string PEndingVendNum = null,
		string PStartingVendName = null,
		string PEndingVendName = null,
		DateTime? PPayDateStarting = null,
		DateTime? PPayDateEnding = null,
		int? SCheckNumber = null,
		int? ECheckNumber = null,
		int? PSPayDateOffset = null,
		int? PEPayDateOffset = null,
		int? internalNotes = null,
		int? ExternalNotes = null,
		string PSite = null);
	}
}

