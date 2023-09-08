//PROJECT NAME: POS
//CLASS NAME: SSSPOSCreateCoitem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.POS
{
	public class SSSPOSCreateCoitem : ISSSPOSCreateCoitem
	{
		readonly IApplicationDB appDB;
		
		public SSSPOSCreateCoitem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) SSSPOSCreateCoitemSp(
			string TCoNum,
			string POSNum,
			string POSMCustNum,
			int? POSMMatlTransNum,
			Guid? PosmMatlRowPointer,
			string POSMMatlItem,
			string POSMMatlItemDescription,
			string POSMMatlUM,
			string POSMMatlWhse,
			decimal? POSMMatlDisc,
			decimal? POSMMatlQtyOrdered,
			decimal? POSMMatlQtyOrderedConv,
			decimal? POSMMatlPrice,
			decimal? POSMMatlPriceConv,
			string POSMMatlTaxCode1,
			string POSMMatlTaxCode2,
			string Infobar)
		{
			CoNumType _TCoNum = TCoNum;
			POSMNumType _POSNum = POSNum;
			CustNumType _POSMCustNum = POSMCustNum;
			POSMTransNumType _POSMMatlTransNum = POSMMatlTransNum;
			RowPointerType _PosmMatlRowPointer = PosmMatlRowPointer;
			ItemType _POSMMatlItem = POSMMatlItem;
			DescriptionType _POSMMatlItemDescription = POSMMatlItemDescription;
			UMType _POSMMatlUM = POSMMatlUM;
			WhseType _POSMMatlWhse = POSMMatlWhse;
			FSPctType _POSMMatlDisc = POSMMatlDisc;
			QtyUnitType _POSMMatlQtyOrdered = POSMMatlQtyOrdered;
			QtyUnitType _POSMMatlQtyOrderedConv = POSMMatlQtyOrderedConv;
			CostPrcType _POSMMatlPrice = POSMMatlPrice;
			CostPrcType _POSMMatlPriceConv = POSMMatlPriceConv;
			TaxCodeType _POSMMatlTaxCode1 = POSMMatlTaxCode1;
			TaxCodeType _POSMMatlTaxCode2 = POSMMatlTaxCode2;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSPOSCreateCoitemSp";
				
				appDB.AddCommandParameter(cmd, "TCoNum", _TCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSNum", _POSNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMCustNum", _POSMCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMMatlTransNum", _POSMMatlTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PosmMatlRowPointer", _PosmMatlRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMMatlItem", _POSMMatlItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMMatlItemDescription", _POSMMatlItemDescription, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMMatlUM", _POSMMatlUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMMatlWhse", _POSMMatlWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMMatlDisc", _POSMMatlDisc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMMatlQtyOrdered", _POSMMatlQtyOrdered, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMMatlQtyOrderedConv", _POSMMatlQtyOrderedConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMMatlPrice", _POSMMatlPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMMatlPriceConv", _POSMMatlPriceConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMMatlTaxCode1", _POSMMatlTaxCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMMatlTaxCode2", _POSMMatlTaxCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
