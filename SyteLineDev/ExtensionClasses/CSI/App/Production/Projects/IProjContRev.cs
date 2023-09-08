//PROJECT NAME: Production
//CLASS NAME: IProjContRev.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IProjContRev
	{
		(int? ReturnCode,
			string Infobar) ProjContRevSp(
			string PCoNum,
			int? PCoLine,
			int? PCoRelease,
			string Infobar);
	}
}

