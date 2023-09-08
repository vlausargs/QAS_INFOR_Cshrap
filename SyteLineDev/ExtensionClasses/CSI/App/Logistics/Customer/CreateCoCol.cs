//PROJECT NAME: CSICustomer
//CLASS NAME: CreateCoCol.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface ICreateCoCol
	{
		(int? ReturnCode, Guid? CoRowPointer, string Infobar) CreateCoColSp(string CoCustNum,
		int? CoCustSeq,
		DateTime? CoOrderDate,
		string CoWhse,
		byte? CoConsignment,
		string ColItem,
		string ColUM,
		decimal? ColQtyOrdered,
		string CoType = null,
		string CoShipFromSite = null,
		decimal? ItemPriceConv = null,
		decimal? ItemPrice = null,
		string PortalUsername = null,
		DateTime? ColProjectedDate = null,
		DateTime? ColDueDate = null,
		DateTime? ColPromiseDate = null,
		Guid? CoRowPointer = null,
		string Infobar = null);
	}
	
	public class CreateCoCol : ICreateCoCol
	{
		readonly IApplicationDB appDB;
		
		public CreateCoCol(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, Guid? CoRowPointer, string Infobar) CreateCoColSp(string CoCustNum,
		int? CoCustSeq,
		DateTime? CoOrderDate,
		string CoWhse,
		byte? CoConsignment,
		string ColItem,
		string ColUM,
		decimal? ColQtyOrdered,
		string CoType = null,
		string CoShipFromSite = null,
		decimal? ItemPriceConv = null,
		decimal? ItemPrice = null,
		string PortalUsername = null,
		DateTime? ColProjectedDate = null,
		DateTime? ColDueDate = null,
		DateTime? ColPromiseDate = null,
		Guid? CoRowPointer = null,
		string Infobar = null)
		{
			CustNumType _CoCustNum = CoCustNum;
			CustSeqType _CoCustSeq = CoCustSeq;
			DateType _CoOrderDate = CoOrderDate;
			WhseType _CoWhse = CoWhse;
			ListYesNoType _CoConsignment = CoConsignment;
			ItemType _ColItem = ColItem;
			UMType _ColUM = ColUM;
			QtyUnitNoNegType _ColQtyOrdered = ColQtyOrdered;
			CoTypeType _CoType = CoType;
			SiteType _CoShipFromSite = CoShipFromSite;
			AmountType _ItemPriceConv = ItemPriceConv;
			AmountType _ItemPrice = ItemPrice;
			UsernameType _PortalUsername = PortalUsername;
			DateType _ColProjectedDate = ColProjectedDate;
			DateType _ColDueDate = ColDueDate;
			DateType _ColPromiseDate = ColPromiseDate;
			RowPointerType _CoRowPointer = CoRowPointer;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CreateCoColSp";
				
				appDB.AddCommandParameter(cmd, "CoCustNum", _CoCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoCustSeq", _CoCustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoOrderDate", _CoOrderDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoWhse", _CoWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoConsignment", _CoConsignment, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ColItem", _ColItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ColUM", _ColUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ColQtyOrdered", _ColQtyOrdered, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoType", _CoType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoShipFromSite", _CoShipFromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemPriceConv", _ItemPriceConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemPrice", _ItemPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PortalUsername", _PortalUsername, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ColProjectedDate", _ColProjectedDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ColDueDate", _ColDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ColPromiseDate", _ColPromiseDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoRowPointer", _CoRowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CoRowPointer = _CoRowPointer;
				Infobar = _Infobar;
				
				return (Severity, CoRowPointer, Infobar);
			}
		}
	}
}
