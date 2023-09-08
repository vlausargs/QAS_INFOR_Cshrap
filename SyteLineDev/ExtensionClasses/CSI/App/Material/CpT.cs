//PROJECT NAME: Material
//CLASS NAME: CpT.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class CpT : ICpT
	{
		readonly IApplicationDB appDB;
		
		
		public CpT(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, DateTime? TSchShipDate,
		DateTime? TSchRcvDate,
		string TTrn,
		string Infobar) CpTSp(string FTrn,
		string FromParmsSite,
		string TTransferFromSite,
		string TTransferToSite,
		int? FSLine,
		int? FELine,
		int? TCpCharge,
		DateTime? TSchShipDate,
		DateTime? TSchRcvDate,
		string TTrn,
		string Infobar)
		{
			TrnNumType _FTrn = FTrn;
			SiteType _FromParmsSite = FromParmsSite;
			SiteType _TTransferFromSite = TTransferFromSite;
			SiteType _TTransferToSite = TTransferToSite;
			TrnLineType _FSLine = FSLine;
			TrnLineType _FELine = FELine;
			ListYesNoType _TCpCharge = TCpCharge;
			DateType _TSchShipDate = TSchShipDate;
			DateType _TSchRcvDate = TSchRcvDate;
			TrnNumType _TTrn = TTrn;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CpTSp";
				
				appDB.AddCommandParameter(cmd, "FTrn", _FTrn, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromParmsSite", _FromParmsSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TTransferFromSite", _TTransferFromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TTransferToSite", _TTransferToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FSLine", _FSLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FELine", _FELine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TCpCharge", _TCpCharge, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TSchShipDate", _TSchShipDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TSchRcvDate", _TSchRcvDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TTrn", _TTrn, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TSchShipDate = _TSchShipDate;
				TSchRcvDate = _TSchRcvDate;
				TTrn = _TTrn;
				Infobar = _Infobar;
				
				return (Severity, TSchShipDate, TSchRcvDate, TTrn, Infobar);
			}
		}
	}
}
