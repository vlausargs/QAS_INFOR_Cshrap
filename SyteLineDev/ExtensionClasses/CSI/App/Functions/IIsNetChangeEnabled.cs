//PROJECT NAME: Data
//CLASS NAME: IIsNetChangeEnabled.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IIsNetChangeEnabled
	{
		int? IsNetChangeEnabledFn();
	}
}

