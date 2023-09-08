//PROJECT NAME: Data
//CLASS NAME: FRDisplayOurAddress.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class FRDisplayOurAddress : IFRDisplayOurAddress
	{
		readonly IApplicationDB appDB;
		
		public FRDisplayOurAddress(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string FRDisplayOurAddressFn(
			string FRMessageLanguage = null)
		{
			MessageLanguageType _FRMessageLanguage = FRMessageLanguage;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[FRDisplayOurAddress](@FRMessageLanguage)";
				
				appDB.AddCommandParameter(cmd, "FRMessageLanguage", _FRMessageLanguage, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
