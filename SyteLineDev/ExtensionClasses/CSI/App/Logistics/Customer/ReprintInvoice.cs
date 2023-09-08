//PROJECT NAME: CSICustomer
//CLASS NAME: ReprintInvoice.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IReprintInvoice
	{
		int ReprintInvoiceSp(string InvNum,
		                     string BillType,
		                     string UserName1,
		                     string LangCode);
	}
	
	public class ReprintInvoice : IReprintInvoice
	{
		readonly IApplicationDB appDB;
		
		public ReprintInvoice(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int ReprintInvoiceSp(string InvNum,
		                            string BillType,
		                            string UserName1,
		                            string LangCode)
		{
			InvNumType _InvNum = InvNum;
			BillingTypeType _BillType = BillType;
			UsernameType _UserName1 = UserName1;
			LangCodeType _LangCode = LangCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ReprintInvoiceSp";
				
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BillType", _BillType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserName1", _UserName1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LangCode", _LangCode, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return Severity;
			}
		}
	}
}
