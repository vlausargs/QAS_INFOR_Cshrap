//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBReplDocumentExt.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBReplDocumentExt
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string InfoBar) CLM_ESBReplDocumentExtSp(string BODNoun,
		string BODVerb,
		string DocumentID,
		string FilterString,
		string CollectionName,
		string TextPrefix = null,
		string InfoBar = null);
	}
}

