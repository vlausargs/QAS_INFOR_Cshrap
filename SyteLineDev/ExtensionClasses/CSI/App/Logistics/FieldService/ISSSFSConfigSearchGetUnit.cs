//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSConfigSearchGetUnit.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSConfigSearchGetUnit
	{
		(int? ReturnCode,
			string SerNum,
			string Item) SSSFSConfigSearchGetUnitSp(
			int? CompId,
			string SerNum,
			string Item);
	}
}

