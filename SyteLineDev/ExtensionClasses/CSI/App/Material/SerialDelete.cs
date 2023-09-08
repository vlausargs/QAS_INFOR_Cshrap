//PROJECT NAME: Material
//CLASS NAME: SerialDelete.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class SerialDelete : ISerialDelete
	{
		readonly IApplicationDB appDB;
		
		
		public SerialDelete(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SerialDeleteSp(string FROMWhse,
		string ToWhse,
		string FROMSerNum,
		string ToSerNum,
		string FROMItem,
		string ToItem,
		string FROMLot,
		string ToLot,
		string SerialStat,
		string Infobar,
		string ImportDocId)
		{
			WhseType _FROMWhse = FROMWhse;
			WhseType _ToWhse = ToWhse;
			SerNumType _FROMSerNum = FROMSerNum;
			SerNumType _ToSerNum = ToSerNum;
			ItemType _FROMItem = FROMItem;
			ItemType _ToItem = ToItem;
			LotType _FROMLot = FROMLot;
			LotType _ToLot = ToLot;
			StringType _SerialStat = SerialStat;
			InfobarType _Infobar = Infobar;
			ImportDocIdType _ImportDocId = ImportDocId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SerialDeleteSp";
				
				appDB.AddCommandParameter(cmd, "FROMWhse", _FROMWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToWhse", _ToWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FROMSerNum", _FROMSerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSerNum", _ToSerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FROMItem", _FROMItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToItem", _ToItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FROMLot", _FROMLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToLot", _ToLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerialStat", _SerialStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ImportDocId", _ImportDocId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
