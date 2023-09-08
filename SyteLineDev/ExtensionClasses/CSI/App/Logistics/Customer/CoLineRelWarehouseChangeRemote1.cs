//PROJECT NAME: Logistics
//CLASS NAME: CoLineRelWarehouseChangeRemote1.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CoLineRelWarehouseChangeRemote1 : ICoLineRelWarehouseChangeRemote1
	{
		readonly IApplicationDB appDB;
		
		public CoLineRelWarehouseChangeRemote1(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) CoLineRelWarehouseChangeRemote1Sp(
			string CoOrigSite,
			string CoItemCoNum,
			int? CoItemCoLine,
			int? CoItemCoRelease,
			string OldWhse,
			string NewWhse,
			string CoItemItem,
			string Infobar)
		{
			SiteType _CoOrigSite = CoOrigSite;
			CoNumType _CoItemCoNum = CoItemCoNum;
			CoLineType _CoItemCoLine = CoItemCoLine;
			CoReleaseType _CoItemCoRelease = CoItemCoRelease;
			WhseType _OldWhse = OldWhse;
			WhseType _NewWhse = NewWhse;
			ItemType _CoItemItem = CoItemItem;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CoLineRelWarehouseChangeRemote1Sp";
				
				appDB.AddCommandParameter(cmd, "CoOrigSite", _CoOrigSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoItemCoNum", _CoItemCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoItemCoLine", _CoItemCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoItemCoRelease", _CoItemCoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldWhse", _OldWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewWhse", _NewWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoItemItem", _CoItemItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
