//PROJECT NAME: Config
//CLASS NAME: CfgGetPricingInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Config
{
	public class CfgGetPricingInfo : ICfgGetPricingInfo
	{
		readonly IApplicationDB appDB;
		
		
		public CfgGetPricingInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? pDoPricing,
		int? pUseModelPrice,
		decimal? pBasePrice,
		string Infobar) CfgGetPricingInfoSp(string pConfigId,
		int? pDoPricing,
		int? pUseModelPrice,
		decimal? pBasePrice,
		string Infobar)
		{
			ConfigIdType _pConfigId = pConfigId;
			FlagNyType _pDoPricing = pDoPricing;
			FlagNyType _pUseModelPrice = pUseModelPrice;
			CostPrcType _pBasePrice = pBasePrice;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CfgGetPricingInfoSp";
				
				appDB.AddCommandParameter(cmd, "pConfigId", _pConfigId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pDoPricing", _pDoPricing, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pUseModelPrice", _pUseModelPrice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pBasePrice", _pBasePrice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				pDoPricing = _pDoPricing;
				pUseModelPrice = _pUseModelPrice;
				pBasePrice = _pBasePrice;
				Infobar = _Infobar;
				
				return (Severity, pDoPricing, pUseModelPrice, pBasePrice, Infobar);
			}
		}
	}
}
