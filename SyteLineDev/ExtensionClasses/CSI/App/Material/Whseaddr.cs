//PROJECT NAME: Material
//CLASS NAME: Whseaddr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class Whseaddr : IWhseaddr
	{
		readonly IApplicationDB appDB;
		
		public Whseaddr(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string WhseaddrSp(
			string Whse,
			string Site,
			string Contact = null)
		{
			WhseType _Whse = Whse;
			SiteType _Site = Site;
			ContactType _Contact = Contact;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[WhseaddrSp](@Whse, @Site, @Contact)";
				
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Contact", _Contact, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
