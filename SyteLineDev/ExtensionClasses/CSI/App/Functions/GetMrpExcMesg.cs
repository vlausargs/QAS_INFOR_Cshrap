//PROJECT NAME: Data
//CLASS NAME: GetMrpExcMesg.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetMrpExcMesg : IGetMrpExcMesg
	{
		readonly IApplicationDB appDB;
		
		public GetMrpExcMesg(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string GetMrpExcMesgFn(
			string Item,
			string OrderType,
			string OrderNum,
			int? OrderLineSuf,
			int? OrderRel,
			Guid? RowPointer)
		{
			ItemType _Item = Item;
			MrpOrderTypeType _OrderType = OrderType;
			ApsOrderType _OrderNum = OrderNum;
			MrpOrderLineType _OrderLineSuf = OrderLineSuf;
			MrpOrderReleaseType _OrderRel = OrderRel;
			RowPointerType _RowPointer = RowPointer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetMrpExcMesg](@Item, @OrderType, @OrderNum, @OrderLineSuf, @OrderRel, @RowPointer)";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderType", _OrderType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderNum", _OrderNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderLineSuf", _OrderLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderRel", _OrderRel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
