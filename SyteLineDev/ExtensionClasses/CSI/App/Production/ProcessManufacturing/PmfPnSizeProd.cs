//PROJECT NAME: Production
//CLASS NAME: PmfPnSizeProd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfPnSizeProd
	{
		(int? ReturnCode, string Infobar) PmfPnSizeProdSp(string Infobar = null,
		                                                  Guid? JobRp = null,
		                                                  decimal? NewQty = null);
	}
	
	public class PmfPnSizeProd : IPmfPnSizeProd
	{
		readonly IApplicationDB appDB;
		
		public PmfPnSizeProd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) PmfPnSizeProdSp(string Infobar = null,
		                                                         Guid? JobRp = null,
		                                                         decimal? NewQty = null)
		{
			InfobarType _Infobar = Infobar;
			RowPointerType _JobRp = JobRp;
			ProcessMfgQuantityType _NewQty = NewQty;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfPnSizeProdSp";
				
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobRp", _JobRp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewQty", _NewQty, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
