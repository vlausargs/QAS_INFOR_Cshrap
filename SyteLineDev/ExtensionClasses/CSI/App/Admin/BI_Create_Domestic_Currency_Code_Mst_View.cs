//PROJECT NAME: Admin
//CLASS NAME: BI_Create_Domestic_Currency_Code_Mst_View_.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Admin
{
	public class BI_Create_Domestic_Currency_Code_Mst_View : IBI_Create_Domestic_Currency_Code_Mst_View
	{
		readonly IApplicationDB appDB;
		
		public BI_Create_Domestic_Currency_Code_Mst_View(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? BI_Create_Domestic_Currency_Code_Mst_ViewSP(
			string CommonCurrencyCodesList)
		{
			LongListType _CommonCurrencyCodesList = CommonCurrencyCodesList;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "BI_Create_Domestic_Currency_Code_Mst_ViewSP";
				
				appDB.AddCommandParameter(cmd, "CommonCurrencyCodesList", _CommonCurrencyCodesList, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
