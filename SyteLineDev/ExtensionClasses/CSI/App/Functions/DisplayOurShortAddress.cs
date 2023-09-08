//PROJECT NAME: Data
//CLASS NAME: DisplayOurShortAddress.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class DisplayOurShortAddress : IDisplayOurShortAddress
	{
		readonly IApplicationDB appDB;
		
		public DisplayOurShortAddress(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string DisplayOurShortAddressFn()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[DisplayOurShortAddress]()";
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
