//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSConfigSearchAddUnit.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSConfigSearchAddUnit
	{
		int? SSSFSConfigSearchAddUnitSp(
			string SerNum,
			string Item);
	}
}

