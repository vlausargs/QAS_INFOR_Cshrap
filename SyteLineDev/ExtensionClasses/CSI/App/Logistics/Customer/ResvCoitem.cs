//PROJECT NAME: Logistics
//CLASS NAME: ResvCoitem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ResvCoitem : IResvCoitem
	{
		readonly IApplicationDB appDB;
		
		
		public ResvCoitem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ResvCoitemSp(string CurCoNum,
		int? CurCoLine,
		int? CurCoRel,
		string Infobar)
		{
			CoNumType _CurCoNum = CurCoNum;
			CoLineType _CurCoLine = CurCoLine;
			CoReleaseType _CurCoRel = CurCoRel;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ResvCoitemSp";
				
				appDB.AddCommandParameter(cmd, "CurCoNum", _CurCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurCoLine", _CurCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurCoRel", _CurCoRel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
