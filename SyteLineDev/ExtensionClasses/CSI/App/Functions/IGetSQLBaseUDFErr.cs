//PROJECT NAME: Data
//CLASS NAME: IGetSQLBaseUDFErr.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetSQLBaseUDFErr
	{
		(int? ReturnCode,
			string SQLBaseUDFErr) GetSQLBaseUDFErrSp(
			string SQLBaseUDFErr);
	}
}

