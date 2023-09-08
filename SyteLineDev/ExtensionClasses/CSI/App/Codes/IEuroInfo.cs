//PROJECT NAME: Codes
//CLASS NAME: IEuroInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IEuroInfo
	{
		(int? ReturnCode, int? PEuroUser,
		int? PEuroExists,
		int? PBaseEuro,
		string PEuroCurr,
		string InfoBar) EuroInfoSp(int? DispMsg,
		int? PEuroUser,
		int? PEuroExists,
		int? PBaseEuro,
		string PEuroCurr,
		string InfoBar,
		string Site = null);
	}
}

