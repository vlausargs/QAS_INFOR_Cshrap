//PROJECT NAME: Finance
//CLASS NAME: EXTCHSGetCHGLInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class EXTCHSGetCHGLInfo : IEXTCHSGetCHGLInfo
	{
		readonly IApplicationDB appDB;
		
		
		public EXTCHSGetCHGLInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string CHVounum,
		int? LineNum,
		int? Rubric) EXTCHSGetCHGLInfoSp(decimal? TransNum,
		string CHVounum,
		int? LineNum,
		int? Rubric)
		{
			MatlTransNumType _TransNum = TransNum;
			GenericMedCodeType _CHVounum = CHVounum;
			GenericIntType _LineNum = LineNum;
			FlagNyType _Rubric = Rubric;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EXTCHSGetCHGLInfoSp";
				
				appDB.AddCommandParameter(cmd, "TransNum", _TransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CHVounum", _CHVounum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LineNum", _LineNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Rubric", _Rubric, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CHVounum = _CHVounum;
				LineNum = _LineNum;
				Rubric = _Rubric;
				
				return (Severity, CHVounum, LineNum, Rubric);
			}
		}
	}
}
