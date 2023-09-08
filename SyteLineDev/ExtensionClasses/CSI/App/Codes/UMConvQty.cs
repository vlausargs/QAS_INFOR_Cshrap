//PROJECT NAME: Codes
//CLASS NAME: UMConvQty.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public interface IUMConvQty
	{
		(int? ReturnCode, decimal? OutQty, string Infobar) UMConvQtySp(string UM,
		string Item,
		string VendNum = null,
		string Area = null,
		byte? ConvertToBase = null,
		decimal? QtyToBeConverted = null,
		decimal? OutQty = null,
		string Infobar = null);
	}
	
	public class UMConvQty : IUMConvQty
	{
		readonly IApplicationDB appDB;
		
		public UMConvQty(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? OutQty, string Infobar) UMConvQtySp(string UM,
		string Item,
		string VendNum = null,
		string Area = null,
		byte? ConvertToBase = null,
		decimal? QtyToBeConverted = null,
		decimal? OutQty = null,
		string Infobar = null)
		{
			UMType _UM = UM;
			ItemType _Item = Item;
			VendNumType _VendNum = VendNum;
			StringType _Area = Area;
			ListYesNoType _ConvertToBase = ConvertToBase;
			QtyUnitType _QtyToBeConverted = QtyToBeConverted;
			QtyUnitType _OutQty = OutQty;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UMConvQtySp";
				
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Area", _Area, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ConvertToBase", _ConvertToBase, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyToBeConverted", _QtyToBeConverted, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OutQty", _OutQty, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				OutQty = _OutQty;
				Infobar = _Infobar;
				
				return (Severity, OutQty, Infobar);
			}
		}
	}
}
