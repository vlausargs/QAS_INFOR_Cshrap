//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROQtyConvert.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSROQtyConvert : ISSSFSSROQtyConvert
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSROQtyConvert(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSFSSROQtyConvertSP(
			string PSite = null,
			string PUM = null,
			string PItem = null,
			decimal? PQtyOnHand = null,
			decimal? PQtyRsvdCo = null)
		{
			SiteType _PSite = PSite;
			UMType _PUM = PUM;
			ItemType _PItem = PItem;
			QtyTotlType _PQtyOnHand = PQtyOnHand;
			QtyTotlType _PQtyRsvdCo = PQtyRsvdCo;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROQtyConvertSP";
				
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUM", _PUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyOnHand", _PQtyOnHand, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyRsvdCo", _PQtyRsvdCo, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
