//PROJECT NAME: DataCollection
//CLASS NAME: WcLbrDcValidate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class WcLbrDcValidate : IWcLbrDcValidate
	{
		readonly IApplicationDB appDB;
		
		
		public WcLbrDcValidate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) WcLbrDcValidateSp(string Wc,
		decimal? AHrs,
		decimal? JobRate,
		string Infobar)
		{
			WcType _Wc = Wc;
			TotalHoursType _AHrs = AHrs;
			PayRateType _JobRate = JobRate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "WcLbrDcValidateSp";
				
				appDB.AddCommandParameter(cmd, "Wc", _Wc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AHrs", _AHrs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobRate", _JobRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
