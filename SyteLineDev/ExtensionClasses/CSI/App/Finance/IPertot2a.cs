//PROJECT NAME: Finance
//CLASS NAME: IPertot2a.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IPertot2a
	{
		(int? ReturnCode,
			string Infobar) Pertot2aSp(
			int? BegSort,
			int? EndSort,
			int? ActiveOnly,
			string Infobar,
			int? ChunkSize);
	}
}

