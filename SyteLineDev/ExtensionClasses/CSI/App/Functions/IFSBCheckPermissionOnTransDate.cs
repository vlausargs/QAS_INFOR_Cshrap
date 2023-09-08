//PROJECT NAME: Data
//CLASS NAME: IFSBCheckPermissionOnTransDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFSBCheckPermissionOnTransDate
	{
		(int? ReturnCode,
			int? OutOfPeriod,
			int? CanTransact,
			string Infobar) FSBCheckPermissionOnTransDateSp(
			string FSBName,
			DateTime? PTransDate,
			string Site = null,
			int? OutOfPeriod = null,
			int? CanTransact = null,
			string Infobar = null);
	}
}

