//PROJECT NAME: Logistics
//CLASS NAME: SumPo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class SumPo : ISumPo
	{
		readonly IApplicationDB appDB;
		
		
		public SumPo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SumPoSp(string PoNum,
		string Infobar,
		int? CurrencyPlaces = null,
		string PoVendLcrNum = null,
		string PoVendNum = null)
		{
			PoNumType _PoNum = PoNum;
			Infobar _Infobar = Infobar;
			DecimalPlacesType _CurrencyPlaces = CurrencyPlaces;
			VendLcrNumType _PoVendLcrNum = PoVendLcrNum;
			VendNumType _PoVendNum = PoVendNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SumPoSp";
				
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurrencyPlaces", _CurrencyPlaces, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoVendLcrNum", _PoVendLcrNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoVendNum", _PoVendNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
