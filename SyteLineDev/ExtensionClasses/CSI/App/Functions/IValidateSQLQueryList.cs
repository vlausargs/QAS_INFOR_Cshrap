//PROJECT NAME: Data
//CLASS NAME: IValidateSQLQueryList.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IValidateSQLQueryList
	{
		string ValidateSQLQueryListFn(
			string ListString);
	}
}

