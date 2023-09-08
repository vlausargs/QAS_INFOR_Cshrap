//PROJECT NAME: Data
//CLASS NAME: IAPP_IncDateConfig.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IAPP_IncDateConfig
	{
		(int? ReturnCode,
			string ExcludedTableNameList,
			string ExcludedColumnNameList,
			string ExcludedTypeNameList,
			string YearTypeNameList) APP_IncDateConfigSp(
			string ExcludedTableNameList,
			string ExcludedColumnNameList,
			string ExcludedTypeNameList,
			string YearTypeNameList);
	}
}

