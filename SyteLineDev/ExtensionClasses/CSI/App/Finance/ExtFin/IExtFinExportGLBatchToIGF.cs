//PROJECT NAME: Finance
//CLASS NAME: IExtFinExportGLBatchToIGF.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.ExtFin
{
	public interface IExtFinExportGLBatchToIGF
	{
		(int? ReturnCode,
			string Infobar) ExtFinExportGLBatchToIGFSp(
			decimal? BatchNum,
			string Infobar);
	}
}

