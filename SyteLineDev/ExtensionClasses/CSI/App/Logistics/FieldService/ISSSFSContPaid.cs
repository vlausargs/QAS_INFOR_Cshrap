//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSContPaid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSContPaid
	{
		(int? ReturnCode,
			string Infobar) SSSFSContPaidSp(
			string InvNum,
			DateTime? RecvDate,
			string Infobar);
	}
}

