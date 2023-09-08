//PROJECT NAME: CSIAUIndPack
//CLASS NAME: AU_CheckQAProcessSourceValue.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Automotive
{
	public interface IAU_CheckQAProcessSourceValue
	{
		(int? ReturnCode, string Infobar) AU_CheckQAProcessSourceValueSp(string RefType = null,
		string RefNum = null,
		short? RefLineSuf = null,
		short? RefRelease = null,
		int? SourceLevel = null,
		string Infobar = null);
	}
	
	public class AU_CheckQAProcessSourceValue : IAU_CheckQAProcessSourceValue
	{
		readonly IApplicationDB appDB;
		
		public AU_CheckQAProcessSourceValue(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) AU_CheckQAProcessSourceValueSp(string RefType = null,
		string RefNum = null,
		short? RefLineSuf = null,
		short? RefRelease = null,
		int? SourceLevel = null,
		string Infobar = null)
		{
			RefTypeIJKOPRSTWType _RefType = RefType;
			ReferenceType _RefNum = RefNum;
			CoLineSuffixPoLineProjTaskRmaTrnLineType _RefLineSuf = RefLineSuf;
			CoPoReleaseType _RefRelease = RefRelease;
			IntType _SourceLevel = SourceLevel;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AU_CheckQAProcessSourceValueSp";
				
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLineSuf", _RefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SourceLevel", _SourceLevel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
