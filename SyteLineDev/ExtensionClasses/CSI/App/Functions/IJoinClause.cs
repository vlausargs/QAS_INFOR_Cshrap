//PROJECT NAME: Data
//CLASS NAME: IJoinClause.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IJoinClause
	{
		string JoinClauseFn(
			string TableName,
			string JoinTableName,
			string Keys,
			string JoinKeys,
			string AssumedKeys,
			string AssumedJoinKeys,
			string Delim = ",");
	}
}

