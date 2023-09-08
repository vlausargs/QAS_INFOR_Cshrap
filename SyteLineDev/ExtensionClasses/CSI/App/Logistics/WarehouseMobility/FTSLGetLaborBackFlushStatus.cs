//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLGetLaborBackFlushStatus.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLGetLaborBackFlushStatus
	{
		int FTSLGetLaborBackFlushStatusSp(string Type,
		                                  string Job,
		                                  short? Suffix,
		                                  int? OperNum,
		                                  string Item,
		                                  string WC,
		                                  ref byte? BackFlush,
		                                  ref string Infobar);
	}
	
	public class FTSLGetLaborBackFlushStatus : IFTSLGetLaborBackFlushStatus
	{
		readonly IApplicationDB appDB;
		
		public FTSLGetLaborBackFlushStatus(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int FTSLGetLaborBackFlushStatusSp(string Type,
		                                         string Job,
		                                         short? Suffix,
		                                         int? OperNum,
		                                         string Item,
		                                         string WC,
		                                         ref byte? BackFlush,
		                                         ref string Infobar)
		{
			ProcessIndType _Type = Type;
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			OperNumType _OperNum = OperNum;
			ItemType _Item = Item;
			WcType _WC = WC;
			ListYesNoType _BackFlush = BackFlush;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTSLGetLaborBackFlushStatusSp";
				
				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WC", _WC, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BackFlush", _BackFlush, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				BackFlush = _BackFlush;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
