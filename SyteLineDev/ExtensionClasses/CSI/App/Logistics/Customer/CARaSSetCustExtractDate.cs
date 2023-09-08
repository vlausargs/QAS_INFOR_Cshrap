//PROJECT NAME: CSICustomer
//CLASS NAME: CARaSSetCustExtractDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface ICARaSSetCustExtractDate
	{
		int CARaSSetCustExtractDateSp(string StartCustNum,
		                              string EndCustNum,
		                              byte? ExtractAll,
		                              DateTime? ExtractDate);
	}
	
	public class CARaSSetCustExtractDate : ICARaSSetCustExtractDate
	{
		readonly IApplicationDB appDB;
		
		public CARaSSetCustExtractDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CARaSSetCustExtractDateSp(string StartCustNum,
		                                     string EndCustNum,
		                                     byte? ExtractAll,
		                                     DateTime? ExtractDate)
		{
			CustNumType _StartCustNum = StartCustNum;
			CustNumType _EndCustNum = EndCustNum;
			FlagNyType _ExtractAll = ExtractAll;
			DateTimeType _ExtractDate = ExtractDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CARaSSetCustExtractDateSp";
				
				appDB.AddCommandParameter(cmd, "StartCustNum", _StartCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCustNum", _EndCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExtractAll", _ExtractAll, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExtractDate", _ExtractDate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return Severity;
			}
		}
	}
}
