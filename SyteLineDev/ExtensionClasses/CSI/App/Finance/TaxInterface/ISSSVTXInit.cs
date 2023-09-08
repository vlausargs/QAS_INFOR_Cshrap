//PROJECT NAME: Finance
//CLASS NAME: ISSSVTXInit.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.TaxInterface
{
	public interface ISSSVTXInit
	{
		(int? ReturnCode,
			string Infobar) SSSVTXInitSp(
			string Infobar);
	}
}

