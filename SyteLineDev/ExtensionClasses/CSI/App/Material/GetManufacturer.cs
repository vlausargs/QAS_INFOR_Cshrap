//PROJECT NAME: CSIMaterial
//CLASS NAME: GetManufacturer.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IGetManufacturer
	{
		(int? ReturnCode, string ManufacturerName, string Infobar) GetManufacturerSp(string Item,
		string Manufacturer,
		string ManufacturerName,
		string RefType,
		string RefNum,
		string Infobar,
		string SiteRef = null);
	}
	
	public class GetManufacturer : IGetManufacturer
	{
		readonly IApplicationDB appDB;
		
		public GetManufacturer(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string ManufacturerName, string Infobar) GetManufacturerSp(string Item,
		string Manufacturer,
		string ManufacturerName,
		string RefType,
		string RefNum,
		string Infobar,
		string SiteRef = null)
		{
			ItemType _Item = Item;
			ManufacturerIdType _Manufacturer = Manufacturer;
			NameType _ManufacturerName = ManufacturerName;
			RefTypeCGPVType _RefType = RefType;
			CustVendRefNumType _RefNum = RefNum;
			InfobarType _Infobar = Infobar;
			SiteType _SiteRef = SiteRef;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetManufacturerSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Manufacturer", _Manufacturer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ManufacturerName", _ManufacturerName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SiteRef", _SiteRef, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ManufacturerName = _ManufacturerName;
				Infobar = _Infobar;
				
				return (Severity, ManufacturerName, Infobar);
			}
		}
	}
}
