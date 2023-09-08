//PROJECT NAME: Data
//CLASS NAME: CanChangeItemRev.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CanChangeItemRev : ICanChangeItemRev
	{
		readonly IApplicationDB appDB;
		
		public CanChangeItemRev(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CanChangeItemRevFn(
			string PItem)
		{
			ItemType _PItem = PItem;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[CanChangeItemRev](@PItem)";
				
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
