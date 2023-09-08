//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBCaptureDocument.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBCaptureDocument
	{
		int LoadESBCaptureDocumentSp(string DerBODID,
		                             string ActionExpression,
		                             string AlternateID,
		                             ref string Infobar);
	}
	
	public class LoadESBCaptureDocument : ILoadESBCaptureDocument
	{
		readonly IApplicationDB appDB;
		
		public LoadESBCaptureDocument(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadESBCaptureDocumentSp(string DerBODID,
		                                    string ActionExpression,
		                                    string AlternateID,
		                                    ref string Infobar)
		{
			LongListType _DerBODID = DerBODID;
			StringType _ActionExpression = ActionExpression;
			LongListType _AlternateID = AlternateID;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBCaptureDocumentSp";
				
				appDB.AddCommandParameter(cmd, "DerBODID", _DerBODID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ActionExpression", _ActionExpression, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlternateID", _AlternateID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
