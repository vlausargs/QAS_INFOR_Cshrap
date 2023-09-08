//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBCustomerReturnLine.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBCustomerReturnLine
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBCustomerReturnLineSp(string RmaNum);
	}
}

