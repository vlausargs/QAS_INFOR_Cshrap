//PROJECT NAME: Logistics
//CLASS NAME: SSSRMXCreatePckItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class SSSRMXCreatePckItem : ISSSRMXCreatePckItem
	{
		readonly IApplicationDB appDB;
		
		
		public SSSRMXCreatePckItem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SSSRMXCreatePckItemSp(string TPckCall,
		int? PackNum,
		string RefNum,
		string ShipCode,
		int? QtyPackages,
		decimal? Weight,
		DateTime? PackDate,
		string Whse,
		int? RefLine,
		int? RefRelease,
		string RefType,
		string Item,
		string UM,
		string description,
		decimal? qtyordered,
		decimal? qtytopack,
		decimal? qtytopackconv,
		string vendRef,
		string VendNum,
		Guid? RowPointer,
		string ProcessId,
		int? PackLine,
		string Infobar)
		{
			StringType _TPckCall = TPckCall;
			PackNumType _PackNum = PackNum;
			RMXRefNumType _RefNum = RefNum;
			ShipCodeType _ShipCode = ShipCode;
			PackagesType _QtyPackages = QtyPackages;
			WeightType _Weight = Weight;
			DateType _PackDate = PackDate;
			WhseType _Whse = Whse;
			RMXRefLineSufType _RefLine = RefLine;
			RMXRefReleaseType _RefRelease = RefRelease;
			RMXRefTypeType _RefType = RefType;
			ItemType _Item = Item;
			UMType _UM = UM;
			DescriptionType _description = description;
			QtyUnitType _qtyordered = qtyordered;
			QtyUnitType _qtytopack = qtytopack;
			QtyUnitType _qtytopackconv = qtytopackconv;
			VendOrderType _vendRef = vendRef;
			VendNumType _VendNum = VendNum;
			RowPointerType _RowPointer = RowPointer;
			InfobarType _ProcessId = ProcessId;
			GenericIntType _PackLine = PackLine;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSRMXCreatePckItemSp";
				
				appDB.AddCommandParameter(cmd, "TPckCall", _TPckCall, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PackNum", _PackNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipCode", _ShipCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyPackages", _QtyPackages, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Weight", _Weight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PackDate", _PackDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLine", _RefLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "description", _description, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "qtyordered", _qtyordered, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "qtytopack", _qtytopack, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "qtytopackconv", _qtytopackconv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "vendRef", _vendRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PackLine", _PackLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
