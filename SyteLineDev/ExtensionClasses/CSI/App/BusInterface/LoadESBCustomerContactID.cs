//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBCustomerContactID.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBCustomerContactID
	{
		int LoadESBCustomerContactIDSp(string ContactID,
		                               ref string Infobar);
	}
	
	public class LoadESBCustomerContactID : ILoadESBCustomerContactID
	{
		readonly IApplicationDB appDB;
		
		public LoadESBCustomerContactID(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadESBCustomerContactIDSp(string ContactID,
		                                      ref string Infobar)
		{
			LongListType _ContactID = ContactID;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBCustomerContactIDSp";
				
				appDB.AddCommandParameter(cmd, "ContactID", _ContactID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
