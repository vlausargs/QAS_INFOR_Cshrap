//PROJECT NAME: Data
//CLASS NAME: BldTtcp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class BldTtcp : IBldTtcp
	{
		readonly IApplicationDB appDB;
		
		public BldTtcp(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) BldTtcpSp(
			string PItem,
			int? PDynLead,
			int? PAllJobs,
			int? PExclXref,
			int? pUseSchedTimesInPlanning,
			string pApsMode,
			string Infobar)
		{
			ItemType _PItem = PItem;
			ListYesNoType _PDynLead = PDynLead;
			FlagNyType _PAllJobs = PAllJobs;
			FlagNyType _PExclXref = PExclXref;
			ListYesNoType _pUseSchedTimesInPlanning = pUseSchedTimesInPlanning;
			ApsModeType _pApsMode = pApsMode;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "BldTtcpSp";
				
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDynLead", _PDynLead, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAllJobs", _PAllJobs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PExclXref", _PExclXref, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pUseSchedTimesInPlanning", _pUseSchedTimesInPlanning, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pApsMode", _pApsMode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
