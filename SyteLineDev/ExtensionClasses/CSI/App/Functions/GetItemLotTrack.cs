//PROJECT NAME: Data
//CLASS NAME: GetItemLotTrack.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetItemLotTrack : IGetItemLotTrack
	{
		readonly IApplicationDB appDB;
		
		public GetItemLotTrack(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? TLotTracked,
			string Infobar) GetItemLotTrackSp(
			string PItem,
			string PSite,
			int? TLotTracked,
			string Infobar)
		{
			ItemType _PItem = PItem;
			SiteType _PSite = PSite;
			FlagNyType _TLotTracked = TLotTracked;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetItemLotTrackSp";
				
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TLotTracked", _TLotTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TLotTracked = _TLotTracked;
				Infobar = _Infobar;
				
				return (Severity, TLotTracked, Infobar);
			}
		}
	}
}
