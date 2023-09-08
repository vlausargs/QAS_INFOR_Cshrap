//PROJECT NAME: Data
//CLASS NAME: ICanChangeShipToAddr.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICanChangeShipToAddr
	{
		int? CanChangeShipToAddrFn(
			string CustNum,
			int? CustSeq);
	}
}

