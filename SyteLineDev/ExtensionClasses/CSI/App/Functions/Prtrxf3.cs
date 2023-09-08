//PROJECT NAME: Data
//CLASS NAME: Prtrxf3.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Prtrxf3 : IPrtrxf3
	{
		readonly IApplicationDB appDB;
		
		public Prtrxf3(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? PrtrxNetPay,
			decimal? PrtrxFwtG,
			decimal? PrtrxEFicaG,
			decimal? PrtrxRFicaG,
			decimal? PrtrxEMedG,
			decimal? PrtrxRMedG,
			decimal? PrtrxFuiG,
			decimal? PrtrxEicG,
			decimal? PrtrxSwtG,
			decimal? PrtrxSuiG,
			decimal? PrtrxOstG,
			decimal? PrtrxWCompG,
			decimal? PrtrxSupplBenG,
			decimal? PrtrxCwtG,
			string Infobar) Prtrxf3Sp(
			Guid? PrdecdRec,
			int? Index,
			string PrtrxEmpNum,
			decimal? PrtrxNetPay,
			decimal? PrtrxDeAmt,
			decimal? PrtrxFwtG,
			decimal? PrtrxEFicaG,
			decimal? PrtrxRFicaG,
			decimal? PrtrxEMedG,
			decimal? PrtrxRMedG,
			decimal? PrtrxFuiG,
			decimal? PrtrxEicG,
			decimal? PrtrxSwtG,
			decimal? PrtrxSuiG,
			decimal? PrtrxOstG,
			decimal? PrtrxWCompG,
			decimal? PrtrxSupplBenG,
			decimal? PrtrxCwtG,
			string Infobar)
		{
			RowPointerType _PrdecdRec = PrdecdRec;
			IntType _Index = Index;
			EmpNumType _PrtrxEmpNum = PrtrxEmpNum;
			PrAmountType _PrtrxNetPay = PrtrxNetPay;
			PrAmountType _PrtrxDeAmt = PrtrxDeAmt;
			PrAmountType _PrtrxFwtG = PrtrxFwtG;
			PrAmountType _PrtrxEFicaG = PrtrxEFicaG;
			PrAmountType _PrtrxRFicaG = PrtrxRFicaG;
			PrAmountType _PrtrxEMedG = PrtrxEMedG;
			PrAmountType _PrtrxRMedG = PrtrxRMedG;
			PrAmountType _PrtrxFuiG = PrtrxFuiG;
			PrAmountType _PrtrxEicG = PrtrxEicG;
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
				cmd.CommandText = "Prtrxf3Sp";
				
				appDB.AddCommandParameter(cmd, "PrdecdRec", _PrdecdRec, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Index", _Index, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrtrxEmpNum", _PrtrxEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrtrxNetPay", _PrtrxNetPay, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeAmt", _PrtrxDeAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrtrxFwtG", _PrtrxFwtG, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxEFicaG", _PrtrxEFicaG, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxRFicaG", _PrtrxRFicaG, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxEMedG", _PrtrxEMedG, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxRMedG", _PrtrxRMedG, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxFuiG", _PrtrxFuiG, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxEicG", _PrtrxEicG, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxSwtG", _PrtrxSwtG, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxSuiG", _PrtrxSuiG, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxOstG", _PrtrxOstG, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxWCompG", _PrtrxWCompG, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxSupplBenG", _PrtrxSupplBenG, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxCwtG", _PrtrxCwtG, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PrtrxNetPay = _PrtrxNetPay;
				PrtrxFwtG = _PrtrxFwtG;
				PrtrxEFicaG = _PrtrxEFicaG;
				PrtrxRFicaG = _PrtrxRFicaG;
				PrtrxEMedG = _PrtrxEMedG;
				PrtrxRMedG = _PrtrxRMedG;
				PrtrxFuiG = _PrtrxFuiG;
				PrtrxEicG = _PrtrxEicG;
				PrtrxSwtG = _PrtrxSwtG;
				PrtrxSuiG = _PrtrxSuiG;
				PrtrxOstG = _PrtrxOstG;
				PrtrxWCompG = _PrtrxWCompG;
				PrtrxSupplBenG = _PrtrxSupplBenG;
				PrtrxCwtG = _PrtrxCwtG;
				Infobar = _Infobar;
				
				return (Severity, PrtrxNetPay, PrtrxFwtG, PrtrxEFicaG, PrtrxRFicaG, PrtrxEMedG, PrtrxRMedG, PrtrxFuiG, PrtrxEicG, PrtrxSwtG, PrtrxSuiG, PrtrxOstG, PrtrxWCompG, PrtrxSupplBenG, PrtrxCwtG, Infobar);
			}
		}
	}
}
