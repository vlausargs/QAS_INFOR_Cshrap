//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSProfileConInvoicing.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSProfileConInvoicing
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSProfileConInvoicingSp(string StartInvNum = null,
		string EndInvNum = null,
		string StartContNum = null,
		string EndContNum = null,
		DateTime? StartInvDate = null,
		DateTime? EndInvDate = null,
		string StartCustNum = null,
		string EndCustNum = null);
	}
}

