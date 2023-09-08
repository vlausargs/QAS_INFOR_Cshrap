//PROJECT NAME: Data
//CLASS NAME: IUETBundle.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IUETBundle
	{
		(int? ReturnCode,
			string UETListPairs) UETBundleSp(
			string TableName,
			Guid? RowPointer,
			string UETListPairs);
	}
}

