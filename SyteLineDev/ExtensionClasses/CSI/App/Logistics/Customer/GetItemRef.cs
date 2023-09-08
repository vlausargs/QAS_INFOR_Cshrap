//PROJECT NAME: Logistics
//CLASS NAME: GetItemRef.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetItemRef : IGetItemRef
	{
		readonly IApplicationDB appDB;
		
		
		public GetItemRef(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string RefType,
		string Infobar) GetItemRefSp(string Item,
		string CalledFrom,
		string RefType,
		string Infobar,
		string Site = null)
		{
			ItemType _Item = Item;
			StringType _CalledFrom = CalledFrom;
			RefTypeIJKPRTType _RefType = RefType;
			InfobarType _Infobar = Infobar;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetItemRefSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CalledFrom", _CalledFrom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RefType = _RefType;
				Infobar = _Infobar;
				
				return (Severity, RefType, Infobar);
			}
		}
	}
}
