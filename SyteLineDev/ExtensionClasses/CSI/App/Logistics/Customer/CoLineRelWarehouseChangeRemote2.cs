//PROJECT NAME: Logistics
//CLASS NAME: CoLineRelWarehouseChangeRemote2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CoLineRelWarehouseChangeRemote2 : ICoLineRelWarehouseChangeRemote2
	{
		readonly IApplicationDB appDB;
		
		public CoLineRelWarehouseChangeRemote2(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CoLineRelWarehouseChangeRemote2Sp(
			string CoItemCoNum,
			int? CoItemCoLine,
			int? CoItemCoRelease,
			string OldWhse,
			string NewWhse)
		{
			CoNumType _CoItemCoNum = CoItemCoNum;
			CoLineType _CoItemCoLine = CoItemCoLine;
			CoReleaseType _CoItemCoRelease = CoItemCoRelease;
			WhseType _OldWhse = OldWhse;
			WhseType _NewWhse = NewWhse;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CoLineRelWarehouseChangeRemote2Sp";
				
				appDB.AddCommandParameter(cmd, "CoItemCoNum", _CoItemCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoItemCoLine", _CoItemCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoItemCoRelease", _CoItemCoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldWhse", _OldWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewWhse", _NewWhse, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
