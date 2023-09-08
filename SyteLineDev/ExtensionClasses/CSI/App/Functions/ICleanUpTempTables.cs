//PROJECT NAME: Data
//CLASS NAME: ICleanUpTempTables.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICleanUpTempTables
	{
		int? CleanUpTempTablesSp();
	}
}

