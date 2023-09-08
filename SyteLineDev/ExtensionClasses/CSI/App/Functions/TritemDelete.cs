//PROJECT NAME: Data
//CLASS NAME: TritemDelete.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class TritemDelete : ITritemDelete
	{
		readonly IApplicationDB appDB;
		
		public TritemDelete(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) TritemDeleteSp(
			string PTrnNum,
			int? PTrnLine,
			string Infobar,
			int? RepFromTrigger = 0,
			string RepFromSite = null)
		{
			TrnNumType _PTrnNum = PTrnNum;
			TrnLineType _PTrnLine = PTrnLine;
			InfobarType _Infobar = Infobar;
			ListYesNoType _RepFromTrigger = RepFromTrigger;
			SiteType _RepFromSite = RepFromSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TritemDeleteSp";
				
				appDB.AddCommandParameter(cmd, "PTrnNum", _PTrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTrnLine", _PTrnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RepFromTrigger", _RepFromTrigger, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RepFromSite", _RepFromSite, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
