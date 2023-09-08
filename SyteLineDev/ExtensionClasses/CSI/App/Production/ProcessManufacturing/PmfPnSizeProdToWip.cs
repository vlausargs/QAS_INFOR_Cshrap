//PROJECT NAME: Production
//CLASS NAME: PmfPnSizeProdToWip.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfPnSizeProdToWip
	{
		(int? ReturnCode, string Infobar) PmfPnSizeProdToWipSp(string Infobar = null,
		                                                       Guid? PnRp = null,
		                                                       int? UseActualWip = 0);
	}
	
	public class PmfPnSizeProdToWip : IPmfPnSizeProdToWip
	{
		readonly IApplicationDB appDB;
		
		public PmfPnSizeProdToWip(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) PmfPnSizeProdToWipSp(string Infobar = null,
		                                                              Guid? PnRp = null,
		                                                              int? UseActualWip = 0)
		{
			InfobarType _Infobar = Infobar;
			RowPointerType _PnRp = PnRp;
			IntType _UseActualWip = UseActualWip;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfPnSizeProdToWipSp";
				
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PnRp", _PnRp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseActualWip", _UseActualWip, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
