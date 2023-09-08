//PROJECT NAME: Logistics
//CLASS NAME: IGetLatestPORcvdDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IGetLatestPORcvdDate
	{
		(int? ReturnCode, DateTime? PoitemRcvdDate) GetLatestPORcvdDateSp(string PoNum,
		DateTime? PoitemRcvdDate);
	}
}

