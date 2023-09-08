//PROJECT NAME: Admin
//CLASS NAME: BI_Create_MutipleSites_Domestic_Currency_Code_Mst_View_.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Admin
{
	public class BI_Create_MutipleSites_Domestic_Currency_Code_Mst_View : IBI_Create_MutipleSites_Domestic_Currency_Code_Mst_View
	{
		readonly IApplicationDB appDB;
		
		public BI_Create_MutipleSites_Domestic_Currency_Code_Mst_View(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? BI_Create_MutipleSites_Domestic_Currency_Code_Mst_ViewSP()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "BI_Create_MutipleSites_Domestic_Currency_Code_Mst_ViewSP";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
