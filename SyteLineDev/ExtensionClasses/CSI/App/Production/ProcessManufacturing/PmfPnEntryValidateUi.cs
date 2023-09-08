//PROJECT NAME: Production
//CLASS NAME: PmfPnEntryValidateUi.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfPnEntryValidateUi
	{
		(int? ReturnCode, string InfoBar, int? ResetPn, string RecordDate, int? EnforceBatchSizes, int? HasByProduct) PmfPnEntryValidateUiSp(string InfoBar = null,
		                                                                                                                                     Guid? PnWrkRp = null,
		                                                                                                                                     int? InitOnly = 1,
		                                                                                                                                     int? ResetPn = 0,
		                                                                                                                                     int? SpecChanged = 0,
		                                                                                                                                     string RecordDate = null,
		                                                                                                                                     int? EnforceBatchSizes = 0,
		                                                                                                                                     int? HasByProduct = 0);
	}
	
	public class PmfPnEntryValidateUi : IPmfPnEntryValidateUi
	{
		readonly IApplicationDB appDB;
		
		public PmfPnEntryValidateUi(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string InfoBar, int? ResetPn, string RecordDate, int? EnforceBatchSizes, int? HasByProduct) PmfPnEntryValidateUiSp(string InfoBar = null,
		                                                                                                                                            Guid? PnWrkRp = null,
		                                                                                                                                            int? InitOnly = 1,
		                                                                                                                                            int? ResetPn = 0,
		                                                                                                                                            int? SpecChanged = 0,
		                                                                                                                                            string RecordDate = null,
		                                                                                                                                            int? EnforceBatchSizes = 0,
		                                                                                                                                            int? HasByProduct = 0)
		{
			InfobarType _InfoBar = InfoBar;
			RowPointerType _PnWrkRp = PnWrkRp;
			IntType _InitOnly = InitOnly;
			IntType _ResetPn = ResetPn;
			IntType _SpecChanged = SpecChanged;
			StringType _RecordDate = RecordDate;
			IntType _EnforceBatchSizes = EnforceBatchSizes;
			IntType _HasByProduct = HasByProduct;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfPnEntryValidateUiSp";
				
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PnWrkRp", _PnWrkRp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InitOnly", _InitOnly, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResetPn", _ResetPn, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SpecChanged", _SpecChanged, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RecordDate", _RecordDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EnforceBatchSizes", _EnforceBatchSizes, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "HasByProduct", _HasByProduct, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				ResetPn = _ResetPn;
				RecordDate = _RecordDate;
				EnforceBatchSizes = _EnforceBatchSizes;
				HasByProduct = _HasByProduct;
				
				return (Severity, InfoBar, ResetPn, RecordDate, EnforceBatchSizes, HasByProduct);
			}
		}
	}
}
