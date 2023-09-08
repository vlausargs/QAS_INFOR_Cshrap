//PROJECT NAME: Data
//CLASS NAME: Prtrxf4.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Prtrxf4 : IPrtrxf4
	{
		readonly IApplicationDB appDB;
		
		public Prtrxf4(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string PrtrxDeCode__1,
			string PrtrxDeCode__2,
			string PrtrxDeCode__3,
			string PrtrxDeCode__4,
			string PrtrxDeCode__5,
			string PrtrxDeCode__6,
			string PrtrxDeCode__7,
			string PrtrxDeCode__8,
			string PrtrxDeCode__9,
			string PrtrxDeCode__10,
			string PrtrxDeCode__11,
			string PrtrxDeCode__12,
			string PrtrxDeCode__13,
			string PrtrxDeCode__14,
			string PrtrxDeCode__15,
			string PrtrxDeCode__16,
			string PrtrxDeCode__17,
			string PrtrxDeCode__18,
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
			decimal? PrtrxEMedG,
			decimal? PrtrxRFicaG,
			decimal? PrtrxRMedG,
			decimal? PrtrxFuiG,
			decimal? PrtrxEicG,
			decimal? PrtrxSwtG,
			decimal? PrtrxSuiG,
			decimal? PrtrxOstG,
			decimal? PrtrxWCompG,
			decimal? PrtrxSupplBenG,
			decimal? PrtrxCwtG,
			string Infobar) Prtrxf4Sp(
			decimal? TDeBal__1,
			decimal? TDeBal__2,
			decimal? TDeBal__3,
			decimal? TDeBal__4,
			decimal? TDeBal__5,
			decimal? TDeBal__6,
			decimal? TDeBal__7,
			decimal? TDeBal__8,
			decimal? TDeBal__9,
			decimal? TDeBal__10,
			decimal? TDeBal__11,
			decimal? TDeBal__12,
			decimal? TDeBal__13,
			decimal? TDeBal__14,
			decimal? TDeBal__15,
			string PrtrxEmpNum,
			string PrtrxPayFreqs,
			string PrtrxDeCode__1,
			string PrtrxDeCode__2,
			string PrtrxDeCode__3,
			string PrtrxDeCode__4,
			string PrtrxDeCode__5,
			string PrtrxDeCode__6,
			string PrtrxDeCode__7,
			string PrtrxDeCode__8,
			string PrtrxDeCode__9,
			string PrtrxDeCode__10,
			string PrtrxDeCode__11,
			string PrtrxDeCode__12,
			string PrtrxDeCode__13,
			string PrtrxDeCode__14,
			string PrtrxDeCode__15,
			string PrtrxDeCode__16,
			string PrtrxDeCode__17,
			string PrtrxDeCode__18,
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
			decimal? PrtrxEMedG,
			decimal? PrtrxRFicaG,
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
			PrAmountType _TDeBal__1 = TDeBal__1;
			PrAmountType _TDeBal__2 = TDeBal__2;
			PrAmountType _TDeBal__3 = TDeBal__3;
			PrAmountType _TDeBal__4 = TDeBal__4;
			PrAmountType _TDeBal__5 = TDeBal__5;
			PrAmountType _TDeBal__6 = TDeBal__6;
			PrAmountType _TDeBal__7 = TDeBal__7;
			PrAmountType _TDeBal__8 = TDeBal__8;
			PrAmountType _TDeBal__9 = TDeBal__9;
			PrAmountType _TDeBal__10 = TDeBal__10;
			PrAmountType _TDeBal__11 = TDeBal__11;
			PrAmountType _TDeBal__12 = TDeBal__12;
			PrAmountType _TDeBal__13 = TDeBal__13;
			PrAmountType _TDeBal__14 = TDeBal__14;
			PrAmountType _TDeBal__15 = TDeBal__15;
			EmpNumType _PrtrxEmpNum = PrtrxEmpNum;
			PrPayFreqsType _PrtrxPayFreqs = PrtrxPayFreqs;
			DeCodeType _PrtrxDeCode__1 = PrtrxDeCode__1;
			DeCodeType _PrtrxDeCode__2 = PrtrxDeCode__2;
			DeCodeType _PrtrxDeCode__3 = PrtrxDeCode__3;
			DeCodeType _PrtrxDeCode__4 = PrtrxDeCode__4;
			DeCodeType _PrtrxDeCode__5 = PrtrxDeCode__5;
			DeCodeType _PrtrxDeCode__6 = PrtrxDeCode__6;
			DeCodeType _PrtrxDeCode__7 = PrtrxDeCode__7;
			DeCodeType _PrtrxDeCode__8 = PrtrxDeCode__8;
			DeCodeType _PrtrxDeCode__9 = PrtrxDeCode__9;
			DeCodeType _PrtrxDeCode__10 = PrtrxDeCode__10;
			DeCodeType _PrtrxDeCode__11 = PrtrxDeCode__11;
			DeCodeType _PrtrxDeCode__12 = PrtrxDeCode__12;
			DeCodeType _PrtrxDeCode__13 = PrtrxDeCode__13;
			DeCodeType _PrtrxDeCode__14 = PrtrxDeCode__14;
			DeCodeType _PrtrxDeCode__15 = PrtrxDeCode__15;
			DeCodeType _PrtrxDeCode__16 = PrtrxDeCode__16;
			DeCodeType _PrtrxDeCode__17 = PrtrxDeCode__17;
			DeCodeType _PrtrxDeCode__18 = PrtrxDeCode__18;
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
			PrAmountType _PrtrxEMedG = PrtrxEMedG;
			PrAmountType _PrtrxRFicaG = PrtrxRFicaG;
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
				cmd.CommandText = "Prtrxf4Sp";
				
				appDB.AddCommandParameter(cmd, "TDeBal##1", _TDeBal__1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TDeBal##2", _TDeBal__2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TDeBal##3", _TDeBal__3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TDeBal##4", _TDeBal__4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TDeBal##5", _TDeBal__5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TDeBal##6", _TDeBal__6, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TDeBal##7", _TDeBal__7, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TDeBal##8", _TDeBal__8, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TDeBal##9", _TDeBal__9, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TDeBal##10", _TDeBal__10, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TDeBal##11", _TDeBal__11, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TDeBal##12", _TDeBal__12, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TDeBal##13", _TDeBal__13, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TDeBal##14", _TDeBal__14, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TDeBal##15", _TDeBal__15, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrtrxEmpNum", _PrtrxEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrtrxPayFreqs", _PrtrxPayFreqs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrtrxDeCode##1", _PrtrxDeCode__1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeCode##2", _PrtrxDeCode__2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeCode##3", _PrtrxDeCode__3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeCode##4", _PrtrxDeCode__4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeCode##5", _PrtrxDeCode__5, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeCode##6", _PrtrxDeCode__6, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeCode##7", _PrtrxDeCode__7, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeCode##8", _PrtrxDeCode__8, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeCode##9", _PrtrxDeCode__9, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeCode##10", _PrtrxDeCode__10, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeCode##11", _PrtrxDeCode__11, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeCode##12", _PrtrxDeCode__12, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeCode##13", _PrtrxDeCode__13, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeCode##14", _PrtrxDeCode__14, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeCode##15", _PrtrxDeCode__15, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeCode##16", _PrtrxDeCode__16, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeCode##17", _PrtrxDeCode__17, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeCode##18", _PrtrxDeCode__18, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeAmt##1", _PrtrxDeAmt__1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeAmt##2", _PrtrxDeAmt__2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeAmt##3", _PrtrxDeAmt__3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeAmt##4", _PrtrxDeAmt__4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeAmt##5", _PrtrxDeAmt__5, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeAmt##6", _PrtrxDeAmt__6, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeAmt##7", _PrtrxDeAmt__7, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeAmt##8", _PrtrxDeAmt__8, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeAmt##9", _PrtrxDeAmt__9, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeAmt##10", _PrtrxDeAmt__10, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeAmt##11", _PrtrxDeAmt__11, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeAmt##12", _PrtrxDeAmt__12, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeAmt##13", _PrtrxDeAmt__13, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeAmt##14", _PrtrxDeAmt__14, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeAmt##15", _PrtrxDeAmt__15, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeAmt##16", _PrtrxDeAmt__16, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeAmt##17", _PrtrxDeAmt__17, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxDeAmt##18", _PrtrxDeAmt__18, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxGrossPay", _PrtrxGrossPay, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxNetPay", _PrtrxNetPay, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxFwtG", _PrtrxFwtG, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxEFicaG", _PrtrxEFicaG, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxEMedG", _PrtrxEMedG, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrtrxRFicaG", _PrtrxRFicaG, ParameterDirection.InputOutput);
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
				
				PrtrxDeCode__1 = _PrtrxDeCode__1;
				PrtrxDeCode__2 = _PrtrxDeCode__2;
				PrtrxDeCode__3 = _PrtrxDeCode__3;
				PrtrxDeCode__4 = _PrtrxDeCode__4;
				PrtrxDeCode__5 = _PrtrxDeCode__5;
				PrtrxDeCode__6 = _PrtrxDeCode__6;
				PrtrxDeCode__7 = _PrtrxDeCode__7;
				PrtrxDeCode__8 = _PrtrxDeCode__8;
				PrtrxDeCode__9 = _PrtrxDeCode__9;
				PrtrxDeCode__10 = _PrtrxDeCode__10;
				PrtrxDeCode__11 = _PrtrxDeCode__11;
				PrtrxDeCode__12 = _PrtrxDeCode__12;
				PrtrxDeCode__13 = _PrtrxDeCode__13;
				PrtrxDeCode__14 = _PrtrxDeCode__14;
				PrtrxDeCode__15 = _PrtrxDeCode__15;
				PrtrxDeCode__16 = _PrtrxDeCode__16;
				PrtrxDeCode__17 = _PrtrxDeCode__17;
				PrtrxDeCode__18 = _PrtrxDeCode__18;
				PrtrxDeAmt__1 = _PrtrxDeAmt__1;
				PrtrxDeAmt__2 = _PrtrxDeAmt__2;
				PrtrxDeAmt__3 = _PrtrxDeAmt__3;
				PrtrxDeAmt__4 = _PrtrxDeAmt__4;
				PrtrxDeAmt__5 = _PrtrxDeAmt__5;
				PrtrxDeAmt__6 = _PrtrxDeAmt__6;
				PrtrxDeAmt__7 = _PrtrxDeAmt__7;
				PrtrxDeAmt__8 = _PrtrxDeAmt__8;
				PrtrxDeAmt__9 = _PrtrxDeAmt__9;
				PrtrxDeAmt__10 = _PrtrxDeAmt__10;
				PrtrxDeAmt__11 = _PrtrxDeAmt__11;
				PrtrxDeAmt__12 = _PrtrxDeAmt__12;
				PrtrxDeAmt__13 = _PrtrxDeAmt__13;
				PrtrxDeAmt__14 = _PrtrxDeAmt__14;
				PrtrxDeAmt__15 = _PrtrxDeAmt__15;
				PrtrxDeAmt__16 = _PrtrxDeAmt__16;
				PrtrxDeAmt__17 = _PrtrxDeAmt__17;
				PrtrxDeAmt__18 = _PrtrxDeAmt__18;
				PrtrxGrossPay = _PrtrxGrossPay;
				PrtrxNetPay = _PrtrxNetPay;
				PrtrxFwtG = _PrtrxFwtG;
				PrtrxEFicaG = _PrtrxEFicaG;
				PrtrxEMedG = _PrtrxEMedG;
				PrtrxRFicaG = _PrtrxRFicaG;
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
				
				return (Severity, PrtrxDeCode__1, PrtrxDeCode__2, PrtrxDeCode__3, PrtrxDeCode__4, PrtrxDeCode__5, PrtrxDeCode__6, PrtrxDeCode__7, PrtrxDeCode__8, PrtrxDeCode__9, PrtrxDeCode__10, PrtrxDeCode__11, PrtrxDeCode__12, PrtrxDeCode__13, PrtrxDeCode__14, PrtrxDeCode__15, PrtrxDeCode__16, PrtrxDeCode__17, PrtrxDeCode__18, PrtrxDeAmt__1, PrtrxDeAmt__2, PrtrxDeAmt__3, PrtrxDeAmt__4, PrtrxDeAmt__5, PrtrxDeAmt__6, PrtrxDeAmt__7, PrtrxDeAmt__8, PrtrxDeAmt__9, PrtrxDeAmt__10, PrtrxDeAmt__11, PrtrxDeAmt__12, PrtrxDeAmt__13, PrtrxDeAmt__14, PrtrxDeAmt__15, PrtrxDeAmt__16, PrtrxDeAmt__17, PrtrxDeAmt__18, PrtrxGrossPay, PrtrxNetPay, PrtrxFwtG, PrtrxEFicaG, PrtrxEMedG, PrtrxRFicaG, PrtrxRMedG, PrtrxFuiG, PrtrxEicG, PrtrxSwtG, PrtrxSuiG, PrtrxOstG, PrtrxWCompG, PrtrxSupplBenG, PrtrxCwtG, Infobar);
			}
		}
	}
}
