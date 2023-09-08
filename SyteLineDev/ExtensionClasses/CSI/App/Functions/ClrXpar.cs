//PROJECT NAME: Data
//CLASS NAME: ClrXpar.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ClrXpar : IClrXpar
	{
		readonly IApplicationDB appDB;
		
		public ClrXpar(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ClrXparSp(
			string RefType,
			string RefNum,
			int? RefLine,
			int? RefRel,
			string ChlNum,
			int? ChlLine,
			int? ChlRel,
			string Infobar,
			string ORefType = null)
		{
			UnknownRefTypeType _RefType = RefType;
			AnyRefNumType _RefNum = RefNum;
			CoLineType _RefLine = RefLine;
			CoLineType _RefRel = RefRel;
			AnyRefNumType _ChlNum = ChlNum;
			CoLineType _ChlLine = ChlLine;
			CoLineType _ChlRel = ChlRel;
			Infobar _Infobar = Infobar;
			UnknownRefTypeType _ORefType = ORefType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ClrXparSp";
				
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLine", _RefLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRel", _RefRel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChlNum", _ChlNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChlLine", _ChlLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChlRel", _ChlRel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ORefType", _ORefType, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
