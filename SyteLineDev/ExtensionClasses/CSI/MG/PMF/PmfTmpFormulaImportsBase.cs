//PROJECT NAME: PmfExt
//CLASS NAME: PmfTmpFormulaImportsBase.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.ProcessManufacturing;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.PMF
{
	[IDOExtensionClass("PmfTmpFormulaImportsBase")]
	public class PmfTmpFormulaImportsBase : ExtensionClassBase
	{

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int PmfFmImportProcess(Guid? SessionID)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iPmfFmImportProcessExt = new PmfFmImportProcessFactory().Create(appDb);

                var result = iPmfFmImportProcessExt.PmfFmImportProcessSp(SessionID);


                return result.Value;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
		public int PmfFmImportValidate(Guid? SessionID)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPmfFmImportValidateExt = new PmfFmImportValidateFactory().Create(appDb);
				
				var result = iPmfFmImportValidateExt.PmfFmImportValidateSp(SessionID);
				
				
				return result.Value;
			}
		}
	}
}
