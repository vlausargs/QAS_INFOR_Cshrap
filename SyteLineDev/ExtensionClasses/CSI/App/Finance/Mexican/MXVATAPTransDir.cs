//PROJECT NAME: Finance
//CLASS NAME: MXVATAPTransDir.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.Mexican
{
	public class MXVATAPTransDir : IMXVATAPTransDir
	{
		readonly IApplicationDB appDB;
		
		public MXVATAPTransDir(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) MXVATAPTransDirSp(
			int? PCheckNum = null,
			string PVendNum = null,
			int? IsReaplication = null,
			DateTime? DistribucionDate = null,
			decimal? OpenPmtExchRate = null,
			string Infobar = null,
			int? AtLeastOneOpenExists = null)
		{
			ApCheckNumType _PCheckNum = PCheckNum;
			VendNumType _PVendNum = PVendNum;
			ListYesNoType _IsReaplication = IsReaplication;
			DateType _DistribucionDate = DistribucionDate;
			ExchRateType _OpenPmtExchRate = OpenPmtExchRate;
			Infobar _Infobar = Infobar;
			ListYesNoType _AtLeastOneOpenExists = AtLeastOneOpenExists;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MXVATAPTransDirSp";
				
				appDB.AddCommandParameter(cmd, "PCheckNum", _PCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IsReaplication", _IsReaplication, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DistribucionDate", _DistribucionDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OpenPmtExchRate", _OpenPmtExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AtLeastOneOpenExists", _AtLeastOneOpenExists, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
