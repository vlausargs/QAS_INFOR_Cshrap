//PROJECT NAME: Finance
//CLASS NAME: IExtFinExportUnitCode1ToIGF.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.ExtFin
{
	public interface IExtFinExportUnitCode1ToIGF
	{
		(int? ReturnCode,
			string Infobar) ExtFinExportUnitCode1ToIGFSp(
			string UnitCode1,
			string Infobar);
	}
}

