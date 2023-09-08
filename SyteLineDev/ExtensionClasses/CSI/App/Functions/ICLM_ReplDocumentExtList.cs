//PROJECT NAME: Data
//CLASS NAME: ICLM_ReplDocumentExtList.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICLM_ReplDocumentExtList
	{
		(ICollectionLoadResponse Data, int? ReturnCode,
			string InfoBar) CLM_ReplDocumentExtListSp(
			string BODNoun,
			string BODVerb,
			string DocumentID,
			string TextPrefix = null,
			string InfoBar = null);
	}
}

