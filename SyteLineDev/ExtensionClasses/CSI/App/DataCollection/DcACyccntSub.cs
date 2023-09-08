//PROJECT NAME: DataCollection
//CLASS NAME: DcACyccntSub.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class DcACyccntSub : IDcACyccntSub
	{
		readonly IApplicationDB appDB;
		
		public DcACyccntSub(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? DcACyccntSubSp(
			string TTermId,
			string TEmpNum,
			DateTime? TTransDate,
			string TItem,
			string TLocation,
			string TLot,
			string TCurWhse,
			decimal? TQty)
		{
			DcTermIdType _TTermId = TTermId;
			EmpNumType _TEmpNum = TEmpNum;
			DateTimeType _TTransDate = TTransDate;
			ItemType _TItem = TItem;
			LocType _TLocation = TLocation;
			LotType _TLot = TLot;
			WhseType _TCurWhse = TCurWhse;
			QtyUnitType _TQty = TQty;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DcACyccntSubSp";
				
				appDB.AddCommandParameter(cmd, "TTermId", _TTermId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TEmpNum", _TEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TTransDate", _TTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TItem", _TItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TLocation", _TLocation, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TLot", _TLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TCurWhse", _TCurWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TQty", _TQty, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
