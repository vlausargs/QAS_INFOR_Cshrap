//PROJECT NAME: Logistics
//CLASS NAME: UpdateOldInvoiceNum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class UpdateOldInvoiceNum : IUpdateOldInvoiceNum
	{
		readonly IApplicationDB appDB;
		
		
		public UpdateOldInvoiceNum(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? UpdateOldInvoiceNumSp(int? InvLength)
		{
			InvNumLength _InvLength = InvLength;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UpdateOldInvoiceNumSp";
				
				appDB.AddCommandParameter(cmd, "InvLength", _InvLength, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
