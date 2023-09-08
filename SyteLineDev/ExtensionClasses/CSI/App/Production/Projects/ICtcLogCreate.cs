//PROJECT NAME: Production
//CLASS NAME: ICtcLogCreate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface ICtcLogCreate
	{
		(int? ReturnCode, string Infobar) CtcLogCreateSp(string FromProjNum,
		string ToProjNum,
		int? FromTaskNum,
		int? ToTaskNum,
		string FromCostCode,
		string ToCostCode,
		string Infobar);
	}
}

