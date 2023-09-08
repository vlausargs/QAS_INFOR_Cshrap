//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadProcessQuoteLinePost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadProcessQuoteLinePost
	{
		int LoadProcessQuoteLinePostSp(string ExternalConfirmationRef,
		                               ref string Infobar);
	}
	
	public class LoadProcessQuoteLinePost : ILoadProcessQuoteLinePost
	{
		readonly IApplicationDB appDB;
		
		public LoadProcessQuoteLinePost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadProcessQuoteLinePostSp(string ExternalConfirmationRef,
		                                      ref string Infobar)
		{
			OrderConfirmationRefType _ExternalConfirmationRef = ExternalConfirmationRef;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadProcessQuoteLinePostSp";
				
				appDB.AddCommandParameter(cmd, "ExternalConfirmationRef", _ExternalConfirmationRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
