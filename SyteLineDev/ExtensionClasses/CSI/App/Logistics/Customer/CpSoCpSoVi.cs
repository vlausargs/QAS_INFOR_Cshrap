//PROJECT NAME: Logistics
//CLASS NAME: CpSoCpSoVi.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CpSoCpSoVi : ICpSoCpSoVi
	{
		readonly IApplicationDB appDB;
		
		public CpSoCpSoVi(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? PFoundItem,
			string Infobar) CpSoCpSoViSp(
			string pSite,
			string PItem,
			int? PFoundItem,
			string Infobar)
		{
			SiteType _pSite = pSite;
			ItemType _PItem = PItem;
			FlagNyType _PFoundItem = PFoundItem;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CpSoCpSoViSp";
				
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFoundItem", _PFoundItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PFoundItem = _PFoundItem;
				Infobar = _Infobar;
				
				return (Severity, PFoundItem, Infobar);
			}
		}
	}
}
