//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLTAGetOverHeadMachine.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLTAGetOverHeadMachine
	{
		int FTSLTAGetOverHeadMachineSp(string Ordernumber,
		                               int? Operation,
		                               short? Suffix,
		                               ref string OverHead,
		                               ref string Infobar);
	}
	
	public class FTSLTAGetOverHeadMachine : IFTSLTAGetOverHeadMachine
	{
		readonly IApplicationDB appDB;
		
		public FTSLTAGetOverHeadMachine(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int FTSLTAGetOverHeadMachineSp(string Ordernumber,
		                                      int? Operation,
		                                      short? Suffix,
		                                      ref string OverHead,
		                                      ref string Infobar)
		{
			JobType _Ordernumber = Ordernumber;
			OperNumType _Operation = Operation;
			SuffixType _Suffix = Suffix;
			OverheadBasisType _OverHead = OverHead;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTSLTAGetOverHeadMachineSp";
				
				appDB.AddCommandParameter(cmd, "Ordernumber", _Ordernumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Operation", _Operation, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OverHead", _OverHead, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				OverHead = _OverHead;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
