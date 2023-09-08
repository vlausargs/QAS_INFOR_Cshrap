//PROJECT NAME: Logistics
//CLASS NAME: SSSFSFormatPartnerAddress.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSFormatPartnerAddress : ISSSFSFormatPartnerAddress
	{
		readonly IApplicationDB appDB;
		
		public SSSFSFormatPartnerAddress(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string SSSFSFormatPartnerAddressFn(
			string iPartnerID)
		{
			FSPartnerType _iPartnerID = iPartnerID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSFSFormatPartnerAddress](@iPartnerID)";
				
				appDB.AddCommandParameter(cmd, "iPartnerID", _iPartnerID, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
