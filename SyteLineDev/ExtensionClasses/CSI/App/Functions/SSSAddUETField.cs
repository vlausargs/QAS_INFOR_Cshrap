//PROJECT NAME: Data
//CLASS NAME: SSSAddUETField.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class SSSAddUETField : ISSSAddUETField
	{
		readonly IApplicationDB appDB;
		
		public SSSAddUETField(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSAddUETFieldSp(
			string ClassName,
			string FldName,
			string FldDataType,
			string FldInitial,
			int? FldDecimals,
			string FldUDT,
			int? FldPrec)
		{
			ClassNameType _ClassName = ClassName;
			FldNameType _FldName = FldName;
			UetDataTypeType _FldDataType = FldDataType;
			UetDefaultType _FldInitial = FldInitial;
			UetScaleType _FldDecimals = FldDecimals;
			StringType _FldUDT = FldUDT;
			ByteType _FldPrec = FldPrec;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSAddUETFieldSp";
				
				appDB.AddCommandParameter(cmd, "ClassName", _ClassName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FldName", _FldName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FldDataType", _FldDataType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FldInitial", _FldInitial, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FldDecimals", _FldDecimals, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FldUDT", _FldUDT, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FldPrec", _FldPrec, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
