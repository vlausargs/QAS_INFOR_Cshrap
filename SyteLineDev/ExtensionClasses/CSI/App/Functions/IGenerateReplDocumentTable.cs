//PROJECT NAME: Data
//CLASS NAME: IGenerateReplDocumentTable.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGenerateReplDocumentTable
	{
		ICollectionLoadResponse GenerateReplDocumentTableFn(
			string BODNoun,
			string BODVerb);
	}
}

