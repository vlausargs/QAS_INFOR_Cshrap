//PROJECT NAME: Data
//CLASS NAME: DisplayWhseAddressWithPhone.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class DisplayWhseAddressWithPhone : IDisplayWhseAddressWithPhone
	{
		readonly IApplicationDB appDB;
		
		public DisplayWhseAddressWithPhone(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string DisplayWhseAddressWithPhoneSp(
			string Whse,
			string SiteRef)
		{
			WhseType _Whse = Whse;
			SiteType _SiteRef = SiteRef;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[DisplayWhseAddressWithPhoneSp](@Whse, @SiteRef)";
				
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SiteRef", _SiteRef, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
