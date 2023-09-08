//PROJECT NAME: Finance
//CLASS NAME: IPertot2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IPertot2
	{
		(int? ReturnCode,
			string Infobar) Pertot2Sp(
			int? BegSort,
			int? EndSort,
			int? ActiveOnly,
			string Infobar,
			int? ChunkSize);
	}
}

