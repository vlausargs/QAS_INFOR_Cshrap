//PROJECT NAME: Data
//CLASS NAME: Prtrxf1.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Prtrxf1 : IPrtrxf1
	{
		readonly IApplicationDB appDB;
		
		public Prtrxf1(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? PrtrxGrossPay,
			decimal? PrtrxRegPay,
			decimal? PrtrxOtPay,
			decimal? PrtrxDtPay,
			decimal? PrtrxHolPay,
			decimal? PrtrxSickPay,
			decimal? PrtrxVacPay,
			decimal? PrtrxOthPay,
			decimal? PrtrxSupplEarn,
			decimal? PrtrxNetPay,
			decimal? PrtrxFwtG,
			decimal? PrtrxEFicaG,
			decimal? PrtrxRFicaG,
			decimal? PrtrxEMedG,
			decimal? PrtrxRMedG,
			decimal? PrtrxFuiG,
			decimal? PrtrxEicG,
			decimal? PrtrxCoPdInsG,
			decimal? PrtrxCoPdIns,
			decimal? PrtrxEmprConG,
			decimal? PrtrxEmprCon,
			decimal? PrtrxSwtG,
			decimal? PrtrxSuiG,
			decimal? PrtrxOstG,
			decimal? PrtrxWCompG,
			decimal? PrtrxSupplBenG,
			decimal? PrtrxCwtG,
			string Infobar) Prtrxf1Sp(
			string PrtrxEmpNum,
			decimal? PrtrxGrossPay,
			decimal? PrtrxRegPay,
			decimal? PrtrxOtPay,
			decimal? PrtrxDtPay,
			decimal? PrtrxHolPay,
			decimal? PrtrxSickPay,
			decimal? PrtrxVacPay,
			decimal? PrtrxOthPay,
			decimal? PrtrxSupplEarn,
			decimal? PrtrxNetPay,
			decimal? PrtrxFwtG,
			decimal? PrtrxEFicaG,
			decimal? PrtrxRFicaG,
			decimal? PrtrxEMedG,
			decimal? PrtrxRMedG,
			decimal? PrtrxFuiG,
			decimal? PrtrxEicG,
			decimal? PrtrxCoPdInsG,
			decimal? PrtrxCoPdIns,
			decimal? PrtrxEmprConG,
			decimal? PrtrxEmprCon,
			decimal? PrtrxSwtG,
			decimal? PrtrxSuiG,
			decimal? PrtrxOstG,
			decimal? PrtrxWCompG,
			decimal? PrtrxSupplBenG,
			decimal? PrtrxCwtG,
			string Infobar)
		{
			EmpNumType _PrtrxEmpNum = PrtrxEmpNum;
			PrAmountType _PrtrxGrossPay = PrtrxGrossPay;
			PrAmountType _PrtrxRegPay = PrtrxRegPay;
			PrAmountType _PrtrxOtPay = PrtrxOtPay;
			PrAmountType _PrtrxDtPay = PrtrxDtPay;
			PrAmountType _PrtrxHolPay = PrtrxHolPay;
			PrAmountType _PrtrxSickPay = PrtrxSickPay;
			PrAmountType _PrtrxVacPay = PrtrxVacPay;
			PrAmountType _PrtrxOthPay = PrtrxOthPay;
			PrAmountType _PrtrxSupplEarn = PrtrxSupplEarn;
			PrAmountType _PrtrxNetPay = PrtrxNetPay;
			PrAmountType _PrtrxFwtG = PrtrxFwtG;
			PrAmountType _PrtrxEFicaG = PrtrxEFicaG;
			PrAmountType _PrtrxRFicaG = PrtrxRFicaG;
			PrAmountType _PrtrxEMedG = PrtrxEMedG;
			PrAmountType _PrtrxRMedG = PrtrxRMedG;
			PrAmountType _PrtrxFuiG = PrtrxFuiG;
			PrAmountType _PrtrxEicG = PrtrxEicG;
			PrAmountType _PrtrxCoPdInsG = PrtrxCoPdInsG;
			PrAmountType _PrtrxCoPdIns = PrtrxCoPdIns;
			PrAmountType _PrtrxEmprConG = PrtrxEmprConG;
			PrAmountType _PrtrxEmprCon = PrtrxEmprCon;
			PrAmountType _PrtrxSwtG = PrtrxSwtG;
			PrAmountType _PrtrxSuiG = PrtrxSuiG;
			PrAmountType _PrtrxOstG = PrtrxOstG;
			PrAmountType _PrtrxWCompG = PrtrxWCompG;
			PrAmountType _PrtrxSupplBenG = PrtrxSupplBenG;
			PrAmountType _PrtrxCwtG = PrtrxCwtG;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Prtrxf1Sp";
				
				appDB.AddCommandParameter(cmd, "PrtrxEmpNum", _PrtrxEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrtrxGrossPay", _PrtrxGrossPay, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxRegPay", _PrtrxRegPay, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxOtPay", _PrtrxOtPay, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDtPay", _PrtrxDtPay, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxHolPay", _PrtrxHolPay, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxSickPay", _PrtrxSickPay, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxVacPay", _PrtrxVacPay, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxOthPay", _PrtrxOthPay, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxSupplEarn", _PrtrxSupplEarn, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxNetPay", _PrtrxNetPay, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxFwtG", _PrtrxFwtG, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxEFicaG", _PrtrxEFicaG, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxRFicaG", _PrtrxRFicaG, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxEMedG", _PrtrxEMedG, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxRMedG", _PrtrxRMedG, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxFuiG", _PrtrxFuiG, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxEicG", _PrtrxEicG, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxCoPdInsG", _PrtrxCoPdInsG, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxCoPdIns", _PrtrxCoPdIns, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxEmprConG", _PrtrxEmprConG, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxEmprCon", _PrtrxEmprCon, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxSwtG", _PrtrxSwtG, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxSuiG", _PrtrxSuiG, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxOstG", _PrtrxOstG, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxWCompG", _PrtrxWCompG, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxSupplBenG", _PrtrxSupplBenG, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxCwtG", _PrtrxCwtG, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PrtrxGrossPay = _PrtrxGrossPay;
				PrtrxRegPay = _PrtrxRegPay;
				PrtrxOtPay = _PrtrxOtPay;
				PrtrxDtPay = _PrtrxDtPay;
				PrtrxHolPay = _PrtrxHolPay;
				PrtrxSickPay = _PrtrxSickPay;
				PrtrxVacPay = _PrtrxVacPay;
				PrtrxOthPay = _PrtrxOthPay;
				PrtrxSupplEarn = _PrtrxSupplEarn;
				PrtrxNetPay = _PrtrxNetPay;
				PrtrxFwtG = _PrtrxFwtG;
				PrtrxEFicaG = _PrtrxEFicaG;
				PrtrxRFicaG = _PrtrxRFicaG;
				PrtrxEMedG = _PrtrxEMedG;
				PrtrxRMedG = _PrtrxRMedG;
				PrtrxFuiG = _PrtrxFuiG;
				PrtrxEicG = _PrtrxEicG;
				PrtrxCoPdInsG = _PrtrxCoPdInsG;
				PrtrxCoPdIns = _PrtrxCoPdIns;
				PrtrxEmprConG = _PrtrxEmprConG;
				PrtrxEmprCon = _PrtrxEmprCon;
				PrtrxSwtG = _PrtrxSwtG;
				PrtrxSuiG = _PrtrxSuiG;
				PrtrxOstG = _PrtrxOstG;
				PrtrxWCompG = _PrtrxWCompG;
				PrtrxSupplBenG = _PrtrxSupplBenG;
				PrtrxCwtG = _PrtrxCwtG;
				Infobar = _Infobar;
				
				return (Severity, PrtrxGrossPay, PrtrxRegPay, PrtrxOtPay, PrtrxDtPay, PrtrxHolPay, PrtrxSickPay, PrtrxVacPay, PrtrxOthPay, PrtrxSupplEarn, PrtrxNetPay, PrtrxFwtG, PrtrxEFicaG, PrtrxRFicaG, PrtrxEMedG, PrtrxRMedG, PrtrxFuiG, PrtrxEicG, PrtrxCoPdInsG, PrtrxCoPdIns, PrtrxEmprConG, PrtrxEmprCon, PrtrxSwtG, PrtrxSuiG, PrtrxOstG, PrtrxWCompG, PrtrxSupplBenG, PrtrxCwtG, Infobar);
			}
		}
	}
}
