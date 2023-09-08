//PROJECT NAME: Data
//CLASS NAME: ClrXref.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ClrXref : IClrXref
	{
		readonly IApplicationDB appDB;
		
		public ClrXref(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ClrXrefSp(
			string RefType,
			string RefNum,
			int? RefLine,
			int? RefRel,
			string ParNum,
			int? ParLine,
			int? ParRel,
			string Infobar,
			string ORefType = null)
		{
			UnknownRefTypeType _RefType = RefType;
			AnyRefNumType _RefNum = RefNum;
			CoLineType _RefLine = RefLine;
			CoLineType _RefRel = RefRel;
			AnyRefNumType _ParNum = ParNum;
			CoLineType _ParLine = ParLine;
			CoLineType _ParRel = ParRel;
			Infobar _Infobar = Infobar;
			UnknownRefTypeType _ORefType = ORefType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ClrXrefSp";
				
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLine", _RefLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRel", _RefRel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParNum", _ParNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParLine", _ParLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParRel", _ParRel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ORefType", _ORefType, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
