//PROJECT NAME: DataCollection
//CLASS NAME: DctrVP.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class DctrVP : IDctrVP
	{
		readonly IApplicationDB appDB;
		
		public DctrVP(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? TQtyHand,
			string Infobar) DctrVPSp(
			string PWhse,
			string PItem,
			string PLoc,
			string PLot,
			string PLocType,
			decimal? TQtyHand,
			string Infobar,
			string Site = null)
		{
			WhseType _PWhse = PWhse;
			ItemType _PItem = PItem;
			LocType _PLoc = PLoc;
			LotType _PLot = PLot;
			LocTypeType _PLocType = PLocType;
			QtyUnitType _TQtyHand = TQtyHand;
			InfobarType _Infobar = Infobar;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DctrVPSp";
				
				appDB.AddCommandParameter(cmd, "PWhse", _PWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLoc", _PLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLot", _PLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLocType", _PLocType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TQtyHand", _TQtyHand, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TQtyHand = _TQtyHand;
				Infobar = _Infobar;
				
				return (Severity, TQtyHand, Infobar);
			}
		}
	}
}
