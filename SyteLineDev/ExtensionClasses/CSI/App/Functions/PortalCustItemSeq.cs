//PROJECT NAME: Data
//CLASS NAME: PortalCustItemSeq.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class PortalCustItemSeq : IPortalCustItemSeq
	{
		readonly IApplicationDB appDB;
		
		public PortalCustItemSeq(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PortalCustItemSeqFn(
			string item,
			string custnum)
		{
			ItemType _item = item;
			CustNumType _custnum = custnum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[PortalCustItemSeq](@item, @custnum)";
				
				appDB.AddCommandParameter(cmd, "item", _item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "custnum", _custnum, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
