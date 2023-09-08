//PROJECT NAME: Production
//CLASS NAME: PmfPnAddProd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfPnAddProd : IPmfPnAddProd
	{
		readonly IApplicationDB appDB;
		
		public PmfPnAddProd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar,
			int? Severity,
			Guid? JobRp) PmfPnAddProdSp(
			string Infobar = null,
			int? Severity = null,
			Guid? PnRp = null,
			Guid? MfSpecOrdRp = null,
			string Item = null,
			string Whse = null,
			decimal? Qty = null,
			string BOMItemOvrd = null,
			int? BOMItemSource = 0,
			Guid? JobRp = null,
			int? AddWipItemIfMissing = 0,
			string WipItem = null,
			decimal? FmDens = null,
			int? OrdType = 0)
		{
			InfobarType _Infobar = Infobar;
			ShortType _Severity = Severity;
			RowPointerType _PnRp = PnRp;
			RowPointerType _MfSpecOrdRp = MfSpecOrdRp;
			ItemType _Item = Item;
			WhseType _Whse = Whse;
			ProcessMfgQuantityType _Qty = Qty;
			ItemType _BOMItemOvrd = BOMItemOvrd;
			IntType _BOMItemSource = BOMItemSource;
			RowPointer _JobRp = JobRp;
			IntType _AddWipItemIfMissing = AddWipItemIfMissing;
			ItemType _WipItem = WipItem;
			ProcessMfgQuantityType _FmDens = FmDens;
			IntType _OrdType = OrdType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfPnAddProdSp";
				
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Severity", _Severity, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PnRp", _PnRp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MfSpecOrdRp", _MfSpecOrdRp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Qty", _Qty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BOMItemOvrd", _BOMItemOvrd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BOMItemSource", _BOMItemSource, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobRp", _JobRp, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AddWipItemIfMissing", _AddWipItemIfMissing, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WipItem", _WipItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FmDens", _FmDens, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrdType", _OrdType, ParameterDirection.Input);
				
				Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				Severity = _Severity;
				JobRp = _JobRp;
				
				return (Severity, Infobar, Severity, JobRp);
			}
		}
	}
}
