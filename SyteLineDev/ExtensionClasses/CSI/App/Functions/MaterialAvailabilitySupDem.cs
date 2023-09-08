//PROJECT NAME: Data
//CLASS NAME: MaterialAvailabilitySupDem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class MaterialAvailabilitySupDem : IMaterialAvailabilitySupDem
	{
		readonly IApplicationDB appDB;
		
		public MaterialAvailabilitySupDem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? ReqQty,
			decimal? CurrentQty) MaterialAvailabilitySupDemSp(
			string PItem,
			string PWhse,
			string PJob,
			int? PSuffix,
			decimal? HrsPerDay,
			DateTime? ReqDate,
			decimal? ReqQty,
			DateTime? CurrentDate,
			decimal? CurrentQty)
		{
			ItemType _PItem = PItem;
			WhseType _PWhse = PWhse;
			JobType _PJob = PJob;
			SuffixType _PSuffix = PSuffix;
			GenericDecimalType _HrsPerDay = HrsPerDay;
			CurrentDateType _ReqDate = ReqDate;
			QtyPerType _ReqQty = ReqQty;
			CurrentDateType _CurrentDate = CurrentDate;
			QtyPerType _CurrentQty = CurrentQty;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MaterialAvailabilitySupDem";
				
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PWhse", _PWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJob", _PJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSuffix", _PSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "HrsPerDay", _HrsPerDay, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReqDate", _ReqDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReqQty", _ReqQty, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurrentDate", _CurrentDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrentQty", _CurrentQty, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ReqQty = _ReqQty;
				CurrentQty = _CurrentQty;
				
				return (Severity, ReqQty, CurrentQty);
			}
		}
	}
}
