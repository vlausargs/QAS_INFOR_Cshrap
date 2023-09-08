//PROJECT NAME: Production
//CLASS NAME: ProjLabrProjNumValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class ProjLabrProjNumValid : IProjLabrProjNumValid
	{
		readonly IApplicationDB appDB;
		
		public ProjLabrProjNumValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string ProjDesc,
			string Infobar) ProjLabrProjNumValidSp(
			string ProjNum,
			string ProjDesc,
			string Infobar)
		{
			ProjNumType _ProjNum = ProjNum;
			DescriptionType _ProjDesc = ProjDesc;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProjLabrProjNumValidSp";
				
				appDB.AddCommandParameter(cmd, "ProjNum", _ProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjDesc", _ProjDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ProjDesc = _ProjDesc;
				Infobar = _Infobar;
				
				return (Severity, ProjDesc, Infobar);
			}
		}
	}
}
