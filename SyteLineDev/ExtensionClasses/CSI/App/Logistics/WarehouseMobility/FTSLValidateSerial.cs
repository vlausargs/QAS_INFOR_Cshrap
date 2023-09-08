//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLValidateSerial.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLValidateSerial
	{
		(int? ReturnCode, string Infobar) FTSLValidateSerialSp(string Item,
		string Whse,
		string Loc,
		string Lot,
		string Status,
		string Ser_num,
		string Infobar,
		string RefNum);
	}
	
	public class FTSLValidateSerial : IFTSLValidateSerial
	{
		readonly IApplicationDB appDB;
		
		public FTSLValidateSerial(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) FTSLValidateSerialSp(string Item,
		string Whse,
		string Loc,
		string Lot,
		string Status,
		string Ser_num,
		string Infobar,
		string RefNum)
		{
			ItemType _Item = Item;
			WhseType _Whse = Whse;
			LocType _Loc = Loc;
			LotType _Lot = Lot;
			ProcessIndType _Status = Status;
			SerNumType _Ser_num = Ser_num;
			InfobarType _Infobar = Infobar;
			CoNumType _RefNum = RefNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTSLValidateSerialSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Status", _Status, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Ser_num", _Ser_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
