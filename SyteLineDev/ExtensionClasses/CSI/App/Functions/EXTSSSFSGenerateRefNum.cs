//PROJECT NAME: Data
//CLASS NAME: EXTSSSFSGenerateRefNum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EXTSSSFSGenerateRefNum : IEXTSSSFSGenerateRefNum
	{
		readonly IApplicationDB appDB;
		
		public EXTSSSFSGenerateRefNum(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string RefNum,
			string Infobar) EXTSSSFSGenerateRefNumSp(
			string RefType,
			string RefNum,
			string Infobar)
		{
			RefTypeIJKPRTType _RefType = RefType;
			JobPoProjReqTrnNumType _RefNum = RefNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EXTSSSFSGenerateRefNumSp";
				
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RefNum = _RefNum;
				Infobar = _Infobar;
				
				return (Severity, RefNum, Infobar);
			}
		}
	}
}
