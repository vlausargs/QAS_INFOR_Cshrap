//PROJECT NAME: BusInterface
//CLASS NAME: ILoadESBEmployeeTimeSheetDetail.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ILoadESBEmployeeTimeSheetDetail
	{
		(int? ReturnCode, string Infobar) LoadESBEmployeeTimeSheetDetailSp(string DerBODID,
		string ActionExpression,
		string EmployeeID,
		DateTime? TransactionDate,
		string ReferenceID,
		string Prefix,
		string Duration,
		string Status,
		string Infobar);
	}
}

