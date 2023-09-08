//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSConInvSubDelBillLine.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSConInvSubDelBillLine
	{
		int? SSSFSConInvSubDelBillLineSp(
			Guid? SessionId);
	}
}

