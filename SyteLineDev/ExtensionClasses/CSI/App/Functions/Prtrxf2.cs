//PROJECT NAME: Data
//CLASS NAME: Prtrxf2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Prtrxf2 : IPrtrxf2
	{
		readonly IApplicationDB appDB;
		
		public Prtrxf2(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? PrtrxGrossPay,
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
			string Infobar) Prtrxf2Sp(
			Guid? PrdecdRec,
			int? Index,
			string PrtrxEmpNum,
			decimal? PrtrxDeAmt__1,
			decimal? PrtrxDeAmt__2,
			decimal? PrtrxDeAmt__3,
			decimal? PrtrxDeAmt__4,
			decimal? PrtrxDeAmt__5,
			decimal? PrtrxDeAmt__6,
			decimal? PrtrxDeAmt__7,
			decimal? PrtrxDeAmt__8,
			decimal? PrtrxDeAmt__9,
			decimal? PrtrxDeAmt__10,
			decimal? PrtrxDeAmt__11,
			decimal? PrtrxDeAmt__12,
			decimal? PrtrxDeAmt__13,
			decimal? PrtrxDeAmt__14,
			decimal? PrtrxDeAmt__15,
			decimal? PrtrxDeAmt__16,
			decimal? PrtrxDeAmt__17,
			decimal? PrtrxDeAmt__18,
			decimal? PrtrxGrossPay,
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
			string Infobar)
		{
			RowPointerType _PrdecdRec = PrdecdRec;
			IntType _Index = Index;
			EmpNumType _PrtrxEmpNum = PrtrxEmpNum;
			PrAmountType _PrtrxDeAmt__1 = PrtrxDeAmt__1;
			PrAmountType _PrtrxDeAmt__2 = PrtrxDeAmt__2;
			PrAmountType _PrtrxDeAmt__3 = PrtrxDeAmt__3;
			PrAmountType _PrtrxDeAmt__4 = PrtrxDeAmt__4;
			PrAmountType _PrtrxDeAmt__5 = PrtrxDeAmt__5;
			PrAmountType _PrtrxDeAmt__6 = PrtrxDeAmt__6;
			PrAmountType _PrtrxDeAmt__7 = PrtrxDeAmt__7;
			PrAmountType _PrtrxDeAmt__8 = PrtrxDeAmt__8;
			PrAmountType _PrtrxDeAmt__9 = PrtrxDeAmt__9;
			PrAmountType _PrtrxDeAmt__10 = PrtrxDeAmt__10;
			PrAmountType _PrtrxDeAmt__11 = PrtrxDeAmt__11;
			PrAmountType _PrtrxDeAmt__12 = PrtrxDeAmt__12;
			PrAmountType _PrtrxDeAmt__13 = PrtrxDeAmt__13;
			PrAmountType _PrtrxDeAmt__14 = PrtrxDeAmt__14;
			PrAmountType _PrtrxDeAmt__15 = PrtrxDeAmt__15;
			PrAmountType _PrtrxDeAmt__16 = PrtrxDeAmt__16;
			PrAmountType _PrtrxDeAmt__17 = PrtrxDeAmt__17;
			PrAmountType _PrtrxDeAmt__18 = PrtrxDeAmt__18;
			PrAmountType _PrtrxGrossPay = PrtrxGrossPay;
			PrAmountType _PrtrxNetPay = PrtrxNetPay;
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
				cmd.CommandText = "Prtrxf2Sp";
				
				appDB.AddCommandParameter(cmd, "PrdecdRec", _PrdecdRec, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Index", _Index, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrtrxEmpNum", _PrtrxEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrtrxDeAmt##1", _PrtrxDeAmt__1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrtrxDeAmt##2", _PrtrxDeAmt__2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrtrxDeAmt##3", _PrtrxDeAmt__3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrtrxDeAmt##4", _PrtrxDeAmt__4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrtrxDeAmt##5", _PrtrxDeAmt__5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrtrxDeAmt##6", _PrtrxDeAmt__6, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrtrxDeAmt##7", _PrtrxDeAmt__7, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrtrxDeAmt##8", _PrtrxDeAmt__8, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrtrxDeAmt##9", _PrtrxDeAmt__9, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrtrxDeAmt##10", _PrtrxDeAmt__10, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrtrxDeAmt##11", _PrtrxDeAmt__11, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrtrxDeAmt##12", _PrtrxDeAmt__12, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrtrxDeAmt##13", _PrtrxDeAmt__13, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrtrxDeAmt##14", _PrtrxDeAmt__14, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrtrxDeAmt##15", _PrtrxDeAmt__15, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrtrxDeAmt##16", _PrtrxDeAmt__16, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrtrxDeAmt##17", _PrtrxDeAmt__17, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrtrxDeAmt##18", _PrtrxDeAmt__18, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrtrxGrossPay", _PrtrxGrossPay, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxNetPay", _PrtrxNetPay, ParameterDirection.InputOutput);
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
				
				PrtrxGrossPay = _PrtrxGrossPay;
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
				
				return (Severity, PrtrxGrossPay, PrtrxNetPay, PrtrxFwtG, PrtrxEFicaG, PrtrxRFicaG, PrtrxEMedG, PrtrxRMedG, PrtrxFuiG, PrtrxEicG, PrtrxSwtG, PrtrxSuiG, PrtrxOstG, PrtrxWCompG, PrtrxSupplBenG, PrtrxCwtG, Infobar);
			}
		}
	}
}
