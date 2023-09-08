//PROJECT NAME: Codes
//CLASS NAME: InsertCurrency.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class InsertCurrency : IInsertCurrency
	{
		readonly IApplicationDB appDB;
		
		
		public InsertCurrency(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? InsertCurrencySp(string CurrCode)
		{
			CurrCodeType _CurrCode = CurrCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InsertCurrencySp";
				
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
