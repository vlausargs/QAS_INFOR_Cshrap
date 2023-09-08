//PROJECT NAME: Data
//CLASS NAME: IMoveProspectCommLogToCustomerCommLog.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IMoveProspectCommLogToCustomerCommLog
	{
		(int? ReturnCode,
			string Infobar) MoveProspectCommLogToCustomerCommLogSp(
			string ProspectId,
			string CustNum,
			string Infobar);
	}
}

