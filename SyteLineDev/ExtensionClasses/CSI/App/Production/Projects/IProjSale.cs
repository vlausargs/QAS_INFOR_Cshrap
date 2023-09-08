//PROJECT NAME: Production
//CLASS NAME: IProjSale.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IProjSale
	{
		(int? ReturnCode,
			string Infobar) ProjSaleSp(
			string PProjNum,
			int? PTaskNum,
			string PCoNum,
			int? PCoLine,
			int? PCoRelease,
			DateTime? PInvDate,
			decimal? PInvAmt,
			string PCurrCode,
			decimal? PExchRate,
			string Infobar);
	}
}

