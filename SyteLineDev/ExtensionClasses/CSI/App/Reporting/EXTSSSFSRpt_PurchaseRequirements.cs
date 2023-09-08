//PROJECT NAME: Reporting
//CLASS NAME: EXTSSSFSRpt_PurchaseRequirements.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class EXTSSSFSRpt_PurchaseRequirements : IEXTSSSFSRpt_PurchaseRequirements
	{
		readonly IApplicationDB appDB;
		
		public EXTSSSFSRpt_PurchaseRequirements(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? EXTSSSFSRpt_PurchaseRequirementsSp(
			string Item,
			string WhseStarting,
			string WhseEnding,
			string SROStatus,
			int? ShowDepl)
		{
			ItemType _Item = Item;
			WhseType _WhseStarting = WhseStarting;
			WhseType _WhseEnding = WhseEnding;
			InfobarType _SROStatus = SROStatus;
			FlagNyType _ShowDepl = ShowDepl;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EXTSSSFSRpt_PurchaseRequirementsSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WhseStarting", _WhseStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WhseEnding", _WhseEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SROStatus", _SROStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowDepl", _ShowDepl, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
