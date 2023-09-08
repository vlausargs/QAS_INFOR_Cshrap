//PROJECT NAME: Data
//CLASS NAME: ICheckPermissionOnTransDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICheckPermissionOnTransDate
	{
		(int? ReturnCode,
			int? OutOfPeriod,
			int? CanTransact,
			int? Closed,
			int? FiscalYear,
			int? TransPeriod,
			string Infobar,
			DateTime? ZBegRange,
			DateTime? ZEndRange) CheckPermissionOnTransDateSp(
			DateTime? PTransDate,
			string Site = null,
			int? OutOfPeriod = 0,
			int? CanTransact = 0,
			int? Closed = 0,
			int? FiscalYear = null,
			int? TransPeriod = null,
			string Infobar = null,
			DateTime? ZBegRange = null,
			DateTime? ZEndRange = null);
	}
}

