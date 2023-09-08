//PROJECT NAME: Data
//CLASS NAME: IValidateJobschStartDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IValidateJobschStartDate
	{
		(int? ReturnCode,
			string Infobar) ValidateJobschStartDateSp(
			DateTime? PStartDate,
			string PSchedule,
			string Infobar);
	}
}

