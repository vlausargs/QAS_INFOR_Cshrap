//PROJECT NAME: Production
//CLASS NAME: PmfFmCreateRevision.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfFmCreateRevision
	{
		(int? ReturnCode, string InfoBar, Guid? ToFmRp, int? CurrRevision, DateTime? FmRecordDate) PmfFmCreateRevisionSp(string InfoBar = null,
		                                                                                                                 Guid? FromFmRp = null,
		                                                                                                                 Guid? ToFmRp = null,
		                                                                                                                 int? CurrRevision = null,
		                                                                                                                 DateTime? FmRecordDate = null);
	}
	
	public class PmfFmCreateRevision : IPmfFmCreateRevision
	{
		readonly IApplicationDB appDB;
		
		public PmfFmCreateRevision(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string InfoBar, Guid? ToFmRp, int? CurrRevision, DateTime? FmRecordDate) PmfFmCreateRevisionSp(string InfoBar = null,
		                                                                                                                        Guid? FromFmRp = null,
		                                                                                                                        Guid? ToFmRp = null,
		                                                                                                                        int? CurrRevision = null,
		                                                                                                                        DateTime? FmRecordDate = null)
		{
			InfobarType _InfoBar = InfoBar;
			RowPointerType _FromFmRp = FromFmRp;
			RowPointerType _ToFmRp = ToFmRp;
			IntType _CurrRevision = CurrRevision;
			DateTimeType _FmRecordDate = FmRecordDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfFmCreateRevisionSp";
				
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FromFmRp", _FromFmRp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToFmRp", _ToFmRp, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurrRevision", _CurrRevision, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FmRecordDate", _FmRecordDate, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				ToFmRp = _ToFmRp;
				CurrRevision = _CurrRevision;
				FmRecordDate = _FmRecordDate;
				
				return (Severity, InfoBar, ToFmRp, CurrRevision, FmRecordDate);
			}
		}
	}
}
