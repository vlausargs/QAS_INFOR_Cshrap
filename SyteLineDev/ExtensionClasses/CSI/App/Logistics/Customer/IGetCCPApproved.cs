//PROJECT NAME: Logistics
//CLASS NAME: IGetCCPApproved.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGetCCPApproved
	{
		(int? ReturnCode, int? Approved,
		string Infobar) GetCCPApprovedSp(string CoNum,
		int? Approved,
		string Infobar);
	}
}

