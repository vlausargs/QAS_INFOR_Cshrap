//PROJECT NAME: Logistics
//CLASS NAME: ICOShipGetPoXRef.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICOShipGetPoXRef
	{
		(int? ReturnCode, int? PFound,
		string PType) COShipGetPoXRefSp(string PPoNum,
		int? PPoLine,
		int? PPoRelease,
		int? PFound,
		string PType);
	}
}

