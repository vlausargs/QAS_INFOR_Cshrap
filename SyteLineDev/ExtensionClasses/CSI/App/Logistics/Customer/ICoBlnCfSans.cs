//PROJECT NAME: Logistics
//CLASS NAME: ICoBlnCfSans.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICoBlnCfSans
	{
		(int? ReturnCode, int? PAnyFound) CoBlnCfSansSp(string PCoNum,
		int? PCoLine,
		string PStatus,
		int? PAnyFound);
	}
}

