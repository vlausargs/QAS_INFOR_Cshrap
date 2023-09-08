//PROJECT NAME: Production
//CLASS NAME: ProjSetEffDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class ProjSetEffDate : IProjSetEffDate
	{
		readonly IApplicationDB appDB;
		
		
		public ProjSetEffDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ProjSetEffDateSp(string ProjNum,
		int? ProjTaskNum,
		DateTime? NewEffDate,
		string Infobar)
		{
			ProjNumType _ProjNum = ProjNum;
			TaskNumType _ProjTaskNum = ProjTaskNum;
			DateType _NewEffDate = NewEffDate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProjSetEffDateSp";
				
				appDB.AddCommandParameter(cmd, "ProjNum", _ProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjTaskNum", _ProjTaskNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewEffDate", _NewEffDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
