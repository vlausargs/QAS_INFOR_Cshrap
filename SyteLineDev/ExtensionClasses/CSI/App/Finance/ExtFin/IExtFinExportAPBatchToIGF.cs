//PROJECT NAME: Finance
//CLASS NAME: IExtFinExportAPBatchToIGF.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.ExtFin
{
	public interface IExtFinExportAPBatchToIGF
	{
		(int? ReturnCode,
			string Infobar) ExtFinExportAPBatchToIGFSp(
			decimal? BatchNum,
			string Infobar);
	}
}

