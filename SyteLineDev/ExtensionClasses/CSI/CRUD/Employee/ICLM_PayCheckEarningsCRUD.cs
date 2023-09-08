//PROJECT NAME: Employee
//CLASS NAME: ICLM_PayCheckEarningsCRUD.cs

using System;
using System.Data;
using CSI.Data.Cache;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface ICLM_PayCheckEarningsCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse Optional_Module1Select();
		void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName);
		ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
		void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		ICollectionLoadResponse Tv_Tmp_TblSelect();
		void Tv_Tmp_TblDelete(ICollectionLoadResponse tv_tmp_tblLoadResponse);
		(int? CheckNum, int? rowCount) PrtrxpLoad(Guid? CheckRowPointer, int? CheckNum);
		ICollectionLoadResponse Tv_Tmp_Tbl1Select(DateTime? YearStart, DateTime? CheckDate, int? CheckNum, string EmpNum, Guid? CheckRowPointer);
		void Tv_Tmp_Tbl1Insert(ICollectionLoadResponse tv_tmp_tbl1LoadResponse);
		ICollectionLoadResponse Tv_Tmp_Tbl2Select(DateTime? YearStart, DateTime? CheckDate, int? CheckNum, string EmpNum, Guid? CheckRowPointer);
		void Tv_Tmp_Tbl2Insert(ICollectionLoadResponse tv_tmp_tbl2LoadResponse);
		ICollectionLoadResponse Tv_Tmp_Tbl3Select(DateTime? YearStart, DateTime? CheckDate, int? CheckNum, string EmpNum, Guid? CheckRowPointer);
		void Tv_Tmp_Tbl3Insert(ICollectionLoadResponse tv_tmp_tbl3LoadResponse);
		ICollectionLoadResponse Tv_Tmp_Tbl4Select(DateTime? YearStart, DateTime? CheckDate, int? CheckNum, string EmpNum, Guid? CheckRowPointer);
		void Tv_Tmp_Tbl4Insert(ICollectionLoadResponse tv_tmp_tbl4LoadResponse);
		ICollectionLoadResponse Tv_Tmp_Tbl5Select(DateTime? YearStart, DateTime? CheckDate, int? CheckNum, string EmpNum, Guid? CheckRowPointer);
		void Tv_Tmp_Tbl5Insert(ICollectionLoadResponse tv_tmp_tbl5LoadResponse);
		ICollectionLoadResponse Tv_Tmp_Tbl6Select(DateTime? YearStart, DateTime? CheckDate, int? CheckNum, string EmpNum, Guid? CheckRowPointer);
		void Tv_Tmp_Tbl6Insert(ICollectionLoadResponse tv_tmp_tbl6LoadResponse);
		ICollectionLoadResponse Tv_Tmp_Tbl7Select(DateTime? YearStart, DateTime? CheckDate, int? CheckNum, string EmpNum, Guid? CheckRowPointer);
		void Tv_Tmp_Tbl7Insert(ICollectionLoadResponse tv_tmp_tbl7LoadResponse);
		ICollectionLoadResponse Tv_Tmp_Tbl8Select(DateTime? YearStart, DateTime? CheckDate, int? CheckNum, string EmpNum, Guid? CheckRowPointer);
		void Tv_Tmp_Tbl8Insert(ICollectionLoadResponse tv_tmp_tbl8LoadResponse);
		ICollectionLoadResponse Tv_Tmp_Tbl9Select(DateTime? YearStart, DateTime? CheckDate, int? CheckNum, string EmpNum, Guid? CheckRowPointer);
		void Tv_Tmp_Tbl9Insert(ICollectionLoadResponse tv_tmp_tbl9LoadResponse);
		IRecordStream Prtrxp1Select(DateTime? CheckDate, string EmpNum, DateTime? YearStart, int? CheckNum, Guid? CheckRowPointer, LoadType loadType = LoadType.First, CachePageSize pageSize = CachePageSize.XLarge);
		(string TmpDeCode, string TmpDescription, string TmpType, decimal? TmpDeAmt, int? rowCount) PrdecdLoad(string PrtrxpDeCode__1, decimal? PrtrxpDeAmt__1, string TmpDescription, string TmpDeCode, decimal? TmpDeAmt, string TmpType);
		(string TmpDeCode, string TmpDescription, string TmpType, decimal? TmpDeAmt, int? rowCount) Prdecd1Load(string PrtrxpDeCode__2, decimal? PrtrxpDeAmt__2, string TmpDescription, string TmpDeCode, decimal? TmpDeAmt, string TmpType);
		(string TmpDeCode, string TmpDescription, string TmpType, decimal? TmpDeAmt, int? rowCount) Prdecd2Load(string PrtrxpDeCode__3, decimal? PrtrxpDeAmt__3, string TmpDescription, string TmpDeCode, decimal? TmpDeAmt, string TmpType);
		(string TmpDeCode, string TmpDescription, string TmpType, decimal? TmpDeAmt, int? rowCount) Prdecd3Load(string PrtrxpDeCode__4, decimal? PrtrxpDeAmt__4, string TmpDescription, string TmpDeCode, decimal? TmpDeAmt, string TmpType);
		(string TmpDeCode, string TmpDescription, string TmpType, decimal? TmpDeAmt, int? rowCount) Prdecd4Load(string PrtrxpDeCode__5, decimal? PrtrxpDeAmt__5, string TmpDescription, string TmpDeCode, decimal? TmpDeAmt, string TmpType);
		(string TmpDeCode, string TmpDescription, string TmpType, decimal? TmpDeAmt, int? rowCount) Prdecd5Load(string PrtrxpDeCode__6, decimal? PrtrxpDeAmt__6, string TmpDescription, string TmpDeCode, decimal? TmpDeAmt, string TmpType);
		(string TmpDeCode, string TmpDescription, string TmpType, decimal? TmpDeAmt, int? rowCount) Prdecd6Load(string PrtrxpDeCode__7, decimal? PrtrxpDeAmt__7, string TmpDescription, string TmpDeCode, decimal? TmpDeAmt, string TmpType);
		(string TmpDeCode, string TmpDescription, string TmpType, decimal? TmpDeAmt, int? rowCount) Prdecd7Load(string PrtrxpDeCode__8, decimal? PrtrxpDeAmt__8, string TmpDescription, string TmpDeCode, decimal? TmpDeAmt, string TmpType);
		(string TmpDeCode, string TmpDescription, string TmpType, decimal? TmpDeAmt, int? rowCount) Prdecd8Load(string PrtrxpDeCode__9, decimal? PrtrxpDeAmt__9, string TmpDescription, string TmpDeCode, decimal? TmpDeAmt, string TmpType);
		(string TmpDeCode, string TmpDescription, string TmpType, decimal? TmpDeAmt, int? rowCount) Prdecd9Load(string PrtrxpDeCode__10, decimal? PrtrxpDeAmt__10, string TmpDescription, string TmpDeCode, decimal? TmpDeAmt, string TmpType);
		(string TmpDeCode, string TmpDescription, string TmpType, decimal? TmpDeAmt, int? rowCount) Prdecd10Load(string PrtrxpDeCode__11, decimal? PrtrxpDeAmt__11, string TmpDescription, string TmpDeCode, decimal? TmpDeAmt, string TmpType);
		(string TmpDeCode, string TmpDescription, string TmpType, decimal? TmpDeAmt, int? rowCount) Prdecd11Load(string PrtrxpDeCode__12, decimal? PrtrxpDeAmt__12, string TmpDescription, string TmpDeCode, decimal? TmpDeAmt, string TmpType);
		(string TmpDeCode, string TmpDescription, string TmpType, decimal? TmpDeAmt, int? rowCount) Prdecd12Load(string PrtrxpDeCode__13, decimal? PrtrxpDeAmt__13, string TmpDescription, string TmpDeCode, decimal? TmpDeAmt, string TmpType);
		(string TmpDeCode, string TmpDescription, string TmpType, decimal? TmpDeAmt, int? rowCount) Prdecd13Load(string PrtrxpDeCode__14, decimal? PrtrxpDeAmt__14, string TmpDescription, string TmpDeCode, decimal? TmpDeAmt, string TmpType);
		(string TmpDeCode, string TmpDescription, string TmpType, decimal? TmpDeAmt, int? rowCount) Prdecd14Load(string PrtrxpDeCode__15, decimal? PrtrxpDeAmt__15, string TmpDescription, string TmpDeCode, decimal? TmpDeAmt, string TmpType);
		(string TmpDeCode, string TmpDescription, string TmpType, decimal? TmpDeAmt, int? rowCount) Prdecd15Load(string PrtrxpDeCode__16, decimal? PrtrxpDeAmt__16, string TmpDescription, string TmpDeCode, decimal? TmpDeAmt, string TmpType);
		(string TmpDeCode, string TmpDescription, string TmpType, decimal? TmpDeAmt, int? rowCount) Prdecd16Load(string PrtrxpDeCode__17, decimal? PrtrxpDeAmt__17, string TmpDescription, string TmpDeCode, decimal? TmpDeAmt, string TmpType);
		(string TmpDeCode, string TmpDescription, string TmpType, decimal? TmpDeAmt, int? rowCount) Prdecd17Load(string PrtrxpDeCode__18, decimal? PrtrxpDeAmt__18, string TmpDescription, string TmpDeCode, decimal? TmpDeAmt, string TmpType);
		bool Tv_Tmp_Tbl10ForExists(string TmpDeCode);
		ICollectionLoadResponse Nontable1Select(string TmpDescription, string TmpDeCode, Guid? CheckRowPointer, Guid? PrtrxpRowPointer, decimal? TmpDeAmt);
		void Nontable1Insert(ICollectionLoadResponse nonTable1LoadResponse);
		ICollectionLoadResponse Tv_Tmp_Tbl11Select(string TmpDeCode);
		void Tv_Tmp_Tbl11Update(Guid? CheckRowPointer, Guid? PrtrxpRowPointer, decimal? TmpDeAmt, ICollectionLoadResponse tv_tmp_tbl11LoadResponse);
		ICollectionLoadResponse Tv_Tmp_Tbl12Select();
		(ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_CLM_PayCheckEarningsSp(string AltExtGenSp, DateTime? CheckDate, Guid? CheckRowPointer, string EmpNum);
	}
}

