//PROJECT NAME: Finance
//CLASS NAME: IExtFinExportARBatchToIGF.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.ExtFin
{
	public interface IExtFinExportARBatchToIGF
	{
		(int? ReturnCode,
			string Infobar) ExtFinExportARBatchToIGFSp(
			decimal? BatchNum,
			string Infobar);
	}
}

