//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLValidateJobLot.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLValidateJobLot
	{
		int FTSLValidateJobLotSp(string Lot,
		                         string Item,
		                         string Job,
		                         int? SLLotExp,
		                         ref string Infobar);
	}
	
	public class FTSLValidateJobLot : IFTSLValidateJobLot
	{
		readonly IApplicationDB appDB;
		
		public FTSLValidateJobLot(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int FTSLValidateJobLotSp(string Lot,
		                                string Item,
		                                string Job,
		                                int? SLLotExp,
		                                ref string Infobar)
		{
			LotType _Lot = Lot;
			ItemType _Item = Item;
			JobType _Job = Job;
			CustSeqType _SLLotExp = SLLotExp;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTSLValidateJobLotSp";
				
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SLLotExp", _SLLotExp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
