//PROJECT NAME: Finance
//CLASS NAME: IArpmtCalcDueDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AR
{
	public interface IArpmtCalcDueDate
	{
		(int? ReturnCode,
			DateTime? PDueDate) ArpmtCalcDueDateSP(
			DateTime? PRecptDate,
			string PCustNum,
			DateTime? PDueDate);
	}
}

