//PROJECT NAME: Data
//CLASS NAME: IPop_AllTables.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPop_AllTables
	{
		(int? ReturnCode,
			string AllCode1,
			string AllCode2,
			string AllCode3,
			string AllCode4) Pop_AllTablesSp(
			string TableName,
			string AllCode1,
			string AllCode2,
			string AllCode3,
			string AllCode4);
	}
}

