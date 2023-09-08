//PROJECT NAME: Production
//CLASS NAME: PmfPnBalanceWip.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfPnBalanceWip
	{
		(int? ReturnCode, string InfoBar) PmfPnBalanceWipSp(string InfoBar = null,
		                                                    Guid? PnRp = null,
		                                                    short? FromSuffix = 0,
		                                                    int? Backward = 0,
		                                                    int? UseActualProd = 0);
	}
	
	public class PmfPnBalanceWip : IPmfPnBalanceWip
	{
		readonly IApplicationDB appDB;
		
		public PmfPnBalanceWip(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string InfoBar) PmfPnBalanceWipSp(string InfoBar = null,
		                                                           Guid? PnRp = null,
		                                                           short? FromSuffix = 0,
		                                                           int? Backward = 0,
		                                                           int? UseActualProd = 0)
		{
			InfobarType _InfoBar = InfoBar;
			RowPointerType _PnRp = PnRp;
			SuffixType _FromSuffix = FromSuffix;
			IntType _Backward = Backward;
			IntType _UseActualProd = UseActualProd;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfPnBalanceWipSp";
				
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PnRp", _PnRp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromSuffix", _FromSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Backward", _Backward, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseActualProd", _UseActualProd, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (Severity, InfoBar);
			}
		}
	}
}
