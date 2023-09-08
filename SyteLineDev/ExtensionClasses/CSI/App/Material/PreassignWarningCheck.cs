//PROJECT NAME: CSIMaterial
//CLASS NAME: PreassignWarningCheck.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IPreassignWarningCheck
	{
		(int? ReturnCode, byte? PreassignExists) PreassignWarningCheckSp(string RefType,
		string RefNum,
		short? RefLineSuf,
		short? RefRelease,
		byte? CheckForLot,
		byte? PreassignExists);
	}
	
	public class PreassignWarningCheck : IPreassignWarningCheck
	{
		readonly IApplicationDB appDB;
		
		public PreassignWarningCheck(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, byte? PreassignExists) PreassignWarningCheckSp(string RefType,
		string RefNum,
		short? RefLineSuf,
		short? RefRelease,
		byte? CheckForLot,
		byte? PreassignExists)
		{
			RefTypeIJKPRTType _RefType = RefType;
			JobPoProjReqTrnNumType _RefNum = RefNum;
			SuffixPoLineProjTaskReqTrnLineType _RefLineSuf = RefLineSuf;
			OperNumPoReleaseType _RefRelease = RefRelease;
			ListYesNoType _CheckForLot = CheckForLot;
			ListYesNoType _PreassignExists = PreassignExists;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PreassignWarningCheckSp";
				
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLineSuf", _RefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckForLot", _CheckForLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PreassignExists", _PreassignExists, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PreassignExists = _PreassignExists;
				
				return (Severity, PreassignExists);
			}
		}
	}
}
