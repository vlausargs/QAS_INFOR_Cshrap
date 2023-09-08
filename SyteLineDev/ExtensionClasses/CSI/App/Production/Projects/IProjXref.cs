//PROJECT NAME: Production
//CLASS NAME: IProjXref.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IProjXref
	{
		(int? ReturnCode,
			string ProjNum,
			int? TaskNum,
			string Infobar) ProjXrefSp(
			string CoNum,
			int? CoLine,
			int? CoRelease,
			string RefNum,
			int? RefLine,
			int? RefRelease,
			string Item,
			string ItemDescription,
			int? CreateProj,
			int? CreateProjtask,
			string ProjNum,
			int? TaskNum,
			string Infobar);
	}
}

