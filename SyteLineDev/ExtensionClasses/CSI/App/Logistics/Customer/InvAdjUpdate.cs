//PROJECT NAME: Logistics
//CLASS NAME: InvAdjUpdate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class InvAdjUpdate : IInvAdjUpdate
	{
		readonly IApplicationDB appDB;
		
		
		public InvAdjUpdate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) InvAdjUpdateSp(Guid? PRowPointer,
		string PCoNum,
		int? PCoLine,
		int? PCoRelease,
		decimal? PQtyAdj,
		decimal? PNewDisc,
		decimal? PNewPrice,
		decimal? PNewPriceConv,
		decimal? PNewQtyConv,
		decimal? PNewLineNet,
		decimal? PNetAdjust,
		string PTransNat,
		string PTransNatDesc,
		string PTransNat2,
		string PTransNat2Desc,
		string POrigInvNum,
		string PReasonText,
		string Infobar)
		{
			RowPointerType _PRowPointer = PRowPointer;
			CoNumType _PCoNum = PCoNum;
			CoLineType _PCoLine = PCoLine;
			CoReleaseType _PCoRelease = PCoRelease;
			QtyUnitNoNegType _PQtyAdj = PQtyAdj;
			LineDiscType _PNewDisc = PNewDisc;
			CostPrcType _PNewPrice = PNewPrice;
			CostPrcType _PNewPriceConv = PNewPriceConv;
			QtyUnitNoNegType _PNewQtyConv = PNewQtyConv;
			CostPrcType _PNewLineNet = PNewLineNet;
			CostPrcType _PNetAdjust = PNetAdjust;
			TransNatType _PTransNat = PTransNat;
			DescriptionType _PTransNatDesc = PTransNatDesc;
			TransNat2Type _PTransNat2 = PTransNat2;
			DescriptionType _PTransNat2Desc = PTransNat2Desc;
			InvNumType _POrigInvNum = POrigInvNum;
			FormEditorType _PReasonText = PReasonText;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InvAdjUpdateSp";
				
				appDB.AddCommandParameter(cmd, "PRowPointer", _PRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoNum", _PCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoLine", _PCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoRelease", _PCoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyAdj", _PQtyAdj, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewDisc", _PNewDisc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewPrice", _PNewPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewPriceConv", _PNewPriceConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewQtyConv", _PNewQtyConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewLineNet", _PNewLineNet, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNetAdjust", _PNetAdjust, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransNat", _PTransNat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransNatDesc", _PTransNatDesc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransNat2", _PTransNat2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransNat2Desc", _PTransNat2Desc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POrigInvNum", _POrigInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PReasonText", _PReasonText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
