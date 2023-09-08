//PROJECT NAME: Data
//CLASS NAME: ChgRemoteCoitem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ChgRemoteCoitem : IChgRemoteCoitem
	{
		readonly IApplicationDB appDB;
		
		public ChgRemoteCoitem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ChgRemoteCoitemSp(
			string coitemNum,
			int? coitemLine,
			int? coitemRelease,
			string cotype,
			decimal? qty_ordered,
			decimal? qty_shipped,
			string item,
			string cust_num,
			string whse)
		{
			CoNumType _coitemNum = coitemNum;
			CoLineType _coitemLine = coitemLine;
			CoReleaseType _coitemRelease = coitemRelease;
			CoTypeType _cotype = cotype;
			QtyUnitNoNegType _qty_ordered = qty_ordered;
			QtyUnitNoNegType _qty_shipped = qty_shipped;
			ItemType _item = item;
			CustNumType _cust_num = cust_num;
			WhseType _whse = whse;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ChgRemoteCoitemSp";
				
				appDB.AddCommandParameter(cmd, "coitemNum", _coitemNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "coitemLine", _coitemLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "coitemRelease", _coitemRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "cotype", _cotype, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "qty_ordered", _qty_ordered, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "qty_shipped", _qty_shipped, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "item", _item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "cust_num", _cust_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "whse", _whse, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
