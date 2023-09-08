//PROJECT NAME: Codes
//CLASS NAME: GetDataTypeLength.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class GetDataTypeLength : IGetDataTypeLength
	{
		readonly IApplicationDB appDB;
		
		
		public GetDataTypeLength(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? DataTypeLength,
		string Infobar) GetDataTypeLengthSp(string DataType,
		int? DataTypeLength,
		string Infobar)
		{
			StringType _DataType = DataType;
			IntType _DataTypeLength = DataTypeLength;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetDataTypeLengthSp";
				
				appDB.AddCommandParameter(cmd, "DataType", _DataType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DataTypeLength", _DataTypeLength, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DataTypeLength = _DataTypeLength;
				Infobar = _Infobar;
				
				return (Severity, DataTypeLength, Infobar);
			}
		}
	}
}
