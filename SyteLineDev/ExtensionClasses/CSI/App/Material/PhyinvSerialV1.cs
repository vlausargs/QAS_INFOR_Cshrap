//PROJECT NAME: Material
//CLASS NAME: PhyinvSerialV1.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class PhyinvSerialV1 : IPhyinvSerialV1
	{
		readonly IApplicationDB appDB;
		
		
		public PhyinvSerialV1(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? SerialEnable,
		string Infobar) PhyinvSerialV1Sp(string Item,
		string Lot,
		string SerNum,
		int? LotTracked,
		int? SerialEnable,
		string Infobar,
		string ImportDocId)
		{
			ItemType _Item = Item;
			LotType _Lot = Lot;
			SerNumType _SerNum = SerNum;
			ListYesNoType _LotTracked = LotTracked;
			ListYesNoType _SerialEnable = SerialEnable;
			Infobar _Infobar = Infobar;
			ImportDocIdType _ImportDocId = ImportDocId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PhyinvSerialV1Sp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LotTracked", _LotTracked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerialEnable", _SerialEnable, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ImportDocId", _ImportDocId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				SerialEnable = _SerialEnable;
				Infobar = _Infobar;
				
				return (Severity, SerialEnable, Infobar);
			}
		}
	}
}
