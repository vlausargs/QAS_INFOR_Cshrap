//PROJECT NAME: Data
//CLASS NAME: ISumLogI.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ISumLogI
	{
		int? SumLogISp(
			string PEmpNum,
			int? PSeq,
			DateTime? PCurStart,
			DateTime? PCurEnd);
	}
}

