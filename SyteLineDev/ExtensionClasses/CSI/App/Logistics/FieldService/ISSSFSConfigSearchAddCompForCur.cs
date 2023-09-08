//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSConfigSearchAddCompForCur.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSConfigSearchAddCompForCur
	{
		int? SSSFSConfigSearchAddCompForCurSp(
			int? CompId,
			string Search,
			int? Level,
			int? CompSer,
			int? CompItem,
			int? CompCustItem,
			int? CompDesc);
	}
}

