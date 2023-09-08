//PROJECT NAME: Material
//CLASS NAME: ValidateSchRcvDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class ValidateSchRcvDate : IValidateSchRcvDate
	{
		readonly IApplicationDB appDB;
		
		
		public ValidateSchRcvDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, DateTime? TSchShipDate,
		string Infobar) ValidateSchRcvDateSp(string SourceTrnNum,
		DateTime? TSchRcvDate,
		DateTime? TSchShipDate,
		string Infobar)
		{
			TrnNumType _SourceTrnNum = SourceTrnNum;
			DateType _TSchRcvDate = TSchRcvDate;
			DateType _TSchShipDate = TSchShipDate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateSchRcvDateSp";
				
				appDB.AddCommandParameter(cmd, "SourceTrnNum", _SourceTrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TSchRcvDate", _TSchRcvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TSchShipDate", _TSchShipDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TSchShipDate = _TSchShipDate;
				Infobar = _Infobar;
				
				return (Severity, TSchShipDate, Infobar);
			}
		}
	}
}
