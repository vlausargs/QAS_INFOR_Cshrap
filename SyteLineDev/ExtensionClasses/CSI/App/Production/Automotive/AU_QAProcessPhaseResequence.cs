//PROJECT NAME: Production
//CLASS NAME: AU_QAProcessPhaseResequence.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Automotive
{
	public class AU_QAProcessPhaseResequence : IAU_QAProcessPhaseResequence
	{
		readonly IApplicationDB appDB;

		public AU_QAProcessPhaseResequence(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public int? AU_QAProcessPhaseResequenceSp(
			string QAProcess)
		{
			AU_QAProcessIDType _QAProcess = QAProcess;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AU_QAProcessPhaseResequenceSp";

				appDB.AddCommandParameter(cmd, "QAProcess", _QAProcess, ParameterDirection.Input);

				var Severity = appDB.ExecuteNonQuery(cmd);

				return (Severity);
			}
		}
	}
}
