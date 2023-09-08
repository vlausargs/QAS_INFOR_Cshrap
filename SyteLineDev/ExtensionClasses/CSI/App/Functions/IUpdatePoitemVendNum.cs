//PROJECT NAME: Data
//CLASS NAME: IUpdatePoitemVendNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IUpdatePoitemVendNum
	{
		int? UpdatePoitemVendNumSp(
			string PPoNum,
			string PVendNum,
			string PTransNat,
			string PTransNat2,
			string PDelterm,
			string PProcessInd);
	}
}

