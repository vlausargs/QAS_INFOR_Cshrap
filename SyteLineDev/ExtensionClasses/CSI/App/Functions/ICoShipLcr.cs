//PROJECT NAME: Data
//CLASS NAME: ICoShipLcr.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICoShipLcr
	{
		(int? ReturnCode,
			string rInfobar) CoShipLcrSp(
			string pCoNum,
			DateTime? pTransDate,
			string pMText,
			int? pSuppressErrorWhenCustomerLcrNotReqd,
			string rInfobar);
	}
}

