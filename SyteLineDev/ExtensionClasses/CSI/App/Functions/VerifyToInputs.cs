//PROJECT NAME: Data
//CLASS NAME: VerifyToInputs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class VerifyToInputs : IVerifyToInputs
	{
		readonly IApplicationDB appDB;
		
		public VerifyToInputs(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string O_Job,
			int? O_Suffix,
			string O_Item,
			string O_Revision,
			string Infobar) VerifyToInputsSp(
			string ToCategory,
			string P_Type,
			string P_Job,
			int? P_Suffix,
			string P_Ps_Num,
			string P_Item,
			string P_Revision,
			string P_Type_F,
			string P_Item_F,
			int? P_Bom,
			int? P_Op_Start,
			int? P_Op_End,
			string P_Choice,
			string O_Job,
			int? O_Suffix,
			string O_Item,
			string O_Revision,
			string Infobar)
		{
			StringType _ToCategory = ToCategory;
			JobTypeType _P_Type = P_Type;
			JobType _P_Job = P_Job;
			SuffixType _P_Suffix = P_Suffix;
			PsNumType _P_Ps_Num = P_Ps_Num;
			ItemType _P_Item = P_Item;
			RevisionType _P_Revision = P_Revision;
			JobTypeType _P_Type_F = P_Type_F;
			ItemType _P_Item_F = P_Item_F;
			ListYesNoType _P_Bom = P_Bom;
			OperNumType _P_Op_Start = P_Op_Start;
			OperNumType _P_Op_End = P_Op_End;
			StringType _P_Choice = P_Choice;
			JobType _O_Job = O_Job;
			SuffixType _O_Suffix = O_Suffix;
			ItemType _O_Item = O_Item;
			RevisionType _O_Revision = O_Revision;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "VerifyToInputsSp";
				
				appDB.AddCommandParameter(cmd, "ToCategory", _ToCategory, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "P_Type", _P_Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "P_Job", _P_Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "P_Suffix", _P_Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "P_Ps_Num", _P_Ps_Num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "P_Item", _P_Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "P_Revision", _P_Revision, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "P_Type_F", _P_Type_F, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "P_Item_F", _P_Item_F, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "P_Bom", _P_Bom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "P_Op_Start", _P_Op_Start, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "P_Op_End", _P_Op_End, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "P_Choice", _P_Choice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "O_Job", _O_Job, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "O_Suffix", _O_Suffix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "O_Item", _O_Item, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "O_Revision", _O_Revision, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				O_Job = _O_Job;
				O_Suffix = _O_Suffix;
				O_Item = _O_Item;
				O_Revision = _O_Revision;
				Infobar = _Infobar;
				
				return (Severity, O_Job, O_Suffix, O_Item, O_Revision, Infobar);
			}
		}
	}
}
