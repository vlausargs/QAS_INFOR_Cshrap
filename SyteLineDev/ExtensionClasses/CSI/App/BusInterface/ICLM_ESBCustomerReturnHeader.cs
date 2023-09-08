//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBCustomerReturnHeader.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBCustomerReturnHeader
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBCustomerReturnHeaderSp(string RmaNum);
	}
}

