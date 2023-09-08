//PROJECT NAME: Logistics
//CLASS NAME: GetUMConvFactor.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetUMConvFactor : IGetUMConvFactor
	{
		readonly IApplicationDB appDB;
		
		public GetUMConvFactor(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? UomConvConvFactor,
			string Infobar) GetUMConvFactorSp(
			string FromUM,
			string ToUM,
			decimal? UomConvConvFactor,
			string Infobar)
		{
			UMType _FromUM = FromUM;
			UMType _ToUM = ToUM;
			UMConvFactorType _UomConvConvFactor = UomConvConvFactor;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetUMConvFactorSp";
				
				appDB.AddCommandParameter(cmd, "FromUM", _FromUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToUM", _ToUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UomConvConvFactor", _UomConvConvFactor, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				UomConvConvFactor = _UomConvConvFactor;
				Infobar = _Infobar;
				
				return (Severity, UomConvConvFactor, Infobar);
			}
		}
	}
}
