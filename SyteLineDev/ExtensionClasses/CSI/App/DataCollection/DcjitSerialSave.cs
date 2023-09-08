//PROJECT NAME: DataCollection
//CLASS NAME: DcjitSerialSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class DcjitSerialSave : IDcjitSerialSave
	{
		readonly IApplicationDB appDB;
		
		
		public DcjitSerialSave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? DcjitSerialSaveSp(int? TransNum,
		string SerNum,
		int? DerSelect,
		Guid? RowPointer)
		{
			DcTransNumType _TransNum = TransNum;
			SerNumType _SerNum = SerNum;
			ListYesNoType _DerSelect = DerSelect;
			RowPointerType _RowPointer = RowPointer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DcjitSerialSaveSp";
				
				appDB.AddCommandParameter(cmd, "TransNum", _TransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerSelect", _DerSelect, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
