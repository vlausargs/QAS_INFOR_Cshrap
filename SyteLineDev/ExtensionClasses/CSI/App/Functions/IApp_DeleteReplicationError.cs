//PROJECT NAME: Data
//CLASS NAME: IApp_DeleteReplicationError.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IApp_DeleteReplicationError
	{
		(int? ReturnCode,
			string Infobar) App_DeleteReplicationErrorSp(
			decimal? OperationNumber,
			string Value1,
			string Value2,
			string Infobar);
	}
}

