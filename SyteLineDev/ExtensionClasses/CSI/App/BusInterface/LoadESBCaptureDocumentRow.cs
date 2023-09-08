//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBCaptureDocumentRow.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBCaptureDocumentRow
	{
		int LoadESBCaptureDocumentRowSp(string DerBODID,
		                                string ActionExpression,
		                                int? RowID,
		                                ref string Infobar);
	}
	
	public class LoadESBCaptureDocumentRow : ILoadESBCaptureDocumentRow
	{
		readonly IApplicationDB appDB;
		
		public LoadESBCaptureDocumentRow(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadESBCaptureDocumentRowSp(string DerBODID,
		                                       string ActionExpression,
		                                       int? RowID,
		                                       ref string Infobar)
		{
			LongListType _DerBODID = DerBODID;
			StringType _ActionExpression = ActionExpression;
			IntType _RowID = RowID;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBCaptureDocumentRowSp";
				
				appDB.AddCommandParameter(cmd, "DerBODID", _DerBODID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ActionExpression", _ActionExpression, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowID", _RowID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
