//PROJECT NAME: POS
//CLASS NAME: SSSPOSValidatePayment.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.POS
{
	public class SSSPOSValidatePayment : ISSSPOSValidatePayment
	{
		readonly IApplicationDB appDB;
		
		public SSSPOSValidatePayment(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) SSSPOSValidatePaymentSp(
			string POSMCustNum,
			int? POSMCustSeq,
			string POSMPaymentPayType,
			string POSMOrdType,
			string Infobar)
		{
			CustNumType _POSMCustNum = POSMCustNum;
			CustSeqType _POSMCustSeq = POSMCustSeq;
			POSMPayTypeType _POSMPaymentPayType = POSMPaymentPayType;
			POSMOrdTypeType _POSMOrdType = POSMOrdType;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSPOSValidatePaymentSp";
				
				appDB.AddCommandParameter(cmd, "POSMCustNum", _POSMCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMCustSeq", _POSMCustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMPaymentPayType", _POSMPaymentPayType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMOrdType", _POSMOrdType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
