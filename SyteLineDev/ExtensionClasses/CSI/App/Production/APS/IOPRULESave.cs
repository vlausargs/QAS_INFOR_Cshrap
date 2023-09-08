//PROJECT NAME: Production
//CLASS NAME: IOPRULESave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IOPRULESave
	{
		int? OPRULESaveSp(int? InsertFlag,
		int? AltNo,
		int? RULESEQ,
		int? RULETYPE,
		string RULEVALUE,
		Guid? RowPointer);
	}
}

