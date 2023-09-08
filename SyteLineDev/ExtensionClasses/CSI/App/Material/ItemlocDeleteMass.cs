//PROJECT NAME: CSIMaterial
//CLASS NAME: ItemlocDeleteMass.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IItemlocDeleteMass
	{
		(int? ReturnCode, string Infobar) ItemlocDeleteMassSp(string FromWhse,
		string ToWhse,
		string FromItem,
		string ToItem,
		string FromLoc,
		string ToLoc,
		decimal? Quantity,
		byte? DelPermLocs,
		string ReasonCode,
		string Infobar,
		byte? PrintDiagnostics = (byte)0,
		int? DeleteBlockSize = 10000);
	}
	
	public class ItemlocDeleteMass : IItemlocDeleteMass
	{
		readonly IApplicationDB appDB;
		
		public ItemlocDeleteMass(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ItemlocDeleteMassSp(string FromWhse,
		string ToWhse,
		string FromItem,
		string ToItem,
		string FromLoc,
		string ToLoc,
		decimal? Quantity,
		byte? DelPermLocs,
		string ReasonCode,
		string Infobar,
		byte? PrintDiagnostics = (byte)0,
		int? DeleteBlockSize = 10000)
		{
			WhseType _FromWhse = FromWhse;
			WhseType _ToWhse = ToWhse;
			ItemType _FromItem = FromItem;
			ItemType _ToItem = ToItem;
			LocType _FromLoc = FromLoc;
			LocType _ToLoc = ToLoc;
			QtyUnitType _Quantity = Quantity;
			ListYesNoType _DelPermLocs = DelPermLocs;
			ReasonCodeType _ReasonCode = ReasonCode;
			InfobarType _Infobar = Infobar;
			ListYesNoType _PrintDiagnostics = PrintDiagnostics;
			IntType _DeleteBlockSize = DeleteBlockSize;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemlocDeleteMassSp";
				
				appDB.AddCommandParameter(cmd, "FromWhse", _FromWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToWhse", _ToWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromItem", _FromItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToItem", _ToItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromLoc", _FromLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToLoc", _ToLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Quantity", _Quantity, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DelPermLocs", _DelPermLocs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReasonCode", _ReasonCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrintDiagnostics", _PrintDiagnostics, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DeleteBlockSize", _DeleteBlockSize, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
