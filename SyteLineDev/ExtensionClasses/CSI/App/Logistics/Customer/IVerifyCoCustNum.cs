//PROJECT NAME: Logistics
//CLASS NAME: IVerifyCoCustNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IVerifyCoCustNum
	{
		(int? ReturnCode, string CustNum,
		string Infobar) VerifyCoCustNumSp(string CoNum,
		string CustNum,
		string Infobar);
	}
}

