//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSroPlanTransPostMatl.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSroPlanTransPostMatl : ISSSFSSroPlanTransPostMatl
	{
		readonly IApplicationDB appDB;
		
		
		public SSSFSSroPlanTransPostMatl(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SSSFSSroPlanTransPostMatlSp(Guid? iRowPointer,
		string iMode,
		string iPartnerId,
		string iDept,
		string iWhse,
		DateTime? iTransDate,
		DateTime? iPostDate,
		decimal? iPstMatlQtyConv,
		decimal? iMatlCostConv,
		decimal? iLbrCostConv,
		decimal? iFovhdCostConv,
		decimal? iVovhdCostConv,
		decimal? iOutCostConv,
		string UpdateStatus,
		string Infobar)
		{
			RowPointerType _iRowPointer = iRowPointer;
			StringType _iMode = iMode;
			FSPartnerType _iPartnerId = iPartnerId;
			DeptType _iDept = iDept;
			WhseType _iWhse = iWhse;
			DateType _iTransDate = iTransDate;
			DateType _iPostDate = iPostDate;
			QtyUnitType _iPstMatlQtyConv = iPstMatlQtyConv;
			CostPrcType _iMatlCostConv = iMatlCostConv;
			CostPrcType _iLbrCostConv = iLbrCostConv;
			CostPrcType _iFovhdCostConv = iFovhdCostConv;
			CostPrcType _iVovhdCostConv = iVovhdCostConv;
			CostPrcType _iOutCostConv = iOutCostConv;
			StringType _UpdateStatus = UpdateStatus;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSroPlanTransPostMatlSp";
				
				appDB.AddCommandParameter(cmd, "iRowPointer", _iRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iMode", _iMode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iPartnerId", _iPartnerId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iDept", _iDept, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iWhse", _iWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iTransDate", _iTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iPostDate", _iPostDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iPstMatlQtyConv", _iPstMatlQtyConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iMatlCostConv", _iMatlCostConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iLbrCostConv", _iLbrCostConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iFovhdCostConv", _iFovhdCostConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iVovhdCostConv", _iVovhdCostConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iOutCostConv", _iOutCostConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UpdateStatus", _UpdateStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
