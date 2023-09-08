//PROJECT NAME: Production
//CLASS NAME: CLM_SavePPJobInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class CLM_SavePPJobInfo : ICLM_SavePPJobInfo
	{
		readonly IApplicationDB appDB;
		
		
		public CLM_SavePPJobInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) CLM_SavePPJobInfoSp(int? ProdBatchId,
		decimal? MinSheetCount,
		decimal? PrintQuatePrice,
		decimal? PaperConsumptionQty,
		int? Out,
		int? Up,
		int? IsNeedAddppJob,
		string Infobar)
		{
			ApsBatchNumberType _ProdBatchId = ProdBatchId;
			PP_SheetCountType _MinSheetCount = MinSheetCount;
			CostPrcType _PrintQuatePrice = PrintQuatePrice;
			QtyUnitNoNegType _PaperConsumptionQty = PaperConsumptionQty;
			PP_OutNumberType _Out = Out;
			PP_UpNumberType _Up = Up;
			ListYesNoType _IsNeedAddppJob = IsNeedAddppJob;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_SavePPJobInfoSp";
				
				appDB.AddCommandParameter(cmd, "ProdBatchId", _ProdBatchId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MinSheetCount", _MinSheetCount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintQuatePrice", _PrintQuatePrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PaperConsumptionQty", _PaperConsumptionQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Out", _Out, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Up", _Up, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IsNeedAddppJob", _IsNeedAddppJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
