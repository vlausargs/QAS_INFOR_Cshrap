//PROJECT NAME: Admin
//CLASS NAME: LoadActiveFeatureList.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Admin
{
	public class LoadActiveFeatureList : ILoadActiveFeatureList
	{
		readonly IApplicationDB appDB;
		
		
		public LoadActiveFeatureList(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string ActiveFeatureList) LoadActiveFeatureListSp(string ProductName = "CSI",
		string ActiveFeatureList = null)
		{
			ProductNameType _ProductName = ProductName;
			VeryLongListType _ActiveFeatureList = ActiveFeatureList;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadActiveFeatureListSp";
				
				appDB.AddCommandParameter(cmd, "ProductName", _ProductName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ActiveFeatureList", _ActiveFeatureList, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ActiveFeatureList = _ActiveFeatureList;
				
				return (Severity, ActiveFeatureList);
			}
		}
	}
}
