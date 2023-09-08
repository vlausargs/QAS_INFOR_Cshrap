//PROJECT NAME: Data
//CLASS NAME: FSBBPActual.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class FSBBPActual : IFSBBPActual
	{
		readonly IApplicationDB appDB;
		
		public FSBBPActual(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? FSBBPActualFn(
			string FSBName,
			DateTime? PerStart,
			DateTime? PerEnd,
			string ChartType,
			string Acct,
			string UC1,
			string UC2,
			string UC3,
			string UC4)
		{
			FSBNameType _FSBName = FSBName;
			DateType _PerStart = PerStart;
			DateType _PerEnd = PerEnd;
			ChartTypeType _ChartType = ChartType;
			AcctType _Acct = Acct;
			UnitCode1Type _UC1 = UC1;
			UnitCode2Type _UC2 = UC2;
			UnitCode3Type _UC3 = UC3;
			UnitCode4Type _UC4 = UC4;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[FSBBPActual](@FSBName, @PerStart, @PerEnd, @ChartType, @Acct, @UC1, @UC2, @UC3, @UC4)";
				
				appDB.AddCommandParameter(cmd, "FSBName", _FSBName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerStart", _PerStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerEnd", _PerEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChartType", _ChartType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Acct", _Acct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UC1", _UC1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UC2", _UC2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UC3", _UC3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UC4", _UC4, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
