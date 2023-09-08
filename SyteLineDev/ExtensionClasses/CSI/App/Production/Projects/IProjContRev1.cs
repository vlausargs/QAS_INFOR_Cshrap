//PROJECT NAME: Production
//CLASS NAME: IProjContRev1.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IProjContRev1
	{
		(int? ReturnCode,
			string Infobar) ProjContRev1Sp(
			string PProjNum,
			int? PTaskNum,
			string PCustNum,
			decimal? PContRev,
			string Infobar);
	}
}

