//PROJECT NAME: Data
//CLASS NAME: Itemlfnd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Itemlfnd : IItemlfnd
	{
		readonly IApplicationDB appDB;
		
		public Itemlfnd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
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
			string Whse = null)
		{
			ItemType _item = item;
			CostMethodType _cost_method = cost_method;
			AcctType _inv_acct = inv_acct;
			AcctType _lbr_acct = lbr_acct;
			AcctType _fovhd_acct = fovhd_acct;
			AcctType _vovhd_acct = vovhd_acct;
			AcctType _out_acct = out_acct;
			InfobarType _Infobar = Infobar;
			DateTimeType _trans_date = trans_date;
			QtyUnitType _qty = qty;
			CostPrcType _unit_cost = unit_cost;
			CostPrcType _matl_cost = matl_cost;
			CostPrcType _lbr_cost = lbr_cost;
			CostPrcType _fovhd_cost = fovhd_cost;
			CostPrcType _vovhd_cost = vovhd_cost;
			CostPrcType _out_cost = out_cost;
			UnitCode1Type _inv_acct_unit1 = inv_acct_unit1;
			UnitCode2Type _inv_acct_unit2 = inv_acct_unit2;
			UnitCode3Type _inv_acct_unit3 = inv_acct_unit3;
			UnitCode4Type _inv_acct_unit4 = inv_acct_unit4;
			UnitCode1Type _lbr_acct_unit1 = lbr_acct_unit1;
			UnitCode2Type _lbr_acct_unit2 = lbr_acct_unit2;
			UnitCode3Type _lbr_acct_unit3 = lbr_acct_unit3;
			UnitCode4Type _lbr_acct_unit4 = lbr_acct_unit4;
			UnitCode1Type _fovhd_acct_unit1 = fovhd_acct_unit1;
			UnitCode2Type _fovhd_acct_unit2 = fovhd_acct_unit2;
			UnitCode3Type _fovhd_acct_unit3 = fovhd_acct_unit3;
			UnitCode4Type _fovhd_acct_unit4 = fovhd_acct_unit4;
			UnitCode1Type _vovhd_acct_unit1 = vovhd_acct_unit1;
			UnitCode2Type _vovhd_acct_unit2 = vovhd_acct_unit2;
			UnitCode3Type _vovhd_acct_unit3 = vovhd_acct_unit3;
			UnitCode4Type _vovhd_acct_unit4 = vovhd_acct_unit4;
			UnitCode1Type _out_acct_unit1 = out_acct_unit1;
			UnitCode2Type _out_acct_unit2 = out_acct_unit2;
			UnitCode3Type _out_acct_unit3 = out_acct_unit3;
			UnitCode4Type _out_acct_unit4 = out_acct_unit4;
			FlagNyType _NoteExistsFlag = NoteExistsFlag;
			CurrentDateType _RecordDate = RecordDate;
			RowPointerType _RowPointer = RowPointer;
			WhseType _Whse = Whse;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemlfndSp";
				
				appDB.AddCommandParameter(cmd, "item", _item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "cost_method", _cost_method, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "inv_acct", _inv_acct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "lbr_acct", _lbr_acct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "fovhd_acct", _fovhd_acct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "vovhd_acct", _vovhd_acct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "out_acct", _out_acct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "trans_date", _trans_date, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "qty", _qty, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "unit_cost", _unit_cost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "matl_cost", _matl_cost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "lbr_cost", _lbr_cost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "fovhd_cost", _fovhd_cost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "vovhd_cost", _vovhd_cost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "out_cost", _out_cost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "inv_acct_unit1", _inv_acct_unit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "inv_acct_unit2", _inv_acct_unit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "inv_acct_unit3", _inv_acct_unit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "inv_acct_unit4", _inv_acct_unit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "lbr_acct_unit1", _lbr_acct_unit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "lbr_acct_unit2", _lbr_acct_unit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "lbr_acct_unit3", _lbr_acct_unit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "lbr_acct_unit4", _lbr_acct_unit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "fovhd_acct_unit1", _fovhd_acct_unit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "fovhd_acct_unit2", _fovhd_acct_unit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "fovhd_acct_unit3", _fovhd_acct_unit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "fovhd_acct_unit4", _fovhd_acct_unit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "vovhd_acct_unit1", _vovhd_acct_unit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "vovhd_acct_unit2", _vovhd_acct_unit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "vovhd_acct_unit3", _vovhd_acct_unit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "vovhd_acct_unit4", _vovhd_acct_unit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "out_acct_unit1", _out_acct_unit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "out_acct_unit2", _out_acct_unit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "out_acct_unit3", _out_acct_unit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "out_acct_unit4", _out_acct_unit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NoteExistsFlag", _NoteExistsFlag, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RecordDate", _RecordDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				trans_date = _trans_date;
				qty = _qty;
				unit_cost = _unit_cost;
				matl_cost = _matl_cost;
				lbr_cost = _lbr_cost;
				fovhd_cost = _fovhd_cost;
				vovhd_cost = _vovhd_cost;
				out_cost = _out_cost;
				inv_acct_unit1 = _inv_acct_unit1;
				inv_acct_unit2 = _inv_acct_unit2;
				inv_acct_unit3 = _inv_acct_unit3;
				inv_acct_unit4 = _inv_acct_unit4;
				lbr_acct_unit1 = _lbr_acct_unit1;
				lbr_acct_unit2 = _lbr_acct_unit2;
				lbr_acct_unit3 = _lbr_acct_unit3;
				lbr_acct_unit4 = _lbr_acct_unit4;
				fovhd_acct_unit1 = _fovhd_acct_unit1;
				fovhd_acct_unit2 = _fovhd_acct_unit2;
				fovhd_acct_unit3 = _fovhd_acct_unit3;
				fovhd_acct_unit4 = _fovhd_acct_unit4;
				vovhd_acct_unit1 = _vovhd_acct_unit1;
				vovhd_acct_unit2 = _vovhd_acct_unit2;
				vovhd_acct_unit3 = _vovhd_acct_unit3;
				vovhd_acct_unit4 = _vovhd_acct_unit4;
				out_acct_unit1 = _out_acct_unit1;
				out_acct_unit2 = _out_acct_unit2;
				out_acct_unit3 = _out_acct_unit3;
				out_acct_unit4 = _out_acct_unit4;
				NoteExistsFlag = _NoteExistsFlag;
				RecordDate = _RecordDate;
				RowPointer = _RowPointer;
				
				return (Severity, Infobar, trans_date, qty, unit_cost, matl_cost, lbr_cost, fovhd_cost, vovhd_cost, out_cost, inv_acct_unit1, inv_acct_unit2, inv_acct_unit3, inv_acct_unit4, lbr_acct_unit1, lbr_acct_unit2, lbr_acct_unit3, lbr_acct_unit4, fovhd_acct_unit1, fovhd_acct_unit2, fovhd_acct_unit3, fovhd_acct_unit4, vovhd_acct_unit1, vovhd_acct_unit2, vovhd_acct_unit3, vovhd_acct_unit4, out_acct_unit1, out_acct_unit2, out_acct_unit3, out_acct_unit4, NoteExistsFlag, RecordDate, RowPointer);
			}
		}
	}
}
