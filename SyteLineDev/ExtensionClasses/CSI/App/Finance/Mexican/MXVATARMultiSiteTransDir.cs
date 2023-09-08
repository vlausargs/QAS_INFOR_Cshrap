//PROJECT NAME: Finance
//CLASS NAME: MXVATARMultiSiteTransDir.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.Mexican
{
	public class MXVATARMultiSiteTransDir : IMXVATARMultiSiteTransDir
	{
		readonly IApplicationDB appDB;
		
		public MXVATARMultiSiteTransDir(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) MXVATARMultiSiteTransDirSp(
			int? PCheckNum = null,
			string PInvNum = null,
			string PCustNum = null,
			string RefType = null,
			string Type = null,
			string RefNum = null,
			int? BankRecon = null,
			DateTime? UfReconDate = null,
			DateTime? CheckDate = null,
			int? CheckNum = null,
			decimal? CheckAmt = null,
			string BankCode = null,
			int? CustCheckNum = null,
			string BankCurrCode = null,
			int? IsReaplication = null,
			DateTime? DistribucionDate = null,
			decimal? OpenPmtExchRate = null,
			string Infobar = null)
		{
			ArCheckNumType _PCheckNum = PCheckNum;
			InvNumType _PInvNum = PInvNum;
			CustNumType _PCustNum = PCustNum;
			RefType _RefType = RefType;
			ArtranTypeType _Type = Type;
			CustEmpVendNumType _RefNum = RefNum;
			ListYesNoType _BankRecon = BankRecon;
			DateType _UfReconDate = UfReconDate;
			DateType _CheckDate = CheckDate;
			GlCheckNumType _CheckNum = CheckNum;
			AmountType _CheckAmt = CheckAmt;
			BankCodeType _BankCode = BankCode;
			ArCheckNumType _CustCheckNum = CustCheckNum;
			CurrCodeType _BankCurrCode = BankCurrCode;
			ListYesNoType _IsReaplication = IsReaplication;
			DateType _DistribucionDate = DistribucionDate;
			ExchRateType _OpenPmtExchRate = OpenPmtExchRate;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MXVATARMultiSiteTransDirSp";
				
				appDB.AddCommandParameter(cmd, "PCheckNum", _PCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvNum", _PInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BankRecon", _BankRecon, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UfReconDate", _UfReconDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckDate", _CheckDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckNum", _CheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckAmt", _CheckAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BankCode", _BankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustCheckNum", _CustCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BankCurrCode", _BankCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IsReaplication", _IsReaplication, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DistribucionDate", _DistribucionDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OpenPmtExchRate", _OpenPmtExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
