//PROJECT NAME: AdaptersExt
//CLASS NAME: SLOrderStatuses.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Material;
using CSI.Adapters;
using CSI.Data.RecordSets;

namespace CSI.MG.Adapters
{
    [IDOExtensionClass("SLOrderStatuses")]
    public class SLOrderStatuses : CSIExtensionClassBase
    {


        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GetCodeDescsSp(string PClass,
        [Optional] string PCharCodes,
        [Optional] string PDelimiter,
        ref string PCodeDescs)
        {
            var iGetCodeDescsExt = new GetCodeDescsFactory().Create(this, true);

            var result = iGetCodeDescsExt.GetCodeDescsSp(PClass,
            PCharCodes,
            PDelimiter,
            PCodeDescs);

            int Severity = result.ReturnCode.Value;
            PCodeDescs = result.PCodeDescs;
            return Severity;
        }


        [IDOMethod(MethodFlags.None, "Infobar")]
		public int ExpandKyByTypeSp(string DataType,
		string Key,
		[Optional, DefaultParameterValue(null)] string Site,
		ref string Result)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iExpandKyByTypeExt = new ExpandKyByTypeFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iExpandKyByTypeExt.ExpandKyByTypeSp(DataType,
				Key,
				Site,
				Result);
				
				int Severity = result.ReturnCode.Value;
				Result = result.Result;
				return Severity;
			}
		}
    }
}
