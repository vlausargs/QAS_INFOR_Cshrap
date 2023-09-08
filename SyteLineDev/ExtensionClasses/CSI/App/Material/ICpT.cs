//PROJECT NAME: Material
//CLASS NAME: ICpT.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ICpT
	{
		(int? ReturnCode, DateTime? TSchShipDate,
		DateTime? TSchRcvDate,
		string TTrn,
		string Infobar) CpTSp(string FTrn,
		string FromParmsSite,
		string TTransferFromSite,
		string TTransferToSite,
		int? FSLine,
		int? FELine,
		int? TCpCharge,
		DateTime? TSchShipDate,
		DateTime? TSchRcvDate,
		string TTrn,
		string Infobar);
	}
}

