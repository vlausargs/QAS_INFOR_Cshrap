//PROJECT NAME: Logistics
//CLASS NAME: SSSFSPartReimbProcessSub.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSPartReimbProcessSub : ISSSFSPartReimbProcessSub
	{
		readonly IApplicationDB appDB;
		
		public SSSFSPartReimbProcessSub(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? ReimbTot,
			decimal? ReimbTotTax,
			string Infobar) SSSFSPartReimbProcessSubSp(
			string ReimbMethod,
			string VendCatEndUserType,
			string VendNum,
			Guid? SessionID,
			string BatchId,
			decimal? MiscCharges,
			decimal? AmtDue,
			decimal? ReimbTot,
			decimal? ReimbTotTax,
			string Infobar)
		{
			FSReimbMethodType _ReimbMethod = ReimbMethod;
			EndUserTypeType _VendCatEndUserType = VendCatEndUserType;
			VendNumType _VendNum = VendNum;
			RowPointerType _SessionID = SessionID;
			FSReimbBatchIdType _BatchId = BatchId;
			AmountType _MiscCharges = MiscCharges;
			AmountType _AmtDue = AmtDue;
			AmountType _ReimbTot = ReimbTot;
			AmountType _ReimbTotTax = ReimbTotTax;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSPartReimbProcessSubSp";
				
				appDB.AddCommandParameter(cmd, "ReimbMethod", _ReimbMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendCatEndUserType", _VendCatEndUserType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BatchId", _BatchId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MiscCharges", _MiscCharges, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AmtDue", _AmtDue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReimbTot", _ReimbTot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ReimbTotTax", _ReimbTotTax, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ReimbTot = _ReimbTot;
				ReimbTotTax = _ReimbTotTax;
				Infobar = _Infobar;
				
				return (Severity, ReimbTot, ReimbTotTax, Infobar);
			}
		}
	}
}
