//PROJECT NAME: Data
//CLASS NAME: CoBlnChgStat.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CoBlnChgStat : ICoBlnChgStat
	{
		readonly IApplicationDB appDB;
		
		public CoBlnChgStat(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? PReplicateAllCoitem,
			string Infobar) CoBlnChgStatSp(
			string PCoNum,
			int? PCoLine,
			string PCoOrigSite,
			string POldCoBlnStat,
			string PNewCoBlnStat,
			int? PReplicateAllCoitem,
			string Infobar)
		{
			CoNumType _PCoNum = PCoNum;
			CoLineType _PCoLine = PCoLine;
			SiteType _PCoOrigSite = PCoOrigSite;
			CoBlnStatusType _POldCoBlnStat = POldCoBlnStat;
			CoBlnStatusType _PNewCoBlnStat = PNewCoBlnStat;
			FlagNyType _PReplicateAllCoitem = PReplicateAllCoitem;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CoBlnChgStatSp";
				
				appDB.AddCommandParameter(cmd, "PCoNum", _PCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoLine", _PCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoOrigSite", _PCoOrigSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldCoBlnStat", _POldCoBlnStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewCoBlnStat", _PNewCoBlnStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PReplicateAllCoitem", _PReplicateAllCoitem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PReplicateAllCoitem = _PReplicateAllCoitem;
				Infobar = _Infobar;
				
				return (Severity, PReplicateAllCoitem, Infobar);
			}
		}
	}
}
