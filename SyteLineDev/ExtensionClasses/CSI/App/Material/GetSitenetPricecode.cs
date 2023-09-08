//PROJECT NAME: Material
//CLASS NAME: GetSitenetPricecode.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IGetSitenetPricecode
	{
		(int? ReturnCode, string Pricecode) GetSitenetPricecodeSp(string FromSite,
		string ToSite,
		string Pricecode);
	}
	
	public class GetSitenetPricecode : IGetSitenetPricecode
	{
		readonly IApplicationDB appDB;
		
		public GetSitenetPricecode(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Pricecode) GetSitenetPricecodeSp(string FromSite,
		string ToSite,
		string Pricecode)
		{
			SiteType _FromSite = FromSite;
			SiteType _ToSite = ToSite;
			PriceCodeType _Pricecode = Pricecode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetSitenetPricecodeSp";
				
				appDB.AddCommandParameter(cmd, "FromSite", _FromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSite", _ToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Pricecode", _Pricecode, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Pricecode = _Pricecode;
				
				return (Severity, Pricecode);
			}
		}
	}
}
