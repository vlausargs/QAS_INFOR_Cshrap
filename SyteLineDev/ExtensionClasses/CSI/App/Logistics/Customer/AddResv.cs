//PROJECT NAME: Logistics
//CLASS NAME: AddResv.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class AddResv : IAddResv
	{
		readonly IApplicationDB appDB;
		
		
		public AddResv(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? RsvdNum,
		string Infobar) AddResvSp(string Item,
		string Whse,
		string RefNum,
		int? RefLine,
		int? RefRelease,
		string Loc,
		string Lot,
		decimal? Qty,
		decimal? ConvFactor,
		string UM,
		int? AutoRsvd,
		string ProgramName,
		decimal? RsvdNum,
		string Infobar,
		Guid? SessionID = null,
		string ImportDocId = null,
		string ParmsSite = null)
		{
			ItemType _Item = Item;
			WhseType _Whse = Whse;
			CoNumType _RefNum = RefNum;
			CoLineType _RefLine = RefLine;
			CoLineType _RefRelease = RefRelease;
			LocType _Loc = Loc;
			LotType _Lot = Lot;
			QtyUnitType _Qty = Qty;
			UMConvFactorType _ConvFactor = ConvFactor;
			UMType _UM = UM;
			Flag _AutoRsvd = AutoRsvd;
			OSLocationType _ProgramName = ProgramName;
			RsvdNumType _RsvdNum = RsvdNum;
			Infobar _Infobar = Infobar;
			RowPointerType _SessionID = SessionID;
			ImportDocIdType _ImportDocId = ImportDocId;
			SiteType _ParmsSite = ParmsSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AddResvSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLine", _RefLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Qty", _Qty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ConvFactor", _ConvFactor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AutoRsvd", _AutoRsvd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProgramName", _ProgramName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RsvdNum", _RsvdNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ImportDocId", _ImportDocId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmsSite", _ParmsSite, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RsvdNum = _RsvdNum;
				Infobar = _Infobar;
				
				return (Severity, RsvdNum, Infobar);
			}
		}
	}
}
