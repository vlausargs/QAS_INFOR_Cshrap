//PROJECT NAME: Data
//CLASS NAME: IAPP_IncDateGetColumnIncMode.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IAPP_IncDateGetColumnIncMode
	{
		(int? ReturnCode,
			string IncrementMode) APP_IncDateGetColumnIncModeSp(
			string TableName,
			string ColumnName,
			string IncrementMode);
	}
}

