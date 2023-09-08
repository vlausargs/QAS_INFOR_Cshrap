//PROJECT NAME: Data
//CLASS NAME: EuroCustProjMs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EuroCustProjMs : IEuroCustProjMs
	{
		readonly IApplicationDB appDB;
		
		public EuroCustProjMs(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? EuroCustProjMsSp(
			Guid? pProjRowPointer,
			int? pToCurrencyPlaces,
			int? pForToEuro)
		{
			RowPointerType _pProjRowPointer = pProjRowPointer;
			DecimalPlacesType _pToCurrencyPlaces = pToCurrencyPlaces;
			DecimalPlacesType _pForToEuro = pForToEuro;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EuroCustProjMsSp";
				
				appDB.AddCommandParameter(cmd, "pProjRowPointer", _pProjRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pToCurrencyPlaces", _pToCurrencyPlaces, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pForToEuro", _pForToEuro, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
