//PROJECT NAME: Data
//CLASS NAME: DisplayWhseAddressWithPhoneLang.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class DisplayWhseAddressWithPhoneLang : IDisplayWhseAddressWithPhoneLang
	{
		readonly IApplicationDB appDB;
		
		public DisplayWhseAddressWithPhoneLang(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string DisplayWhseAddressWithPhoneLangSp(
			string Whse,
			string SiteRef,
			string MessageLanguage)
		{
			WhseType _Whse = Whse;
			SiteType _SiteRef = SiteRef;
			MessageLanguageType _MessageLanguage = MessageLanguage;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[DisplayWhseAddressWithPhoneLangSp](@Whse, @SiteRef, @MessageLanguage)";
				
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SiteRef", _SiteRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MessageLanguage", _MessageLanguage, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
