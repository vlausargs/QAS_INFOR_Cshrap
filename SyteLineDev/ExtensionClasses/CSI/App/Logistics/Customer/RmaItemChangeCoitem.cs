//PROJECT NAME: Logistics
//CLASS NAME: RmaItemChangeCoitem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IRmaItemChangeCoitem
	{
		(int? ReturnCode, string Item, string Description, string CustItem, string UM, decimal? UnitCreditConv, string TaxCode1, string TaxCode2, decimal? QtyInvoiced, string Infobar) RmaItemChangeCoitemSp(string CoNum = null,
		short? CoLine = null,
		short? CoRelease = null,
		string Item = null,
		string Description = null,
		string CustItem = null,
		string UM = null,
		decimal? UnitCreditConv = null,
		string TaxCode1 = null,
		string TaxCode2 = null,
		decimal? QtyInvoiced = null,
		string Infobar = null,
		string RMANum = null,
		short? RMALine = null);
	}
	
	public class RmaItemChangeCoitem : IRmaItemChangeCoitem
	{
		readonly IApplicationDB appDB;
		
		public RmaItemChangeCoitem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Item, string Description, string CustItem, string UM, decimal? UnitCreditConv, string TaxCode1, string TaxCode2, decimal? QtyInvoiced, string Infobar) RmaItemChangeCoitemSp(string CoNum = null,
		short? CoLine = null,
		short? CoRelease = null,
		string Item = null,
		string Description = null,
		string CustItem = null,
		string UM = null,
		decimal? UnitCreditConv = null,
		string TaxCode1 = null,
		string TaxCode2 = null,
		decimal? QtyInvoiced = null,
		string Infobar = null,
		string RMANum = null,
		short? RMALine = null)
		{
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			CoReleaseType _CoRelease = CoRelease;
			ItemType _Item = Item;
			DescriptionType _Description = Description;
			ItemType _CustItem = CustItem;
			UMType _UM = UM;
			CostPrcNoNegType _UnitCreditConv = UnitCreditConv;
			TaxCodeType _TaxCode1 = TaxCode1;
			TaxCodeType _TaxCode2 = TaxCode2;
			QtyUnitNoNegType _QtyInvoiced = QtyInvoiced;
			InfobarType _Infobar = Infobar;
			RmaNumType _RMANum = RMANum;
			RmaLineType _RMALine = RMALine;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RmaItemChangeCoitemSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoRelease", _CoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustItem", _CustItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitCreditConv", _UnitCreditConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode1", _TaxCode1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode2", _TaxCode2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyInvoiced", _QtyInvoiced, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RMANum", _RMANum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RMALine", _RMALine, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Item = _Item;
				Description = _Description;
				CustItem = _CustItem;
				UM = _UM;
				UnitCreditConv = _UnitCreditConv;
				TaxCode1 = _TaxCode1;
				TaxCode2 = _TaxCode2;
				QtyInvoiced = _QtyInvoiced;
				Infobar = _Infobar;
				
				return (Severity, Item, Description, CustItem, UM, UnitCreditConv, TaxCode1, TaxCode2, QtyInvoiced, Infobar);
			}
		}
	}
}
