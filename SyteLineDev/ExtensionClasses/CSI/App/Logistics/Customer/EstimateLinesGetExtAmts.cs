//PROJECT NAME: Logistics
//CLASS NAME: EstimateLinesGetExtAmts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class EstimateLinesGetExtAmts : IEstimateLinesGetExtAmts
	{
		readonly IApplicationDB appDB;
		
		
		public EstimateLinesGetExtAmts(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? TcAmtExtPrice,
		decimal? TcAmtNetPrice,
		decimal? TcAmtTotCost,
		string Infobar) EstimateLinesGetExtAmtsSp(string PEstNum,
		decimal? PQtyOrdered,
		decimal? PPriceConv,
		decimal? PDisc,
		decimal? PCostConv,
		decimal? TcAmtExtPrice,
		decimal? TcAmtNetPrice,
		decimal? TcAmtTotCost,
		string Infobar)
		{
			EstNumType _PEstNum = PEstNum;
			QtyUnitNoNegType _PQtyOrdered = PQtyOrdered;
			CostPrcType _PPriceConv = PPriceConv;
			LineDiscType _PDisc = PDisc;
			CostPrcType _PCostConv = PCostConv;
			AmountType _TcAmtExtPrice = TcAmtExtPrice;
			AmountType _TcAmtNetPrice = TcAmtNetPrice;
			AmountType _TcAmtTotCost = TcAmtTotCost;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EstimateLinesGetExtAmtsSp";
				
				appDB.AddCommandParameter(cmd, "PEstNum", _PEstNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyOrdered", _PQtyOrdered, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPriceConv", _PPriceConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDisc", _PDisc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCostConv", _PCostConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TcAmtExtPrice", _TcAmtExtPrice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TcAmtNetPrice", _TcAmtNetPrice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TcAmtTotCost", _TcAmtTotCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TcAmtExtPrice = _TcAmtExtPrice;
				TcAmtNetPrice = _TcAmtNetPrice;
				TcAmtTotCost = _TcAmtTotCost;
				Infobar = _Infobar;
				
				return (Severity, TcAmtExtPrice, TcAmtNetPrice, TcAmtTotCost, Infobar);
			}
		}
	}
}
