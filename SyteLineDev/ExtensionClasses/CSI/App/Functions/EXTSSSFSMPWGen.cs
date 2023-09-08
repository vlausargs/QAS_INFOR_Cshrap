//PROJECT NAME: Data
//CLASS NAME: EXTSSSFSMPWGen.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EXTSSSFSMPWGen : IEXTSSSFSMPWGen
	{
		readonly IApplicationDB appDB;
		
		public EXTSSSFSMPWGen(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string InfobarSave,
			string Infobar) EXTSSSFSMPWGenSp(
			DateTime? EndDate,
			string Source,
			string PlannerCode,
			string Buyer,
			string ThingsToProcess,
			decimal? UserId,
			string InfobarSave,
			string Infobar)
		{
			DateType _EndDate = EndDate;
			StringType _Source = Source;
			UserCodeType _PlannerCode = PlannerCode;
			UsernameType _Buyer = Buyer;
			StringType _ThingsToProcess = ThingsToProcess;
			TokenType _UserId = UserId;
			InfobarType _InfobarSave = InfobarSave;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EXTSSSFSMPWGenSp";
				
				appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Source", _Source, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PlannerCode", _PlannerCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Buyer", _Buyer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ThingsToProcess", _ThingsToProcess, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserId", _UserId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfobarSave", _InfobarSave, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfobarSave = _InfobarSave;
				Infobar = _Infobar;
				
				return (Severity, InfobarSave, Infobar);
			}
		}
	}
}
