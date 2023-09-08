//PROJECT NAME: Data
//CLASS NAME: ITriggerIupCustomPostCode.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITriggerIupCustomPostCode
	{
		(int? ReturnCode,
			string CustomPostInsertCode,
			string CustomPostUpdateCode,
			int? InsertNeedSeverityOrInfobar,
			int? UpdateNeedSeverityOrInfobar) TriggerIupCustomPostCodeSp(
			string TableName,
			string CustomPostInsertCode,
			string CustomPostUpdateCode,
			int? InsertNeedSeverityOrInfobar,
			int? UpdateNeedSeverityOrInfobar);
	}
}

