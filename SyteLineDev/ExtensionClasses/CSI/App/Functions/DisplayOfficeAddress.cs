//PROJECT NAME: Data
//CLASS NAME: DisplayOfficeAddress.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class DisplayOfficeAddress : IDisplayOfficeAddress
	{
		readonly IApplicationDB appDB;
		
		public DisplayOfficeAddress(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string DisplayOfficeAddressSp(
			string LcnNo)
		{
			LcnNoType _LcnNo = LcnNo;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[DisplayOfficeAddressSp](@LcnNo)";
				
				appDB.AddCommandParameter(cmd, "LcnNo", _LcnNo, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
