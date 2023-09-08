//PROJECT NAME: Finance
//CLASS NAME: ArpmtdGArtran.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.AR
{
	public class ArpmtdGArtran : IArpmtdGArtran
	{
		readonly IApplicationDB appDB;
		
		public ArpmtdGArtran(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? ExchRate,
			int? UpdateExchRate,
			string Infobar) ArpmtdGArtranSp(
			string SiteRef,
			string CustNum,
			string InvNum,
			int? SetActive,
			int? AddMode,
			decimal? ArpmtdExchRate,
			decimal? ArpmtExchRate,
			decimal? ExchRate,
			int? UpdateExchRate,
			string Infobar)
		{
			SiteType _SiteRef = SiteRef;
			CustNumType _CustNum = CustNum;
			InvNumType _InvNum = InvNum;
			ListYesNoType _SetActive = SetActive;
			ListYesNoType _AddMode = AddMode;
			ExchRateType _ArpmtdExchRate = ArpmtdExchRate;
			ExchRateType _ArpmtExchRate = ArpmtExchRate;
			ExchRateType _ExchRate = ExchRate;
			ListYesNoType _UpdateExchRate = UpdateExchRate;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ArpmtdGArtranSp";
				
				appDB.AddCommandParameter(cmd, "SiteRef", _SiteRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SetActive", _SetActive, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AddMode", _AddMode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtdExchRate", _ArpmtdExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtExchRate", _ArpmtExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExchRate", _ExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UpdateExchRate", _UpdateExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ExchRate = _ExchRate;
				UpdateExchRate = _UpdateExchRate;
				Infobar = _Infobar;
				
				return (Severity, ExchRate, UpdateExchRate, Infobar);
			}
		}
	}
}
