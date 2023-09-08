//PROJECT NAME: Production
//CLASS NAME: PmfPnAddFm.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfPnAddFm : IPmfPnAddFm
	{
		readonly IApplicationDB appDB;
		
		public PmfPnAddFm(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string InfoBar,
			Guid? PnFmRp,
			Guid? JobRp) PmfPnAddFmSp(
			string InfoBar = null,
			string Pn = null,
			Guid? PnRp = null,
			Guid? FmRp = null,
			string Whse = null,
			string FmRouteItemJobType = null,
			string FmRouteItem = null,
			string WipItem = null,
			Guid? PnFmRp = null,
			Guid? JobRp = null)
		{
			InfobarType _InfoBar = InfoBar;
			ProcessMfgProductionIdType _Pn = Pn;
			RowPointerType _PnRp = PnRp;
			RowPointerType _FmRp = FmRp;
			WhseType _Whse = Whse;
			StringType _FmRouteItemJobType = FmRouteItemJobType;
			ItemType _FmRouteItem = FmRouteItem;
			ItemType _WipItem = WipItem;
			RowPointerType _PnFmRp = PnFmRp;
			RowPointerType _JobRp = JobRp;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfPnAddFmSp";
				
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Pn", _Pn, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PnRp", _PnRp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FmRp", _FmRp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FmRouteItemJobType", _FmRouteItemJobType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FmRouteItem", _FmRouteItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WipItem", _WipItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PnFmRp", _PnFmRp, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobRp", _JobRp, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				PnFmRp = _PnFmRp;
				JobRp = _JobRp;
				
				return (Severity, InfoBar, PnFmRp, JobRp);
			}
		}
	}
}
