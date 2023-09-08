//PROJECT NAME: Material
//CLASS NAME: ItemFl.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class ItemFl : IItemFl
	{
		readonly IApplicationDB appDB;
		
		
		public ItemFl(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PTrnLot,
		decimal? PUomConvFactor,
		decimal? PQty,
		string Infobar) ItemFlSp(string PSite,
		string PWhse,
		string PItem,
		string PTrnLoc,
		string PTrnNum,
		int? PTrnLine,
		string PTrnLot,
		decimal? PUomConvFactor,
		decimal? PQty,
		string Infobar)
		{
			SiteType _PSite = PSite;
			WhseType _PWhse = PWhse;
			ItemType _PItem = PItem;
			LocType _PTrnLoc = PTrnLoc;
			TrnNumType _PTrnNum = PTrnNum;
			TrnLineType _PTrnLine = PTrnLine;
			LotType _PTrnLot = PTrnLot;
			UMConvFactorType _PUomConvFactor = PUomConvFactor;
			QtyUnitType _PQty = PQty;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemFlSp";
				
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PWhse", _PWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTrnLoc", _PTrnLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTrnNum", _PTrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTrnLine", _PTrnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTrnLot", _PTrnLot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PUomConvFactor", _PUomConvFactor, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PQty", _PQty, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PTrnLot = _PTrnLot;
				PUomConvFactor = _PUomConvFactor;
				PQty = _PQty;
				Infobar = _Infobar;
				
				return (Severity, PTrnLot, PUomConvFactor, PQty, Infobar);
			}
		}
	}
}
