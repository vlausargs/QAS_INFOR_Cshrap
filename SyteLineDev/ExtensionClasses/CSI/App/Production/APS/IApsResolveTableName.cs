//PROJECT NAME: Production
//CLASS NAME: IApsResolveTableName.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsResolveTableName
	{
		string ApsResolveTableNameFn(
			int? AltNum,
			string ApsBaseTable);
	}
}

