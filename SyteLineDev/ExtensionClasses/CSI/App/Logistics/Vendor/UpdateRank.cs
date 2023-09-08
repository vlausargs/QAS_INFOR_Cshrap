//PROJECT NAME: CSIVendor
//CLASS NAME: UpdateRank.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IUpdateRank
	{
		int UpdateRankSp(string TableName,
		                 ref string Infobar);
	}
	
	public class UpdateRank : IUpdateRank
	{
		readonly IApplicationDB appDB;
		
		public UpdateRank(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int UpdateRankSp(string TableName,
		                        ref string Infobar)
		{
			StringType _TableName = TableName;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UpdateRankSp";
				
				appDB.AddCommandParameter(cmd, "TableName", _TableName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
