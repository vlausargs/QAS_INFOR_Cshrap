//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBBankStmEntryDetailTran.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBBankStmEntryDetailTran
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string InfoBar) CLM_ESBBankStmEntryDetailTranSp(string BODNoun,
		string BODVerb,
		string DocumentID,
		string FilterString,
		string CollectionName,
		string TextPrefix = null,
		string FilterObject = null,
		string InfoBar = null);
	}
}

