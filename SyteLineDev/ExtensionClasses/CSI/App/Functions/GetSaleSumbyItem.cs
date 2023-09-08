//PROJECT NAME: Data
//CLASS NAME: GetSaleSumbyItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetSaleSumbyItem : IGetSaleSumbyItem
	{
		readonly IApplicationDB appDB;
		
		public GetSaleSumbyItem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? Price,
			decimal? Qty) GetSaleSumbyItemSp(
			string Item,
			DateTime? RefDate,
			DateTime? SaleSumRefDate,
			int? SaleSumRefBucket,
			decimal? Price,
			decimal? Qty)
		{
			ItemType _Item = Item;
			DateType _RefDate = RefDate;
			DateType _SaleSumRefDate = SaleSumRefDate;
			SaleSumBucketType _SaleSumRefBucket = SaleSumRefBucket;
			AmountType _Price = Price;
			QtyTotlType _Qty = Qty;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetSaleSumbyItemSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefDate", _RefDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SaleSumRefDate", _SaleSumRefDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SaleSumRefBucket", _SaleSumRefBucket, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Price", _Price, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Qty", _Qty, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Price = _Price;
				Qty = _Qty;
				
				return (Severity, Price, Qty);
			}
		}
	}
}
