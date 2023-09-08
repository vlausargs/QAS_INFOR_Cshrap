//PROJECT NAME: Production
//CLASS NAME: Pojob3PPre.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class Pojob3PPre : IPojob3PPre
	{
		readonly IApplicationDB appDB;
		
		
		public Pojob3PPre(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? TNextOper,
		int? TIsLastOper,
		int? ParmsLotGenExp,
		Guid? SessionID,
		string Infobar) Pojob3PPreSp(string TJob,
		int? TSuffix,
		int? TOper,
		int? TNextOper,
		int? TIsLastOper,
		int? ParmsLotGenExp,
		Guid? SessionID,
		string Infobar)
		{
			JobType _TJob = TJob;
			SuffixType _TSuffix = TSuffix;
			OperNumType _TOper = TOper;
			OperNumType _TNextOper = TNextOper;
			ListYesNoType _TIsLastOper = TIsLastOper;
			ListYesNoType _ParmsLotGenExp = ParmsLotGenExp;
			RowPointerType _SessionID = SessionID;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Pojob3PPreSp";
				
				appDB.AddCommandParameter(cmd, "TJob", _TJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TSuffix", _TSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TOper", _TOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TNextOper", _TNextOper, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TIsLastOper", _TIsLastOper, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ParmsLotGenExp", _ParmsLotGenExp, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TNextOper = _TNextOper;
				TIsLastOper = _TIsLastOper;
				ParmsLotGenExp = _ParmsLotGenExp;
				SessionID = _SessionID;
				Infobar = _Infobar;
				
				return (Severity, TNextOper, TIsLastOper, ParmsLotGenExp, SessionID, Infobar);
			}
		}
	}
}
