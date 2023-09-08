//PROJECT NAME: Data
//CLASS NAME: JobBFlushO.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class JobBFlushO : IJobBFlushO
	{
		readonly IApplicationDB appDB;
		
		public JobBFlushO(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) JobBFlushOSp(
			decimal? PQtyComplete,
			decimal? PQtyScrapped,
			string PBflushSetup,
			Guid? pJobTranRP,
			Guid? pJobRouteRp,
			string Infobar)
		{
			QtyUnitType _PQtyComplete = PQtyComplete;
			QtyUnitType _PQtyScrapped = PQtyScrapped;
			LongListType _PBflushSetup = PBflushSetup;
			RowPointerType _pJobTranRP = pJobTranRP;
			RowPointerType _pJobRouteRp = pJobRouteRp;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobBFlushOSp";
				
				appDB.AddCommandParameter(cmd, "PQtyComplete", _PQtyComplete, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyScrapped", _PQtyScrapped, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBflushSetup", _PBflushSetup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pJobTranRP", _pJobTranRP, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pJobRouteRp", _pJobRouteRp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
