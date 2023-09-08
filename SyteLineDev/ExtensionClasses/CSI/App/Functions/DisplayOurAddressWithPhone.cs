//PROJECT NAME: Data
//CLASS NAME: DisplayOurAddressWithPhone.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class DisplayOurAddressWithPhone : IDisplayOurAddressWithPhone
	{
		readonly IApplicationDB appDB;
		
		public DisplayOurAddressWithPhone(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string DisplayOurAddressWithPhoneSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[DisplayOurAddressWithPhoneSp]()";
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
