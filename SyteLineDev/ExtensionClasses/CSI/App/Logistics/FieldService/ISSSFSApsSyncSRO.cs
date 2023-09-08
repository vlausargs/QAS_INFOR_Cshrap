//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSApsSyncSRO.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSApsSyncSRO
	{
		int? SSSFSApsSyncSROSp(
			Guid? Partition);
	}
}

