//PROJECT NAME: Logistics
//CLASS NAME: CustPriceIncludeTax.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CustPriceIncludeTax : ICustPriceIncludeTax
	{
		readonly IApplicationDB appDB;
		
		
		public CustPriceIncludeTax(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? CustIncludePrice) CustPriceIncludeTaxSp(string CustNum,
		int? CustSeq,
		int? CustIncludePrice,
		string PSite = null)
		{
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			ListYesNoType _CustIncludePrice = CustIncludePrice;
			SiteType _PSite = PSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CustPriceIncludeTaxSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustIncludePrice", _CustIncludePrice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CustIncludePrice = _CustIncludePrice;
				
				return (Severity, CustIncludePrice);
			}
		}
	}
}
