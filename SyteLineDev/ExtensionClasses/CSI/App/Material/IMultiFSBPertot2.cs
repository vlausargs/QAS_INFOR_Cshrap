//PROJECT NAME: Finance
//CLASS NAME: IMultiFSBPertot2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IMultiFSBPertot2
	{
		(int? ReturnCode,
			string Infobar) MultiFSBPertot2Sp(
			int? BegSort,
			int? EndSort,
			int? Activeonly,
			string FSBName,
			string Infobar);
	}
}

