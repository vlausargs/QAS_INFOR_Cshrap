//PROJECT NAME: Logistics
//CLASS NAME: ICoDuePer.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICoDuePer
	{
		(int? ReturnCode, int? PDuePeriod) CoDuePerSp(string PItem,
		string PCustNum,
		int? PDuePeriod,
		string CustItem);
	}
}

