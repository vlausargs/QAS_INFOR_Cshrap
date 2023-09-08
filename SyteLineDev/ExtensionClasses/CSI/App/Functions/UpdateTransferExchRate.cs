//PROJECT NAME: Data
//CLASS NAME: UpdateTransferExchRate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class UpdateTransferExchRate : IUpdateTransferExchRate
	{
		readonly IApplicationDB appDB;
		
		public UpdateTransferExchRate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) UpdateTransferExchRateSp(
			string FromSite,
			string ToSite,
			decimal? ExchRate,
			string Infobar)
		{
			SiteType _FromSite = FromSite;
			SiteType _ToSite = ToSite;
			ExchRateType _ExchRate = ExchRate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UpdateTransferExchRateSp";
				
				appDB.AddCommandParameter(cmd, "FromSite", _FromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSite", _ToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExchRate", _ExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
