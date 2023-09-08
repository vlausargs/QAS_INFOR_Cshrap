//PROJECT NAME: Production
//CLASS NAME: PmfPnUpdProd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfPnUpdProd : IPmfPnUpdProd
	{
		readonly IApplicationDB appDB;
		
		public PmfPnUpdProd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar,
			Guid? JobRp) PmfPnUpdProdSp(
			string Infobar = null,
			Guid? JobRp = null,
			decimal? NewQty = null,
			int? DoRoll = 0)
		{
			InfobarType _Infobar = Infobar;
			RowPointer _JobRp = JobRp;
			ProcessMfgQuantityType _NewQty = NewQty;
			IntType _DoRoll = DoRoll;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfPnUpdProdSp";
				
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobRp", _JobRp, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NewQty", _NewQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DoRoll", _DoRoll, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				JobRp = _JobRp;
				
				return (Severity, Infobar, JobRp);
			}
		}
	}
}
