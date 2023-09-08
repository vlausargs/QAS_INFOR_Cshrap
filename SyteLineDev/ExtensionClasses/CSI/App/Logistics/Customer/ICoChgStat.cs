//PROJECT NAME: Logistics
//CLASS NAME: ICoChgStat.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICoChgStat
	{
		(int? ReturnCode, string Infobar) CoChgStatSp(string PCoNum,
		string PNewStatus,
		string Infobar);
	}
}

