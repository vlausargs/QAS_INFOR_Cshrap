//PROJECT NAME: CSITest
//CLASS NAME: CLM_XMLView.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Test
{
	public interface ICLM_XMLView
	{
		DataTable CLM_XMLViewSp(string TableName,
		                        string TableColumn);
	}
	
	public class CLM_XMLView : ICLM_XMLView
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		
		public CLM_XMLView(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
		}
		
		public DataTable CLM_XMLViewSp(string TableName,
		                               string TableColumn)
		{
			TableNameType _TableName = TableName;
			ColumnType _TableColumn = TableColumn;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_XMLViewSp";
				
				appDB.AddCommandParameter(cmd, "TableName", _TableName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TableColumn", _TableColumn, ParameterDirection.Input);

                dtReturn = appDB.ExecuteQuery(cmd);

                return dtReturn;
			}
		}
	}
}
