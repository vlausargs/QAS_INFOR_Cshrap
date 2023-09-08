//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSchedProfilesFiltersSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Partner
{
	public interface ISSSFSSchedProfilesFiltersSave
	{
		(int? ReturnCode,
			string Infobar) SSSFSSchedProfilesFiltersSaveSp(
			string List,
			string Infobar);
	}
}

