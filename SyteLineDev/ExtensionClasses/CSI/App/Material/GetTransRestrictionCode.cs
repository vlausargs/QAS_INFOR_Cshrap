//PROJECT NAME: CSIMaterial
//CLASS NAME: GetTransRestrictionCode.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IGetTransRestrictionCode
	{
		(int? ReturnCode, string TransRestrictionCode, string Infobar) GetTransRestrictionCodeSp(string Site,
		string Item,
		string Lot,
		string TransRestrictionCode,
		string Infobar);
	}
	
	public class GetTransRestrictionCode : IGetTransRestrictionCode
	{
		readonly IApplicationDB appDB;
		
		public GetTransRestrictionCode(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string TransRestrictionCode, string Infobar) GetTransRestrictionCodeSp(string Site,
		string Item,
		string Lot,
		string TransRestrictionCode,
		string Infobar)
		{
			SiteType _Site = Site;
			ItemType _Item = Item;
			LotType _Lot = Lot;
			TransRestrictionCodeType _TransRestrictionCode = TransRestrictionCode;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetTransRestrictionCodeSp";
				
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransRestrictionCode", _TransRestrictionCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TransRestrictionCode = _TransRestrictionCode;
				Infobar = _Infobar;
				
				return (Severity, TransRestrictionCode, Infobar);
			}
		}
	}
}
