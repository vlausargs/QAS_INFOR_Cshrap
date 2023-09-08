//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBAcknowledge.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBAcknowledge
	{
		int LoadESBAcknowledgeSp(string BODID,
		                         string DocumentIDID,
		                         string ResponseExpression,
		                         ref string Infobar,
		                         string AlternateDocumentIDID);
	}
	
	public class LoadESBAcknowledge : ILoadESBAcknowledge
	{
		readonly IApplicationDB appDB;
		
		public LoadESBAcknowledge(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadESBAcknowledgeSp(string BODID,
		                                string DocumentIDID,
		                                string ResponseExpression,
		                                ref string Infobar,
		                                string AlternateDocumentIDID)
		{
			StringType _BODID = BODID;
			StringType _DocumentIDID = DocumentIDID;
			StringType _ResponseExpression = ResponseExpression;
			InfobarType _Infobar = Infobar;
			StringType _AlternateDocumentIDID = AlternateDocumentIDID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBAcknowledgeSp";
				
				appDB.AddCommandParameter(cmd, "BODID", _BODID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocumentIDID", _DocumentIDID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResponseExpression", _ResponseExpression, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AlternateDocumentIDID", _AlternateDocumentIDID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
