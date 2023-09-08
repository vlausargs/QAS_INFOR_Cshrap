//PROJECT NAME: Data
//CLASS NAME: GetInteractionUserCompany.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetInteractionUserCompany : IGetInteractionUserCompany
	{
		readonly IApplicationDB appDB;
		
		public GetInteractionUserCompany(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string GetInteractionUserCompanyFn(
			string EnteredBy,
			string Portal)
		{
			NameType _EnteredBy = EnteredBy;
			StringType _Portal = Portal;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetInteractionUserCompany](@EnteredBy, @Portal)";
				
				appDB.AddCommandParameter(cmd, "EnteredBy", _EnteredBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Portal", _Portal, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
