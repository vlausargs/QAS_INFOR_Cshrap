//PROJECT NAME: Data
//CLASS NAME: IItemlfnd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IItemlfnd
	{
		(int? ReturnCode,
			string Infobar,
			DateTime? trans_date,
			decimal? qty,
			decimal? unit_cost,
			decimal? matl_cost,
			decimal? lbr_cost,
			decimal? fovhd_cost,
			decimal? vovhd_cost,
			decimal? out_cost,
			string inv_acct_unit1,
			string inv_acct_unit2,
			string inv_acct_unit3,
			string inv_acct_unit4,
			string lbr_acct_unit1,
			string lbr_acct_unit2,
			string lbr_acct_unit3,
			string lbr_acct_unit4,
			string fovhd_acct_unit1,
			string fovhd_acct_unit2,
			string fovhd_acct_unit3,
			string fovhd_acct_unit4,
			string vovhd_acct_unit1,
			string vovhd_acct_unit2,
			string vovhd_acct_unit3,
			string vovhd_acct_unit4,
			string out_acct_unit1,
			string out_acct_unit2,
			string out_acct_unit3,
			string out_acct_unit4,
			int? NoteExistsFlag,
			DateTime? RecordDate,
			Guid? RowPointer) ItemlfndSp(
			string item,
			string cost_method,
			string inv_acct,
			string lbr_acct,
			string fovhd_acct,
			string vovhd_acct,
			string out_acct,
			string Infobar,
			DateTime? trans_date = null,
			decimal? qty = null,
			decimal? unit_cost = null,
			decimal? matl_cost = null,
			decimal? lbr_cost = null,
			decimal? fovhd_cost = null,
			decimal? vovhd_cost = null,
			decimal? out_cost = null,
			string inv_acct_unit1 = null,
			string inv_acct_unit2 = null,
			string inv_acct_unit3 = null,
			string inv_acct_unit4 = null,
			string lbr_acct_unit1 = null,
			string lbr_acct_unit2 = null,
			string lbr_acct_unit3 = null,
			string lbr_acct_unit4 = null,
			string fovhd_acct_unit1 = null,
			string fovhd_acct_unit2 = null,
			string fovhd_acct_unit3 = null,
			string fovhd_acct_unit4 = null,
			string vovhd_acct_unit1 = null,
			string vovhd_acct_unit2 = null,
			string vovhd_acct_unit3 = null,
			string vovhd_acct_unit4 = null,
			string out_acct_unit1 = null,
			string out_acct_unit2 = null,
			string out_acct_unit3 = null,
			string out_acct_unit4 = null,
			int? NoteExistsFlag = null,
			DateTime? RecordDate = null,
			Guid? RowPointer = null,
			string Whse = null);
	}
}

