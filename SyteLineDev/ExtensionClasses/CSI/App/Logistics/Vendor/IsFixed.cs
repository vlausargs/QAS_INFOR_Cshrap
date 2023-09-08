//PROJECT NAME: Logistics
//CLASS NAME: IsFixed.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class IsFixed : IIsFixed
	{
		readonly IApplicationDB appDB;
		
		
		public IsFixed(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? Fixed,
		string Infobar) IsFixedSp(string CurrCode,
		int? Fixed,
		string Infobar,
		string Site = null)
		{
			CurrCodeType _CurrCode = CurrCode;
			Flag _Fixed = Fixed;
			Infobar _Infobar = Infobar;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "IsFixedSp";
				
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Fixed", _Fixed, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Fixed = _Fixed;
				Infobar = _Infobar;
				
				return (Severity, Fixed, Infobar);
			}
		}
		public int? IsFixedFn(
			string CurrCode)
		{
			CurrCodeType _CurrCode = CurrCode;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[IsFixed](@CurrCode)";

				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<int?>(cmd);

				return Output;
			}
		}

	}
}
