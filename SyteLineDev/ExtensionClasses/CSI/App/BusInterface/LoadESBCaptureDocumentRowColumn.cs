//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBCaptureDocumentRowColumn.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBCaptureDocumentRowColumn
	{
		int LoadESBCaptureDocumentRowColumnSp(string DerBODID,
		                                      string ActionExpression,
		                                      int? RowID,
		                                      string ColumnName,
		                                      string ColumnValue,
		                                      ref string Infobar);
	}
	
	public class LoadESBCaptureDocumentRowColumn : ILoadESBCaptureDocumentRowColumn
	{
		readonly IApplicationDB appDB;
		
		public LoadESBCaptureDocumentRowColumn(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadESBCaptureDocumentRowColumnSp(string DerBODID,
		                                             string ActionExpression,
		                                             int? RowID,
		                                             string ColumnName,
		                                             string ColumnValue,
		                                             ref string Infobar)
		{
			LongListType _DerBODID = DerBODID;
			StringType _ActionExpression = ActionExpression;
			IntType _RowID = RowID;
			LongListType _ColumnName = ColumnName;
			LongListType _ColumnValue = ColumnValue;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBCaptureDocumentRowColumnSp";
				
				appDB.AddCommandParameter(cmd, "DerBODID", _DerBODID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ActionExpression", _ActionExpression, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowID", _RowID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ColumnName", _ColumnName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ColumnValue", _ColumnValue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
