//PROJECT NAME: Production
//CLASS NAME: IJobOperations.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IJobOperations
	{
		(int? ReturnCode, string job,
		int? Suffix,
		string Type) JobOperationsSp(string OpCategory,
		string job,
		string SchedId,
		string Item,
		DateTime? Release,
		int? Suffix,
		string Type,
		string AlternateID = null);
	}
}

