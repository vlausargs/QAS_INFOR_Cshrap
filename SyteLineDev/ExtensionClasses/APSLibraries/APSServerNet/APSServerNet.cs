using System;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Globalization;
using System.Security;

[assembly: AllowPartiallyTrustedCallers]
namespace APS
{
     public class ServerService
    {
        private const string VERSION_LABEL = "171211-1";

        private const string PDBPROJ = "PDBPROJ10";

        private const int VERSION_NUMBER = 10012;
        private const int VERSION_APS10  = 10012;
        private const int VERSION_APS901 = 10011;
        private const int VERSION_APS900 = 10010;
        private const int VERSION_APS803 = 10009;
        private const int VERSION_APS802 = 10008;

        /*------------------------------------------------------------------------*/
        /* Return Codes and Messages                                              */
        /*------------------------------------------------------------------------*/
        public const int APS_ERR_OK           = 1;
        public const int APS_ERR_NETWORK      = -30000;
        public const int APS_ERR_NETWORKSETUP = -30001;
        public const int APS_ERR_HOSTADDR     = -30002;
        public const int APS_ERR_VERSION      = -30003;
        public const int APS_ERR_REGISTRY     = -30004;
        public const int APS_ERR_SQLCONNECT   = -30005;
        public const int APS_ERR_SQLQUERY     = -30006;
        public const int APS_ERR_ALTNO        = -30007;
        public const int APS_ERR_EXEC         = -30008;
        public const int APS_ERR_WAIT         = -30009;
        public const int APS_ERR_PDBINFO      = -30010;
        public const int APS_ERR_PDBCONNECT   = -30011;
        public const int APS_ERR_PLANNERAPI   = -30012;
        public const int APS_ERR_RELOAD       = -30013;
        public const int APS_ERR_PDBDOWN      = -30014;
        public const int APS_ERR_GETEXIT      = -30015;
        public const int APS_ERR_RELOADERRS   = -30016;
        public const int APS_ERR_SCHEDBUSY    = -30017;
        public const int APS_ERR_PLANBUSY     = -30018;
        public const int APS_ERR_GENPLANORD   = -30019;
        public const int APS_ERR_FLUSH        = -30020;
        public const int APS_ERR_SCHEDERR     = -30021;
        public const int APS_ERR_DIFFALT      = -30022;
        public const int APS_ERR_FROMALTNO    = -30023; // Used in ApsCopyAlt
        public const int APS_ERR_TOALTNO      = -30024; // Used in ApsCopyAlt
        public const int APS_ERR_BADDSNAME    = -30025; // Used in ApsCopyAlt
        public const int APS_ERR_DIFFALTS     = -30026; // Used in ApsCopyAlt
        public const int APS_ERR_GWFLUSH      = -30029;
        public const int APS_ERR_NOSITES      = -30030;
        public const int APS_ERR_SITEINFO     = -30031;
        public const int APS_ERR_APSCONNECT   = -30032;
        public const int APS_ERR_OUTOFMEMORY  = -30033;
        public const int APS_ERR_HPMATCH      = -30034;
        public const int APS_ERR_STARTGPLAN   = -30035;
        public const int APS_ERR_ENDGPLAN     = -30036;
        public const int APS_ERR_SCHEDSTART   = -30037;
        public const int APS_ERR_PLANSTART    = -30038;
        public const int APS_ERR_MISSINGSITE  = -30043;
        public const int APS_ERR_PDBAPI       = -30044;
        public const int APS_ERR_TMBUSY       = -30045;
        public const int APS_ERR_INITSL       = -30046;
        public const int APS_ERR_ENCRYPT      = -30047;
        public const int APS_ERR_MODE_NOT_SET = -30048;

        private const string APS_ERM_OK           = "Successful";
        private const string APS_ERM_NETWORK      = "Network communications error connecting to the APS Server Service.  Check parameters on the APS Sites and Alternative Management form.";
        private const string APS_ERM_NETWORKSETUP = "Network communications setup error. Please contact APS Support.";
        private const string APS_ERM_HOSTADDR     = "Cannot resolve APS Server Service host name.  Check the value on the APS Sites and Alternative Management form.";
        private const string APS_ERM_VERSION      = "Version mismatch in code files. Please contact APS Support.";
        private const string APS_ERM_REGISTRY     = "Registry access error. Please contact APS Support.";
        private const string APS_ERM_SQLCONNECT   = "Error connecting to SQL Server.  Check the SQL Login and Password parameters on the APS Sites and Alternative Management form.";
        private const string APS_ERM_SQLQUERY     = "Error in SQL query. Please contact APS Support.";
        private const string APS_ERM_ALTNO        = "Alternative not found. Please contact APS Support.";
        private const string APS_ERM_EXEC         = "Error running external command. Please contact APS Support.";
        private const string APS_ERM_WAIT         = "Error waiting for external command to finish. Please contact APS Support.";
        private const string APS_ERM_PDBINFO      = "Planner connection information not found. Please contact APS Support.";
        private const string APS_ERM_PDBCONNECT   = "Error connecting to the APS Server Service. Please contact APS Support.";
        private const string APS_ERM_PLANNERAPI   = "Planner API returned error. Please contact APS Support.";
        private const string APS_ERM_RELOAD       = "Planner database reload in progress. Please wait for the current Planning task to finish.";
        private const string APS_ERM_PDBDOWN      = "Planner database is marked as down.  Use the Clear Planner Status action menu item on the APS Sites and Alternative Management form, and then try Planning again.";
        private const string APS_ERM_GETEXIT      = "Error getting command return code. Please contact APS Support.";
        private const string APS_ERM_RELOADERRS   = "Planner database reload was unsuccessful. Please contact APS Support.";
        private const string APS_ERM_SCHEDBUSY    = "The Scheduler is currently running for the specified alternative.  Please wait for the current Scheduling task to finish.";
        private const string APS_ERM_PLANBUSY     = "The Planner is currently running for the specified alternative.  Please wait for the current Planning task to finish.";
        private const string APS_ERM_GENPLANORD   = "Generation of planned orders was unsuccessful. Please contact APS Support.";
        private const string APS_ERM_FLUSH        = "Refreshing of the gateway table was unsuccessful. Please contact APS Support.";
        private const string APS_ERM_SCHEDERR     = "The Scheduler detected an error.  See the View Scheduling Log form for details.";
        private const string APS_ERM_DIFFALT      = "API alternative number different than Server Service. Please contact APS Support.";
        private const string APS_ERM_FROMALTNO    = "From alternative not found.";
        private const string APS_ERM_TOALTNO      = "To alternative not found.";
        private const string APS_ERM_BADDSNAME    = "Dataset name not found.";
        private const string APS_ERM_DIFFALTS     = "The from and to alternatives must be different.";
        private const string APS_ERM_GWFLUSH      = "Refresh of the APS gateway in progress. Please try again later.";
        private const string APS_ERM_NOSITES      = "No sites are defined. Please contact APS Support.";
        private const string APS_ERM_SITEINFO     = "Cannot retrieve site connection information for one of the sites. Check the Remote Sites tab on the APS Sites and Alternative Management form.";
        private const string APS_ERM_APSCONNECT   = "Error connecting to APS Server Service. Validate the host and port fields on the Remote Sites tab on the APS Sites and Alternative Management form.";
        private const string APS_ERM_OUTOFMEMORY  = "Program out of memory. Please contact APS Support.";
        private const string APS_ERM_HPMATCH      = "Server Service host or port does not match site information. Validate the host and port fields on the Remote Sites tab on the APS Sites and Alternative Management form.";
        private const string APS_ERM_STARTGPLAN   = "Error starting a global planning run at a site. Please contact APS Support.";
        private const string APS_ERM_ENDGPLAN     = "Error ending a global planning run at a site. Please contact APS Support.";
        private const string APS_ERM_SCHEDSTART   = "ApsSchedulerStartSp returned an error. Check the APS Planning and Scheduling Messages form for more details. Please contact APS Support.";
        private const string APS_ERM_PLANSTART    = "ApsPlannerStartSp returned an error. Check the APS Planning and Scheduling Messages form for more details. Please contact APS Support.";
        private const string APS_ERM_MISSINGSITE  = "An item refers to a site which does not exist.";
        private const string APS_ERM_PDBAPI       = "Planner Database API returned an error. Please contact APS Support.";
        private const string APS_ERM_TMBUSY       = "The system is undergoing maintenance.  Please try again later.";
        private const string APS_ERM_INITSL       = "Error in InitSyteLineSession. Please contact APS Support.";
        private const string APS_ERM_ENCRYPT      = "Error in encryption logic. Please contact APS Support.";
        private const string APS_ERM_MODE_NOT_SET = "Planning mode is not APS. Please contact APS Support.";

        private const string APS_ERM_UNKNOWN      = "Unknown error code.";

        public string geterrortext(int iError)
        {
            switch (iError)
            {
                case APS_ERR_OK: return (APS_ERM_OK);
                case APS_ERR_NETWORK: return (APS_ERM_NETWORK);
                case APS_ERR_NETWORKSETUP: return (APS_ERM_NETWORKSETUP);
                case APS_ERR_HOSTADDR: return (APS_ERM_HOSTADDR);
                case APS_ERR_VERSION: return (APS_ERM_VERSION);
                case APS_ERR_REGISTRY: return (APS_ERM_REGISTRY);
                case APS_ERR_SQLCONNECT: return (APS_ERM_SQLCONNECT);
                case APS_ERR_SQLQUERY: return (APS_ERM_SQLQUERY);
                case APS_ERR_ALTNO: return (APS_ERM_ALTNO);
                case APS_ERR_EXEC: return (APS_ERM_EXEC);
                case APS_ERR_WAIT: return (APS_ERM_WAIT);
                case APS_ERR_PDBINFO: return (APS_ERM_PDBINFO);
                case APS_ERR_PDBCONNECT: return (APS_ERM_PDBCONNECT);
                case APS_ERR_PLANNERAPI: return (APS_ERM_PLANNERAPI);
                case APS_ERR_RELOAD: return (APS_ERM_RELOAD);
                case APS_ERR_PDBDOWN: return (APS_ERM_PDBDOWN);
                case APS_ERR_GETEXIT: return (APS_ERM_GETEXIT);
                case APS_ERR_RELOADERRS: return (APS_ERM_RELOADERRS);
                case APS_ERR_SCHEDBUSY: return (APS_ERM_SCHEDBUSY);
                case APS_ERR_PLANBUSY: return (APS_ERM_PLANBUSY);
                case APS_ERR_GENPLANORD: return (APS_ERM_GENPLANORD);
                case APS_ERR_FLUSH: return (APS_ERM_FLUSH);
                case APS_ERR_SCHEDERR: return (APS_ERM_SCHEDERR);
                case APS_ERR_DIFFALT: return (APS_ERM_DIFFALT);
                case APS_ERR_FROMALTNO: return (APS_ERM_FROMALTNO);
                case APS_ERR_TOALTNO: return (APS_ERM_TOALTNO);
                case APS_ERR_BADDSNAME: return (APS_ERM_BADDSNAME);
                case APS_ERR_DIFFALTS: return (APS_ERM_DIFFALTS);
                case APS_ERR_GWFLUSH: return (APS_ERM_GWFLUSH);
                case APS_ERR_NOSITES: return (APS_ERM_NOSITES);
                case APS_ERR_SITEINFO: return (APS_ERM_SITEINFO);
                case APS_ERR_APSCONNECT: return (APS_ERM_APSCONNECT);
                case APS_ERR_OUTOFMEMORY: return (APS_ERM_OUTOFMEMORY);
                case APS_ERR_HPMATCH: return (APS_ERM_HPMATCH);
                case APS_ERR_STARTGPLAN: return (APS_ERM_STARTGPLAN);
                case APS_ERR_ENDGPLAN: return (APS_ERM_ENDGPLAN);
                case APS_ERR_SCHEDSTART: return (APS_ERM_SCHEDSTART);
                case APS_ERR_PLANSTART: return (APS_ERM_PLANSTART);
                case APS_ERR_MISSINGSITE: return (APS_ERM_MISSINGSITE);
                case APS_ERR_PDBAPI: return (APS_ERM_PDBAPI);
                case APS_ERR_TMBUSY: return (APS_ERM_TMBUSY);
                case APS_ERR_INITSL: return (APS_ERM_INITSL);
                case APS_ERR_ENCRYPT: return (APS_ERM_ENCRYPT);
                case APS_ERR_MODE_NOT_SET: return (APS_ERM_MODE_NOT_SET);
                default: return (APS_ERM_UNKNOWN);
            }
        }

        /*------------------------------------------------------------------------*/
        /* STATUS Code Values                                                     */
        /*------------------------------------------------------------------------*/

        public const int PDB_STATUS_OK     = 0;
        public const int PDB_STATUS_DOWN   = -1;
        public const int PDB_STATUS_RELOAD = 1;
        public const int PDB_STATUS_BUSY   = 2;
        public const int PDB_STATUS_FLUSH  = 3;
        public const int PDB_STATUS_TMBUSY = 4;

        public const int ERDB_STATUS_OK     = 0;  // same as above
        public const int ERDB_STATUS_DOWN   = -1; // kept around for backwards compatibility
        public const int ERDB_STATUS_RELOAD = 1;
        public const int ERDB_STATUS_BUSY   = 2;
        public const int ERDB_STATUS_FLUSH  = 3;
        public const int ERDB_STATUS_TMBUSY = 4;

        public const int APS_STATUS_NEVERSIM = 0;
        public const int APS_STATUS_SIMOK    = 1;
        public const int APS_STATUS_SIMERROR = 2;
        public const int APS_STATUS_SIMBUSY  = 3;
        public const int APS_STATUS_TMBUSY   = 4;

        /*------------------------------------------------------------------------*/
        /* Field Maximum Sizes For Serialization.                                 */
        /*------------------------------------------------------------------------*/
        private const int APSNET_MAX_STRING = 163;  /* string -> string */
        private const int APSNET_MAX_INT = 12;      /* int    -> string */
        private const int APSNET_MAX_DOUBLE = 22;   /* double -> string */

        public struct apsverinfo_s
        {
            public string label;
            public int number;
        }

        public struct apscon_s
        {
            public Socket sock;                /* local client socket              */
            public apsverinfo_s verclient;     /* client version struct            */
            public apsverinfo_s verserver;     /* server version struct            */
        }

        public struct runsched_s
        {
            public int altno;
            public int taskid;
            public string startdate;
            public string enddate;
            public int startoffset;
            public int endoffset;
        }

        public struct runplan_s
        {
            public int altno;
            public int scope;
            public string item;
            public int taskid;
            public int reload; /* 0=false, 1=true */
        }
        public const int APS_RUNPLAN_SCOPE_GLOBAL = 1;
        public const int APS_RUNPLAN_SCOPE_LOCAL = 2;
        public const int APS_RUNPLAN_SCOPE_BATCHLOCAL = 3;

        public const int APS_RUNPLAN_RELOAD_FALSE = 0;
        public const int APS_RUNPLAN_RELOAD_TRUE = 1;

        public struct reloaderdb_s
        {
            public int altno;
        }

        public struct flushgateway_s
        {
            public int altno;
        }

        public struct gplan_s
        {
            public int altno;
            public string ERDBHost;
            public int ERDBPort;
            public int reload; /* 0=false, 1=true */
            public int msg_taskid;
            public int numwarn;
            public int numerr;
            public int numblocked;
        }

        public struct getsqlinfo_s
        {
            public string sqlhost;
            public string database;
            public string user;
            public string password;
            public string site;
            public string dirname;
            public int alwayson;
            public int alt;
        }

        public struct delorder_s
        {
            public int altno;
            public string order;
            public int taskid;
        }

        public struct copypdbfiles_s
        {
            public string APSHost;
            public int APSPort;
        }

        /*------------------------------------------------------------------------*/
        /* API Command Codes.                                                     */
        /*------------------------------------------------------------------------*/
        private const int APS_GET_CONNECTION = 10000;
        private const int APS_GET_VERSION = 10100;
        private const int APS_RUN_SCHEDULER = 10200;
        private const int APS_RUN_PLANNER = 10300;
        private const int APS_RELOAD_ERDB = 10400;
        private const int APS_FLUSH_GATEWAY = 10700;
        private const int APS_START_GPLAN = 10800;
        private const int APS_END_GPLAN = 10900;
        private const int APS_RESET_GPLAN = 11000;
        private const int APS_GET_SQLINFO = 11100;
        private const int APS_DELETE_ORDER = 11400;
        private const int APS_COPY_PDBFILES = 11700;
        private const int APS_IMPORT_PDB = 11900;
        private const int APS_EXPORT_PDB = 12000;
        private const int APS_DEL_CONNECTION = 19999;

        ////////////////////////////////////////////////////////////////////////////

        private const string APS_ERM_CLI_SENDREQCODE = "Client error sending request code";
        private const string APS_ERM_CLI_SENDINPUTS = "Client error sending inputs";
        private const string APS_ERM_CLI_RECVRETCODE = "Client error receiving return code";
        private const string APS_ERM_CLI_RECVOUTPUTS = "Client error receiving ouputs";

        private const int APSNET_MAX_BUFFER = 32000;

        private byte[] mbBuffer = new byte[APSNET_MAX_BUFFER];
        private int miIndex;
        private ASCIIEncoding ascii = new ASCIIEncoding();

        private void apsnet_sendstart()
        {
            miIndex = 0;
            for (int i = 0; i < APSNET_MAX_BUFFER; i++)
                mbBuffer[i] = 0;
        }

        private void apsnet_senddbl(double dValue)
        {
            byte[] bValue = ascii.GetBytes(dValue.ToString("0.00000000000000e+000") + '\0');
            bValue.CopyTo(mbBuffer, miIndex);
            miIndex = miIndex + APSNET_MAX_DOUBLE + 1;
        }

        private void apsnet_sendint(int iValue)
        {
            byte[] bValue = ascii.GetBytes(iValue.ToString("############") + '\0');
            bValue.CopyTo(mbBuffer, miIndex);
            miIndex = miIndex + APSNET_MAX_INT + 1;
        }

        private void apsnet_sendstr(string sValue)
        {
            int i, iChar, len;
            char cValue;

            // Prepend length to string
            len = sValue.Length;
            apsnet_sendint(len);

            for (i = 0; i < len; i++)
            {
                if (i < sValue.Length)
                {
                    cValue = sValue[i];
                    iChar = (int)cValue;
                }
                else
                {
                    iChar = 0;
                }

                if (iChar != 0)
                {
                    byte[] bValue = ascii.GetBytes(iChar.ToString("x4"));
                    bValue.CopyTo(mbBuffer, miIndex);
                    miIndex += 4;
                }
                else
                {
                    byte[] bValue = ascii.GetBytes("0000");
                    bValue.CopyTo(mbBuffer, miIndex);
                    miIndex += 4;
                }
            }
            byte[] bValue2 = ascii.GetBytes("\0");
            bValue2.CopyTo(mbBuffer, miIndex);
            miIndex += 1;
        }

        private void apsnet_recvprepstart()
        {
            miIndex = 0;
            for (int i = 0; i < APSNET_MAX_BUFFER; i++)
                mbBuffer[i] = 0;
        }

        private void apsnet_recvprepdbl()
        {
            miIndex = miIndex + APSNET_MAX_DOUBLE + 1;
        }

        private void apsnet_recvprepint()
        {
            miIndex = miIndex + APSNET_MAX_INT + 1;
        }

        private void apsnet_recvprepstr()
        {
            miIndex = miIndex + APSNET_MAX_INT + 1 + APSNET_MAX_STRING * 4 + 1;
        }

        private void apsnet_recvstart()
        {
            miIndex = 0;
        }

        private void apsnet_recvdbl(out double dValue)
        {
            char[] cValue = ascii.GetChars(mbBuffer, miIndex, APSNET_MAX_DOUBLE);
            for (int i = 0; i < cValue.Length; i++)
                if (cValue[i] == '\0')
                    cValue[i] = ' ';
            string sValue = new string(cValue);
            dValue = double.Parse(sValue, CultureInfo.InvariantCulture);
            miIndex = miIndex + APSNET_MAX_DOUBLE + 1;
        }

        private void apsnet_recvint(out int iValue)
        {
            char[] cValue = ascii.GetChars(mbBuffer, miIndex, APSNET_MAX_INT);
            string sValue = new string(cValue);
            iValue = int.Parse(sValue, CultureInfo.InvariantCulture);
            miIndex = miIndex + APSNET_MAX_INT + 1;
        }

        private void apsnet_recvstr(out string sValue)
        {
            int i, iChar, len;

            // Get string length
            apsnet_recvint(out len);

            // Get string
            char[] cValue = ascii.GetChars(mbBuffer, miIndex, len * 4);
            string s = new string(cValue);

            sValue = "";

            for (i=0; i<len; i++)
            {
                string s2 = s.Substring(i * 4, 4);
                iChar = int.Parse(s2, System.Globalization.NumberStyles.HexNumber);
                sValue += Convert.ToChar(iChar);
            }
            miIndex = miIndex + len*4 + 1;
        }

        /*------------------------------------------------------------------------*/
        /*  OVERVIEW: Receive a message across a network socket                   */
        /*  OUTPUTS:   0=ok                                                       */
        /*            -1=length is greater than max allowed by network            */
        /*            ??=socket error code                                        */
        /*------------------------------------------------------------------------*/
        [SecurityCritical]
        private int apsnet_recv(Socket sock)
        {
            int idx, ret, len;

            if (miIndex > APSNET_MAX_BUFFER+1)
            {
                return (-1);
            }

            // Get length of buffer contents
            idx = 0;
            while (idx < APSNET_MAX_INT + 1)
            {
                try
                {
                    ret = sock.Receive(mbBuffer, idx, APSNET_MAX_INT + 1 - idx, SocketFlags.None);
                }
                catch (SocketException ex)
                {
                    return (int)ex.SocketErrorCode;
                }
                idx = idx + ret;
            }
            apsnet_recvstart();
            apsnet_recvint(out len);

            idx = 0;
            while (idx < len)
            {
                try
                {
                    ret = sock.Receive(mbBuffer, idx, len - idx, SocketFlags.None);
                }
                catch (SocketException ex)
                {
                    return (int)ex.SocketErrorCode;
                }
                idx = idx + ret;
            }

            return (0);
        }

        /*------------------------------------------------------------------------*/
        /*  OVERVIEW: Send a message across the network socket                    */
        /*  OUTPUTS:   0=ok                                                       */
        /*            -1=length is greater than max allowed by network.           */
        /*            ??=socket error code                                        */
        /*------------------------------------------------------------------------*/

        [SecurityCritical]
        private int apsnet_send(Socket sock)
        {
            int idx, ret;

            if (miIndex > APSNET_MAX_BUFFER+1)
            {
                return (-1);
            }

            // Send length of buffer contents
            byte[] bValue = ascii.GetBytes(miIndex.ToString("############") + '\0' + "            ");
            idx = 0;
            while (idx < APSNET_MAX_INT + 1)
            {
                try
                {
                    ret = sock.Send(bValue, idx, APSNET_MAX_INT + 1 - idx, SocketFlags.None);
                }
                catch (SocketException ex)
                {
                    return (int)ex.SocketErrorCode;
                }
                idx = idx + ret;
            }
            if (idx != APSNET_MAX_INT + 1)
            {
                return (-3);
            }

            idx = 0;
            while (idx < miIndex)
            {
                try
                {
                    ret = sock.Send(mbBuffer, idx, miIndex - idx, SocketFlags.None);
                }
                catch (SocketException ex)
                {
                    return (int) ex.SocketErrorCode;
                }
                idx = idx + ret;
            }
            if (idx != miIndex)
            {
                return (-3);
            }

            return (0);
        }

        /*------------------------------------------------------------------------*/
        /*  OVERVIEW: Log a fatal error.                                          */
        /*  INPUTS:   mod  - module name                                          */
        /*            loc  - location or line number                              */
        /*            err  - error code                                           */
        /*            func - function causing error                               */
        /*            buf  - descriptive message                                  */
        /*------------------------------------------------------------------------*/

        [SecurityCritical]
        private void aps_logerr(string mod, int loc, int err, string func, string buf)
        {
            DateTime timenow = DateTime.Now;
            string sErrorFile;

            // sErrorFile = Environment.GetEnvironmentVariable(PDBPROJ) + "\\apserror.txt";
            sErrorFile = "C:\\ProgramData\\Infor\\CSI\\APS\\apserror.txt";

            try
            {
                StreamWriter sw = File.AppendText(sErrorFile);
                sw.WriteLine("-------------------------------------------------");
                sw.WriteLine("{0}: Error {1} from function {2}.", timenow.ToString("yyMMdd.HHmmss"), err, func);
                sw.WriteLine("Module: {0} Location: {1}.", mod, loc);
                if (buf.Length > 0)
                {
                    sw.WriteLine("Message: {0}", buf);
                }
                sw.Close();
            }
            catch
            {
                string sMsg = string.Format("file open error {0} on file apserror.txt", err);

                if (!System.Diagnostics.EventLog.SourceExists("APSServer"))
                    System.Diagnostics.EventLog.CreateEventSource(
                       "APSServer", "Application");

                System.Diagnostics.EventLog EventLog1 =
                   new System.Diagnostics.EventLog();
                EventLog1.Source = "APSServer";
                EventLog1.WriteEntry(sMsg);
            }
        }

        [SecuritySafeCritical]
        public int cget_connection(out apscon_s con, string sHost, int iPort)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mget_connection(out con, sHost, iPort);

            PermissionSet.RevertAssert();

            return (ret);
        }

        /*------------------------------------------------------------------------*/
        /*  OVERVIEW: Client call to get a connection.                            */
        /*  RETURNS:  APS_ERR_OK, APS_ERR_VERSION, APS_ERR_NETWORK, or            */
        /*            APS_ERR_NETWORKSETUP                                        */
        /*------------------------------------------------------------------------*/
        [SecurityCritical]
        private int mget_connection(out apscon_s con, string sHost, int iPort)
        {
            int ret;
            apsverinfo_s apsverinfo;

            con = new apscon_s();
            try
            {
                con.sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                con.sock.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.NoDelay, 1);
                IPHostEntry ipHostInfo = Dns.GetHostEntry(sHost);

                IPAddress ipAddress = null;
                if (ipHostInfo != null && ipHostInfo.AddressList != null)
                {
                    for (int i = 0; i < ipHostInfo.AddressList.Length; i++)
                    {
                        if (ipHostInfo.AddressList[i].AddressFamily == AddressFamily.InterNetworkV6)
                            continue;
                        ipAddress = ipHostInfo.AddressList[i];
                        break;
                    }
                }
                if (ipAddress == null)
                {
                    ret = -1;
                    aps_logerr("cget_connection", 1001, ret, "GetHostEntry", "Address not found");
                    return (APS_ERR_NETWORKSETUP);
                }

                IPEndPoint ep = new IPEndPoint(ipAddress, iPort);
                con.sock.Connect(ep);
            }
            catch (Exception e)
            {
                ret = -1;
                aps_logerr("cget_connection", 1002, ret, "socket", e.ToString());
                return (APS_ERR_NETWORKSETUP);
            }

            apsnet_sendstart();
            apsnet_sendint(APS_GET_CONNECTION);
            if ((ret = apsnet_send(con.sock)) != 0)
            {
                aps_logerr("cget_connection", 1003, ret, "apsnet_send", "get connection");
                return (APS_ERR_NETWORK);
            }

            if ((ret = cget_apsverinfo(con, out apsverinfo)) < 0)
            {
                aps_logerr("cget_connection", 1004, ret, "cget_apsverinfo", "");
                return (APS_ERR_NETWORK);
            }

            con.verclient.label = VERSION_LABEL;
            con.verclient.number = VERSION_NUMBER;

            con.verserver.label = apsverinfo.label;
            con.verserver.number = apsverinfo.number;

            if (con.verserver.number != con.verclient.number)
            {
			    if ((ret = cdel_connection(con)) < 0)
			    {
				    aps_logerr("cget_connection", 1005, ret, "cdel_connection", "");
				    return (APS_ERR_NETWORK);
			    }       
			    return (APS_ERR_VERSION);
            }

            return (APS_ERR_OK);
        }

        /*------------------------------------------------------------------------*/
        /*  OVERVIEW: Client call to delete a connection.                         */
        /*  RETURNS:  APS_ERR_OK or APS_ERR_NETWORK                               */
        /*------------------------------------------------------------------------*/
        [SecuritySafeCritical]
        public int cdel_connection(apscon_s con)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mdel_connection(con);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mdel_connection(apscon_s con)
        {
            int ret;
                
            apsnet_sendstart();
            apsnet_sendint(APS_DEL_CONNECTION);
            if ((ret = apsnet_send(con.sock)) != 0)
            {
                aps_logerr("cdel_connection", 1001, ret, "apsnet_send", "delete connection");
                return (APS_ERR_NETWORK);
            }

            /* Wait for return from Worker saying I got it, then close socket */
            
            apsnet_recvprepstart();
            apsnet_recvprepint();
            if ((ret = apsnet_recv(con.sock)) != 0)
            {
                aps_logerr("cdel_connection", 1002, ret, "apsnet_recv",
                           "Closing connection with worker.");
                return (APS_ERR_NETWORK);
            }

            con.sock.Close();
            return (APS_ERR_OK);
        }

        //private int ctest(apscon_s con)
        //{
        //    int ret;
        //    int iValue1, iValue2, iValue3;
        //    double dValue1, dValue2, dValue3;
        //    string sValue1, sValue2, sValue3;
        //    string sMsg;

        //    /*--------------------------------------------------------------------*/
        //    /* Send request code                                                  */
        //    /*--------------------------------------------------------------------*/

        //    apsnet_sendstart();
        //    apsnet_sendint(9999);
        //    if ((ret = apsnet_send(con.sock)) != 0)
        //    {
        //        aps_logerr("ctest", 1001, ret, "apsnet_send",
        //                   APS_ERM_CLI_SENDREQCODE);
        //        return (APS_ERR_NETWORK);
        //    }

        //    /*--------------------------------------------------------------------*/
        //    /* Send inputs                                                        */
        //    /*--------------------------------------------------------------------*/

        //    apsnet_sendstart();
        //    apsnet_sendint(1234);
        //    apsnet_senddbl(1.234);
        //    apsnet_sendstr("abcd");
        //    apsnet_sendint(123456789);
        //    apsnet_senddbl(1234.56789);
        //    apsnet_sendstr("abcdefghijklmnopqrstuvwxyz");
        //    apsnet_sendint(-5);
        //    apsnet_senddbl(-0.001234);
        //    apsnet_sendstr("12345678901234567890123456789012345678901234567890123456789012345678901234567890");
        //    if ((ret = apsnet_send(con.sock)) != 0)
        //    {
        //        aps_logerr("ctest", 1002, ret, "apsnet_send",
        //                   APS_ERM_CLI_SENDINPUTS);
        //        return (APS_ERR_NETWORK);
        //    }

        //    /*--------------------------------------------------------------------*/
        //    /* Recv return code                                                   */
        //    /*--------------------------------------------------------------------*/

        //    apsnet_recvprepstart();
        //    apsnet_recvprepint();
        //    apsnet_recvprepdbl();
        //    apsnet_recvprepstr();
        //    apsnet_recvprepint();
        //    apsnet_recvprepdbl();
        //    apsnet_recvprepstr();
        //    apsnet_recvprepint();
        //    apsnet_recvprepdbl();
        //    apsnet_recvprepstr();
        //    if ((ret = apsnet_recv(con.sock)) != 0)
        //    {
        //        aps_logerr("ctest", 1003, ret, "apsnet_recv",
        //                   APS_ERM_CLI_RECVRETCODE);
        //        return (APS_ERR_NETWORK);
        //    }
        //    apsnet_recvstart();
        //    apsnet_recvint(out iValue1);
        //    apsnet_recvdbl(out dValue1);
        //    apsnet_recvstr(out sValue1);
        //    apsnet_recvint(out iValue2);
        //    apsnet_recvdbl(out dValue2);
        //    apsnet_recvstr(out sValue2);
        //    apsnet_recvint(out iValue3);
        //    apsnet_recvdbl(out dValue3);
        //    apsnet_recvstr(out sValue3);

        //    sMsg = "";
        //    if (iValue1 != 1234) sMsg += "l1 " + iValue1.ToString();
        //    if (dValue1 != 1.234) sMsg += "d1 " + dValue1.ToString();
        //    if (sValue1 != "abcd") sMsg += "s1 " + sValue1.ToString();
        //    if (iValue2 != 123456789) sMsg += "l2 " + iValue2.ToString();
        //    if (dValue2 != 1234.56789) sMsg += "d2 " + dValue2.ToString();
        //    if (sValue2 != "abcdefghijklmnopqrstuvwxyz") sMsg += "s2 " + sValue2.ToString();
        //    if (iValue3 != -5) sMsg += "l3 " + iValue3.ToString();
        //    if (dValue3 != -0.001234) sMsg += "d3 " + dValue3.ToString();
        //    if (sValue3 != "12345678901234567890123456789012345678901234567890123456789012345678901234567890") sMsg += "s3 " + sValue3.ToString();

        //    if (sMsg.Length > 0)
        //    {
        //        aps_logerr("ctest", 1004, ret, "diff", sMsg);
        //    }

        //    return (APS_ERR_OK);
        //}

        [SecuritySafeCritical]
        public int cget_apsverinfo(apscon_s con, out apsverinfo_s apsverinfo)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mget_apsverinfo(con, out apsverinfo);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mget_apsverinfo(apscon_s con, out apsverinfo_s apsverinfo)
        {
            int ret, apiret;

            apsverinfo.label = "";
            apsverinfo.number = 0;

            /*--------------------------------------------------------------------*/
            /* Send request code                                                  */
            /*--------------------------------------------------------------------*/
            
            apsnet_sendstart();
            apsnet_sendint(APS_GET_VERSION);
            if ((ret = apsnet_send(con.sock)) != 0)
            {
                aps_logerr("cget_apsverinfo", 1001, ret, "apsnet_send",
                           APS_ERM_CLI_SENDREQCODE);
                return (APS_ERR_NETWORK);
            }

            /*--------------------------------------------------------------------*/
            /* Recv return code                                                   */
            /*--------------------------------------------------------------------*/
            
            apsnet_recvprepstart();
            apsnet_recvprepint();
            if ((ret = apsnet_recv(con.sock)) != 0)
            {
                aps_logerr("cget_apsverinfo", 1002, ret, "apsnet_recv",
                           APS_ERM_CLI_RECVRETCODE);
                return (APS_ERR_NETWORK);
            }
            apsnet_recvstart();
            apsnet_recvint(out apiret);

            /*--------------------------------------------------------------------*/
            /* Recv outputs                                                       */
            /*--------------------------------------------------------------------*/
            
            apsnet_recvprepstart();
            apsnet_recvprepstr();
            apsnet_recvprepint();
            if ((ret = apsnet_recv(con.sock)) != 0)
            {
                aps_logerr("cget_apsverinfo", 1003, ret, "apsnet_recv",
                           APS_ERM_CLI_RECVOUTPUTS);
                return (APS_ERR_NETWORK);
            }
            apsnet_recvstart();
            apsnet_recvstr(out apsverinfo.label);
            apsnet_recvint(out apsverinfo.number);

            return (apiret);
        }

        [SecuritySafeCritical]
        public int cdelete_order(apscon_s con, delorder_s delorder)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mdelete_order(con, delorder);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mdelete_order(apscon_s con, delorder_s delorder)
        {
            int ret, apiret;

	        /*--------------------------------------------------------------------*/
            /* Send request code                                                  */
            /*--------------------------------------------------------------------*/
            
            apsnet_sendstart();
            apsnet_sendint(APS_DELETE_ORDER);
            if ((ret = apsnet_send(con.sock)) != 0)
            {
                aps_logerr("cdelete_order", 1002, ret, "apsnet_send",
                           APS_ERM_CLI_SENDREQCODE);
                return (APS_ERR_NETWORK);
            }

            /*--------------------------------------------------------------------*/
            /* Send inputs                                                        */
            /*--------------------------------------------------------------------*/
            
            apsnet_sendstart();
            apsnet_sendint(delorder.altno);
            apsnet_sendstr(delorder.order);
            apsnet_sendint(delorder.taskid);
            if ((ret = apsnet_send(con.sock)) != 0)
            {
                aps_logerr("cdelete_order", 1003, ret, "apsnet_send",
                           APS_ERM_CLI_SENDINPUTS);
                return (APS_ERR_NETWORK);
            }

            /*--------------------------------------------------------------------*/
            /* Recv return code                                                   */
            /*--------------------------------------------------------------------*/
            
            apsnet_recvprepstart();
            apsnet_recvprepint();
            if ((ret = apsnet_recv(con.sock)) != 0)
            {
                aps_logerr("cdelete_order", 1004, ret, "apsnet_recv",
                           APS_ERM_CLI_RECVRETCODE);
                return (APS_ERR_NETWORK);
            }
            apsnet_recvstart();
            apsnet_recvint(out apiret);

            return (apiret);
        }

        [SecuritySafeCritical]
        public int cend_gplan(apscon_s con, gplan_s gplan)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mend_gplan(con, gplan);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mend_gplan(apscon_s con, gplan_s gplan)
        {
            int ret, apiret;

            /*--------------------------------------------------------------------*/
            /* Send request code                                                  */
            /*--------------------------------------------------------------------*/
            
            apsnet_sendstart();
            apsnet_sendint(APS_END_GPLAN);
            if ((ret = apsnet_send(con.sock)) != 0)
            {
                aps_logerr("cend_gplan", 1001, ret, "apsnet_send",
                           APS_ERM_CLI_SENDREQCODE);
                return (APS_ERR_NETWORK);
            }

            /*--------------------------------------------------------------------*/
            /* Send inputs                                                        */
            /*--------------------------------------------------------------------*/
            
            apsnet_sendstart();
            apsnet_sendint(gplan.altno);
            apsnet_sendstr(gplan.ERDBHost);
            apsnet_sendint(gplan.ERDBPort);
            apsnet_sendint(gplan.msg_taskid);
            if ((ret = apsnet_send(con.sock)) != 0)
            {
                aps_logerr("cend_gplan", 1002, ret, "apsnet_send",
                           APS_ERM_CLI_SENDINPUTS);
                return (APS_ERR_NETWORK);
            }

            /*--------------------------------------------------------------------*/
            /* Recv return code                                                   */
            /*--------------------------------------------------------------------*/
            
            apsnet_recvprepstart();
            apsnet_recvprepint();
            if ((ret = apsnet_recv(con.sock)) != 0)
            {
                aps_logerr("cend_gplan", 1003, ret, "apsnet_recv",
                           APS_ERM_CLI_RECVRETCODE);
                return (APS_ERR_NETWORK);
            }
            apsnet_recvstart();
            apsnet_recvint(out apiret);
            apsnet_recvint(out gplan.numwarn);
            apsnet_recvint(out gplan.numerr);
            apsnet_recvint(out gplan.numblocked);

            return (apiret);
        }

        [SecuritySafeCritical]
        public int cflush_gateway(apscon_s con, flushgateway_s flushgateway)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mflush_gateway(con, flushgateway);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mflush_gateway(apscon_s con, flushgateway_s flushgateway)
        {
            int ret, apiret;

            /*--------------------------------------------------------------------*/
            /* Send request code                                                  */
            /*--------------------------------------------------------------------*/
            
            apsnet_sendstart();
            apsnet_sendint(APS_FLUSH_GATEWAY);
            if ((ret = apsnet_send(con.sock)) != 0)
            {
                aps_logerr("cflush_gateway", 1001, ret, "apsnet_send",
                           APS_ERM_CLI_SENDREQCODE);
                return (APS_ERR_NETWORK);
            }

            /*--------------------------------------------------------------------*/
            /* Send inputs                                                        */
            /*--------------------------------------------------------------------*/
            
            apsnet_sendstart();
            apsnet_sendint(flushgateway.altno);
            if ((ret = apsnet_send(con.sock)) != 0)
            {
                aps_logerr("cflush_gateway", 1002, ret, "apsnet_send",
                           APS_ERM_CLI_SENDINPUTS);
                return (APS_ERR_NETWORK);
            }

            /*--------------------------------------------------------------------*/
            /* Recv return code                                                   */
            /*--------------------------------------------------------------------*/
            
            apsnet_recvprepstart();
            apsnet_recvprepint();
            if ((ret = apsnet_recv(con.sock)) != 0)
            {
                aps_logerr("cflush_gateway", 1003, ret, "apsnet_recv",
                           APS_ERM_CLI_RECVRETCODE);
                return (APS_ERR_NETWORK);
            }
            apsnet_recvstart();
            apsnet_recvint(out apiret);

            return (apiret);
        }

        [SecuritySafeCritical]
        public int cget_sqlinfo(apscon_s con, out getsqlinfo_s getsqlinfo)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mget_sqlinfo(con, out getsqlinfo);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mget_sqlinfo(apscon_s con, out getsqlinfo_s getsqlinfo)
        {
            int ret, apiret;

            getsqlinfo.sqlhost = "";
            getsqlinfo.database = "";
            getsqlinfo.user = "";
            getsqlinfo.password = "";
            getsqlinfo.site = "";
            getsqlinfo.dirname = "";
            getsqlinfo.alwayson = 0;
            getsqlinfo.alt = 0;

            /*--------------------------------------------------------------------*/
            /* Send request code                                                  */
            /*--------------------------------------------------------------------*/

            apsnet_sendstart();
            apsnet_sendint(APS_GET_SQLINFO);
            if ((ret = apsnet_send(con.sock)) != 0)
            {
                aps_logerr("cget_sqlinfo", 1001, ret, "apsnet_send",
                           APS_ERM_CLI_SENDREQCODE);
                return (APS_ERR_NETWORK);
            }

            /*--------------------------------------------------------------------*/
            /* Recv return code                                                   */
            /*--------------------------------------------------------------------*/
            
            apsnet_recvprepstart();
            apsnet_recvprepint();
            if ((ret = apsnet_recv(con.sock)) != 0)
            {
                aps_logerr("cget_sqlinfo", 1002, ret, "apsnet_recv",
                           APS_ERM_CLI_RECVRETCODE);
                return (APS_ERR_NETWORK);
            }
            apsnet_recvstart();
            apsnet_recvint(out apiret);

            /*--------------------------------------------------------------------*/
            /* Recv outputs                                                       */
            /*--------------------------------------------------------------------*/
            
            apsnet_recvprepstart();
            apsnet_recvprepstr();
            apsnet_recvprepstr();
            apsnet_recvprepstr();
            apsnet_recvprepstr();
            apsnet_recvprepstr();
            apsnet_recvprepstr();
            apsnet_recvprepint();
            apsnet_recvprepint();
            if ((ret = apsnet_recv(con.sock)) != 0)
            {
                aps_logerr("cget_sqlinfo", 1003, ret, "apsnet_recv",
                           APS_ERM_CLI_RECVOUTPUTS);
                return (APS_ERR_NETWORK);
            }
            apsnet_recvstart();
            apsnet_recvstr(out getsqlinfo.sqlhost);
            apsnet_recvstr(out getsqlinfo.database);
            apsnet_recvstr(out getsqlinfo.user);
            apsnet_recvstr(out getsqlinfo.password);
            apsnet_recvstr(out getsqlinfo.site);
            apsnet_recvstr(out getsqlinfo.dirname);
            apsnet_recvint(out getsqlinfo.alwayson);
            apsnet_recvint(out getsqlinfo.alt);

            return (apiret);
        }

        [SecuritySafeCritical]
        public int creload_erdb(apscon_s con, reloaderdb_s reloaderdb)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mreload_erdb(con, reloaderdb);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mreload_erdb(apscon_s con, reloaderdb_s reloaderdb)
        {
            int ret, apiret;

            /*--------------------------------------------------------------------*/
            /* Send request code                                                  */
            /*--------------------------------------------------------------------*/
            
            apsnet_sendstart();
            apsnet_sendint(APS_RELOAD_ERDB);
            if ((ret = apsnet_send(con.sock)) != 0)
            {
                aps_logerr("creload_erdb", 1001, ret, "apsnet_send",
                           APS_ERM_CLI_SENDREQCODE);
                return (APS_ERR_NETWORK);
            }

            /*--------------------------------------------------------------------*/
            /* Send inputs                                                        */
            /*--------------------------------------------------------------------*/
            
            apsnet_sendstart();
            apsnet_sendint(reloaderdb.altno);
            if ((ret = apsnet_send(con.sock)) != 0)
            {
                aps_logerr("creload_erdb", 1002, ret, "apsnet_send",
                           APS_ERM_CLI_SENDINPUTS);
                return (APS_ERR_NETWORK);
            }

            /*--------------------------------------------------------------------*/
            /* Recv return code                                                   */
            /*--------------------------------------------------------------------*/
            
            apsnet_recvprepstart();
            apsnet_recvprepint();
            if ((ret = apsnet_recv(con.sock)) != 0)
            {
                aps_logerr("creload_erdb", 1003, ret, "apsnet_recv",
                           APS_ERM_CLI_RECVRETCODE);
                return (APS_ERR_NETWORK);
            }
            apsnet_recvstart();
            apsnet_recvint(out apiret);

            return (apiret);
        }

        [SecuritySafeCritical]
        public int creset_gplan(apscon_s con, gplan_s gplan)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mreset_gplan(con, gplan);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mreset_gplan(apscon_s con, gplan_s gplan)
        {
            int ret, apiret;

            /*--------------------------------------------------------------------*/
            /* Send request code                                                  */
            /*--------------------------------------------------------------------*/
            
            apsnet_sendstart();
            apsnet_sendint(APS_RESET_GPLAN);
            if ((ret = apsnet_send(con.sock)) != 0)
            {
                aps_logerr("creset_gplan", 1001, ret, "apsnet_send",
                           APS_ERM_CLI_SENDREQCODE);
                return (APS_ERR_NETWORK);
            }

            /*--------------------------------------------------------------------*/
            /* Send inputs                                                        */
            /*--------------------------------------------------------------------*/
            
            apsnet_sendstart();
            apsnet_sendint(gplan.altno);
            apsnet_sendstr(gplan.ERDBHost);
            apsnet_sendint(gplan.ERDBPort);
            if ((ret = apsnet_send(con.sock)) != 0)
            {
                aps_logerr("creset_gplan", 1002, ret, "apsnet_send",
                           APS_ERM_CLI_SENDINPUTS);
                return (APS_ERR_NETWORK);
            }

            /*--------------------------------------------------------------------*/
            /* Recv return code                                                   */
            /*--------------------------------------------------------------------*/
            
            apsnet_recvprepstart();
            apsnet_recvprepint();
            if ((ret = apsnet_recv(con.sock)) != 0)
            {
                aps_logerr("creset_gplan", 1003, ret, "apsnet_recv",
                           APS_ERM_CLI_RECVRETCODE);
                return (APS_ERR_NETWORK);
            }
            apsnet_recvstart();
            apsnet_recvint(out apiret);

            return (apiret);
        }

        [SecuritySafeCritical]
        public int crun_planner(apscon_s con, runplan_s runplan)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mrun_planner(con, runplan);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mrun_planner(apscon_s con, runplan_s runplan)
        {
            int ret, apiret;

            /*--------------------------------------------------------------------*/
            /* Send request code                                                  */
            /*--------------------------------------------------------------------*/
            
            apsnet_sendstart();
            apsnet_sendint(APS_RUN_PLANNER);
            if ((ret = apsnet_send(con.sock)) != 0)
            {
                aps_logerr("crun_planner", 1001, ret, "apsnet_send",
                           APS_ERM_CLI_SENDREQCODE);
                return (APS_ERR_NETWORK);
            }

            /*--------------------------------------------------------------------*/
            /* Send inputs                                                        */
            /*--------------------------------------------------------------------*/
            
            apsnet_sendstart();
            apsnet_sendint(runplan.altno);
            apsnet_sendint(runplan.scope);
            apsnet_sendstr(runplan.item);
            apsnet_sendint(runplan.taskid);
            apsnet_sendint(runplan.taskid);
            apsnet_sendint(runplan.reload);
            if ((ret = apsnet_send(con.sock)) != 0)
            {
                aps_logerr("crun_planner", 1002, ret, "apsnet_send",
                           APS_ERM_CLI_SENDINPUTS);
                return (APS_ERR_NETWORK);
            }

            /*--------------------------------------------------------------------*/
            /* Recv return code                                                   */
            /*--------------------------------------------------------------------*/
            
            apsnet_recvprepstart();
            apsnet_recvprepint();
            if ((ret = apsnet_recv(con.sock)) != 0)
            {
                aps_logerr("crun_planner", 1003, ret, "apsnet_recv",
                           APS_ERM_CLI_RECVRETCODE);
                return (APS_ERR_NETWORK);
            }
            apsnet_recvstart();
            apsnet_recvint(out apiret);

            return (apiret);
        }

        [SecuritySafeCritical]
        public int crun_scheduler(apscon_s con, runsched_s runsched)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mrun_scheduler(con, runsched);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mrun_scheduler(apscon_s con, runsched_s runsched)
        {
            int ret, apiret;

            /*--------------------------------------------------------------------*/
            /* Send request code                                                  */
            /*--------------------------------------------------------------------*/
            
            apsnet_sendstart();
            apsnet_sendint(APS_RUN_SCHEDULER);
            if ((ret = apsnet_send(con.sock)) != 0)
            {
                aps_logerr("crun_scheduler", 1001, ret, "apsnet_send",
                           APS_ERM_CLI_SENDREQCODE);
                return (APS_ERR_NETWORK);
            }

            /*--------------------------------------------------------------------*/
            /* Send inputs                                                        */
            /*--------------------------------------------------------------------*/
            
            apsnet_sendstart();
            apsnet_sendint(runsched.altno);
            apsnet_sendint(runsched.taskid);
            apsnet_sendstr(runsched.startdate);
            apsnet_sendstr(runsched.enddate);
            apsnet_sendint(runsched.startoffset);
            apsnet_sendint(runsched.endoffset);
            if ((ret = apsnet_send(con.sock)) != 0)
            {
                aps_logerr("crun_scheduler", 1002, ret, "apsnet_send",
                           APS_ERM_CLI_SENDINPUTS);
                return (APS_ERR_NETWORK);
            }

            /*--------------------------------------------------------------------*/
            /* Recv return code                                                   */
            /*--------------------------------------------------------------------*/
            
            apsnet_recvprepstart();
            apsnet_recvprepint();
            if ((ret = apsnet_recv(con.sock)) != 0)
            {
                aps_logerr("crun_scheduler", 1003, ret, "apsnet_recv",
                           APS_ERM_CLI_RECVRETCODE);
                return (APS_ERR_NETWORK);
            }
            apsnet_recvstart();
            apsnet_recvint(out apiret);

            return (apiret);
        }

        [SecuritySafeCritical]
        public int cstart_gplan(apscon_s con, gplan_s gplan)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mstart_gplan(con, gplan);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mstart_gplan(apscon_s con, gplan_s gplan)
        {
            int ret, apiret;

            /*--------------------------------------------------------------------*/
            /* Send request code                                                  */
            /*--------------------------------------------------------------------*/
            
            apsnet_sendstart();
            apsnet_sendint(APS_START_GPLAN);
            if ((ret = apsnet_send(con.sock)) != 0)
            {
                aps_logerr("cstart_gplan", 1001, ret, "apsnet_send",
                           APS_ERM_CLI_SENDREQCODE);
                return (APS_ERR_NETWORK);
            }

            /*--------------------------------------------------------------------*/
            /* Send inputs                                                        */
            /*--------------------------------------------------------------------*/
            
            apsnet_sendstart();
            apsnet_sendint(gplan.altno);
            apsnet_sendstr(gplan.ERDBHost);
            apsnet_sendint(gplan.ERDBPort);
            apsnet_sendint(gplan.reload);
            apsnet_sendint(gplan.msg_taskid);
            if ((ret = apsnet_send(con.sock)) != 0)
            {
                aps_logerr("cstart_gplan", 1002, ret, "apsnet_send",
                           APS_ERM_CLI_SENDINPUTS);
                return (APS_ERR_NETWORK);
            }

            /*--------------------------------------------------------------------*/
            /* Recv return code                                                   */
            /*--------------------------------------------------------------------*/
            
            apsnet_recvprepstart();
            apsnet_recvprepint();
            if ((ret = apsnet_recv(con.sock)) != 0)
            {
                aps_logerr("cstart_gplan", 1003, ret, "apsnet_recv",
                           APS_ERM_CLI_RECVRETCODE);
                return (APS_ERR_NETWORK);
            }
            apsnet_recvstart();
            apsnet_recvint(out apiret);

            return (apiret);
        }

        [SecuritySafeCritical]
        public int ccopy_pdbfiles(apscon_s con, copypdbfiles_s copypdbfiles)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mcopy_pdbfiles(con, copypdbfiles);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mcopy_pdbfiles(apscon_s con, copypdbfiles_s copypdbfiles)
        {
            int ret, apiret;

            /*--------------------------------------------------------------------*/
            /* Send request code                                                  */
            /*--------------------------------------------------------------------*/

            apsnet_sendstart();
            apsnet_sendint(APS_COPY_PDBFILES);
            if ((ret = apsnet_send(con.sock)) != 0)
            {
                aps_logerr("ccopy_pdbfiles", 1001, ret, "apsnet_send", APS_ERM_CLI_SENDREQCODE);
                return (APS_ERR_NETWORK);
            }

            /*--------------------------------------------------------------------*/
            /* Send inputs                                                        */
            /*--------------------------------------------------------------------*/

            apsnet_sendstart();
            apsnet_sendstr(copypdbfiles.APSHost);
            apsnet_sendint(copypdbfiles.APSPort);
            if ((ret = apsnet_send(con.sock)) != 0)
            {
                aps_logerr("ccopy_pdbfiles", 1002, ret, "apsnet_send", APS_ERM_CLI_SENDINPUTS);
                return (APS_ERR_NETWORK);
            }

            /*--------------------------------------------------------------------*/
            /* Recv return code                                                   */
            /*--------------------------------------------------------------------*/

            apsnet_recvprepstart();
            apsnet_recvprepint();
            if ((ret = apsnet_recv(con.sock)) != 0)
            {
                aps_logerr("ccopy_pdbfiles", 1003, ret, "apsnet_recv", APS_ERM_CLI_RECVRETCODE);
                return (APS_ERR_NETWORK);
            }
            apsnet_recvstart();
            apsnet_recvint(out apiret);

            return (apiret);
        }

        [SecuritySafeCritical]
        public int cimport_pdb(apscon_s con, string file)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mimport_pdb(con, file);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mimport_pdb(apscon_s con, string file)
        {
            int ret, apiret;

            /*--------------------------------------------------------------------*/
            /* Send request code                                                  */
            /*--------------------------------------------------------------------*/

            apsnet_sendstart();
            apsnet_sendint(APS_IMPORT_PDB);
            if ((ret = apsnet_send(con.sock)) != 0)
            {
                aps_logerr("cimport_pdb", 1001, ret, "apsnet_send", APS_ERM_CLI_SENDREQCODE);
                return (APS_ERR_NETWORK);
            }

            /*--------------------------------------------------------------------*/
            /* Send inputs                                                        */
            /*--------------------------------------------------------------------*/

            apsnet_sendstart();
            apsnet_sendstr(file);
            if ((ret = apsnet_send(con.sock)) != 0)
            {
                aps_logerr("cimport_pdb", 1002, ret, "apsnet_send", APS_ERM_CLI_SENDINPUTS);
                return (APS_ERR_NETWORK);
            }

            /*--------------------------------------------------------------------*/
            /* Recv return code                                                   */
            /*--------------------------------------------------------------------*/

            apsnet_recvprepstart();
            apsnet_recvprepint();
            if ((ret = apsnet_recv(con.sock)) != 0)
            {
                aps_logerr("cimport_pdb", 1003, ret, "apsnet_recv", APS_ERM_CLI_RECVRETCODE);
                return (APS_ERR_NETWORK);
            }
            apsnet_recvstart();
            apsnet_recvint(out apiret);

            return (apiret);
        }

        [SecuritySafeCritical]
        public int cexport_pdb(apscon_s con, string file)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mexport_pdb(con, file);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mexport_pdb(apscon_s con, string file)
        {
            int ret, apiret;

            /*--------------------------------------------------------------------*/
            /* Send request code                                                  */
            /*--------------------------------------------------------------------*/

            apsnet_sendstart();
            apsnet_sendint(APS_EXPORT_PDB);
            if ((ret = apsnet_send(con.sock)) != 0)
            {
                aps_logerr("cexport_pdb", 1001, ret, "apsnet_send", APS_ERM_CLI_SENDREQCODE);
                return (APS_ERR_NETWORK);
            }

            /*--------------------------------------------------------------------*/
            /* Send inputs                                                        */
            /*--------------------------------------------------------------------*/

            apsnet_sendstart();
            apsnet_sendstr(file);
            if ((ret = apsnet_send(con.sock)) != 0)
            {
                aps_logerr("cexport_pdb", 1002, ret, "apsnet_send", APS_ERM_CLI_SENDINPUTS);
                return (APS_ERR_NETWORK);
            }

            /*--------------------------------------------------------------------*/
            /* Recv return code                                                   */
            /*--------------------------------------------------------------------*/

            apsnet_recvprepstart();
            apsnet_recvprepint();
            if ((ret = apsnet_recv(con.sock)) != 0)
            {
                aps_logerr("cexport_pdb", 1003, ret, "apsnet_recv", APS_ERM_CLI_RECVRETCODE);
                return (APS_ERR_NETWORK);
            }
            apsnet_recvstart();
            apsnet_recvint(out apiret);

            return (apiret);
        }
    }

    public class MasterService
    {
        private const string VERSION_LABEL = "190925-1";
        private const int VERSION_NUMBER = 11;

        private const string PDBPROJ = "PDBPROJ10";

        private int master_service_port = 11911;

        /*------------------------------------------------------------------------*/
        /* Return Codes and Messages                                              */
        /*------------------------------------------------------------------------*/
        public const int APS_ERR_OK           = 1;
        public const int APS_ERR_NETWORK      = -40000;
        public const int APS_ERR_NETWORKSETUP = -40001;
        public const int APS_ERR_HOSTADDR     = -40002;
        public const int APS_ERR_VERSION      = -40003;
        public const int APS_ERR_REGISTRY     = -40004;
        public const int APS_ERR_EXEC         = -40005;
        public const int APS_ERR_SRUNNING     = -40007;
        public const int APS_ERR_NOTSRUNNING  = -40008;
        public const int APS_ERR_PDBPROJ      = -40012;
        public const int APS_ERR_REMOVE       = -40013;
        public const int APS_ERR_CONNECT      = -40015;

        private const string APS_ERM_OK           = "Successful";
        private const string APS_ERM_NETWORK      = "Network communications error.";
        private const string APS_ERM_NETWORKSETUP = "Network communications setup error.";
        private const string APS_ERM_HOSTADDR     = "Cannot resolve host address.";
        private const string APS_ERM_VERSION      = "Version mismatch.";
        private const string APS_ERM_REGISTRY     = "Registry access error";
        private const string APS_ERM_EXEC         = "Error running external command.";
        private const string APS_ERM_SRUNNING     = "Service is already running.";
        private const string APS_ERM_NOTSRUNNING  = "Service is not running.";
        private const string APS_ERM_PDBPROJ      = "PDBPROJ environment variable not set.";
        private const string APS_ERM_REMOVE       = "Error removing a file.";
        private const string APS_ERM_CONNECT      = "Cannot connect to the APS Master Service.";
        private const string APS_ERM_UNKNOWN      = "Unknown error code.";

        public string geterrortext(int iError)
        {
            switch (iError)
            {
                case APS_ERR_OK: return (APS_ERM_OK);
                case APS_ERR_NETWORK: return (APS_ERM_NETWORK);
                case APS_ERR_NETWORKSETUP: return (APS_ERM_NETWORKSETUP);
                case APS_ERR_HOSTADDR: return (APS_ERM_HOSTADDR);
                case APS_ERR_VERSION: return (APS_ERM_VERSION);
                case APS_ERR_REGISTRY: return (APS_ERM_REGISTRY);
                case APS_ERR_EXEC: return (APS_ERM_EXEC);
                case APS_ERR_SRUNNING: return (APS_ERM_SRUNNING);
                case APS_ERR_NOTSRUNNING: return (APS_ERM_NOTSRUNNING);
                case APS_ERR_PDBPROJ: return (APS_ERM_PDBPROJ);
                case APS_ERR_REMOVE: return (APS_ERM_REMOVE);
                case APS_ERR_CONNECT: return (APS_ERM_CONNECT);
                default: return (APS_ERM_UNKNOWN);
            }
        }

        public void SetMasterServicePort(int iPort)
        {
            master_service_port = iPort;
        }

        /*------------------------------------------------------------------------*/
        /* Field Maximum Sizes For Serialization.                                 */
        /*------------------------------------------------------------------------*/
        private const int APSNET_MAX_STRING = 200;  /* string -> string */
        private const int APSNET_MAX_INT    = 12;   /* int    -> string */
        private const int APSNET_MAX_DOUBLE = 22;   /* double -> string */

        private struct version_s
        {
            public string label;
            public int number;
        }

        private struct apsmcon_s
        {
            public Socket sock;             /* local client socket              */
            public version_s verclient;     /* client version struct            */
            public version_s verserver;     /* server version struct            */
        }

        public struct GetAPSServerServiceStatus_s
        {
            public string server_service_host;
            public int server_service_port;
            public int is_running;
            public int return_code;
            public string return_message;
        }

        public struct StartAPSServerService_s
        {
            public string server_service_host;
            public int server_service_port;
            public string sql_host;
            public string sql_database;
            public string sql_user;
            public string sql_pfield;
            public int sql_pfield_encrypted;
            public int sql_alwayson;
            public int alternative;
            public string syteline_site;
            public int return_code;
            public string return_message;
        }

        public struct StopAPSServerService_s
        {
            public string server_service_host;
            public int server_service_port;
            public int return_code;
            public string return_message;
        }

        public struct UploadErrorTraceFiles_s
        {
            public string upload_url;
            public string file_prefix;
            public int alternative;
            public string server_service_host;
            public int server_service_port;
            public int return_code;
            public string return_message;
        }

        /*------------------------------------------------------------------------*/
        /* API Command Codes.                                                     */
        /*------------------------------------------------------------------------*/
        private const int APS_GET_CONNECTION            = 20000;
        private const int APS_GET_VERSION               = 20100;
        private const int APS_GETAPSSERVERSERVICESTATUS = 20210;
        private const int APS_STARTAPSSERVERSERVICE     = 20220;
        private const int APS_STOPAPSSERVERSERVICE      = 20230;
        private const int APS_UPLOADERRORTRACEFILES     = 20500;
        private const int APS_DEL_CONNECTION            = 29999;

        ////////////////////////////////////////////////////////////////////////////

        private const string APS_ERM_CLI_SENDREQCODE = "Client error sending request code";
        private const string APS_ERM_CLI_SENDINPUTS  = "Client error sending inputs";
        private const string APS_ERM_CLI_RECVRETCODE = "Client error receiving return code";
        private const string APS_ERM_CLI_RECVOUTPUTS = "Client error receiving ouputs";

        private const int APSNET_MAX_BUFFER = 15000;

        private byte[] mbBuffer = new byte[APSNET_MAX_BUFFER];
        private int miIndex;
        private ASCIIEncoding ascii = new ASCIIEncoding();

        private void apsnet_sendstart()
        {
            miIndex = 0;
            for (int i = 0; i < APSNET_MAX_BUFFER; i++)
                mbBuffer[i] = 0;
        }

        private void apsnet_senddbl(double dValue)
        {
            byte[] bValue = ascii.GetBytes(dValue.ToString("0.00000000000000e+000") + '\0');
            bValue.CopyTo(mbBuffer, miIndex);
            miIndex = miIndex + APSNET_MAX_DOUBLE + 1;
        }

        private void apsnet_sendint(int iValue)
        {
            byte[] bValue = ascii.GetBytes(iValue.ToString("############") + '\0');
            bValue.CopyTo(mbBuffer, miIndex);
            miIndex = miIndex + APSNET_MAX_INT + 1;
        }

        private void apsnet_sendstr(string sValue)
        {
            int i, iChar;
            char cValue;

            for (i=0; i<APSNET_MAX_STRING; i++)
            {
                if (i < sValue.Length)
                {
                    cValue = sValue[i];
                    iChar = (int)cValue;
                }
                else
                {
                    iChar = 0;
                }

                if (iChar != 0)
                {
                    byte[] bValue = ascii.GetBytes(iChar.ToString("x4"));
                    bValue.CopyTo(mbBuffer, miIndex);
                    miIndex += 4;
                }
                else
                {
                    byte[] bValue = ascii.GetBytes("0000");
                    bValue.CopyTo(mbBuffer, miIndex);
                    miIndex += 4;
                }
            }
            byte[] bValue2 = ascii.GetBytes("\0");
            bValue2.CopyTo(mbBuffer, miIndex);
            miIndex += 1;
        }

        private void apsnet_recvprepstart()
        {
            miIndex = 0;
            for (int i = 0; i < APSNET_MAX_BUFFER; i++)
                mbBuffer[i] = 0;
        }

        private void apsnet_recvprepdbl()
        {
            miIndex = miIndex + APSNET_MAX_DOUBLE + 1;
        }

        private void apsnet_recvprepint()
        {
            miIndex = miIndex + APSNET_MAX_INT + 1;
        }

        private void apsnet_recvprepstr()
        {
            miIndex = miIndex + APSNET_MAX_STRING*4 + 1;
        }

        private void apsnet_recvstart()
        {
            miIndex = 0;
        }

        private void apsnet_recvdbl(out double dValue)
        {
            char[] cValue = ascii.GetChars(mbBuffer, miIndex, APSNET_MAX_DOUBLE);
            for (int i = 0; i < cValue.Length; i++)
                if (cValue[i] == '\0')
                    cValue[i] = ' ';
            string sValue = new string(cValue);
            dValue = double.Parse(sValue, CultureInfo.InvariantCulture);
            miIndex = miIndex + APSNET_MAX_DOUBLE + 1;
        }

        private void apsnet_recvint(out int iValue)
        {
            char[] cValue = ascii.GetChars(mbBuffer, miIndex, APSNET_MAX_INT);
            string sValue = new string(cValue);
            iValue = int.Parse(sValue, CultureInfo.InvariantCulture);
            miIndex = miIndex + APSNET_MAX_INT + 1;
        }

        private void apsnet_recvstr(out string sValue)
        {
            int i;
            int iChar;

            char[] cValue = ascii.GetChars(mbBuffer, miIndex, APSNET_MAX_STRING*4);
            string s = new string(cValue);

            sValue = "";

            for (i=0; i<APSNET_MAX_STRING; i++)
            {
                string s2 = s.Substring(i * 4, 4);
                iChar = int.Parse(s2, System.Globalization.NumberStyles.HexNumber);
                sValue += Convert.ToChar(iChar);
            }
            miIndex = miIndex + APSNET_MAX_STRING*4 + 1;

            for (i=sValue.Length-1; i>=0; i--)
            {
                if (sValue[i] != '\0')
                    break;
            }
            if (i > 0)
            {
                sValue = sValue.Substring(0, i + 1);
            }
            else
            {
                sValue = "";
            }
        }

        /*------------------------------------------------------------------------*/
        /*  OVERVIEW: Receive a message across a network socket                   */
        /*  OUTPUTS:   0=ok                                                       */
        /*            -1=length is greater than max allowed by network            */
        /*            ??=socket error code                                        */
        /*------------------------------------------------------------------------*/
        [SecurityCritical]
        private int apsnet_recv(Socket sock)
        {
            int idx, ret;

            if (miIndex > APSNET_MAX_BUFFER+1)
            {
                return (-1);
            }

            idx = 0;
            while (idx < miIndex)
            {
                try
                {
                    ret = sock.Receive(mbBuffer, idx, miIndex - idx, SocketFlags.None);
                }
                catch (SocketException ex)
                {
                    return (int)ex.SocketErrorCode;
                }
                idx = idx + ret;
            }

            return (0);
        }

        /*------------------------------------------------------------------------*/
        /*  OVERVIEW: Send a message across the network socket                    */
        /*  OUTPUTS:   0=ok                                                       */
        /*            -1=length is greater than max allowed by network.           */
        /*            ??=socket error code                                        */
        /*------------------------------------------------------------------------*/
        [SecurityCritical]
        private int apsnet_send(Socket sock)
        {
            int idx, ret;

            if (miIndex > APSNET_MAX_BUFFER+1)
            {
                return (-1);
            }

            idx = 0;
            while (idx < miIndex)
            {
                try
                {
                    ret = sock.Send(mbBuffer, idx, miIndex - idx, SocketFlags.None);
                }
                catch (SocketException ex)
                {
                    return (int) ex.SocketErrorCode;
                }
                idx = idx + ret;
            }

            return (0);
        }

        /*------------------------------------------------------------------------*/
        /*  OVERVIEW: Log a fatal error.                                          */
        /*  INPUTS:   mod  - module name                                          */
        /*            loc  - location or line number                              */
        /*            err  - error code                                           */
        /*            func - function causing error                               */
        /*            buf  - descriptive message                                  */
        /*------------------------------------------------------------------------*/
        [SecurityCritical]
        private void aps_logerr(string mod, int loc, int err, string func, string buf)
        {
            DateTime timenow = DateTime.Now;
            string sErrorFile;

            // sErrorFile = Environment.GetEnvironmentVariable(PDBPROJ) + "\\apserror.txt";
            sErrorFile = "C:\\ProgramData\\Infor\\CSI\\APS\\apserror.txt";

            try
            {
                StreamWriter sw = File.AppendText(sErrorFile);
                sw.WriteLine("-------------------------------------------------");
                sw.WriteLine("{0}: Error {1} from function {2}.", timenow.ToString("yyMMdd.HHmmss"), err, func);
                sw.WriteLine("Module: {0} Location: {1}.", mod, loc);
                if (buf.Length > 0)
                {
                    sw.WriteLine("Message: {0}", buf);
                }
                sw.Close();
            }
            catch
            {
                string sMsg = string.Format("file open error {0} on file apserror.txt", err);

                if (!System.Diagnostics.EventLog.SourceExists("APSServer"))
                    System.Diagnostics.EventLog.CreateEventSource(
                       "APSServer", "Application");

                System.Diagnostics.EventLog EventLog1 =
                   new System.Diagnostics.EventLog();
                EventLog1.Source = "APSServer";
                EventLog1.WriteEntry(sMsg);
            }
        }

        /*------------------------------------------------------------------------*/
        /*  OVERVIEW: Client call to get a connection.                            */
        /*  RETURNS:  APS_ERR_OK, APS_ERR_VERSION, APS_ERR_NETWORK, or            */
        /*            APS_ERR_NETWORKSETUP                                        */
        /*------------------------------------------------------------------------*/
        [SecurityCritical]
        private int get_connection(out apsmcon_s con, string sHost, out int return_code, out string return_message)
        {
            int ret, iPort;
            version_s version;

            con = new apsmcon_s();
            return_code = APS_ERR_OK;
            return_message = "";
            
            iPort = master_service_port;

            try
            {
                con.sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                con.sock.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.NoDelay, 1);
                IPHostEntry ipHostInfo = Dns.GetHostEntry(sHost);

                IPAddress ipAddress = null;
                if (ipHostInfo != null && ipHostInfo.AddressList != null)
                {
                    for (int i = 0; i < ipHostInfo.AddressList.Length; i++)
                    {
                        if (ipHostInfo.AddressList[i].AddressFamily == AddressFamily.InterNetworkV6)
                            continue;
                        ipAddress = ipHostInfo.AddressList[i];
                        break;
                    }
                }
                if (ipAddress == null)
                {
                    return_code = APS_ERR_HOSTADDR;
                    return_message = APS_ERM_HOSTADDR;
                    return (APS_ERR_HOSTADDR);
                }

                IPEndPoint ep = new IPEndPoint(ipAddress, iPort);
                con.sock.Connect(ep);
            }
            catch (SocketException e)
            {
                if (e.NativeErrorCode.Equals(10061))
                {
                    return_code = APS_ERR_CONNECT;
                    return_message = e.ToString();
                    return (APS_ERR_CONNECT);
                }
                else
                {
                    return_code = APS_ERR_NETWORKSETUP;
                    return_message = e.ToString();
                    return (APS_ERR_NETWORKSETUP);
                }
            }
            catch (Exception e)
            {
                return_code = APS_ERR_NETWORKSETUP;
                return_message = e.ToString();
                return (APS_ERR_NETWORKSETUP);
            }

            apsnet_sendstart();
            apsnet_sendint(APS_GET_CONNECTION);
            if ((ret = apsnet_send(con.sock)) != 0)
            {
                return_code = APS_ERR_NETWORK;
                return_message = APS_ERM_CLI_SENDREQCODE;
                return (APS_ERR_NETWORK);
            }

            get_version(con, out version, out return_code, out return_message);
            if (return_code != APS_ERR_OK)
            {
                return (return_code);
            }

            con.verclient.label = VERSION_LABEL;
            con.verclient.number = VERSION_NUMBER;

            con.verserver.label = version.label;
            con.verserver.number = version.number;

            if (con.verserver.number != con.verclient.number)
            {
                if ((ret = del_connection(con)) < 0)
                {
                    return_code = APS_ERR_NETWORK;
                    return_message = APS_ERM_NETWORK;
                    return (APS_ERR_NETWORK);
                }
                return_code = APS_ERR_VERSION;
                return_message = APS_ERM_VERSION;
                return (APS_ERR_VERSION);
            }

            return (APS_ERR_OK);
        }

        /*------------------------------------------------------------------------*/
        /*  OVERVIEW: Client call to delete a connection.                         */
        /*  RETURNS:  APS_ERR_OK or APS_ERR_NETWORK                               */
        /*------------------------------------------------------------------------*/
        [SecurityCritical]
        private int del_connection(apsmcon_s con)
        {
            int ret;
                
            apsnet_sendstart();
            apsnet_sendint(APS_DEL_CONNECTION);
            if ((ret = apsnet_send(con.sock)) != 0)
            {
                aps_logerr("del_connection", 1001, ret, "apsnet_send", "delete connection");
                return (APS_ERR_NETWORK);
            }

            /* Wait for return from Worker saying I got it, then close socket */
            
            apsnet_recvprepstart();
            apsnet_recvprepint();
            if ((ret = apsnet_recv(con.sock)) != 0)
            {
                aps_logerr("del_connection", 1002, ret, "apsnet_recv",
                           "Closing connection with worker.");
                return (APS_ERR_NETWORK);
            }

            con.sock.Close();
            return (APS_ERR_OK);
        }

        [SecurityCritical]
        private void get_version(apsmcon_s con, out version_s version, out int return_code, out string return_message)
        {
            int ret, apiret;

            version.label = "";
            version.number = 0;
            return_code = APS_ERR_OK;
            return_message = "";

            /*--------------------------------------------------------------------*/
            /* Send request code                                                  */
            /*--------------------------------------------------------------------*/
            
            apsnet_sendstart();
            apsnet_sendint(APS_GET_VERSION);
            if ((ret = apsnet_send(con.sock)) != 0)
            {
                return_code = APS_ERR_NETWORK;
                return_message = APS_ERM_CLI_SENDREQCODE;
                return;
            }

            /*--------------------------------------------------------------------*/
            /* Recv return code                                                   */
            /*--------------------------------------------------------------------*/
            
            apsnet_recvprepstart();
            apsnet_recvprepint();
            if ((ret = apsnet_recv(con.sock)) != 0)
            {
                return_code = APS_ERR_NETWORK;
                return_message = APS_ERM_CLI_RECVRETCODE;
                return;
            }
            apsnet_recvstart();
            apsnet_recvint(out apiret);

            /*--------------------------------------------------------------------*/
            /* Recv outputs                                                       */
            /*--------------------------------------------------------------------*/
            
            apsnet_recvprepstart();
            apsnet_recvprepstr();
            apsnet_recvprepint();
            if ((ret = apsnet_recv(con.sock)) != 0)
            {
                return_code = APS_ERR_NETWORK;
                return_message = APS_ERM_CLI_RECVOUTPUTS;
                return;
            }
            apsnet_recvstart();
            apsnet_recvstr(out version.label);
            apsnet_recvint(out version.number);
        }

        [SecuritySafeCritical]
        public void cGetAPSServerServiceStatus(ref GetAPSServerServiceStatus_s GetAPSServerServiceStatus)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            mGetAPSServerServiceStatus(ref GetAPSServerServiceStatus);

            PermissionSet.RevertAssert();
        }

        [SecurityCritical]
        private void mGetAPSServerServiceStatus(ref GetAPSServerServiceStatus_s GetAPSServerServiceStatus)
        {
            int ret;
            apsmcon_s con;
        
            if ((ret = get_connection(out con, GetAPSServerServiceStatus.server_service_host,
                                      out GetAPSServerServiceStatus.return_code,
                                      out GetAPSServerServiceStatus.return_message)) < 0)
            {
                return;
            }
        
            /*--------------------------------------------------------------------*/
            /* Send request code                                                  */
            /*--------------------------------------------------------------------*/
            
            apsnet_sendstart();
            apsnet_sendint(APS_GETAPSSERVERSERVICESTATUS);
            if ((ret = apsnet_send(con.sock)) != 0)
            {
                GetAPSServerServiceStatus.return_code = APS_ERR_NETWORK;
                GetAPSServerServiceStatus.return_message = APS_ERM_CLI_SENDREQCODE;
                ret = del_connection(con);
                return;
            }
        
            /*--------------------------------------------------------------------*/
            /* Send inputs                                                        */
            /*--------------------------------------------------------------------*/
            
            apsnet_sendstart();
            apsnet_sendstr(GetAPSServerServiceStatus.server_service_host);
            apsnet_sendint(GetAPSServerServiceStatus.server_service_port);
            if ((ret = apsnet_send(con.sock)) != 0)
            {
                GetAPSServerServiceStatus.return_code = APS_ERR_NETWORK;
                GetAPSServerServiceStatus.return_message = APS_ERM_CLI_SENDINPUTS;
                ret = del_connection(con);
                return;
            }
        
            /*--------------------------------------------------------------------*/
            /* Recv return code                                                   */
            /*--------------------------------------------------------------------*/
            
            apsnet_recvprepstart();
            apsnet_recvprepint();
            apsnet_recvprepint();
            apsnet_recvprepstr();
            if ((ret = apsnet_recv(con.sock)) != 0)
            {
                GetAPSServerServiceStatus.return_code = APS_ERR_NETWORK;
                GetAPSServerServiceStatus.return_message = APS_ERM_CLI_RECVRETCODE;
                ret = del_connection(con);
                return;
            }
            apsnet_recvstart();
            apsnet_recvint(out GetAPSServerServiceStatus.is_running);
            apsnet_recvint(out GetAPSServerServiceStatus.return_code);
            apsnet_recvstr(out GetAPSServerServiceStatus.return_message);
        
            ret = del_connection(con);
        }

        [SecuritySafeCritical]
        public void cStartAPSServerService(ref StartAPSServerService_s StartAPSServerService)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            mStartAPSServerService(ref StartAPSServerService);

            PermissionSet.RevertAssert();
        }

        [SecurityCritical]
        private void mStartAPSServerService(ref StartAPSServerService_s StartAPSServerService)
        {
            int ret;
            apsmcon_s con;

            if ((ret = get_connection(out con, StartAPSServerService.server_service_host,
                                      out StartAPSServerService.return_code,
                                      out StartAPSServerService.return_message)) < 0)
            {
                return;
            }
        
            /*--------------------------------------------------------------------*/
            /* Send request code                                                  */
            /*--------------------------------------------------------------------*/
            
            apsnet_sendstart();
            apsnet_sendint(APS_STARTAPSSERVERSERVICE);
            if ((ret = apsnet_send(con.sock)) != 0)
            {
                StartAPSServerService.return_code = APS_ERR_NETWORK;
                StartAPSServerService.return_message = APS_ERM_CLI_SENDREQCODE;
                ret = del_connection(con);
                return;
            }
        
            /*--------------------------------------------------------------------*/
            /* Send inputs                                                        */
            /*--------------------------------------------------------------------*/
            
            apsnet_sendstart();
            apsnet_sendstr(StartAPSServerService.server_service_host);
            apsnet_sendint(StartAPSServerService.server_service_port);
            apsnet_sendstr(StartAPSServerService.sql_host);
            apsnet_sendstr(StartAPSServerService.sql_database);
            apsnet_sendstr(StartAPSServerService.sql_user);
            apsnet_sendstr(StartAPSServerService.sql_pfield);
            apsnet_sendint(StartAPSServerService.sql_pfield_encrypted);
            apsnet_sendint(StartAPSServerService.sql_alwayson);
            apsnet_sendint(StartAPSServerService.alternative);
            apsnet_sendstr(StartAPSServerService.syteline_site);
            if ((ret = apsnet_send(con.sock)) != 0)
            {
                StartAPSServerService.return_code = APS_ERR_NETWORK;
                StartAPSServerService.return_message = APS_ERM_CLI_SENDINPUTS;
                ret = del_connection(con);
                return;
            }
        
            /*--------------------------------------------------------------------*/
            /* Recv return code                                                   */
            /*--------------------------------------------------------------------*/
            
            apsnet_recvprepstart();
            apsnet_recvprepint();
            apsnet_recvprepstr();
            if ((ret = apsnet_recv(con.sock)) != 0)
            {
                StartAPSServerService.return_code = APS_ERR_NETWORK;
                StartAPSServerService.return_message = APS_ERM_CLI_RECVRETCODE;
                ret = del_connection(con);
                return;
            }
            apsnet_recvstart();
            apsnet_recvint(out StartAPSServerService.return_code);
            apsnet_recvstr(out StartAPSServerService.return_message);
        
            ret = del_connection(con);
        }

        [SecuritySafeCritical]
        public void cStopAPSServerService(ref StopAPSServerService_s StopAPSServerService)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            mStopAPSServerService(ref StopAPSServerService);

            PermissionSet.RevertAssert();
        }

        [SecurityCritical]
        private void mStopAPSServerService(ref StopAPSServerService_s StopAPSServerService)
        {
            int ret;
            apsmcon_s con;

            if ((ret = get_connection(out con, StopAPSServerService.server_service_host,
                                      out StopAPSServerService.return_code,
                                      out StopAPSServerService.return_message)) < 0)
            {
                return;
            }
        
            /*--------------------------------------------------------------------*/
            /* Send request code                                                  */
            /*--------------------------------------------------------------------*/
            
            apsnet_sendstart();
            apsnet_sendint(APS_STOPAPSSERVERSERVICE);
            if ((ret = apsnet_send(con.sock)) != 0)
            {
                StopAPSServerService.return_code = APS_ERR_NETWORK;
                StopAPSServerService.return_message = APS_ERM_CLI_SENDREQCODE;
                ret = del_connection(con);
                return;
            }
        
            /*--------------------------------------------------------------------*/
            /* Send inputs                                                        */
            /*--------------------------------------------------------------------*/
            
            apsnet_sendstart();
            apsnet_sendstr(StopAPSServerService.server_service_host);
            apsnet_sendint(StopAPSServerService.server_service_port);
            if ((ret = apsnet_send(con.sock)) != 0)
            {
                StopAPSServerService.return_code = APS_ERR_NETWORK;
                StopAPSServerService.return_message = APS_ERM_CLI_SENDINPUTS;
                ret = del_connection(con);
                return;
            }
        
            /*--------------------------------------------------------------------*/
            /* Recv return code                                                   */
            /*--------------------------------------------------------------------*/
            
            apsnet_recvprepstart();
            apsnet_recvprepint();
            apsnet_recvprepstr();
            if ((ret = apsnet_recv(con.sock)) != 0)
            {
                StopAPSServerService.return_code = APS_ERR_NETWORK;
                StopAPSServerService.return_message = APS_ERM_CLI_RECVRETCODE;
                ret = del_connection(con);
                return;
            }
            apsnet_recvstart();
            apsnet_recvint(out StopAPSServerService.return_code);
            apsnet_recvstr(out StopAPSServerService.return_message);
        
            ret = del_connection(con);
        }

        [SecuritySafeCritical]
        public void cUploadErrorTraceFiles(ref UploadErrorTraceFiles_s UploadErrorTraceFiles)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            mUploadErrorTraceFiles(ref UploadErrorTraceFiles);

            PermissionSet.RevertAssert();
        }

        [SecurityCritical]
        private void mUploadErrorTraceFiles(ref UploadErrorTraceFiles_s UploadErrorTraceFiles)
        {
            int ret;
            apsmcon_s con;

            if ((ret = get_connection(out con, UploadErrorTraceFiles.server_service_host,
                                      out UploadErrorTraceFiles.return_code,
                                      out UploadErrorTraceFiles.return_message)) < 0)
            {
                return;
            }
        
            /*--------------------------------------------------------------------*/
            /* Send request code                                                  */
            /*--------------------------------------------------------------------*/
            
            apsnet_sendstart();
            apsnet_sendint(APS_UPLOADERRORTRACEFILES);
            if ((ret = apsnet_send(con.sock)) != 0)
            {
                UploadErrorTraceFiles.return_code = APS_ERR_NETWORK;
                UploadErrorTraceFiles.return_message = APS_ERM_CLI_SENDREQCODE;
                ret = del_connection(con);
                return;
            }
        
            /*--------------------------------------------------------------------*/
            /* Send inputs                                                        */
            /*--------------------------------------------------------------------*/
            
            apsnet_sendstart();
            apsnet_sendstr(UploadErrorTraceFiles.upload_url);
            apsnet_sendstr(UploadErrorTraceFiles.file_prefix);
            apsnet_sendint(UploadErrorTraceFiles.alternative);
            apsnet_sendstr(UploadErrorTraceFiles.server_service_host);
            apsnet_sendint(UploadErrorTraceFiles.server_service_port);
            if ((ret = apsnet_send(con.sock)) != 0)
            {
                UploadErrorTraceFiles.return_code = APS_ERR_NETWORK;
                UploadErrorTraceFiles.return_message = APS_ERM_CLI_SENDINPUTS;
                ret = del_connection(con);
                return;
            }
        
            /*--------------------------------------------------------------------*/
            /* Recv return code                                                   */
            /*--------------------------------------------------------------------*/
            
            apsnet_recvprepstart();
            apsnet_recvprepint();
            apsnet_recvprepstr();
            if ((ret = apsnet_recv(con.sock)) != 0)
            {
                UploadErrorTraceFiles.return_code = APS_ERR_NETWORK;
                UploadErrorTraceFiles.return_message = APS_ERM_CLI_RECVRETCODE;
                ret = del_connection(con);
                return;
            }
            apsnet_recvstart();
            apsnet_recvint(out UploadErrorTraceFiles.return_code);
            apsnet_recvstr(out UploadErrorTraceFiles.return_message);
        
            ret = del_connection(con);
        }
    }
}
