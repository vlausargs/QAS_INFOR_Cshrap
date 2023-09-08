//PROJECT NAME: Data
//CLASS NAME: IMatlIns.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IMatlIns
	{
		(int? ReturnCode,
			string CurJob,
			int? CurSuffix,
			int? CurSequence,
			string Infobar) MatlInsSp(
			int? CurOper,
			string CurJob,
			int? CurSuffix,
			int? CurSequence,
			string Infobar);
	}
}

