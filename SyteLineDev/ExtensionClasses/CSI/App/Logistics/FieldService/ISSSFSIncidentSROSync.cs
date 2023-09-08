//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSIncidentSROSync.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSIncidentSROSync
	{
		int? SSSFSIncidentSROSyncSp(
			string iMode,
			string iIncSroNum,
			int? iParmSyncOptIndex = 0);
	}
}

