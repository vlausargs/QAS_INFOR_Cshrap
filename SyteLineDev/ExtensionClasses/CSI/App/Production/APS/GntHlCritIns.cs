//PROJECT NAME: Production
//CLASS NAME: GntHlCritIns.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class GntHlCritIns : IGntHlCritIns
	{
		readonly IApplicationDB appDB;
		
		
		public GntHlCritIns(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) GntHlCritInsSp(string Highlightid,
		string Username,
		int? Seqnum,
		int? Type,
		int? Comparison,
		string Param,
		int? Color,
		int? CmpSubstr,
		int? CmpStart,
		int? CmpLength,
		string Infobar)
		{
			ApsGntHighlightType _Highlightid = Highlightid;
			UsernameType _Username = Username;
			ApsIntType _Seqnum = Seqnum;
			ApsIntType _Type = Type;
			ApsIntType _Comparison = Comparison;
			ApsMaxIDType _Param = Param;
			ApsIntType _Color = Color;
			ApsIntType _CmpSubstr = CmpSubstr;
			ApsIntType _CmpStart = CmpStart;
			ApsIntType _CmpLength = CmpLength;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GntHlCritInsSp";
				
				appDB.AddCommandParameter(cmd, "Highlightid", _Highlightid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Username", _Username, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Seqnum", _Seqnum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Comparison", _Comparison, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Param", _Param, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Color", _Color, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CmpSubstr", _CmpSubstr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CmpStart", _CmpStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CmpLength", _CmpLength, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
