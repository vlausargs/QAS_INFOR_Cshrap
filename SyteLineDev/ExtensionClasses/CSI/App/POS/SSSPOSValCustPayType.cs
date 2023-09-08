//PROJECT NAME: POS
//CLASS NAME: SSSPOSValCustPayType.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.POS
{
	public class SSSPOSValCustPayType : ISSSPOSValCustPayType
	{
		readonly IApplicationDB appDB;
		
		public SSSPOSValCustPayType(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? IsValid) SSSPOSValCustPayTypeSp(
			string CustNum = null,
			string PayType = null,
			int? IsValid = null)
		{
			CustNumType _CustNum = CustNum;
			FSPayTypeType _PayType = PayType;
			ListYesNoType _IsValid = IsValid;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSPOSValCustPayTypeSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PayType", _PayType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IsValid", _IsValid, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				IsValid = _IsValid;
				
				return (Severity, IsValid);
			}
		}
	}
}
