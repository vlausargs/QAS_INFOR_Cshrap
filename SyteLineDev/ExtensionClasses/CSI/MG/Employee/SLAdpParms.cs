//PROJECT NAME: EmployeeExt
//CLASS NAME: SLAdpParms.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Employee;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Employee
{
    [IDOExtensionClass("SLAdpParms")]
    public class SLAdpParms : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int CheckExistAdpParmSp(decimal? UserID,
                                       ref string InterfaceVersion,
                                       ref string JobLaborAlloc,
                                       ref string InPath,
                                       ref string InFile,
                                       ref string OutPath,
                                       ref string OutFile,
                                       ref string FileId,
                                       ref string CompanyCode,
                                       ref string LogDir,
                                       ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iCheckExistAdpParmExt = new CheckExistAdpParmFactory().Create(appDb);

                AdpVersionType oInterfaceVersion = InterfaceVersion;
                JobLaborAllocType oJobLaborAlloc = JobLaborAlloc;
                OSLocationType oInPath = InPath;
                OSLocationType oInFile = InFile;
                OSLocationType oOutPath = OutPath;
                OSLocationType oOutFile = OutFile;
                AdpFileIdType oFileId = FileId;
                AdpCompanyCodeType oCompanyCode = CompanyCode;
                OSLocationType oLogDir = LogDir;
                InfobarType oInfobar = Infobar;

                int Severity = iCheckExistAdpParmExt.CheckExistAdpParmSp(UserID,
                                                                         ref oInterfaceVersion,
                                                                         ref oJobLaborAlloc,
                                                                         ref oInPath,
                                                                         ref oInFile,
                                                                         ref oOutPath,
                                                                         ref oOutFile,
                                                                         ref oFileId,
                                                                         ref oCompanyCode,
                                                                         ref oLogDir,
                                                                         ref oInfobar);

                InterfaceVersion = oInterfaceVersion;
                JobLaborAlloc = oJobLaborAlloc;
                InPath = oInPath;
                InFile = oInFile;
                OutPath = oOutPath;
                OutFile = oOutFile;
                FileId = oFileId;
                CompanyCode = oCompanyCode;
                LogDir = oLogDir;
                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ChkPathSp(string Path,
                             ref string TChar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iChkPathExt = new ChkPathFactory().Create(appDb);

                LongListType oTChar = TChar;

                int Severity = iChkPathExt.ChkPathSp(Path,
                                                     ref oTChar);

                TChar = oTChar;


                return Severity;
            }
        }


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PayoutGetAdpParmSp(decimal? UserID,
		[Optional] ref string AdpParmInterfaceVersion,
		[Optional] ref string AdpParmFileId,
		[Optional] ref string AdpOutPath,
		[Optional] ref string AdpOutFile,
		[Optional] ref string AdpParmCompanyCode,
		[Optional] ref string AdpJobLaborAlloc,
		[Optional] ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPayoutGetAdpParmExt = new PayoutGetAdpParmFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPayoutGetAdpParmExt.PayoutGetAdpParmSp(UserID,
				AdpParmInterfaceVersion,
				AdpParmFileId,
				AdpOutPath,
				AdpOutFile,
				AdpParmCompanyCode,
				AdpJobLaborAlloc,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				AdpParmInterfaceVersion = result.AdpParmInterfaceVersion;
				AdpParmFileId = result.AdpParmFileId;
				AdpOutPath = result.AdpOutPath;
				AdpOutFile = result.AdpOutFile;
				AdpParmCompanyCode = result.AdpParmCompanyCode;
				AdpJobLaborAlloc = result.AdpJobLaborAlloc;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
