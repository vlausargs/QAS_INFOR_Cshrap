//PROJECT NAME: Logistics
//CLASS NAME: SSSFSContSroGenProdCodeMatl.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSContSroGenProdCodeMatl : ISSSFSContSroGenProdCodeMatl
	{
		readonly IApplicationDB appDB;
		
		public SSSFSContSroGenProdCodeMatl(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) SSSFSContSroGenProdCodeMatlSp(
			string SroNum,
			int? SroLine,
			int? SroOper,
			string ProductCode,
			int? ExtendMatl,
			string Infobar)
		{
			FSSRONumType _SroNum = SroNum;
			FSSROLineType _SroLine = SroLine;
			FSSROOperType _SroOper = SroOper;
			ProductCodeType _ProductCode = ProductCode;
			ListYesNoType _ExtendMatl = ExtendMatl;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSContSroGenProdCodeMatlSp";
				
				appDB.AddCommandParameter(cmd, "SroNum", _SroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroLine", _SroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroOper", _SroOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCode", _ProductCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExtendMatl", _ExtendMatl, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
