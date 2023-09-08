//PROJECT NAME: Logistics
//CLASS NAME: IValidateDueDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IValidateDueDate
	{
		(int? ReturnCode, string Infobar) ValidateDueDateSp(string RefType,
		DateTime? DueDate,
		string Site,
		string Infobar);
	}
}

