//PROJECT NAME: Production
//CLASS NAME: IVerifyFromPr.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IVerifyFromPr
	{
		(int? ReturnCode, int? StartTask,
		int? EndTask,
		int? NoTask,
		string Infobar) VerifyFromProj(string FromType,
		string FromProj,
		int? StartTask,
		int? EndTask,
		int? NoTask,
		string Infobar);
	}
}

