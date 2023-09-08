//PROJECT NAME: CSICustomer
//CLASS NAME: GetRmaparmsLoc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IGetRmaparmsLoc
	{
		(int? ReturnCode, string Loc, byte? TaxFreeImports) GetRmaparmsLocSp(string Loc,
		byte? TaxFreeImports = null);
	}
	
	public class GetRmaparmsLoc : IGetRmaparmsLoc
	{
		readonly IApplicationDB appDB;
		
		public GetRmaparmsLoc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Loc, byte? TaxFreeImports) GetRmaparmsLocSp(string Loc,
		byte? TaxFreeImports = null)
		{
			LocType _Loc = Loc;
			ListYesNoType _TaxFreeImports = TaxFreeImports;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetRmaparmsLocSp";
				
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxFreeImports", _TaxFreeImports, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Loc = _Loc;
				TaxFreeImports = _TaxFreeImports;
				
				return (Severity, Loc, TaxFreeImports);
			}
		}
	}
}
