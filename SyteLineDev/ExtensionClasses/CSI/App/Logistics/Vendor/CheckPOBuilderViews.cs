//PROJECT NAME: CSIVendor
//CLASS NAME: CheckPOBuilderViews.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface ICheckPOBuilderViews
	{
		int CheckPOBuilderViewsSp();
	}
	
	public class CheckPOBuilderViews : ICheckPOBuilderViews
	{
		readonly IApplicationDB appDB;
		
		public CheckPOBuilderViews(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CheckPOBuilderViewsSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CheckPOBuilderViewsSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return Severity;
			}
		}
	}
}
