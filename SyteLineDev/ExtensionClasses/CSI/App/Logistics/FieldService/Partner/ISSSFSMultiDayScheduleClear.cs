//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSMultiDayScheduleClear.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Partner
{
	public interface ISSSFSMultiDayScheduleClear
	{
		(int? ReturnCode,
		string Infobar) SSSFSMultiDayScheduleClearSp(
			Guid? SessionID,
			string Infobar);
	}
}

