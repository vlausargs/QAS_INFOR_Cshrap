//PROJECT NAME: Data
//CLASS NAME: ITaskchng.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITaskchng
	{
		(int? ReturnCode,
			string Infobar) TaskchngSp(
			string ProjNum,
			string ProjTaskStatus,
			string NewStatus,
			int? ProjTaskNum,
			string Infobar);
	}
}

