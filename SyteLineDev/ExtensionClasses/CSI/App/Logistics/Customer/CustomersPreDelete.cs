//PROJECT NAME: CSICustomer
//CLASS NAME: CustomersPreDelete.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface ICustomersPreDelete
	{
		int CustomersPreDeleteSp(string PCustNum,
		                         int? PCustSeq,
		                         ref string Infobar);
	}
	
	public class CustomersPreDelete : ICustomersPreDelete
	{
		readonly IApplicationDB appDB;
		
		public CustomersPreDelete(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CustomersPreDeleteSp(string PCustNum,
		                                int? PCustSeq,
		                                ref string Infobar)
		{
			CustNumType _PCustNum = PCustNum;
			CustSeqType _PCustSeq = PCustSeq;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CustomersPreDeleteSp";
				
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustSeq", _PCustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
