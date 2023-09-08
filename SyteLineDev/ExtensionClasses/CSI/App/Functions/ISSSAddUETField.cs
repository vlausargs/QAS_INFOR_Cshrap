//PROJECT NAME: Data
//CLASS NAME: ISSSAddUETField.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ISSSAddUETField
	{
		int? SSSAddUETFieldSp(
			string ClassName,
			string FldName,
			string FldDataType,
			string FldInitial,
			int? FldDecimals,
			string FldUDT,
			int? FldPrec);
	}
}

