//PROJECT NAME: Data
//CLASS NAME: IApp_CanAny.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IApp_CanAny
	{
		int? App_CanAnyFn(
			string Type,
			string FormName);
	}
}

