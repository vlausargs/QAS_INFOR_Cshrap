//PROJECT NAME: Data
//CLASS NAME: ITmpSerId.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITmpSerId
	{
		Guid? TmpSerIdFn();
	}
}

