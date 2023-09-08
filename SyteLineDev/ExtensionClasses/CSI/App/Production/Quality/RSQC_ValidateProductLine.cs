//PROJECT NAME: Production
//CLASS NAME: RSQC_ValidateProductLi.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_ValidateProductLi : IRSQC_ValidateProductLi
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_ValidateProductLi(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Coordinator,
		string Resolver,
		string Infobar) RSQC_ValidateProductLine(string ProductLine,
		string ReasonCode,
		string Coordinator,
		string Resolver,
		string Infobar)
		{
			QCCharType _ProductLine = ProductLine;
			QCCharType _ReasonCode = ReasonCode;
			CountryType _Coordinator = Coordinator;
			CountryType _Resolver = Resolver;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_ValidateProductLine";
				
				appDB.AddCommandParameter(cmd, "ProductLine", _ProductLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReasonCode", _ReasonCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Coordinator", _Coordinator, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Resolver", _Resolver, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Coordinator = _Coordinator;
				Resolver = _Resolver;
				Infobar = _Infobar;
				
				return (Severity, Coordinator, Resolver, Infobar);
			}
		}
	}
}
