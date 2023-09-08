//PROJECT NAME: Logistics
//CLASS NAME: AppmtValidateCheck.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class AppmtValidateCheck : IAppmtValidateCheck
	{
		readonly IApplicationDB appDB;
		
		
		public AppmtValidateCheck(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) AppmtValidateCheckSp(int? PNewRecord,
		string PBankCode,
		int? PCheckNum,
		string PPayType,
		int? PReapplication,
		string Infobar)
		{
			FlagNyType _PNewRecord = PNewRecord;
			BankCodeType _PBankCode = PBankCode;
			ApCheckNumType _PCheckNum = PCheckNum;
			LongListType _PPayType = PPayType;
			FlagNyType _PReapplication = PReapplication;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AppmtValidateCheckSp";
				
				appDB.AddCommandParameter(cmd, "PNewRecord", _PNewRecord, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBankCode", _PBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCheckNum", _PCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPayType", _PPayType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PReapplication", _PReapplication, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
