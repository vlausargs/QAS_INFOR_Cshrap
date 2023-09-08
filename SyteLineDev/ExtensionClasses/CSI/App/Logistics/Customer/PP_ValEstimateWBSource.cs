//PROJECT NAME: Logistics
//CLASS NAME: PP_ValEstimateWBSource.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class PP_ValEstimateWBSource : IPP_ValEstimateWBSource
	{
		readonly IApplicationDB appDB;
		
		
		public PP_ValEstimateWBSource(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) PP_ValEstimateWBSourceSp(string QuoteMethod,
		string QuoteType,
		string Source,
		int? SourceLine,
		string Infobar)
		{
			StringType _QuoteMethod = QuoteMethod;
			StringType _QuoteType = QuoteType;
			CoNumType _Source = Source;
			CoLineType _SourceLine = SourceLine;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PP_ValEstimateWBSourceSp";
				
				appDB.AddCommandParameter(cmd, "QuoteMethod", _QuoteMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QuoteType", _QuoteType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Source", _Source, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SourceLine", _SourceLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
