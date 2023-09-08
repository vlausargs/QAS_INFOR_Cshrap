//PROJECT NAME: Production
//CLASS NAME: IProjMatlPoitemXrefUpdate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IProjMatlPoitemXrefUpdate
	{
		(int? ReturnCode,
			string Infobar) ProjMatlPoitemXrefUpdateSp(
			string RefType,
			string RefNum,
			int? RefLineSuf,
			int? RefRelease,
			string ProjmatlProjNum,
			int? ProjmatlTaskNum,
			int? ProjmatlSeq,
			string Item,
			string Infobar);
	}
}

