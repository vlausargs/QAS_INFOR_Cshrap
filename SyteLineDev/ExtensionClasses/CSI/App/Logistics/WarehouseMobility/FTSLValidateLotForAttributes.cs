//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLValidateLotForAttributes.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLValidateLotForAttributes
	{
		int FTSLValidateLotForAttributesSp(string Lot,
		                                   string Item,
		                                   ref Guid? LotRowPointer);
	}
	
	public class FTSLValidateLotForAttributes : IFTSLValidateLotForAttributes
	{
		readonly IApplicationDB appDB;
		
		public FTSLValidateLotForAttributes(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int FTSLValidateLotForAttributesSp(string Lot,
		                                          string Item,
		                                          ref Guid? LotRowPointer)
		{
			LotType _Lot = Lot;
			ItemType _Item = Item;
			RowPointerType _LotRowPointer = LotRowPointer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTSLValidateLotForAttributesSp";
				
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LotRowPointer", _LotRowPointer, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				LotRowPointer = _LotRowPointer;
				
				return Severity;
			}
		}
	}
}
