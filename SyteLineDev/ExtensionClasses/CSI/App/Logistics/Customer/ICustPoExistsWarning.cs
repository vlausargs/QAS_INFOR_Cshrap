//PROJECT NAME: Logistics
//CLASS NAME: ICustPoExistsWarning.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICustPoExistsWarning
	{
		(int? ReturnCode, string Infobar) CustPoExistsWarningSp(string CoNum,
		string CustPo,
		string CustNum,
		string Infobar);
	}
}

