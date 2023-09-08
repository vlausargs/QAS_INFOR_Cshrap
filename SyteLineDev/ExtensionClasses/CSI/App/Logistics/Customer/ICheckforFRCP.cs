//PROJECT NAME: Logistics
//CLASS NAME: ICheckforFRCP.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICheckforFRCP
	{
		(int? ReturnCode, int? FRCP) CheckforFRCPSp(int? FRCP);
	}
}

