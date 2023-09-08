//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLValidateQtyOnCompleteOper.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLValidateQtyOnCompleteOper
	{
		int FTSLValidateQtyOnCompleteOperSp(string Job,
		                                    short? Suffix,
		                                    int? OperNum,
		                                    decimal? QtyGood,
		                                    decimal? QtyScrapped,
		                                    ref string PromptCheckMsg,
		                                    ref string PromptCheckButtons);
	}
	
	public class FTSLValidateQtyOnCompleteOper : IFTSLValidateQtyOnCompleteOper
	{
		readonly IApplicationDB appDB;
		
		public FTSLValidateQtyOnCompleteOper(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int FTSLValidateQtyOnCompleteOperSp(string Job,
		                                           short? Suffix,
		                                           int? OperNum,
		                                           decimal? QtyGood,
		                                           decimal? QtyScrapped,
		                                           ref string PromptCheckMsg,
		                                           ref string PromptCheckButtons)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			OperNumType _OperNum = OperNum;
			QtyUnitNoNegType _QtyGood = QtyGood;
			QtyUnitNoNegType _QtyScrapped = QtyScrapped;
			InfobarType _PromptCheckMsg = PromptCheckMsg;
			InfobarType _PromptCheckButtons = PromptCheckButtons;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTSLValidateQtyOnCompleteOperSp";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyGood", _QtyGood, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyScrapped", _QtyScrapped, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PromptCheckMsg", _PromptCheckMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptCheckButtons", _PromptCheckButtons, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PromptCheckMsg = _PromptCheckMsg;
				PromptCheckButtons = _PromptCheckButtons;
				
				return Severity;
			}
		}
	}
}
