//PROJECT NAME: Data
//CLASS NAME: JmatlTm.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class JmatlTm : IJmatlTm
	{
		readonly IApplicationDB appDB;
		
		public JmatlTm(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? JmatlTmSp(
			Guid? JobmatlRowPointer,
			string MatlItem,
			string JobJob,
			int? JobSuffix,
			decimal? Qty,
			string OrderType,
			decimal? GrossQty)
		{
			RowPointerType _JobmatlRowPointer = JobmatlRowPointer;
			ItemType _MatlItem = MatlItem;
			JobType _JobJob = JobJob;
			SuffixType _JobSuffix = JobSuffix;
			QtyPerType _Qty = Qty;
			MrpOrderTypeType _OrderType = OrderType;
			QtyUnitType _GrossQty = GrossQty;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JmatlTmSp";
				
				appDB.AddCommandParameter(cmd, "JobmatlRowPointer", _JobmatlRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlItem", _MatlItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobJob", _JobJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobSuffix", _JobSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Qty", _Qty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderType", _OrderType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GrossQty", _GrossQty, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
