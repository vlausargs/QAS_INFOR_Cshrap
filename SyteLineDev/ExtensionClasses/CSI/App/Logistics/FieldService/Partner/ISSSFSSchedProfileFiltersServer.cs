//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSchedProfileFiltersServer.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Partner
{
	public interface ISSSFSSchedProfileFiltersServer
	{
		(int? ReturnCode,
		string InfoBar) SSSFSSchedProfileFiltersServerSp(
			string List,
			string InfoBar);
	}
}

