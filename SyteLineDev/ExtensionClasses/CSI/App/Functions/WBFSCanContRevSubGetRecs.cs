//PROJECT NAME: Data
//CLASS NAME: WBFSCanContRevSubGetRecs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class WBFSCanContRevSubGetRecs : IWBFSCanContRevSubGetRecs
	{
		readonly IApplicationDB appDB;
		
		public WBFSCanContRevSubGetRecs(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? WBFSCanContRevSubGetRecsSp(
			int? KPINum,
			DateTime? AsOfDate,
			string Parm1 = null,
			string Parm2 = null,
			int? CheckStatus = 0)
		{
			WBKPINumType _KPINum = KPINum;
			DateType _AsOfDate = AsOfDate;
			WBSourceNameType _Parm1 = Parm1;
			WBSourceNameType _Parm2 = Parm2;
			ListYesNoType _CheckStatus = CheckStatus;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "WBFSCanContRevSubGetRecsSp";
				
				appDB.AddCommandParameter(cmd, "KPINum", _KPINum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AsOfDate", _AsOfDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm1", _Parm1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Parm2", _Parm2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckStatus", _CheckStatus, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
