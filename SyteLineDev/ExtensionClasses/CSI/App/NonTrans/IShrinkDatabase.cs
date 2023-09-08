//PROJECT NAME: NonTrans
//CLASS NAME: IShrinkDatabase.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.NonTrans
{
	public interface IShrinkDatabase
	{
		int? ShrinkDatabaseSp(string DatabaseName = null);
	}
}

