//PROJECT NAME: Data
//CLASS NAME: IGetReqRefFromItemPriceRequest.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetReqRefFromItemPriceRequest
	{
		string GetReqRefFromItemPriceRequestFn(
			string ReqNum,
			int? ReqLine);
	}
}

