//PROJECT NAME: CSIProduct
//CLASS NAME: CopyBomVerifyFromInputs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
	public interface ICopyBomVerifyFromInputs
	{
		int CopyBomVerifyFromInputsSp(string FromCategory,
		                              string P_Type,
		                              string P_Job,
		                              short? P_Suffix,
		                              string P_Ps_Num,
		                              string P_Item,
		                              string P_Revision,
		                              int? P_Op_Start,
		                              int? P_Op_End,
		                              ref string O_Job,
		                              ref short? O_Suffix,
		                              ref string O_Ps_Num,
		                              ref string O_Item,
		                              ref string O_Revision,
		                              ref int? O_Op_Start,
		                              ref int? O_Op_End,
		                              ref byte? O_Error,
		                              ref string Infobar);
	}
	
	public class CopyBomVerifyFromInputs : ICopyBomVerifyFromInputs
	{
		readonly IApplicationDB appDB;
		
		public CopyBomVerifyFromInputs(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CopyBomVerifyFromInputsSp(string FromCategory,
		                                     string P_Type,
		                                     string P_Job,
		                                     short? P_Suffix,
		                                     string P_Ps_Num,
		                                     string P_Item,
		                                     string P_Revision,
		                                     int? P_Op_Start,
		                                     int? P_Op_End,
		                                     ref string O_Job,
		                                     ref short? O_Suffix,
		                                     ref string O_Ps_Num,
		                                     ref string O_Item,
		                                     ref string O_Revision,
		                                     ref int? O_Op_Start,
		                                     ref int? O_Op_End,
		                                     ref byte? O_Error,
		                                     ref string Infobar)
		{
			StringType _FromCategory = FromCategory;
			JobTypeType _P_Type = P_Type;
			JobType _P_Job = P_Job;
			SuffixType _P_Suffix = P_Suffix;
			PsNumType _P_Ps_Num = P_Ps_Num;
			ItemType _P_Item = P_Item;
			RevisionType _P_Revision = P_Revision;
			OperNumType _P_Op_Start = P_Op_Start;
			OperNumType _P_Op_End = P_Op_End;
			JobType _O_Job = O_Job;
			SuffixType _O_Suffix = O_Suffix;
			PsNumType _O_Ps_Num = O_Ps_Num;
			ItemType _O_Item = O_Item;
			RevisionType _O_Revision = O_Revision;
			OperNumType _O_Op_Start = O_Op_Start;
			OperNumType _O_Op_End = O_Op_End;
			ListYesNoType _O_Error = O_Error;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CopyBomVerifyFromInputsSp";
				
				appDB.AddCommandParameter(cmd, "FromCategory", _FromCategory, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "P_Type", _P_Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "P_Job", _P_Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "P_Suffix", _P_Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "P_Ps_Num", _P_Ps_Num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "P_Item", _P_Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "P_Revision", _P_Revision, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "P_Op_Start", _P_Op_Start, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "P_Op_End", _P_Op_End, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "O_Job", _O_Job, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "O_Suffix", _O_Suffix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "O_Ps_Num", _O_Ps_Num, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "O_Item", _O_Item, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "O_Revision", _O_Revision, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "O_Op_Start", _O_Op_Start, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "O_Op_End", _O_Op_End, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "O_Error", _O_Error, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				O_Job = _O_Job;
				O_Suffix = _O_Suffix;
				O_Ps_Num = _O_Ps_Num;
				O_Item = _O_Item;
				O_Revision = _O_Revision;
				O_Op_Start = _O_Op_Start;
				O_Op_End = _O_Op_End;
				O_Error = _O_Error;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
