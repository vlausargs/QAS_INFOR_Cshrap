//PROJECT NAME: Logistics
//CLASS NAME: SSSFSConInvSubCalcProrate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSConInvSubCalcProrate : ISSSFSConInvSubCalcProrate
	{
		readonly IApplicationDB appDB;
		
		public SSSFSConInvSubCalcProrate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			DateTime? oEndDate,
			string Infobar) SSSFSConInvSubCalcProrateSp(
			DateTime? IRenewalDate,
			int? ITimes,
			DateTime? IBegdate,
			DateTime? oEndDate,
			string Infobar)
		{
			DateTimeType _IRenewalDate = IRenewalDate;
			IntType _ITimes = ITimes;
			DateTimeType _IBegdate = IBegdate;
			DateTimeType _oEndDate = oEndDate;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSConInvSubCalcProrateSp";
				
				appDB.AddCommandParameter(cmd, "IRenewalDate", _IRenewalDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ITimes", _ITimes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IBegdate", _IBegdate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "oEndDate", _oEndDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				oEndDate = _oEndDate;
				Infobar = _Infobar;
				
				return (Severity, oEndDate, Infobar);
			}
		}
	}
}
