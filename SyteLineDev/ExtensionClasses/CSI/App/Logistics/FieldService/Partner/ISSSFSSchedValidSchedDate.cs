//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSchedValidSchedDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Partner
{
	public interface ISSSFSSchedValidSchedDate
	{
		(int? ReturnCode, string Infobar) SSSFSSchedValidSchedDateSp(DateTime? SchedDate,
		string PartnerId = null,
		string Infobar = null);
	}
}

