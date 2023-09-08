//PROJECT NAME: Logistics
//CLASS NAME: IHomepage_PODocLifecycleDocument.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IHomepage_PODocLifecycleDocument
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Homepage_PODocLifecycleDocumentSp(string DocType,
		string DocId);
	}
}

