//PROJECT NAME: Production
//CLASS NAME: ProjContRev1.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class ProjContRev1 : IProjContRev1
	{
		readonly IApplicationDB appDB;
		
		public ProjContRev1(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ProjContRev1Sp(
			string PProjNum,
			int? PTaskNum,
			string PCustNum,
			decimal? PContRev,
			string Infobar)
		{
			ProjNumType _PProjNum = PProjNum;
			TaskNumType _PTaskNum = PTaskNum;
			CustNumType _PCustNum = PCustNum;
			AmtTotType _PContRev = PContRev;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProjContRev1Sp";
				
				appDB.AddCommandParameter(cmd, "PProjNum", _PProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTaskNum", _PTaskNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PContRev", _PContRev, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
