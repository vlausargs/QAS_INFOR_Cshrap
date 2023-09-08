//PROJECT NAME: CSIMaterial
//CLASS NAME: GetManufacturerItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IGetManufacturerItem
	{
		(int? ReturnCode, string Item, string Manufacturer, string ManufacturerName, string ManufacturerItemDescription, string Infobar) GetManufacturerItemSp(string Item,
		string Manufacturer,
		string ManufacturerName,
		string ManufacturerItem,
		string ManufacturerItemDescription,
		string RefType,
		string RefNum,
		string Infobar,
		string SiteRef = null);
	}
	
	public class GetManufacturerItem : IGetManufacturerItem
	{
		readonly IApplicationDB appDB;
		
		public GetManufacturerItem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Item, string Manufacturer, string ManufacturerName, string ManufacturerItemDescription, string Infobar) GetManufacturerItemSp(string Item,
		string Manufacturer,
		string ManufacturerName,
		string ManufacturerItem,
		string ManufacturerItemDescription,
		string RefType,
		string RefNum,
		string Infobar,
		string SiteRef = null)
		{
			ItemType _Item = Item;
			ManufacturerIdType _Manufacturer = Manufacturer;
			NameType _ManufacturerName = ManufacturerName;
			ManufacturerItemType _ManufacturerItem = ManufacturerItem;
			DescriptionType _ManufacturerItemDescription = ManufacturerItemDescription;
			RefTypeCGPVType _RefType = RefType;
			CustVendRefNumType _RefNum = RefNum;
			InfobarType _Infobar = Infobar;
			SiteType _SiteRef = SiteRef;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetManufacturerItemSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Manufacturer", _Manufacturer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ManufacturerName", _ManufacturerName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ManufacturerItem", _ManufacturerItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ManufacturerItemDescription", _ManufacturerItemDescription, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SiteRef", _SiteRef, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Item = _Item;
				Manufacturer = _Manufacturer;
				ManufacturerName = _ManufacturerName;
				ManufacturerItemDescription = _ManufacturerItemDescription;
				Infobar = _Infobar;
				
				return (Severity, Item, Manufacturer, ManufacturerName, ManufacturerItemDescription, Infobar);
			}
		}
	}
}
