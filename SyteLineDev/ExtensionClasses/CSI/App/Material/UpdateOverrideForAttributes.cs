//PROJECT NAME: Material
//CLASS NAME: UpdateOverrideForAttributes.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class UpdateOverrideForAttributes : IUpdateOverrideForAttributes
	{
		readonly IApplicationDB appDB;
		
		
		public UpdateOverrideForAttributes(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) UpdateOverrideForAttributesSp(string ValColName,
		string Value,
		string Type,
		Guid? RowPointer,
		string Infobar)
		{
			StringType _ValColName = ValColName;
			StringType _Value = Value;
			StringType _Type = Type;
			RowPointerType _RowPointer = RowPointer;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UpdateOverrideForAttributesSp";
				
				appDB.AddCommandParameter(cmd, "ValColName", _ValColName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Value", _Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
