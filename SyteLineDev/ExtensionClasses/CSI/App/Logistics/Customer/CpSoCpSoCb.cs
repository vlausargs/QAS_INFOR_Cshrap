//PROJECT NAME: Logistics
//CLASS NAME: CpSoCpSoCb.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CpSoCpSoCb : ICpSoCpSoCb
	{
		readonly IApplicationDB appDB;
		
		public CpSoCpSoCb(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) CpSoCpSoCbSp(
			string PFromCoType,
			string PFromCoNum,
			int? PFromCoLine,
			string PFromCurr,
			string PToCoNum,
			int? PToCoLine,
			string PToCoOrigSite,
			string PToCurr,
			int? IsCrossSite,
			int? PCopyShipSiteCo,
			int? PToNew,
			int? PHasCfg,
			string Infobar)
		{
			CoTypeType _PFromCoType = PFromCoType;
			CoNumType _PFromCoNum = PFromCoNum;
			CoLineType _PFromCoLine = PFromCoLine;
			CurrCodeType _PFromCurr = PFromCurr;
			CoNumType _PToCoNum = PToCoNum;
			CoLineType _PToCoLine = PToCoLine;
			SiteType _PToCoOrigSite = PToCoOrigSite;
			CurrCodeType _PToCurr = PToCurr;
			ListYesNoType _IsCrossSite = IsCrossSite;
			FlagNyType _PCopyShipSiteCo = PCopyShipSiteCo;
			FlagNyType _PToNew = PToNew;
			FlagNyType _PHasCfg = PHasCfg;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CpSoCpSoCbSp";
				
				appDB.AddCommandParameter(cmd, "PFromCoType", _PFromCoType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFromCoNum", _PFromCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFromCoLine", _PFromCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFromCurr", _PFromCurr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToCoNum", _PToCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToCoLine", _PToCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToCoOrigSite", _PToCoOrigSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToCurr", _PToCurr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IsCrossSite", _IsCrossSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCopyShipSiteCo", _PCopyShipSiteCo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToNew", _PToNew, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PHasCfg", _PHasCfg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
