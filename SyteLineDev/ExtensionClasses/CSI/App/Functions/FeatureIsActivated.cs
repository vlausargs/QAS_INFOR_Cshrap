//PROJECT NAME: Data
//CLASS NAME: FeatureIsActivated.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class FeatureIsActivated : IFeatureIsActivated
	{
		readonly IApplicationDB appDB;
		
		public FeatureIsActivated(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? FeatureIsActivatedSp(
			string ProductName = "CSI",
			string FeatureID = null)
		{
			ProductNameType _ProductName = ProductName;
			ApplicationFeatureIDType _FeatureID = FeatureID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FeatureIsActivatedSp";
				
				appDB.AddCommandParameter(cmd, "ProductName", _ProductName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FeatureID", _FeatureID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
