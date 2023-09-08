//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBCaptureDocumentField.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBCaptureDocumentField
	{
		int LoadESBCaptureDocumentFieldSp(string DerBODID,
		                                  string ActionExpression,
		                                  string FieldName,
		                                  string FieldValue,
		                                  ref string Infobar);
	}
	
	public class LoadESBCaptureDocumentField : ILoadESBCaptureDocumentField
	{
		readonly IApplicationDB appDB;
		
		public LoadESBCaptureDocumentField(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadESBCaptureDocumentFieldSp(string DerBODID,
		                                         string ActionExpression,
		                                         string FieldName,
		                                         string FieldValue,
		                                         ref string Infobar)
		{
			LongListType _DerBODID = DerBODID;
			StringType _ActionExpression = ActionExpression;
			StringType _FieldName = FieldName;
			StringType _FieldValue = FieldValue;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBCaptureDocumentFieldSp";
				
				appDB.AddCommandParameter(cmd, "DerBODID", _DerBODID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ActionExpression", _ActionExpression, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FieldName", _FieldName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FieldValue", _FieldValue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
