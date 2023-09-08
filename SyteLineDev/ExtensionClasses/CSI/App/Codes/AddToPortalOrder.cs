//PROJECT NAME: Codes
//CLASS NAME: AddToPortalOrder.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class AddToPortalOrder : IAddToPortalOrder
	{
		readonly IApplicationDB appDB;
		
		
		public AddToPortalOrder(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? CoCustSeq,
		string CoType,
		Guid? CoRowPointer,
		string CoNum,
		string PaymentMethod,
		string CurrCode,
		string ShippingMethod,
		int? CoLine,
		Guid? CoLineRowPointer,
		int? ItemNotPriced,
		string ItmAutoJob,
		string CfgModel,
		string CustName,
		int? B2B,
		Guid? CatalogRowPointer,
		string Infobar) AddToPortalOrderSp(string CoCustNum,
		DateTime? CoOrderDate,
		string CoWhse,
		int? CoConsignment,
		string ColItem,
		string ColUM,
		decimal? ColQtyOrdered,
		string CoShipFromSite = null,
		decimal? ItemPriceConv = null,
		string PortalUsername = null,
		DateTime? ColProjectedDate = null,
		DateTime? ColDueDate = null,
		DateTime? ColPromiseDate = null,
		int? CoCustSeq = null,
		string CoType = null,
		Guid? CoRowPointer = null,
		string CoNum = null,
		string PaymentMethod = null,
		string CurrCode = null,
		string ShippingMethod = null,
		int? CoLine = null,
		Guid? CoLineRowPointer = null,
		int? ItemNotPriced = null,
		string ItmAutoJob = null,
		string CfgModel = null,
		string CustName = null,
		int? B2B = 0,
		Guid? CatalogRowPointer = null,
		string Infobar = null)
		{
			CustNumType _CoCustNum = CoCustNum;
			DateType _CoOrderDate = CoOrderDate;
			WhseType _CoWhse = CoWhse;
			ListYesNoType _CoConsignment = CoConsignment;
			ItemType _ColItem = ColItem;
			UMType _ColUM = ColUM;
			QtyUnitNoNegType _ColQtyOrdered = ColQtyOrdered;
			SiteType _CoShipFromSite = CoShipFromSite;
			AmountType _ItemPriceConv = ItemPriceConv;
			UsernameType _PortalUsername = PortalUsername;
			DateType _ColProjectedDate = ColProjectedDate;
			DateType _ColDueDate = ColDueDate;
			DateType _ColPromiseDate = ColPromiseDate;
			CustSeqType _CoCustSeq = CoCustSeq;
			CoTypeType _CoType = CoType;
			RowPointerType _CoRowPointer = CoRowPointer;
			CoNumType _CoNum = CoNum;
			PaymentMethodType _PaymentMethod = PaymentMethod;
			CurrCodeType _CurrCode = CurrCode;
			ShipMethodType _ShippingMethod = ShippingMethod;
			CoLineType _CoLine = CoLine;
			RowPointerType _CoLineRowPointer = CoLineRowPointer;
			ListYesNoType _ItemNotPriced = ItemNotPriced;
			ConfigAutoJobType _ItmAutoJob = ItmAutoJob;
			ConfigModelType _CfgModel = CfgModel;
			NameType _CustName = CustName;
			ListYesNoType _B2B = B2B;
			RowPointerType _CatalogRowPointer = CatalogRowPointer;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AddToPortalOrderSp";
				
				appDB.AddCommandParameter(cmd, "CoCustNum", _CoCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoOrderDate", _CoOrderDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoWhse", _CoWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoConsignment", _CoConsignment, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ColItem", _ColItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ColUM", _ColUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ColQtyOrdered", _ColQtyOrdered, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoShipFromSite", _CoShipFromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemPriceConv", _ItemPriceConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PortalUsername", _PortalUsername, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ColProjectedDate", _ColProjectedDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ColDueDate", _ColDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ColPromiseDate", _ColPromiseDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoCustSeq", _CoCustSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoType", _CoType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoRowPointer", _CoRowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PaymentMethod", _PaymentMethod, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShippingMethod", _ShippingMethod, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoLineRowPointer", _CoLineRowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemNotPriced", _ItemNotPriced, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItmAutoJob", _ItmAutoJob, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CfgModel", _CfgModel, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustName", _CustName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "B2B", _B2B, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CatalogRowPointer", _CatalogRowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CoCustSeq = _CoCustSeq;
				CoType = _CoType;
				CoRowPointer = _CoRowPointer;
				CoNum = _CoNum;
				PaymentMethod = _PaymentMethod;
				CurrCode = _CurrCode;
				ShippingMethod = _ShippingMethod;
				CoLine = _CoLine;
				CoLineRowPointer = _CoLineRowPointer;
				ItemNotPriced = _ItemNotPriced;
				ItmAutoJob = _ItmAutoJob;
				CfgModel = _CfgModel;
				CustName = _CustName;
				B2B = _B2B;
				CatalogRowPointer = _CatalogRowPointer;
				Infobar = _Infobar;
				
				return (Severity, CoCustSeq, CoType, CoRowPointer, CoNum, PaymentMethod, CurrCode, ShippingMethod, CoLine, CoLineRowPointer, ItemNotPriced, ItmAutoJob, CfgModel, CustName, B2B, CatalogRowPointer, Infobar);
			}
		}
	}
}
