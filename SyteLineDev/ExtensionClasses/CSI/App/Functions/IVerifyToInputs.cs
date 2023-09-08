//PROJECT NAME: Data
//CLASS NAME: IVerifyToInputs.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IVerifyToInputs
	{
		(int? ReturnCode,
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
			string Infobar);
	}
}

