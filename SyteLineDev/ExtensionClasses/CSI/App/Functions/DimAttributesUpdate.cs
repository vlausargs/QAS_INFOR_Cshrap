//PROJECT NAME: Data
//CLASS NAME: DimAttributesUpdate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class DimAttributesUpdate : IDimAttributesUpdate
	{
		readonly IApplicationDB appDB;
		
		public DimAttributesUpdate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? DimAttributesUpdateSp(
			string ObjectName,
			Guid? TableRowPointer,
			string Dimension,
			string AccountStarting,
			string AccountEnding,
			int? UpdateAnalysisAttributes = 1,
			string FilterString = null,
			int? CommitSize = null,
			int? Debug = null,
			int? TaskID = null)
		{
			DimensionObjectType _ObjectName = ObjectName;
			RowPointerType _TableRowPointer = TableRowPointer;
			DimensionNameType _Dimension = Dimension;
			AcctType _AccountStarting = AccountStarting;
			AcctType _AccountEnding = AccountEnding;
			ListYesNoType _UpdateAnalysisAttributes = UpdateAnalysisAttributes;
			LongListType _FilterString = FilterString;
			IntType _CommitSize = CommitSize;
			ListYesNoType _Debug = Debug;
			TaskNumType _TaskID = TaskID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DimAttributesUpdateSp";
				
				appDB.AddCommandParameter(cmd, "ObjectName", _ObjectName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TableRowPointer", _TableRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Dimension", _Dimension, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AccountStarting", _AccountStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AccountEnding", _AccountEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UpdateAnalysisAttributes", _UpdateAnalysisAttributes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CommitSize", _CommitSize, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Debug", _Debug, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskID", _TaskID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
