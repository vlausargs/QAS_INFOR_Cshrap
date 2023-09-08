//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSProfileSROInvoicing.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSProfileSROInvoicing
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSProfileSROInvoicingSp(string StartInvNum = null,
		string EndInvNum = null,
		string StartOrdNum = null,
		string EndOrdNum = null,
		DateTime? StartInvDate = null,
		DateTime? EndInvDate = null,
		string StartCustNum = null,
		string EndCustNum = null);
	}
}

