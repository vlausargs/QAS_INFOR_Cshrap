//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSSroCopyDefault.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSroCopyDefault
	{
		int SSSFSSroCopyDefaultSp(string RefType,
		                          ref string oDefSroTemplate,
		                          ref string oSroLabel,
		                          ref string oSroNumLabel,
		                          ref byte? oDefAutoSchedSro,
		                          ref string Infobar);
	}
	
	public class SSSFSSroCopyDefault : ISSSFSSroCopyDefault
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSroCopyDefault(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SSSFSSroCopyDefaultSp(string RefType,
		                                 ref string oDefSroTemplate,
		                                 ref string oSroLabel,
		                                 ref string oSroNumLabel,
		                                 ref byte? oDefAutoSchedSro,
		                                 ref string Infobar)
		{
			FSRefTypeIJKMNOPRType _RefType = RefType;
			FSSRONumType _oDefSroTemplate = oDefSroTemplate;
			DescriptionType _oSroLabel = oSroLabel;
			DescriptionType _oSroNumLabel = oSroNumLabel;
			ListYesNoType _oDefAutoSchedSro = oDefAutoSchedSro;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSroCopyDefaultSp";
				
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "oDefSroTemplate", _oDefSroTemplate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oSroLabel", _oSroLabel, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oSroNumLabel", _oSroNumLabel, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oDefAutoSchedSro", _oDefAutoSchedSro, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				oDefSroTemplate = _oDefSroTemplate;
				oSroLabel = _oSroLabel;
				oSroNumLabel = _oSroNumLabel;
				oDefAutoSchedSro = _oDefAutoSchedSro;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
