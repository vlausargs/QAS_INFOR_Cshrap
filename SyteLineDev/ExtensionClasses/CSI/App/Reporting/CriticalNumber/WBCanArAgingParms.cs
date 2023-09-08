//PROJECT NAME: Reporting
//CLASS NAME: WBCanArAgingParms.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting.CriticalNumber
{
	public class WBCanArAgingParms : IWBCanArAgingParms
	{
		readonly IApplicationDB appDB;
		
		public WBCanArAgingParms(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? LastBucket,
			int? TotalShow,
			int? PctShow,
			string AgeBasis,
			int? Days1,
			decimal? TotGoal1,
			decimal? TotAlert1,
			decimal? PctGoal1,
			decimal? PctAlert1,
			int? ShowIndTot1,
			int? ShowIndPct1,
			int? Days2,
			decimal? TotGoal2,
			decimal? TotAlert2,
			decimal? PctGoal2,
			decimal? PctAlert2,
			int? ShowIndTot2,
			int? ShowIndPct2,
			int? Days3,
			decimal? TotGoal3,
			decimal? TotAlert3,
			decimal? PctGoal3,
			decimal? PctAlert3,
			int? ShowIndTot3,
			int? ShowIndPct3,
			int? Days4,
			decimal? TotGoal4,
			decimal? TotAlert4,
			decimal? PctGoal4,
			decimal? PctAlert4,
			int? ShowIndTot4,
			int? ShowIndPct4,
			int? Days5,
			decimal? TotGoal5,
			decimal? TotAlert5,
			decimal? PctGoal5,
			decimal? PctAlert5,
			int? ShowIndTot5,
			int? ShowIndPct5,
			int? Days6,
			decimal? TotGoal6,
			decimal? TotAlert6,
			decimal? PctGoal6,
			decimal? PctAlert6,
			int? ShowIndTot6,
			int? ShowIndPct6,
			int? Days7,
			decimal? TotGoal7,
			decimal? TotAlert7,
			decimal? PctGoal7,
			decimal? PctAlert7,
			int? ShowIndTot7,
			int? ShowIndPct7) WBCanArAgingParmsSp(
			int? KPINum,
			int? LastBucket,
			int? TotalShow,
			int? PctShow,
			string AgeBasis,
			int? Days1,
			decimal? TotGoal1,
			decimal? TotAlert1,
			decimal? PctGoal1,
			decimal? PctAlert1,
			int? ShowIndTot1,
			int? ShowIndPct1,
			int? Days2,
			decimal? TotGoal2,
			decimal? TotAlert2,
			decimal? PctGoal2,
			decimal? PctAlert2,
			int? ShowIndTot2,
			int? ShowIndPct2,
			int? Days3,
			decimal? TotGoal3,
			decimal? TotAlert3,
			decimal? PctGoal3,
			decimal? PctAlert3,
			int? ShowIndTot3,
			int? ShowIndPct3,
			int? Days4,
			decimal? TotGoal4,
			decimal? TotAlert4,
			decimal? PctGoal4,
			decimal? PctAlert4,
			int? ShowIndTot4,
			int? ShowIndPct4,
			int? Days5,
			decimal? TotGoal5,
			decimal? TotAlert5,
			decimal? PctGoal5,
			decimal? PctAlert5,
			int? ShowIndTot5,
			int? ShowIndPct5,
			int? Days6,
			decimal? TotGoal6,
			decimal? TotAlert6,
			decimal? PctGoal6,
			decimal? PctAlert6,
			int? ShowIndTot6,
			int? ShowIndPct6,
			int? Days7,
			decimal? TotGoal7,
			decimal? TotAlert7,
			decimal? PctGoal7,
			decimal? PctAlert7,
			int? ShowIndTot7,
			int? ShowIndPct7)
		{
			WBKPINumType _KPINum = KPINum;
			IntType _LastBucket = LastBucket;
			ListYesNoType _TotalShow = TotalShow;
			ListYesNoType _PctShow = PctShow;
			StringType _AgeBasis = AgeBasis;
			IntType _Days1 = Days1;
			AmountType _TotGoal1 = TotGoal1;
			AmountType _TotAlert1 = TotAlert1;
			AmountType _PctGoal1 = PctGoal1;
			AmountType _PctAlert1 = PctAlert1;
			ListYesNoType _ShowIndTot1 = ShowIndTot1;
			ListYesNoType _ShowIndPct1 = ShowIndPct1;
			IntType _Days2 = Days2;
			AmountType _TotGoal2 = TotGoal2;
			AmountType _TotAlert2 = TotAlert2;
			AmountType _PctGoal2 = PctGoal2;
			AmountType _PctAlert2 = PctAlert2;
			ListYesNoType _ShowIndTot2 = ShowIndTot2;
			ListYesNoType _ShowIndPct2 = ShowIndPct2;
			IntType _Days3 = Days3;
			AmountType _TotGoal3 = TotGoal3;
			AmountType _TotAlert3 = TotAlert3;
			AmountType _PctGoal3 = PctGoal3;
			AmountType _PctAlert3 = PctAlert3;
			ListYesNoType _ShowIndTot3 = ShowIndTot3;
			ListYesNoType _ShowIndPct3 = ShowIndPct3;
			IntType _Days4 = Days4;
			AmountType _TotGoal4 = TotGoal4;
			AmountType _TotAlert4 = TotAlert4;
			AmountType _PctGoal4 = PctGoal4;
			AmountType _PctAlert4 = PctAlert4;
			ListYesNoType _ShowIndTot4 = ShowIndTot4;
			ListYesNoType _ShowIndPct4 = ShowIndPct4;
			IntType _Days5 = Days5;
			AmountType _TotGoal5 = TotGoal5;
			AmountType _TotAlert5 = TotAlert5;
			AmountType _PctGoal5 = PctGoal5;
			AmountType _PctAlert5 = PctAlert5;
			ListYesNoType _ShowIndTot5 = ShowIndTot5;
			ListYesNoType _ShowIndPct5 = ShowIndPct5;
			IntType _Days6 = Days6;
			AmountType _TotGoal6 = TotGoal6;
			AmountType _TotAlert6 = TotAlert6;
			AmountType _PctGoal6 = PctGoal6;
			AmountType _PctAlert6 = PctAlert6;
			ListYesNoType _ShowIndTot6 = ShowIndTot6;
			ListYesNoType _ShowIndPct6 = ShowIndPct6;
			IntType _Days7 = Days7;
			AmountType _TotGoal7 = TotGoal7;
			AmountType _TotAlert7 = TotAlert7;
			AmountType _PctGoal7 = PctGoal7;
			AmountType _PctAlert7 = PctAlert7;
			ListYesNoType _ShowIndTot7 = ShowIndTot7;
			ListYesNoType _ShowIndPct7 = ShowIndPct7;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "WBCanArAgingParmsSp";
				
				appDB.AddCommandParameter(cmd, "KPINum", _KPINum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LastBucket", _LastBucket, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TotalShow", _TotalShow, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PctShow", _PctShow, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AgeBasis", _AgeBasis, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Days1", _Days1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TotGoal1", _TotGoal1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TotAlert1", _TotAlert1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PctGoal1", _PctGoal1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PctAlert1", _PctAlert1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShowIndTot1", _ShowIndTot1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShowIndPct1", _ShowIndPct1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Days2", _Days2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TotGoal2", _TotGoal2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TotAlert2", _TotAlert2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PctGoal2", _PctGoal2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PctAlert2", _PctAlert2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShowIndTot2", _ShowIndTot2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShowIndPct2", _ShowIndPct2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Days3", _Days3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TotGoal3", _TotGoal3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TotAlert3", _TotAlert3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PctGoal3", _PctGoal3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PctAlert3", _PctAlert3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShowIndTot3", _ShowIndTot3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShowIndPct3", _ShowIndPct3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Days4", _Days4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TotGoal4", _TotGoal4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TotAlert4", _TotAlert4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PctGoal4", _PctGoal4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PctAlert4", _PctAlert4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShowIndTot4", _ShowIndTot4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShowIndPct4", _ShowIndPct4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Days5", _Days5, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TotGoal5", _TotGoal5, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TotAlert5", _TotAlert5, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PctGoal5", _PctGoal5, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PctAlert5", _PctAlert5, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShowIndTot5", _ShowIndTot5, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShowIndPct5", _ShowIndPct5, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Days6", _Days6, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TotGoal6", _TotGoal6, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TotAlert6", _TotAlert6, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PctGoal6", _PctGoal6, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PctAlert6", _PctAlert6, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShowIndTot6", _ShowIndTot6, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShowIndPct6", _ShowIndPct6, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Days7", _Days7, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TotGoal7", _TotGoal7, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TotAlert7", _TotAlert7, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PctGoal7", _PctGoal7, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PctAlert7", _PctAlert7, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShowIndTot7", _ShowIndTot7, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShowIndPct7", _ShowIndPct7, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				LastBucket = _LastBucket;
				TotalShow = _TotalShow;
				PctShow = _PctShow;
				AgeBasis = _AgeBasis;
				Days1 = _Days1;
				TotGoal1 = _TotGoal1;
				TotAlert1 = _TotAlert1;
				PctGoal1 = _PctGoal1;
				PctAlert1 = _PctAlert1;
				ShowIndTot1 = _ShowIndTot1;
				ShowIndPct1 = _ShowIndPct1;
				Days2 = _Days2;
				TotGoal2 = _TotGoal2;
				TotAlert2 = _TotAlert2;
				PctGoal2 = _PctGoal2;
				PctAlert2 = _PctAlert2;
				ShowIndTot2 = _ShowIndTot2;
				ShowIndPct2 = _ShowIndPct2;
				Days3 = _Days3;
				TotGoal3 = _TotGoal3;
				TotAlert3 = _TotAlert3;
				PctGoal3 = _PctGoal3;
				PctAlert3 = _PctAlert3;
				ShowIndTot3 = _ShowIndTot3;
				ShowIndPct3 = _ShowIndPct3;
				Days4 = _Days4;
				TotGoal4 = _TotGoal4;
				TotAlert4 = _TotAlert4;
				PctGoal4 = _PctGoal4;
				PctAlert4 = _PctAlert4;
				ShowIndTot4 = _ShowIndTot4;
				ShowIndPct4 = _ShowIndPct4;
				Days5 = _Days5;
				TotGoal5 = _TotGoal5;
				TotAlert5 = _TotAlert5;
				PctGoal5 = _PctGoal5;
				PctAlert5 = _PctAlert5;
				ShowIndTot5 = _ShowIndTot5;
				ShowIndPct5 = _ShowIndPct5;
				Days6 = _Days6;
				TotGoal6 = _TotGoal6;
				TotAlert6 = _TotAlert6;
				PctGoal6 = _PctGoal6;
				PctAlert6 = _PctAlert6;
				ShowIndTot6 = _ShowIndTot6;
				ShowIndPct6 = _ShowIndPct6;
				Days7 = _Days7;
				TotGoal7 = _TotGoal7;
				TotAlert7 = _TotAlert7;
				PctGoal7 = _PctGoal7;
				PctAlert7 = _PctAlert7;
				ShowIndTot7 = _ShowIndTot7;
				ShowIndPct7 = _ShowIndPct7;
				
				return (Severity, LastBucket, TotalShow, PctShow, AgeBasis, Days1, TotGoal1, TotAlert1, PctGoal1, PctAlert1, ShowIndTot1, ShowIndPct1, Days2, TotGoal2, TotAlert2, PctGoal2, PctAlert2, ShowIndTot2, ShowIndPct2, Days3, TotGoal3, TotAlert3, PctGoal3, PctAlert3, ShowIndTot3, ShowIndPct3, Days4, TotGoal4, TotAlert4, PctGoal4, PctAlert4, ShowIndTot4, ShowIndPct4, Days5, TotGoal5, TotAlert5, PctGoal5, PctAlert5, ShowIndTot5, ShowIndPct5, Days6, TotGoal6, TotAlert6, PctGoal6, PctAlert6, ShowIndTot6, ShowIndPct6, Days7, TotGoal7, TotAlert7, PctGoal7, PctAlert7, ShowIndTot7, ShowIndPct7);
			}
		}
	}
}
