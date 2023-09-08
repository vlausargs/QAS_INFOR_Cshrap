//PROJECT NAME: Data
//CLASS NAME: EuroCustSumCo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EuroCustSumCo : IEuroCustSumCo
	{
		readonly IApplicationDB appDB;
		
		public EuroCustSumCo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? EuroCustSumCoSp(
			string pUpdateOrderType,
			string pCoNum,
			int? pCurrencyPlaces)
		{
			StringType _pUpdateOrderType = pUpdateOrderType;
			CoNumType _pCoNum = pCoNum;
			DecimalPlacesType _pCurrencyPlaces = pCurrencyPlaces;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EuroCustSumCoSp";
				
				appDB.AddCommandParameter(cmd, "pUpdateOrderType", _pUpdateOrderType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCoNum", _pCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCurrencyPlaces", _pCurrencyPlaces, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
