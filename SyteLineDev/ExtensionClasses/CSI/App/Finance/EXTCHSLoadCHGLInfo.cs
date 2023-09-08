//PROJECT NAME: Finance
//CLASS NAME: EXTCHSLoadCHGLInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class EXTCHSLoadCHGLInfo : IEXTCHSLoadCHGLInfo
	{
		readonly IApplicationDB appDB;
		
		
		public EXTCHSLoadCHGLInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string CHVounum,
		int? LineNum,
		int? Rubric) EXTCHSLoadCHGLInfoSp(string Id,
		int? Seq,
		string CHVounum,
		int? LineNum,
		int? Rubric)
		{
			JournalIdType _Id = Id;
			JournalSeqType _Seq = Seq;
			GenericMedCodeType _CHVounum = CHVounum;
			GenericIntType _LineNum = LineNum;
			FlagNyType _Rubric = Rubric;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EXTCHSLoadCHGLInfoSp";
				
				appDB.AddCommandParameter(cmd, "Id", _Id, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Seq", _Seq, ParameterDirection.Input);
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
