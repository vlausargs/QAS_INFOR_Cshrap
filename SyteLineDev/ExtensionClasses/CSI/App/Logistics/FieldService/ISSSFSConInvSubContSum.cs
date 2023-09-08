//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSConInvSubContSum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSConInvSubContSum
	{
		int? SSSFSConInvSubContSumSp(
			string Contract);
	}
}

