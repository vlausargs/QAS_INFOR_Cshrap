//PROJECT NAME: Finance
//CLASS NAME: IPertot.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IPertot
	{
		(int? ReturnCode, string Infobar) PertotSp(int? BegSort,
		int? EndSort,
		int? ActiveOnly,
		string Infobar,
		int? ChunkSize = null);
	}
}

