//PROJECT NAME: BusInterface
//CLASS NAME: IReplDocumentExtList.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface IReplDocumentExtList
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string InfoBar) ReplDocumentExtListSp(string BODNoun,
		string BODVerb,
		string DocumentID,
		string TextPrefix,
		string IDOCollection,
		string Nodes,
		string FilterObject,
		string InfoBar,
		int? CallFromDetail = null,
		string ParentNode = null);
	}
}

