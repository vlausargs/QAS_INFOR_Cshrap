//PROJECT NAME: CSICodes
//CLASS NAME: GetTaxParmsTaxRegNum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Codes
{
	public interface IGetTaxParmsTaxRegNum
	{
		int GetTaxParmsTaxRegNumSp(ref string TaxRegNum);
	}
	
	public class GetTaxParmsTaxRegNum : IGetTaxParmsTaxRegNum
	{
		readonly IApplicationDB appDB;
		
		public GetTaxParmsTaxRegNum(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetTaxParmsTaxRegNumSp(ref string TaxRegNum)
		{
			TaxRegNumType _TaxRegNum = TaxRegNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetTaxParmsTaxRegNumSp";
				
				appDB.AddCommandParameter(cmd, "TaxRegNum", _TaxRegNum, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TaxRegNum = _TaxRegNum;
				
				return Severity;
			}
		}
	}
}
