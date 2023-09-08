//PROJECT NAME: Logistics
//CLASS NAME: AppmtValidatePayment.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class AppmtValidatePayment : IAppmtValidatePayment
	{
		readonly IApplicationDB appDB;
		
		
		public AppmtValidatePayment(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) AppmtValidatePaymentSp(string PVendNum,
		int? PCheckSeq,
		string PBankCode,
		int? PReapplication,
		string Infobar)
		{
			VendNumType _PVendNum = PVendNum;
			ApCheckSeqType _PCheckSeq = PCheckSeq;
			BankCodeType _PBankCode = PBankCode;
			FlagNyType _PReapplication = PReapplication;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AppmtValidatePaymentSp";
				
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCheckSeq", _PCheckSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBankCode", _PBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PReapplication", _PReapplication, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
