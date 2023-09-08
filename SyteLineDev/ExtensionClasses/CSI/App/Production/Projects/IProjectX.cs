//PROJECT NAME: Production
//CLASS NAME: IProjectX.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IProjectX
	{
		(int? ReturnCode,
			string PXrefDestination,
			int? CreateProj,
			int? CreateProjtask,
			string PromptMsg,
			string PromptButtons,
			string Infobar) ProjectXSp(
			string RefNum,
			int? RefLineSuf,
			int? RefRelease,
			string CoNum,
			int? CoLine,
			int? CoRelease,
			string Item,
			string PXrefDestination,
			int? CreateProj,
			int? CreateProjtask,
			string PromptMsg,
			string PromptButtons,
			string Infobar);
	}
}

