//PROJECT NAME: Data
//CLASS NAME: LibClrXref.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class LibClrXref : ILibClrXref
	{
		readonly IApplicationDB appDB;
		
		public LibClrXref(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? LibClrXrefSp(
			string RefType,
			string RefNum,
			int? RefLine,
			int? RefRel,
			string ParNum,
			int? ParLine,
			int? ParRel)
		{
			RefTypeIJPRTType _RefType = RefType;
			JobPoReqNumType _RefNum = RefNum;
			SuffixPoReqTrnLineType _RefLine = RefLine;
			OperNumPoReleaseType _RefRel = RefRel;
			JobPoReqNumType _ParNum = ParNum;
			SuffixPoReqTrnLineType _ParLine = ParLine;
			OperNumPoReleaseType _ParRel = ParRel;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LibClrXrefSp";
				
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLine", _RefLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRel", _RefRel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParNum", _ParNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParLine", _ParLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParRel", _ParRel, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
