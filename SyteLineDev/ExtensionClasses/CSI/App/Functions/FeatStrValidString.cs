//PROJECT NAME: Data
//CLASS NAME: FeatStrValidString.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class FeatStrValidString : IFeatStrValidString
	{
		readonly IApplicationDB appDB;
		
		public FeatStrValidString(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) FeatStrValidStringSp(
			string FeatStr,
			string Item,
			string Infobar,
			string Site)
		{
			FeatStrType _FeatStr = FeatStr;
			ItemType _Item = Item;
			InfobarType _Infobar = Infobar;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FeatStrValidStringSp";
				
				appDB.AddCommandParameter(cmd, "FeatStr", _FeatStr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
