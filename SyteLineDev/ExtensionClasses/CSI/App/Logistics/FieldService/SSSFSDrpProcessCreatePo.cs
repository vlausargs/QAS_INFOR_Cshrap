//PROJECT NAME: Logistics
//CLASS NAME: SSSFSDrpProcessCreatePo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSDrpProcessCreatePo : ISSSFSDrpProcessCreatePo
	{
		readonly IApplicationDB appDB;
		
		public SSSFSDrpProcessCreatePo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string oPONum,
			string Infobar) SSSFSDrpProcessCreatePoSp(
			string iVendNum,
			string iWhse,
			string iDefaultPOPrefix,
			int? iPOKeyLength,
			string oPONum,
			string Infobar)
		{
			VendNumType _iVendNum = iVendNum;
			WhseType _iWhse = iWhse;
			PoNumType _iDefaultPOPrefix = iDefaultPOPrefix;
			IntType _iPOKeyLength = iPOKeyLength;
			PoNumType _oPONum = oPONum;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSDrpProcessCreatePoSp";
				
				appDB.AddCommandParameter(cmd, "iVendNum", _iVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iWhse", _iWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iDefaultPOPrefix", _iDefaultPOPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iPOKeyLength", _iPOKeyLength, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "oPONum", _oPONum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				oPONum = _oPONum;
				Infobar = _Infobar;
				
				return (Severity, oPONum, Infobar);
			}
		}
	}
}
