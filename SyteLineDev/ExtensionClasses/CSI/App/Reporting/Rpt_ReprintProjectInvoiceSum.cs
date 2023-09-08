//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ReprintProjectInvoiceSum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_ReprintProjectInvoiceSum : IRpt_ReprintProjectInvoiceSum
	{
		readonly IApplicationDB appDB;
		
		public Rpt_ReprintProjectInvoiceSum(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? Rpt_ReprintProjectInvoiceSumSp(
			string InvNum,
			string BeginInvNum,
			int? TransDomCurr)
		{
			InvNumType _InvNum = InvNum;
			InvNumType _BeginInvNum = BeginInvNum;
			ListYesNoType _TransDomCurr = TransDomCurr;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ReprintProjectInvoiceSumSp";
				
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BeginInvNum", _BeginInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDomCurr", _TransDomCurr, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
