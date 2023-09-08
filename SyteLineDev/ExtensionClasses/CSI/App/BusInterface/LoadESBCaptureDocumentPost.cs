//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBCaptureDocumentPost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBCaptureDocumentPost
	{
		int LoadESBCaptureDocumentPostSp(string DocumentID,
		                                 ref string Infobar);
	}
	
	public class LoadESBCaptureDocumentPost : ILoadESBCaptureDocumentPost
	{
		readonly IApplicationDB appDB;
		
		public LoadESBCaptureDocumentPost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadESBCaptureDocumentPostSp(string DocumentID,
		                                        ref string Infobar)
		{
			StringType _DocumentID = DocumentID;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBCaptureDocumentPostSp";
				
				appDB.AddCommandParameter(cmd, "DocumentID", _DocumentID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
