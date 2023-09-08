//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSroClo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSroClo
	{
		(int? ReturnCode, string Status, string infoBar) SSSFSSroClose(string SRONum = null,
		int? SROLine = null,
		int? SROOper = null,
		byte? BillComplete = (byte)0,
		byte? LinesShipped = (byte)0,
		byte? MatlShipped = (byte)0,
		string Status = null,
		string infoBar = null,
		byte? PlannedTransPosted = (byte)0,
		byte? StatCodeClose = (byte)0);
	}
	
	public class SSSFSSroClo : ISSSFSSroClo
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSroClo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Status, string infoBar) SSSFSSroClose(string SRONum = null,
		int? SROLine = null,
		int? SROOper = null,
		byte? BillComplete = (byte)0,
		byte? LinesShipped = (byte)0,
		byte? MatlShipped = (byte)0,
		string Status = null,
		string infoBar = null,
		byte? PlannedTransPosted = (byte)0,
		byte? StatCodeClose = (byte)0)
		{
			FSSRONumType _SRONum = SRONum;
			FSSROLineType _SROLine = SROLine;
			FSSROOperType _SROOper = SROOper;
			ListYesNoType _BillComplete = BillComplete;
			ListYesNoType _LinesShipped = LinesShipped;
			ListYesNoType _MatlShipped = MatlShipped;
			InfobarType _Status = Status;
			InfobarType _infoBar = infoBar;
			ListYesNoType _PlannedTransPosted = PlannedTransPosted;
			ListYesNoType _StatCodeClose = StatCodeClose;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSroClose";
				
				appDB.AddCommandParameter(cmd, "SRONum", _SRONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SROLine", _SROLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SROOper", _SROOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BillComplete", _BillComplete, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LinesShipped", _LinesShipped, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlShipped", _MatlShipped, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Status", _Status, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "infoBar", _infoBar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PlannedTransPosted", _PlannedTransPosted, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StatCodeClose", _StatCodeClose, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Status = _Status;
				infoBar = _infoBar;
				
				return (Severity, Status, infoBar);
			}
		}
	}
}
