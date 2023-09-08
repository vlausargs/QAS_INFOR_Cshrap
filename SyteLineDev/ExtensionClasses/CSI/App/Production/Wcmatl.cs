//PROJECT NAME: Production
//CLASS NAME: Wcmatl.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class Wcmatl : IWcmatl
	{
		readonly IApplicationDB appDB;
		
		
		public Wcmatl(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) WcmatlSp(string TWc,
		string TItem,
		string TWhse,
		string TLoc,
		string TLot,
		decimal? TQty,
		DateTime? TTransDate,
		string TEmpNum,
		string TAcct,
		string TAcctUnit1,
		string TAcctUnit2,
		string TAcctUnit3,
		string TAcctUnit4,
		decimal? TMatlCost,
		decimal? TLbrCost,
		decimal? TFovhdCost,
		decimal? TVovhdCost,
		decimal? TOutCost,
		decimal? UmConvFactor,
		string SerialPrefix,
		string Infobar,
		string DocumentNum = null)
		{
			WcType _TWc = TWc;
			ItemType _TItem = TItem;
			WhseType _TWhse = TWhse;
			LocType _TLoc = TLoc;
			LotType _TLot = TLot;
			QtyPerType _TQty = TQty;
			DateType _TTransDate = TTransDate;
			EmpNumType _TEmpNum = TEmpNum;
			AcctType _TAcct = TAcct;
			UnitCode1Type _TAcctUnit1 = TAcctUnit1;
			UnitCode2Type _TAcctUnit2 = TAcctUnit2;
			UnitCode3Type _TAcctUnit3 = TAcctUnit3;
			UnitCode4Type _TAcctUnit4 = TAcctUnit4;
			CostPrcType _TMatlCost = TMatlCost;
			CostPrcType _TLbrCost = TLbrCost;
			CostPrcType _TFovhdCost = TFovhdCost;
			CostPrcType _TVovhdCost = TVovhdCost;
			CostPrcType _TOutCost = TOutCost;
			UMConvFactorType _UmConvFactor = UmConvFactor;
			SerialPrefixType _SerialPrefix = SerialPrefix;
			InfobarType _Infobar = Infobar;
			DocumentNumType _DocumentNum = DocumentNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "WcmatlSp";
				
				appDB.AddCommandParameter(cmd, "TWc", _TWc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TItem", _TItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TWhse", _TWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TLoc", _TLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TLot", _TLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TQty", _TQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TTransDate", _TTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TEmpNum", _TEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TAcct", _TAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TAcctUnit1", _TAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TAcctUnit2", _TAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TAcctUnit3", _TAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TAcctUnit4", _TAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TMatlCost", _TMatlCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TLbrCost", _TLbrCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TFovhdCost", _TFovhdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TVovhdCost", _TVovhdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TOutCost", _TOutCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UmConvFactor", _UmConvFactor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerialPrefix", _SerialPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DocumentNum", _DocumentNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
