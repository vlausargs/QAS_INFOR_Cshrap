//PROJECT NAME: Data
//CLASS NAME: IGetKeyInString.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetKeyInString
	{
		(int? ReturnCode,
			string PKeyValue) GetKeyInStringSp(
			string PTableNameForKey,
			string PTableName,
			Guid? PRowPointer,
			string PKeyValue);
	}
}

