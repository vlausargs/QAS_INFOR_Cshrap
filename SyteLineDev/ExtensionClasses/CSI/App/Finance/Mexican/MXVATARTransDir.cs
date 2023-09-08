//PROJECT NAME: Finance
//CLASS NAME: MXVATARTransDir.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.Mexican
{
	public class MXVATARTransDir : IMXVATARTransDir
	{
		readonly IApplicationDB appDB;
		
		public MXVATARTransDir(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) MXVATARTransDirSp(
			int? PCheckNum = null,
			string PCustNum = null,
			string Infobar = null)
		{
			ArCheckNumType _PCheckNum = PCheckNum;
			CustNumType _PCustNum = PCustNum;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MXVATARTransDirSp";
				
				appDB.AddCommandParameter(cmd, "PCheckNum", _PCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
