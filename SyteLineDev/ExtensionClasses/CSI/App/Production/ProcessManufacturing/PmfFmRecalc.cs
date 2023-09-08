//PROJECT NAME: Production
//CLASS NAME: PmfFmRecalc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfFmRecalc
	{
		(int? ReturnCode, string Infobar, DateTime? RecordDate) PmfFmRecalcSp(Guid? FmRp = null,
		                                                                      string Infobar = null,
		                                                                      int? RecalcLines = 1,
		                                                                      DateTime? RecordDate = null,
		                                                                      int? UseRecalcFlag = 0);
	}
	
	public class PmfFmRecalc : IPmfFmRecalc
	{
		readonly IApplicationDB appDB;
		
		public PmfFmRecalc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar, DateTime? RecordDate) PmfFmRecalcSp(Guid? FmRp = null,
		                                                                             string Infobar = null,
		                                                                             int? RecalcLines = 1,
		                                                                             DateTime? RecordDate = null,
		                                                                             int? UseRecalcFlag = 0)
		{
			RowPointer _FmRp = FmRp;
			InfobarType _Infobar = Infobar;
			IntType _RecalcLines = RecalcLines;
			DateTimeType _RecordDate = RecordDate;
			IntType _UseRecalcFlag = UseRecalcFlag;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfFmRecalcSp";
				
				appDB.AddCommandParameter(cmd, "FmRp", _FmRp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RecalcLines", _RecalcLines, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RecordDate", _RecordDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UseRecalcFlag", _UseRecalcFlag, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				RecordDate = _RecordDate;
				
				return (Severity, Infobar, RecordDate);
			}
		}
	}
}
