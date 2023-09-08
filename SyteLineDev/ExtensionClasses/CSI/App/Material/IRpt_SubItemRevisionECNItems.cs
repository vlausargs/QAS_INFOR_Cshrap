//PROJECT NAME: Material
//CLASS NAME: IRpt_SubItemRevisionECNItems.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IRpt_SubItemRevisionECNItems
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_SubItemRevisionECNItemsSp(string ItemItem = null,
		string ItemRevision = null,
		int? ECNNumStarting = null,
		int? ECNNumEnding = null,
		int? PrintECNItemsNotes = null,
		int? PrintInternalNotes = null,
		int? PrintExternalNotes = null,
		string pSite = null);
	}
}

