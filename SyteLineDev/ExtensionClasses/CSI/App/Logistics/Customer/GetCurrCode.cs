//PROJECT NAME: CSICustomer
//CLASS NAME: GetCurrCode.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IGetCurrCode
	{
		int GetCurrCodeSp(string CustNum,
		                  ref string CurrCode);
	}
	
	public class GetCurrCode : IGetCurrCode
	{
		readonly IApplicationDB appDB;
		
		public GetCurrCode(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetCurrCodeSp(string CustNum,
		                         ref string CurrCode)
		{
			CustNumType _CustNum = CustNum;
			CurrCodeType _CurrCode = CurrCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetCurrCodeSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CurrCode = _CurrCode;
				
				return Severity;
			}
		}
	}
}
