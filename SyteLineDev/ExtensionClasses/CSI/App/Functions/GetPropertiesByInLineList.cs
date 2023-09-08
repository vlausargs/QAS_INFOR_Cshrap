//PROJECT NAME: Data
//CLASS NAME: GetPropertiesByInLineList.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetPropertiesByInLineList : IGetPropertiesByInLineList
	{
		readonly IApplicationDB appDB;
		
		public GetPropertiesByInLineList(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string DynamicSQL) GetPropertiesByInLineListSp(
			string InLineList,
			string KeyValue = null,
			string DynamicSQL = null)
		{
			InlineListType _InLineList = InLineList;
			DimensionValueType _KeyValue = KeyValue;
			NoteType _DynamicSQL = DynamicSQL;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetPropertiesByInLineListSp";
				
				appDB.AddCommandParameter(cmd, "InLineList", _InLineList, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "KeyValue", _KeyValue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DynamicSQL", _DynamicSQL, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DynamicSQL = _DynamicSQL;
				
				return (Severity, DynamicSQL);
			}
		}
	}
}
