//PROJECT NAME: Data
//CLASS NAME: FRDisplayOurAddressSite.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class FRDisplayOurAddressSite : IFRDisplayOurAddressSite
	{
		readonly IApplicationDB appDB;
		
		public FRDisplayOurAddressSite(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string FRDisplayOurAddressSiteFn(
			string SiteRef,
			string FRMessageLanguage = null)
		{
			SiteType _SiteRef = SiteRef;
			MessageLanguageType _FRMessageLanguage = FRMessageLanguage;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[FRDisplayOurAddressSite](@SiteRef, @FRMessageLanguage)";
				
				appDB.AddCommandParameter(cmd, "SiteRef", _SiteRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FRMessageLanguage", _FRMessageLanguage, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
