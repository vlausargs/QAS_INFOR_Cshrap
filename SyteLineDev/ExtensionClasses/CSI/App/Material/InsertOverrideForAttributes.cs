//PROJECT NAME: Material
//CLASS NAME: InsertOverrideForAttributes.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class InsertOverrideForAttributes : IInsertOverrideForAttributes
	{
		readonly IApplicationDB appDB;
		
		
		public InsertOverrideForAttributes(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, Guid? RowPointer,
		string Infobar) InsertOverrideForAttributesSp(string ValColName,
		string Value,
		string Type,
		Guid? RefRowPointer,
		Guid? RowPointer,
		string Infobar)
		{
			StringType _ValColName = ValColName;
			StringType _Value = Value;
			StringType _Type = Type;
			RowPointerType _RefRowPointer = RefRowPointer;
			RowPointerType _RowPointer = RowPointer;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InsertOverrideForAttributesSp";
				
				appDB.AddCommandParameter(cmd, "ValColName", _ValColName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Value", _Value, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRowPointer", _RefRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RowPointer = _RowPointer;
				Infobar = _Infobar;
				
				return (Severity, RowPointer, Infobar);
			}
		}
	}
}
