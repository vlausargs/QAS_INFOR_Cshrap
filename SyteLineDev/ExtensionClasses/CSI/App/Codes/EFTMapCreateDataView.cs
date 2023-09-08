//PROJECT NAME: Codes
//CLASS NAME: EFTMapCreateDataView.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class EFTMapCreateDataView : IEFTMapCreateDataView
	{
		readonly IApplicationDB appDB;
		
		
		public EFTMapCreateDataView(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string InfoBar) EFTMapCreateDataViewSp(string MapId,
		string InfoBar)
		{
			EFTMappingIdType _MapId = MapId;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EFTMapCreateDataViewSp";
				
				appDB.AddCommandParameter(cmd, "MapId", _MapId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (Severity, InfoBar);
			}
		}
	}
}
