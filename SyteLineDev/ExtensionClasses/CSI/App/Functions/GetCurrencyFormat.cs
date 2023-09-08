//PROJECT NAME: Data
//CLASS NAME: GetCurrencyFormat.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetCurrencyFormat : IGetCurrencyFormat
	{
		readonly IApplicationDB appDB;
		
		public GetCurrencyFormat(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string AmtFormat,
			string AmtTotFormat,
			string CstPrcFormat,
			string Infobar) GetCurrencyFormatSp(
			string AmtFormat,
			string AmtTotFormat,
			string CstPrcFormat,
			string Infobar)
		{
			InputMaskType _AmtFormat = AmtFormat;
			InputMaskType _AmtTotFormat = AmtTotFormat;
			InputMaskType _CstPrcFormat = CstPrcFormat;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetCurrencyFormatSp";
				
				appDB.AddCommandParameter(cmd, "AmtFormat", _AmtFormat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AmtTotFormat", _AmtTotFormat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CstPrcFormat", _CstPrcFormat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				AmtFormat = _AmtFormat;
				AmtTotFormat = _AmtTotFormat;
				CstPrcFormat = _CstPrcFormat;
				Infobar = _Infobar;
				
				return (Severity, AmtFormat, AmtTotFormat, CstPrcFormat, Infobar);
			}
		}
	}
}
