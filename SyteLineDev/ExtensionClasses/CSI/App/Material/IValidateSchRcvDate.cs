//PROJECT NAME: Material
//CLASS NAME: IValidateSchRcvDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IValidateSchRcvDate
	{
		(int? ReturnCode, DateTime? TSchShipDate,
		string Infobar) ValidateSchRcvDateSp(string SourceTrnNum,
		DateTime? TSchRcvDate,
		DateTime? TSchShipDate,
		string Infobar);
	}
}

