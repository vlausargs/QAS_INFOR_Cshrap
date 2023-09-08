//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSConfigSearchAddComp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSConfigSearchAddComp
	{
		int? SSSFSConfigSearchAddCompSp(
			int? CompId);
	}
}

