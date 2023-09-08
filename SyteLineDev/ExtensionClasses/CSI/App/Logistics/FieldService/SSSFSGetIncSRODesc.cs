//PROJECT NAME: CSIFSPlusUnit
//CLASS NAME: SSSFSGetIncSRODesc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSGetIncSRODesc
	{
		int SSSFSGetIncSRODescSp(string RefType,
		                         string RefNum,
		                         ref string Desc,
		                         ref string Partner,
		                         ref string Infobar);
	}
	
	public class SSSFSGetIncSRODesc : ISSSFSGetIncSRODesc
	{
		readonly IApplicationDB appDB;
		
		public SSSFSGetIncSRODesc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SSSFSGetIncSRODescSp(string RefType,
		                                string RefNum,
		                                ref string Desc,
		                                ref string Partner,
		                                ref string Infobar)
		{
			FSRefTypeNSType _RefType = RefType;
			FSRefNumType _RefNum = RefNum;
			DescriptionType _Desc = Desc;
			FSPartnerType _Partner = Partner;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSGetIncSRODescSp";
				
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Desc", _Desc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Partner", _Partner, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Desc = _Desc;
				Partner = _Partner;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
