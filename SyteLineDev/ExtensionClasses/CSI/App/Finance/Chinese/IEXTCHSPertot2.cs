//PROJECT NAME: Finance
//CLASS NAME: IEXTCHSPertot2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Chinese
{
	public interface IEXTCHSPertot2
	{
		(int? ReturnCode,
			string Infobar) EXTCHSPertot2Sp(
			int? BegSort,
			int? EndSort,
			int? ActiveOnly,
			string Infobar);
	}
}

