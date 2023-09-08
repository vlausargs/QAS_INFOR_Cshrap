//PROJECT NAME: Logistics
//CLASS NAME: AddARDueDateSeq.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class AddARDueDateSeq : IAddARDueDateSeq
	{
		readonly IApplicationDB appDB;
		
		
		public AddARDueDateSeq(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) AddARDueDateSeqSp(string pCustNum,
		string pInvNum,
		int? pInvSeq,
		DateTime? pInvoiceDate,
		string pTermsCode,
		int? pMultiDueDateFlag,
		string Infobar)
		{
			CustNumType _pCustNum = pCustNum;
			InvNumType _pInvNum = pInvNum;
			ArInvSeqType _pInvSeq = pInvSeq;
			GenericDateType _pInvoiceDate = pInvoiceDate;
			TermsCodeType _pTermsCode = pTermsCode;
			FlagNyType _pMultiDueDateFlag = pMultiDueDateFlag;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AddARDueDateSeqSp";
				
				appDB.AddCommandParameter(cmd, "pCustNum", _pCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pInvNum", _pInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pInvSeq", _pInvSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pInvoiceDate", _pInvoiceDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTermsCode", _pTermsCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pMultiDueDateFlag", _pMultiDueDateFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
