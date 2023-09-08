//PROJECT NAME: Data
//CLASS NAME: FbomV2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class FbomV2 : IFbomV2
	{
		readonly IApplicationDB appDB;
		
		public FbomV2(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string XFeatureList,
			string Config,
			string Infobar) FbomV2Sp(
			Guid? ItemRowPointer,
			string XFeatureList,
			string Config,
			string Infobar)
		{
			RowPointerType _ItemRowPointer = ItemRowPointer;
			StringType _XFeatureList = XFeatureList;
			FeatStrType _Config = Config;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FbomV2Sp";
				
				appDB.AddCommandParameter(cmd, "ItemRowPointer", _ItemRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "XFeatureList", _XFeatureList, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Config", _Config, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				XFeatureList = _XFeatureList;
				Config = _Config;
				Infobar = _Infobar;
				
				return (Severity, XFeatureList, Config, Infobar);
			}
		}
	}
}
