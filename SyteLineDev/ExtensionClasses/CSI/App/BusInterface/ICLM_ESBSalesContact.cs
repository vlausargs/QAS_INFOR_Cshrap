//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBSalesContact.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBSalesContact
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBSalesContactSp(string CustNum,
		string ProspectId);
	}
}

