//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSchedProfilesFiltersSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
	public class SSSFSSchedProfilesFiltersSave : ISSSFSSchedProfilesFiltersSave
	{
		readonly IApplicationDB appDB;


		public SSSFSSchedProfilesFiltersSave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public (int? ReturnCode,
			string Infobar) SSSFSSchedProfilesFiltersSaveSp(
			string List,
			string Infobar)
		{
			StringType _List = List;
			StringType _Infobar = Infobar;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSchedProfilesFiltersSaveSp";

				appDB.AddCommandParameter(cmd, "List", _List, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

				var Severity = appDB.ExecuteNonQuery(cmd);

				Infobar = _Infobar;

				return (Severity, Infobar);
			}
		}
	}
}
