//PROJECT NAME: Data
//CLASS NAME: DisplayOurAddress.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class DisplayOurAddress : IDisplayOurAddress
	{
		readonly IApplicationDB appDB;


		public DisplayOurAddress(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public string DisplayOurAddressFn()
		{

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[DisplayOurAddress]()";

				var Output = appDB.ExecuteScalar<string>(cmd);

				return Output;
			}
		}
	}
}
