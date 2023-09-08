//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBReplDocumentExtPivotByIDO.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBReplDocumentExtPivotByIDO
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string InfoBar) CLM_ESBReplDocumentExtPivotByIDOSp(string BODNoun,
		string BODVerb,
		string DocumentID,
		string FilterString = null,
		string CollectionName = null,
		string TextPrefix = null,
		string FilterObject = null,
		string InfoBar = null);
	}
}

