//PROJECT NAME: CSICodes
//CLASS NAME: CheckUsedbyLedger.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Codes
{
	public interface ICheckUsedbyLedger
	{
		int CheckUsedbyLedgerSp(string ChangedType,
		                        string Acct,
		                        string Dimension,
		                        string Attribute,
		                        string InlineListValue,
		                        ref byte? UsedFlag,
		                        ref string OneDimension);
	}
	
	public class CheckUsedbyLedger : ICheckUsedbyLedger
	{
		readonly IApplicationDB appDB;
		
		public CheckUsedbyLedger(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CheckUsedbyLedgerSp(string ChangedType,
		                               string Acct,
		                               string Dimension,
		                               string Attribute,
		                               string InlineListValue,
		                               ref byte? UsedFlag,
		                               ref string OneDimension)
		{
			LongListType _ChangedType = ChangedType;
			AcctType _Acct = Acct;
			DimensionNameType _Dimension = Dimension;
			DimensionAttributeType _Attribute = Attribute;
			DimensionValueType _InlineListValue = InlineListValue;
			ListYesNoType _UsedFlag = UsedFlag;
			DimensionNameType _OneDimension = OneDimension;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CheckUsedbyLedgerSp";
				
				appDB.AddCommandParameter(cmd, "ChangedType", _ChangedType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Acct", _Acct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Dimension", _Dimension, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Attribute", _Attribute, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InlineListValue", _InlineListValue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UsedFlag", _UsedFlag, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OneDimension", _OneDimension, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				UsedFlag = _UsedFlag;
				OneDimension = _OneDimension;
				
				return Severity;
			}
		}
	}
}
