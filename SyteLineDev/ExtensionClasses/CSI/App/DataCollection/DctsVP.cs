//PROJECT NAME: DataCollection
//CLASS NAME: DctsVP.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class DctsVP : IDctsVP
	{
		readonly IApplicationDB appDB;
		
		public DctsVP(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) DctsVPSp(
			Guid? PRecid,
			decimal? PQty,
			string PLot,
			int? PCanAdd,
			string PWhse,
			string PWhseType,
			int? PIssue,
			string PTranType,
			string Infobar,
			string Site = null)
		{
			RowPointerType _PRecid = PRecid;
			QtyUnitType _PQty = PQty;
			LotType _PLot = PLot;
			ListYesNoType _PCanAdd = PCanAdd;
			WhseType _PWhse = PWhse;
			StringType _PWhseType = PWhseType;
			ListYesNoType _PIssue = PIssue;
			StringType _PTranType = PTranType;
			InfobarType _Infobar = Infobar;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DctsVPSp";
				
				appDB.AddCommandParameter(cmd, "PRecid", _PRecid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQty", _PQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLot", _PLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCanAdd", _PCanAdd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PWhse", _PWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PWhseType", _PWhseType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PIssue", _PIssue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTranType", _PTranType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
