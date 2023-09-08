//PROJECT NAME: Logistics
//CLASS NAME: AppmtGetNextCheck.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class AppmtGetNextCheck : IAppmtGetNextCheck
	{
		readonly IApplicationDB appDB;
		
		
		public AppmtGetNextCheck(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? PNextCheck) AppmtGetNextCheckSp(string PBankCode,
		string PPayType,
		int? PNextCheck)
		{
			BankCodeType _PBankCode = PBankCode;
			AppmtPayTypeType _PPayType = PPayType;
			ApCheckNumType _PNextCheck = PNextCheck;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AppmtGetNextCheckSp";
				
				appDB.AddCommandParameter(cmd, "PBankCode", _PBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPayType", _PPayType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNextCheck", _PNextCheck, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PNextCheck = _PNextCheck;
				
				return (Severity, PNextCheck);
			}
		}
	}
}
