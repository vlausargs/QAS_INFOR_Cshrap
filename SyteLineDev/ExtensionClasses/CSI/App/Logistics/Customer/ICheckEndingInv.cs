//PROJECT NAME: Logistics
//CLASS NAME: ICheckEndingInv.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICheckEndingInv
	{
		(int? ReturnCode, string Infobar) CheckEndingInvSp(string PEndInv,
		string Infobar);
	}
}

