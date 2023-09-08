//PROJECT NAME: Data
//CLASS NAME: PortalItemInDescriptions.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class PortalItemInDescriptions : IPortalItemInDescriptions
	{
		readonly IApplicationDB appDB;
		
		public PortalItemInDescriptions(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PortalItemInDescriptionsFn(
			Guid? rp,
			string item)
		{
			RowPointerType _rp = rp;
			ItemType _item = item;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[PortalItemInDescriptions](@rp, @item)";
				
				appDB.AddCommandParameter(cmd, "rp", _rp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "item", _item, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
