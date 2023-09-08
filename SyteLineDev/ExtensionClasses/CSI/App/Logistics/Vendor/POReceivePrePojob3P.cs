//PROJECT NAME: Logistics
//CLASS NAME: POReceivePrePojob3P.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class POReceivePrePojob3P : IPOReceivePrePojob3P
	{
		readonly IApplicationDB appDB;
		
		
		public POReceivePrePojob3P(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? TComplete,
		decimal? TMove,
		string Infobar) POReceivePrePojob3PSp(string PoItemRefNum,
		int? PoItemRefLineSuf,
		int? PoItemRefRelease,
		string PoItem,
		string PoNum,
		int? PoLine,
		int? PoRelease,
		int? DRReturn,
		decimal? QtyToReceiveConv,
		decimal? TComplete,
		decimal? TMove,
		string Infobar)
		{
			CoJobProjTrnNumType _PoItemRefNum = PoItemRefNum;
			CoLineSuffixProjTaskTrnLineType _PoItemRefLineSuf = PoItemRefLineSuf;
			CoReleaseOperNumType _PoItemRefRelease = PoItemRefRelease;
			ItemType _PoItem = PoItem;
			PoNumType _PoNum = PoNum;
			PoLineType _PoLine = PoLine;
			PoReleaseType _PoRelease = PoRelease;
			IntType _DRReturn = DRReturn;
			QtyUnitType _QtyToReceiveConv = QtyToReceiveConv;
			QtyUnitType _TComplete = TComplete;
			QtyUnitType _TMove = TMove;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "POReceivePrePojob3PSp";
				
				appDB.AddCommandParameter(cmd, "PoItemRefNum", _PoItemRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoItemRefLineSuf", _PoItemRefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoItemRefRelease", _PoItemRefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoItem", _PoItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoLine", _PoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoRelease", _PoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DRReturn", _DRReturn, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyToReceiveConv", _QtyToReceiveConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TComplete", _TComplete, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TMove", _TMove, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TComplete = _TComplete;
				TMove = _TMove;
				Infobar = _Infobar;
				
				return (Severity, TComplete, TMove, Infobar);
			}
		}
	}
}
