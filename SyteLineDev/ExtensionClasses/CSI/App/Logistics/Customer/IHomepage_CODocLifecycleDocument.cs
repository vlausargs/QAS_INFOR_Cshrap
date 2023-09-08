//PROJECT NAME: Logistics
//CLASS NAME: IHomepage_CODocLifecycleDocument.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IHomepage_CODocLifecycleDocument
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Homepage_CODocLifecycleDocumentSp(string DocType,
		string DocId);
	}
}

