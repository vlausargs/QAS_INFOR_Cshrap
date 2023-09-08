//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSUnitConfigAutoCreate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSUnitConfigAutoCreate
	{
		int? SSSFSUnitConfigAutoCreateSp(
			decimal? TrackNum);
	}
}

