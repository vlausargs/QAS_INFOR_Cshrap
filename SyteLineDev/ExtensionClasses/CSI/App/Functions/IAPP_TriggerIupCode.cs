//PROJECT NAME: Data
//CLASS NAME: IAPP_TriggerIupCode.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IAPP_TriggerIupCode
	{
		int? APP_TriggerIupCodeSp(
			string TableName);
	}
}

