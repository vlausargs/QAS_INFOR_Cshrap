//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ReprintProjectInvoiceHeader.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_ReprintProjectInvoiceHeader : IRpt_ReprintProjectInvoiceHeader
	{
		readonly IApplicationDB appDB;
		
		public Rpt_ReprintProjectInvoiceHeader(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? Rpt_ReprintProjectInvoiceHeaderSp(
			string InvNum,
			int? TransDomCurr,
			int? PrintCustomerNotes,
			int? ShowInternal = 1,
			int? ShowExternal = 1,
			int? PrintDiscountAmt = 0)
		{
			InvNumType _InvNum = InvNum;
			ListYesNoType _TransDomCurr = TransDomCurr;
			ListYesNoType _PrintCustomerNotes = PrintCustomerNotes;
			ListYesNoType _ShowInternal = ShowInternal;
			ListYesNoType _ShowExternal = ShowExternal;
			ListYesNoType _PrintDiscountAmt = PrintDiscountAmt;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ReprintProjectInvoiceHeaderSp";
				
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDomCurr", _TransDomCurr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintCustomerNotes", _PrintCustomerNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowInternal", _ShowInternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowExternal", _ShowExternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintDiscountAmt", _PrintDiscountAmt, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
