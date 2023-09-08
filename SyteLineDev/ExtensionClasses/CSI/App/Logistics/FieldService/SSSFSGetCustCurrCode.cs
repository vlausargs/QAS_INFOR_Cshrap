//PROJECT NAME: Logistics
//CLASS NAME: SSSFSGetCustCurrCode.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSGetCustCurrCode : ISSSFSGetCustCurrCode
	{
		readonly IApplicationDB appDB;
		
		public SSSFSGetCustCurrCode(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string PCurrCode,
			string Infobar) SSSFSGetCustCurrCodeSp(
			string PCustNum,
			string PCurrCode,
			string Infobar)
		{
			CustNumType _PCustNum = PCustNum;
			CurrCodeType _PCurrCode = PCurrCode;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSGetCustCurrCodeSp";
				
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurrCode", _PCurrCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PCurrCode = _PCurrCode;
				Infobar = _Infobar;
				
				return (Severity, PCurrCode, Infobar);
			}
		}

		public string SSSFSGetCustCurrCodeFn(
			string SroNum,
			int? SroLine,
			int? SroOper = null)
		{
			FSSRONumType _SroNum = SroNum;
			FSSROLineType _SroLine = SroLine;
			FSSROOperType _SroOper = SroOper;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSFSGetCustCurrCode](@SroNum, @SroLine, @SroOper)";

				appDB.AddCommandParameter(cmd, "SroNum", _SroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroLine", _SroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroOper", _SroOper, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<string>(cmd);

				return Output;
			}
		}
	}
}
