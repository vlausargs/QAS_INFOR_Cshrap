//PROJECT NAME: Material
//CLASS NAME: Rloclot.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IRloclot
	{
		(int? ReturnCode, string Lot, string Infobar) RloclotSp(string Site,
		string Item,
		string Whse,
		string Loc,
		string RefNum,
		short? RefLine,
		short? RefRelease,
		string RefType,
		byte? LotTracked,
		string Lot,
		string Infobar,
		string Acct = null);
	}
	
	public class Rloclot : IRloclot
	{
		readonly IApplicationDB appDB;
		
		public Rloclot(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Lot, string Infobar) RloclotSp(string Site,
		string Item,
		string Whse,
		string Loc,
		string RefNum,
		short? RefLine,
		short? RefRelease,
		string RefType,
		byte? LotTracked,
		string Lot,
		string Infobar,
		string Acct = null)
		{
			SiteType _Site = Site;
			ItemType _Item = Item;
			WhseType _Whse = Whse;
			LocType _Loc = Loc;
			EmpJobCoPoRmaProjPsTrnNumType _RefNum = RefNum;
			CoLineSuffixPoLineProjTaskRmaTrnLineType _RefLine = RefLine;
			CoReleaseOperNumPoReleaseType _RefRelease = RefRelease;
			RefTypeIJKOPRSTWType _RefType = RefType;
			ListYesNoType _LotTracked = LotTracked;
			LotType _Lot = Lot;
			InfobarType _Infobar = Infobar;
			AcctType _Acct = Acct;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RloclotSp";
				
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLine", _RefLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LotTracked", _LotTracked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Acct", _Acct, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Lot = _Lot;
				Infobar = _Infobar;
				
				return (Severity, Lot, Infobar);
			}
		}
	}
}
