//PROJECT NAME: Finance
//CLASS NAME: IExtFinExportCustomerToIGF.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.ExtFin
{
	public interface IExtFinExportCustomerToIGF
	{
		(int? ReturnCode,
			string Infobar) ExtFinExportCustomerToIGFSp(
			string CustNum,
			string Infobar);
	}
}

