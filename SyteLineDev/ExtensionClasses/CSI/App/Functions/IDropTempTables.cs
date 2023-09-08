//PROJECT NAME: Data
//CLASS NAME: IDropTempTables.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDropTempTables
	{
		int? DropTempTablesSp(
			string DatabaseName = null);
	}
}

