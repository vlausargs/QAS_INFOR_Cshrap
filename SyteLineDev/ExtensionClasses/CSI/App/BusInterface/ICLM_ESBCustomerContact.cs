//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBCustomerContact.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBCustomerContact
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBCustomerContactSp(string CustNum,
		int? CustSeq);
	}
}

