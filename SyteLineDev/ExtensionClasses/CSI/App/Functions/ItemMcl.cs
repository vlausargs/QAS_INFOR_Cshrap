//PROJECT NAME: Data
//CLASS NAME: ItemMcl.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ItemMcl : IItemMcl
	{
		readonly IApplicationDB appDB;
		
		public ItemMcl(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			DateTime? NewShipDate,
			string Infobar) ItemMclSp(
			DateTime? PShipDate,
			int? CalcShipDate,
			int? PTrnTime,
			int? PDockTime,
			DateTime? NewShipDate,
			string Infobar,
			string Site = null)
		{
			DateType _PShipDate = PShipDate;
			FlagNyType _CalcShipDate = CalcShipDate;
			LeadTimeType _PTrnTime = PTrnTime;
			LeadTimeType _PDockTime = PDockTime;
			DateType _NewShipDate = NewShipDate;
			InfobarType _Infobar = Infobar;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemMclSp";
				
				appDB.AddCommandParameter(cmd, "PShipDate", _PShipDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CalcShipDate", _CalcShipDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTrnTime", _PTrnTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDockTime", _PDockTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewShipDate", _NewShipDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				NewShipDate = _NewShipDate;
				Infobar = _Infobar;
				
				return (Severity, NewShipDate, Infobar);
			}
		}
	}
}
