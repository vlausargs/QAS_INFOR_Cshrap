//PROJECT NAME: Data
//CLASS NAME: ICreateMSDB.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICreateMSDB
	{
		int? CreateMSDBSp();
	}
}

