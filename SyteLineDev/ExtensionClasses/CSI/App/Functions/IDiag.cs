//PROJECT NAME: Data
//CLASS NAME: IDiag.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDiag
	{
		int? DiagSp(
			string PDiagLevl,
			string PDiagMesg);
	}
}

