//PROJECT NAME: Data
//CLASS NAME: IDeleteTableMessages.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDeleteTableMessages
	{
		int? DeleteTableMessagesSp(
			string TableName);
	}
}

