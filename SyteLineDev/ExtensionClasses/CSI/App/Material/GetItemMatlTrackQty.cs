//PROJECT NAME: Material
//CLASS NAME: GetItemMatlTrackQty.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class GetItemMatlTrackQty : IGetItemMatlTrackQty
	{
		readonly IApplicationDB appDB;
		
		
		public GetItemMatlTrackQty(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? PQty,
		decimal? PQtyConv,
		string Infobar,
		decimal? PQtyWithOutLotConv) GetItemMatlTrackQtySp(string PItem,
		string PUM,
		string PRefType,
		string PRefNum = null,
		int? PRefLineSuf = null,
		int? PRefRelease = null,
		string PWhse = null,
		string PLoc = null,
		string PLot = null,
		decimal? PQty = null,
		decimal? PQtyConv = null,
		string Infobar = null,
		decimal? PQtyWithOutLotConv = null)
		{
			ItemType _PItem = PItem;
			UMType _PUM = PUM;
			RefTypeIJOPRSTType _PRefType = PRefType;
			EmpJobCoPoRmaProjPsTrnNumType _PRefNum = PRefNum;
			CoLineSuffixPoLineProjTaskRmaTrnLineType _PRefLineSuf = PRefLineSuf;
			CoReleaseOperNumPoReleaseType _PRefRelease = PRefRelease;
			WhseType _PWhse = PWhse;
			LocType _PLoc = PLoc;
			LotType _PLot = PLot;
			QtyTotlType _PQty = PQty;
			QtyTotlType _PQtyConv = PQtyConv;
			InfobarType _Infobar = Infobar;
			QtyTotlType _PQtyWithOutLotConv = PQtyWithOutLotConv;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetItemMatlTrackQtySp";
				
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUM", _PUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefType", _PRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefNum", _PRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefLineSuf", _PRefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefRelease", _PRefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PWhse", _PWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLoc", _PLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLot", _PLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQty", _PQty, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PQtyConv", _PQtyConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PQtyWithOutLotConv", _PQtyWithOutLotConv, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PQty = _PQty;
				PQtyConv = _PQtyConv;
				Infobar = _Infobar;
				PQtyWithOutLotConv = _PQtyWithOutLotConv;
				
				return (Severity, PQty, PQtyConv, Infobar, PQtyWithOutLotConv);
			}
		}
	}
}
