//PROJECT NAME: Data
//CLASS NAME: IDeleteReplData.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDeleteReplData
	{
		int? DeleteReplDataSp(
			string TableName,
			Guid? SessionID);
	}
}

