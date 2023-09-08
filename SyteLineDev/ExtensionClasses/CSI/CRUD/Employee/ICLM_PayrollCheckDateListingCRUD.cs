//PROJECT NAME: Employee
//CLASS NAME: ICLM_PayrollCheckDateListingCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface ICLM_PayrollCheckDateListingCRUD
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
		ICollectionLoadResponse PrtrxpSelect(string EmpNum);
		void PrtrxpInsert(ICollectionLoadResponse prtrxpLoadResponse);
		ICollectionLoadResponse Tv_Tmp_Tbl1Select();
		bool Prtrxp1ForExists(string EmpNum, int? CheckNum);
		ICollectionLoadResponse Tv_Tmp_Tbl2Select(int? CheckNum);
		void Tv_Tmp_Tbl2Delete(ICollectionLoadResponse tv_tmp_tbl2LoadResponse);
		ICollectionLoadResponse Tv_Tmp_Tbl3Select();
		(ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_CLM_PayrollCheckDateListingSp(string AltExtGenSp, string EmpNum);
	}
}

