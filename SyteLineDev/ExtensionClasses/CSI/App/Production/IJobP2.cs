//PROJECT NAME: Production
//CLASS NAME: IJobP2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IJobP2
	{
		(int? ReturnCode, int? TCoby,
		string Infobar,
		string PromptButtons) JobP2Sp(Guid? SJobtranRowPointer,
		int? PPostNeg = 0,
		int? TCoby = null,
		string Infobar = null,
		string CurWhse = null,
		string PromptButtons = null,
		string DocumentNum = null);
	}
}

