//PROJECT NAME: Codes
//CLASS NAME: UpdateWizardSettingData.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class UpdateWizardSettingData : IUpdateWizardSettingData
	{
		readonly IApplicationDB appDB;
		
		
		public UpdateWizardSettingData(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) UpdateWizardSettingDataSP(string TableName,
		string RowData,
		string Infobar)
		{
			TableNameType _TableName = TableName;
			XMLStringType _RowData = RowData;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UpdateWizardSettingDataSP";
				
				appDB.AddCommandParameter(cmd, "TableName", _TableName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowData", _RowData, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
