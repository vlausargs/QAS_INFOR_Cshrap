//PROJECT NAME: Logistics
//CLASS NAME: ConvertToDomestic.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class ConvertToDomestic : IConvertToDomestic
	{
		readonly IApplicationDB appDB;
		
		
		public ConvertToDomestic(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? PPlanCostDom,
		string Infobar) ConvertToDomesticSp(string PVendNum,
		string PCurrCode,
		decimal? PPlanCostDom,
		string Infobar)
		{
			VendNumType _PVendNum = PVendNum;
			CurrCodeType _PCurrCode = PCurrCode;
			CostPrcType _PPlanCostDom = PPlanCostDom;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ConvertToDomesticSp";
				
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurrCode", _PCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPlanCostDom", _PPlanCostDom, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PPlanCostDom = _PPlanCostDom;
				Infobar = _Infobar;
				
				return (Severity, PPlanCostDom, Infobar);
			}
		}
	}
}
