//PROJECT NAME: Finance
//CLASS NAME: IExtFinExportUnitCode2ToIGF.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.ExtFin
{
	public interface IExtFinExportUnitCode2ToIGF
	{
		(int? ReturnCode,
			string Infobar) ExtFinExportUnitCode2ToIGFSp(
			string UnitCode2,
			string Infobar);
	}
}

