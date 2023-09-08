//PROJECT NAME: Logistics
//CLASS NAME: ICoJobCustNumFixup.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICoJobCustNumFixup
	{
		int? CoJobCustNumFixupSp(
			string CoNum,
			string CustNum);
	}
}

