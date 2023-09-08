//PROJECT NAME: Production
//CLASS NAME: GetVariableDateBuckets.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class GetVariableDateBuckets : IGetVariableDateBuckets
	{
		readonly IApplicationDB appDB;
		
		
		public GetVariableDateBuckets(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, DateTime? PerStart,
		DateTime? PerEnd,
		DateTime? PeriodStart1,
		DateTime? PeriodStart2,
		DateTime? PeriodStart3,
		DateTime? PeriodStart4,
		DateTime? PeriodStart5,
		DateTime? PeriodStart6,
		DateTime? PeriodStart7,
		DateTime? PeriodStart8,
		DateTime? PeriodStart9,
		DateTime? PeriodStart10,
		DateTime? PeriodStart11,
		DateTime? PeriodStart12,
		DateTime? PeriodEnd1,
		DateTime? PeriodEnd2,
		DateTime? PeriodEnd3,
		DateTime? PeriodEnd4,
		DateTime? PeriodEnd5,
		DateTime? PeriodEnd6,
		DateTime? PeriodEnd7,
		DateTime? PeriodEnd8,
		DateTime? PeriodEnd9,
		DateTime? PeriodEnd10,
		DateTime? PeriodEnd11,
		DateTime? PeriodEnd12) GetVariableDateBucketsSp(string PeriodType,
		DateTime? PerStart,
		DateTime? PerEnd,
		DateTime? PeriodStart1,
		DateTime? PeriodStart2,
		DateTime? PeriodStart3,
		DateTime? PeriodStart4,
		DateTime? PeriodStart5,
		DateTime? PeriodStart6,
		DateTime? PeriodStart7,
		DateTime? PeriodStart8,
		DateTime? PeriodStart9,
		DateTime? PeriodStart10,
		DateTime? PeriodStart11,
		DateTime? PeriodStart12,
		DateTime? PeriodEnd1,
		DateTime? PeriodEnd2,
		DateTime? PeriodEnd3,
		DateTime? PeriodEnd4,
		DateTime? PeriodEnd5,
		DateTime? PeriodEnd6,
		DateTime? PeriodEnd7,
		DateTime? PeriodEnd8,
		DateTime? PeriodEnd9,
		DateTime? PeriodEnd10,
		DateTime? PeriodEnd11,
		DateTime? PeriodEnd12)
		{
			StringType _PeriodType = PeriodType;
			DateType _PerStart = PerStart;
			DateType _PerEnd = PerEnd;
			DateType _PeriodStart1 = PeriodStart1;
			DateType _PeriodStart2 = PeriodStart2;
			DateType _PeriodStart3 = PeriodStart3;
			DateType _PeriodStart4 = PeriodStart4;
			DateType _PeriodStart5 = PeriodStart5;
			DateType _PeriodStart6 = PeriodStart6;
			DateType _PeriodStart7 = PeriodStart7;
			DateType _PeriodStart8 = PeriodStart8;
			DateType _PeriodStart9 = PeriodStart9;
			DateType _PeriodStart10 = PeriodStart10;
			DateType _PeriodStart11 = PeriodStart11;
			DateType _PeriodStart12 = PeriodStart12;
			DateType _PeriodEnd1 = PeriodEnd1;
			DateType _PeriodEnd2 = PeriodEnd2;
			DateType _PeriodEnd3 = PeriodEnd3;
			DateType _PeriodEnd4 = PeriodEnd4;
			DateType _PeriodEnd5 = PeriodEnd5;
			DateType _PeriodEnd6 = PeriodEnd6;
			DateType _PeriodEnd7 = PeriodEnd7;
			DateType _PeriodEnd8 = PeriodEnd8;
			DateType _PeriodEnd9 = PeriodEnd9;
			DateType _PeriodEnd10 = PeriodEnd10;
			DateType _PeriodEnd11 = PeriodEnd11;
			DateType _PeriodEnd12 = PeriodEnd12;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetVariableDateBucketsSp";
				
				appDB.AddCommandParameter(cmd, "PeriodType", _PeriodType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerStart", _PerStart, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PerEnd", _PerEnd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PeriodStart1", _PeriodStart1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PeriodStart2", _PeriodStart2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PeriodStart3", _PeriodStart3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PeriodStart4", _PeriodStart4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PeriodStart5", _PeriodStart5, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PeriodStart6", _PeriodStart6, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PeriodStart7", _PeriodStart7, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PeriodStart8", _PeriodStart8, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PeriodStart9", _PeriodStart9, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PeriodStart10", _PeriodStart10, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PeriodStart11", _PeriodStart11, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PeriodStart12", _PeriodStart12, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PeriodEnd1", _PeriodEnd1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PeriodEnd2", _PeriodEnd2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PeriodEnd3", _PeriodEnd3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PeriodEnd4", _PeriodEnd4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PeriodEnd5", _PeriodEnd5, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PeriodEnd6", _PeriodEnd6, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PeriodEnd7", _PeriodEnd7, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PeriodEnd8", _PeriodEnd8, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PeriodEnd9", _PeriodEnd9, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PeriodEnd10", _PeriodEnd10, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PeriodEnd11", _PeriodEnd11, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PeriodEnd12", _PeriodEnd12, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PerStart = _PerStart;
				PerEnd = _PerEnd;
				PeriodStart1 = _PeriodStart1;
				PeriodStart2 = _PeriodStart2;
				PeriodStart3 = _PeriodStart3;
				PeriodStart4 = _PeriodStart4;
				PeriodStart5 = _PeriodStart5;
				PeriodStart6 = _PeriodStart6;
				PeriodStart7 = _PeriodStart7;
				PeriodStart8 = _PeriodStart8;
				PeriodStart9 = _PeriodStart9;
				PeriodStart10 = _PeriodStart10;
				PeriodStart11 = _PeriodStart11;
				PeriodStart12 = _PeriodStart12;
				PeriodEnd1 = _PeriodEnd1;
				PeriodEnd2 = _PeriodEnd2;
				PeriodEnd3 = _PeriodEnd3;
				PeriodEnd4 = _PeriodEnd4;
				PeriodEnd5 = _PeriodEnd5;
				PeriodEnd6 = _PeriodEnd6;
				PeriodEnd7 = _PeriodEnd7;
				PeriodEnd8 = _PeriodEnd8;
				PeriodEnd9 = _PeriodEnd9;
				PeriodEnd10 = _PeriodEnd10;
				PeriodEnd11 = _PeriodEnd11;
				PeriodEnd12 = _PeriodEnd12;
				
				return (Severity, PerStart, PerEnd, PeriodStart1, PeriodStart2, PeriodStart3, PeriodStart4, PeriodStart5, PeriodStart6, PeriodStart7, PeriodStart8, PeriodStart9, PeriodStart10, PeriodStart11, PeriodStart12, PeriodEnd1, PeriodEnd2, PeriodEnd3, PeriodEnd4, PeriodEnd5, PeriodEnd6, PeriodEnd7, PeriodEnd8, PeriodEnd9, PeriodEnd10, PeriodEnd11, PeriodEnd12);
			}
		}
	}
}
