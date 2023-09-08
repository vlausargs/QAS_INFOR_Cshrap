//PROJECT NAME: Material
//CLASS NAME: McalDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class McalDate : IMcalDate
	{
		readonly IApplicationDB appDB;
		
		
		public McalDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, DateTime? McalFirst,
		DateTime? McalLast,
		string Infobar) McalDateSp(DateTime? McalFirst,
		DateTime? McalLast,
		string Infobar)
		{
			DateType _McalFirst = McalFirst;
			DateType _McalLast = McalLast;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "McalDateSp";
				
				appDB.AddCommandParameter(cmd, "McalFirst", _McalFirst, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "McalLast", _McalLast, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				McalFirst = _McalFirst;
				McalLast = _McalLast;
				Infobar = _Infobar;
				
				return (Severity, McalFirst, McalLast, Infobar);
			}
		}
	}
}
