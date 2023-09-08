//PROJECT NAME: Data
//CLASS NAME: ITHAApptcGetDueDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITHAApptcGetDueDate
	{
		(int? ReturnCode,
			DateTime? RDueDate,
			string Infobar) THAApptcGetDueDateSp(
			DateTime? PCheckDate,
			string PVendNum,
			DateTime? RDueDate,
			string Infobar);
	}
}

