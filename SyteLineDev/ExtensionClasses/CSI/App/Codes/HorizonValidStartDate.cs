//PROJECT NAME: CSICodes
//CLASS NAME: HorizonValidStartDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Codes
{
	public interface IHorizonValidStartDate
	{
		int HorizonValidStartDateSp(DateTime? PStartDate,
		                            ref string Infobar);
	}
	
	public class HorizonValidStartDate : IHorizonValidStartDate
	{
		readonly IApplicationDB appDB;
		
		public HorizonValidStartDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int HorizonValidStartDateSp(DateTime? PStartDate,
		                                   ref string Infobar)
		{
			CurrentDateType _PStartDate = PStartDate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "HorizonValidStartDateSp";
				
				appDB.AddCommandParameter(cmd, "PStartDate", _PStartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
