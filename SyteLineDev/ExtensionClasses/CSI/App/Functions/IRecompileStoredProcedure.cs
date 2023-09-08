//PROJECT NAME: Data
//CLASS NAME: IRecompileStoredProcedure.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IRecompileStoredProcedure
	{
		int? RecompileStoredProcedureSp(
			string StoredProcedure,
			string DatabaseName = null);
	}
}

