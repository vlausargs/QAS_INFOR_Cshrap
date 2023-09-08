//PROJECT NAME: Data
//CLASS NAME: INextValidDueDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface INextValidDueDate
	{
		(int? ReturnCode,
			string Infobar) NextValidDueDateSp(
			string RefType,
			int? IsForward,
			DateTime? DueDate,
			string Infobar);
	}
}

