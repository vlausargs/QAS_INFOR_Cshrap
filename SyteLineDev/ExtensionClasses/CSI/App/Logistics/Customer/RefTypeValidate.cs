//PROJECT NAME: Logistics
//CLASS NAME: RefTypeValidate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IRefTypeValidate
	{
		(int? ReturnCode, string Infobar) RefTypeValidateSp(string Item,
		string RefType,
		string Site = null,
		string Infobar = null);
	}
	
	public class RefTypeValidate : IRefTypeValidate
	{
		readonly IApplicationDB appDB;
		
		public RefTypeValidate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) RefTypeValidateSp(string Item,
		string RefType,
		string Site = null,
		string Infobar = null)
		{
			ItemType _Item = Item;
			RefTypeIJKPRTType _RefType = RefType;
			SiteType _Site = Site;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RefTypeValidateSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
