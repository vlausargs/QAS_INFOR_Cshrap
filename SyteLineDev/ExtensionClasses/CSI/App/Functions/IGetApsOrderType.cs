//PROJECT NAME: Data
//CLASS NAME: IGetApsOrderType.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetApsOrderType
	{
		string GetApsOrderTypeFn(
			string ORDERID);
	}
}

