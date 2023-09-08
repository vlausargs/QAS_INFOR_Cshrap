//PROJECT NAME: Logistics
//CLASS NAME: SSSTraceStart.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSTraceStart : ISSSTraceStart
	{
		readonly IApplicationDB appDB;

		public SSSTraceStart(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public (int? ReturnCode,
			int? oTraceID,
			string oServerName,
			string oTraceFile,
			string Infobar) SSSTraceStartSp(
			long? iMaxTraceSizeMB,
			int? oTraceID,
			string oServerName,
			string oTraceFile,
			string Infobar,
			string FilterDatabaseNameLike,
			string FilterHostNameLike,
			string FilterLoginNameLike,
			string FilterTextDataLike,
			string FilterObjectNameLike,
			int? FilterSPIDEQ)
		{
			LongType _iMaxTraceSizeMB = iMaxTraceSizeMB;
			IntType _oTraceID = oTraceID;
			StringType _oServerName = oServerName;
			StringType _oTraceFile = oTraceFile;
			InfobarType _Infobar = Infobar;
			StringType _FilterDatabaseNameLike = FilterDatabaseNameLike;
			StringType _FilterHostNameLike = FilterHostNameLike;
			StringType _FilterLoginNameLike = FilterLoginNameLike;
			StringType _FilterTextDataLike = FilterTextDataLike;
			StringType _FilterObjectNameLike = FilterObjectNameLike;
			IntType _FilterSPIDEQ = FilterSPIDEQ;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSTraceStartSp";

				appDB.AddCommandParameter(cmd, "iMaxTraceSizeMB", _iMaxTraceSizeMB, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "oTraceID", _oTraceID, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oServerName", _oServerName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oTraceFile", _oTraceFile, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FilterDatabaseNameLike", _FilterDatabaseNameLike, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FilterHostNameLike", _FilterHostNameLike, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FilterLoginNameLike", _FilterLoginNameLike, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FilterTextDataLike", _FilterTextDataLike, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FilterObjectNameLike", _FilterObjectNameLike, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FilterSPIDEQ", _FilterSPIDEQ, ParameterDirection.Input);

				var Severity = appDB.ExecuteNonQuery(cmd);

				oTraceID = _oTraceID;
				oServerName = _oServerName;
				oTraceFile = _oTraceFile;
				Infobar = _Infobar;

				return (Severity, oTraceID, oServerName, oTraceFile, Infobar);
			}
		}
	}
}
