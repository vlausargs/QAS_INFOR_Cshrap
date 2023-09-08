//PROJECT NAME: Production
//CLASS NAME: PmfGetRowPointerFromColValues.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfGetRowPointerFromColValues
	{
		(int? ReturnCode, Guid? RowPointer,
		string InfoBar) PmfGetRowPointerFromColValuesSp(string TableName,
		string IdColumn1,
		string Value1,
		string IdColumn2 = null,
		string Value2 = null,
		string IdColumn3 = null,
		string Value3 = null,
		Guid? RowPointer = null,
		string InfoBar = null);
	}
	
	public class PmfGetRowPointerFromColValues : IPmfGetRowPointerFromColValues
	{
		readonly IApplicationDB appDB;
		
		public PmfGetRowPointerFromColValues(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, Guid? RowPointer,
		string InfoBar) PmfGetRowPointerFromColValuesSp(string TableName,
		string IdColumn1,
		string Value1,
		string IdColumn2 = null,
		string Value2 = null,
		string IdColumn3 = null,
		string Value3 = null,
		Guid? RowPointer = null,
		string InfoBar = null)
		{
			StringType _TableName = TableName;
			StringType _IdColumn1 = IdColumn1;
			StringType _Value1 = Value1;
			StringType _IdColumn2 = IdColumn2;
			StringType _Value2 = Value2;
			StringType _IdColumn3 = IdColumn3;
			StringType _Value3 = Value3;
			RowPointerType _RowPointer = RowPointer;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfGetRowPointerFromColValuesSp";
				
				appDB.AddCommandParameter(cmd, "TableName", _TableName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IdColumn1", _IdColumn1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Value1", _Value1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IdColumn2", _IdColumn2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Value2", _Value2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IdColumn3", _IdColumn3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Value3", _Value3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RowPointer = _RowPointer;
				InfoBar = _InfoBar;
				
				return (Severity, RowPointer, InfoBar);
			}
		}
	}
}
