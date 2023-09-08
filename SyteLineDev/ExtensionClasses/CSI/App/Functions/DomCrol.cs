//PROJECT NAME: Data
//CLASS NAME: DomCrol.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class DomCrol : IDomCrol
	{
		readonly IApplicationDB appDB;
		
		public DomCrol(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? DomCrolSp(
			Guid? InRecid,
			int? TUseStandard)
		{
			RowPointerType _InRecid = InRecid;
			FlagNyType _TUseStandard = TUseStandard;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DomCrolSp";
				
				appDB.AddCommandParameter(cmd, "InRecid", _InRecid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TUseStandard", _TUseStandard, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
