//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadProcessSalesOrderLinePost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadProcessSalesOrderLinePost
	{
		int LoadProcessSalesOrderLinePostSp(string ExternalConfirmationRef,
		                                    ref string Infobar);
	}
	
	public class LoadProcessSalesOrderLinePost : ILoadProcessSalesOrderLinePost
	{
		readonly IApplicationDB appDB;
		
		public LoadProcessSalesOrderLinePost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadProcessSalesOrderLinePostSp(string ExternalConfirmationRef,
		                                           ref string Infobar)
		{
			OrderConfirmationRefType _ExternalConfirmationRef = ExternalConfirmationRef;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadProcessSalesOrderLinePostSp";
				
				appDB.AddCommandParameter(cmd, "ExternalConfirmationRef", _ExternalConfirmationRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
