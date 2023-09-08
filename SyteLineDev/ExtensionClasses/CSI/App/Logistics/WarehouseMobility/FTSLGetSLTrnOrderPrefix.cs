//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLGetSLTrnOrderPrefix.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLGetSLTrnOrderPrefix
	{
		int FTSLGetSLTrnOrderPrefixSp(ref string TrnPrefix,
		                              ref string Infobar);
	}
	
	public class FTSLGetSLTrnOrderPrefix : IFTSLGetSLTrnOrderPrefix
	{
		readonly IApplicationDB appDB;
		
		public FTSLGetSLTrnOrderPrefix(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int FTSLGetSLTrnOrderPrefixSp(ref string TrnPrefix,
		                                     ref string Infobar)
		{
			AlphaPrefixType _TrnPrefix = TrnPrefix;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTSLGetSLTrnOrderPrefixSp";
				
				appDB.AddCommandParameter(cmd, "TrnPrefix", _TrnPrefix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TrnPrefix = _TrnPrefix;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
