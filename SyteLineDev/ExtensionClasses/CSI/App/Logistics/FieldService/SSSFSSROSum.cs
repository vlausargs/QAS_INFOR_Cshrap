//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROSum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSROSum : ISSSFSSROSum
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSROSum(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) SSSFSSROSumSp(
			string InSroNum,
			int? InSroLine,
			int? InSroOper,
			int? InSetSro,
			int? InSetLine,
			int? PreventOverride = 0,
			int? CalledFromInvoicing = 0,
			string Infobar = null)
		{
			FSSRONumType _InSroNum = InSroNum;
			FSSROLineType _InSroLine = InSroLine;
			FSSROOperType _InSroOper = InSroOper;
			ListYesNoType _InSetSro = InSetSro;
			ListYesNoType _InSetLine = InSetLine;
			ListYesNoType _PreventOverride = PreventOverride;
			ListYesNoType _CalledFromInvoicing = CalledFromInvoicing;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROSumSp";
				
				appDB.AddCommandParameter(cmd, "InSroNum", _InSroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InSroLine", _InSroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InSroOper", _InSroOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InSetSro", _InSetSro, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InSetLine", _InSetLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PreventOverride", _PreventOverride, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CalledFromInvoicing", _CalledFromInvoicing, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
