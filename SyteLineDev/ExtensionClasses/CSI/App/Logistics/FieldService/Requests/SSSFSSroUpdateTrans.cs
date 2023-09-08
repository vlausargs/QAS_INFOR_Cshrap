//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSroUpdateTrans.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSroUpdateTrans
	{
		int? SSSFSSroUpdateTransSp(string poNum,
		short? poLine,
		decimal? newItemCostConv,
		decimal? newQtyOrderedConv,
		string SroType);
	}
	
	public class SSSFSSroUpdateTrans : ISSSFSSroUpdateTrans
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSroUpdateTrans(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSFSSroUpdateTransSp(string poNum,
		short? poLine,
		decimal? newItemCostConv,
		decimal? newQtyOrderedConv,
		string SroType)
		{
			PoNumType _poNum = poNum;
			PoLineType _poLine = poLine;
			CostPrcType _newItemCostConv = newItemCostConv;
			QtyUnitNoNegType _newQtyOrderedConv = newQtyOrderedConv;
			UnusedCharType _SroType = SroType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSroUpdateTransSp";
				
				appDB.AddCommandParameter(cmd, "poNum", _poNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "poLine", _poLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "newItemCostConv", _newItemCostConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "newQtyOrderedConv", _newQtyOrderedConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroType", _SroType, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
