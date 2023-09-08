//PROJECT NAME: Finance
//CLASS NAME: MXValidateCMToInvoice.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.Mexican
{
	public class MXValidateCMToInvoice : IMXValidateCMToInvoice
	{
		readonly IApplicationDB appDB;
		
		public MXValidateCMToInvoice(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) MXValidateCMToInvoiceSp(
			string InvNum,
			string CustNum,
			decimal? CMAmt,
			string Infobar)
		{
			InvNumType _InvNum = InvNum;
			CustNumType _CustNum = CustNum;
			AmountType _CMAmt = CMAmt;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MXValidateCMToInvoiceSp";
				
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CMAmt", _CMAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
