//PROJECT NAME: Production
//CLASS NAME: PSGenerateTransNum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class PSGenerateTransNum : IPSGenerateTransNum
	{
		readonly IApplicationDB appDB;
		
		
		public PSGenerateTransNum(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? TJobtranTransNum,
		string Infobar) PSGenerateTransNumSp(Guid? SessionID,
		decimal? TJobtranTransNum,
		string Infobar)
		{
			RowPointerType _SessionID = SessionID;
			HugeTransNumType _TJobtranTransNum = TJobtranTransNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PSGenerateTransNumSp";
				
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TJobtranTransNum", _TJobtranTransNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TJobtranTransNum = _TJobtranTransNum;
				Infobar = _Infobar;
				
				return (Severity, TJobtranTransNum, Infobar);
			}
		}
	}
}
