using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Globalization;
using System.Security;

[assembly: AllowPartiallyTrustedCallers]
namespace ERDB
{
    public class Server
    {
        private const string CODELABEL = "10.00.00 171211-1";
        private const int COMPNUMBER = 10;

        private const int COMPNUMBER900 = 900;
        private const int COMPNUMBER90030 = 903;
        private const int COMPNUMBER90100 = 90100;

        private const int MIN_COMPNUMBER = 10;
        private const int MAX_COMPNUMBER = 10;

        private const string PDBPROJ = "PDBPROJ10";
        
        /*---------------------------------------------------------------------------*/
        /* Command Codes.                                                            */
        /*---------------------------------------------------------------------------*/
        private const int COMMAND_INI_RESOURCE        = 16;
        private const int COMMAND_GET_RESOURCE        = 17;
        private const int COMMAND_NEW_TESTDB          = 338;
        private const int COMMAND_DEL_TESTDB          = 31;
        private const int COMMAND_INI_MISC            = 41;
        private const int COMMAND_GET_MISC            = 42;
        private const int COMMAND_EDT_MISC            = 43;
        private const int COMMAND_INI_MISCOUT         = 134;
        private const int COMMAND_GET_MISCOUT         = 135;
        private const int COMMAND_INI_CATEGORY        = 44;
        private const int COMMAND_GET_CATEGORY        = 45;
        private const int COMMAND_INI_OPERATION       = 58;
        private const int COMMAND_GET_OPERATION       = 59;
        private const int COMMAND_INI_OPR22CAT        = 68;
        private const int COMMAND_GET_OPR22CAT        = 69;
        private const int COMMAND_GET_LOGFILE         = 72;
        private const int COMMAND_INI_PART            = 140;
        private const int COMMAND_GET_PART            = 141;
        private const int COMMAND_INI_BOM22PRT        = 185;
        private const int COMMAND_GET_BOM22PRT        = 186;
        private const int COMMAND_INI_ORDER           = 199;
        private const int COMMAND_GET_ORDER           = 200;
        private const int COMMAND_ADD_ORDER           = 201;
        private const int COMMAND_EDT_ORDER           = 202;
        private const int COMMAND_DEL_ORDER           = 203;
        private const int COMMAND_SCH_ORDER           = 204;
        private const int COMMAND_INI_ORDLINEITEM     = 211;
        private const int COMMAND_GET_ORDLINEITEM     = 212;
        private const int COMMAND_ADD_ORDLINEITEM     = 213;
        private const int COMMAND_DEL_ORDLINEITEM     = 215;
        private const int COMMAND_GET_VERSION         = 272;
        private const int COMMAND_INI_ORDWAITHRS      = 323;
        private const int COMMAND_GET_ORDWAITHRS      = 326;
        private const int COMMAND_SCH_ORDERCTP        = 329;
        private const int COMMAND_INI_ERRORMSG        = 348;
        private const int COMMAND_GET_ERRORMSG        = 349;
        private const int COMMAND_INI_INVPLAN         = 350;
        private const int COMMAND_GET_INVPLAN         = 351;
        private const int COMMAND_INI_OPERPLAN        = 352;
        private const int COMMAND_GET_OPERPLAN        = 353;
        private const int COMMAND_INI_MATLPLAN        = 354;
        private const int COMMAND_GET_MATLPLAN        = 355;
        private const int COMMAND_INI_OPN22RES        = 358;
        private const int COMMAND_GET_OPN22RES        = 359;
        private const int COMMAND_INI_ORD22MPN        = 362;
        private const int COMMAND_GET_ORD22MPN        = 363;
        private const int COMMAND_INI_MPN22IPN        = 371;
        private const int COMMAND_GET_MPN22IPN        = 372;
        private const int COMMAND_INI_MPN22OPN        = 373;
        private const int COMMAND_GET_MPN22OPN        = 374;
        private const int COMMAND_INI_MESSAGE         = 380;
        private const int COMMAND_GET_MESSAGE         = 381;
        private const int COMMAND_INI_CONSPLAN        = 382;
        private const int COMMAND_GET_CONSPLAN        = 383;
        private const int COMMAND_INI_CPN22ORD        = 384;
        private const int COMMAND_GET_CPN22ORD        = 385;
        private const int COMMAND_INI_CAT22RES        = 54;
        private const int COMMAND_GET_CAT22RES        = 55;
        private const int COMMAND_INI_RES22SHF        = 26;
        private const int COMMAND_GET_RES22SHF        = 27;

        private const int COMMAND_GET_CONNECTION = 901;
        private const int COMMAND_DEL_CONNECTION = 999;

        /*------------------------------------------------------------------------*/
        /* General Error Return Codes and Messages.                               */
        /* NOTE: If you add an ERR_ code here, make sure that you add a corresp-  */
        /* onding ERM_ below and that the error logging routine is updated also!! */
        /*------------------------------------------------------------------------*/
        public const int ERR_OK                 = 1;
        public const int ERR_DNF                = -1;
        public const int ERR_PNF                = -2;
        public const int ERR_SORT               = -3;
        public const int ERR_IDX                = -4;
        public const int ERR_DUP                = -5;
        public const int ERR_OVERLAP            = -6;
        public const int ERR_PUSHONE            = -7;
        public const int ERR_PUSHMEM            = -8;
        public const int ERR_POPONE             = -9;
        public const int ERR_SAME               = -10;
        public const int ERR_FULL               = -12;
        public const int ERR_CFNF               = -13;
        public const int ERR_SFNF               = -14;
        public const int ERR_IDX2               = -15;
        public const int ERR_RTESCH             = -16;
        public const int ERR_PRTORD             = -17;
        public const int ERR_RECURSE            = -18;
        public const int ERR_NOLINEITEM         = -19;
        public const int ERR_LOGIC              = -20;
        public const int ERR_RESOURCE_OVERLAP   = -21;
        public const int ERR_APINOTINIT         = -22;
        public const int ERR_SHFTIME            = -23;
        public const int ERR_RTEINUSE           = -24;
        public const int ERR_PUSHMAX            = -25;
        public const int ERR_CONNECT_PDBPROJ    = -26;
        public const int ERR_CONNECT_CLOSEDB    = -29;
        public const int ERR_CONNECT_PDBDB      = -30;
        public const int ERR_CONNECT_OPENDB     = -31;
        public const int ERR_CONNECT_CORRUPT    = -32;
        public const int ERR_CONNECT_NOTEXIST   = -35;
        public const int ERR_PING               = -36;
        public const int ERR_MSITE              = -37;
        public const int ERR_MSITECFG           = -38;
        public const int ERR_TIMEOUT            = -39;
        public const int ERR_APSSTATUS_DOWNLOADING = -40;
        public const int ERR_APSSTATUS_INCRPLAN = -41;
        public const int ERR_APSSTATUS_FULLPLAN = -42;
        public const int ERR_APSSTATUS_GLBLPLAN = -43;
        public const int ERR_APSSRVAPI          = -44;
        public const int ERR_OPERCALC           = -45;
        public const int ERR_BCP                = -46;
        public const int ERR_KEY                = -100;
        public const int ERR_ITEM               = -101;
        public const int ERR_SQLCONNECT         = -200;
        public const int ERR_SQLQUERY           = -201;
        public const int ERR_FILEOPEN           = -202;
        public const int ERR_REPORT1            = -1001;
        public const int ERR_REPORT2            = -1002;
        public const int ERR_REPORTDETAIL1      = -1101;
        public const int ERR_REPORTDETAIL2      = -1102;
        public const int ERR_VERSION            = -10000;
        public const int ERR_DATABASE           = -1000000;
        public const int ERR_FILE               = -2000000;
        public const int ERR_NETW               = -3000000;
        public const int ERR_HEAP               = -4000000;
        public const int ERR_LIST               = -5000000;

        private const string ERM_DNF                 = "The key value specified does not exist.";
        private const string ERM_PNF                 = "The parent key value specified does not exist.";
        private const string ERM_SORT                = "Data not found in the key at that sort position.";
        private const string ERM_IDX                 = "Data not found in the list at that index position.";
        private const string ERM_DUP                 = "There already exists a key with that value.";
        private const string ERM_OVERLAP             = "Overlap on standard and overtime shifts is not allowed.";
        private const string ERM_PUSHONE             = "Only one test database is allowed at one time for a given user.";
        private const string ERM_PUSHMEM             = "There was insufficient memory on the server to get a test database.";
        private const string ERM_POPONE              = "Cannot delete a test database prior to obtaining a test database.";
        private const string ERM_SAME                = "The two values must be unique.";
        private const string ERM_FULL                = "Database field is full.";
        private const string ERM_CFNF                = "Local client file not found.";
        private const string ERM_SFNF                = "Remote server file not found.";
        private const string ERM_IDX2                = "Data not found in the second list at that index position.";
        private const string ERM_RTESCH              = "Route has scheduled work and cannot be deleted.";
        private const string ERM_PRTORD              = "Part has current orders and cannot be deleted.";
        private const string ERM_RECURSE             = "Circular BOM configurations are not allowed.";
        private const string ERM_NOLINEITEM          = "Cannot schedule an order with no lineitems.";
        private const string ERM_LOGIC               = "Internal logic error.";
        private const string ERM_RESOURCE_OVERLAP    = "Overlapping a resource on 2 or more standard/overtime shifts is not allowed.";
        private const string ERM_KEY                 = "The key value specified contains one or more illegal characters.";
        private const string ERM_ITEM                = "Invalid item (-101=first item, -102=second item, etc...)";
        private const string ERM_REPORT1             = "The first record (after comments or blank lines) must start with -r.";
        private const string ERM_REPORT2             = "The -r record must reference a valid report format (e.g. detail, work,...).";
        private const string ERM_REPORTDETAIL1       = "The Shift referenced in the detail report request was not found.";
        private const string ERM_REPORTDETAIL2       = "Detail reports must specify a valid primary key (e.g. Order, Part,...).";
        private const string ERM_DATABASE            = "Server side database error.  See ol_error.txt file on server for details.";
        private const string ERM_FILE                = "File error.  See ol_error.txt files on client and server for details.";
        private const string ERM_NETW                = "Network error.  See ol_error.txt files on client and server for details.";
        private const string ERM_APINOTINIT          = "API Structure is not initialized.";
        private const string ERM_SHFTIME             = "Shift has an invalid time or duration.";
        private const string ERM_RTEINUSE            = "This Route is in use by another Part.";
        private const string ERM_PUSHMAX             = "Maximum number of test databases exceeded.";
        private const string ERM_CONNECT_PDBPROJ     = "Unable to get PDBPROJnnn environment variable.";
        private const string ERM_CONNECT_CLOSEDB     = "Error occurred closing planner database.";
        private const string ERM_CONNECT_PDBDB       = "Unable to get PDBDB environment variable.";
        private const string ERM_CONNECT_OPENDB      = "Unable to open planner database.";
        private const string ERM_CONNECT_CORRUPT     = "Planner database is corrupt.";
        private const string ERM_CONNECT_NOTEXIST    = "Planner database does not exist.";
        private const string ERM_VERSION             = "The client and server versions are not compatible.";
        private const string ERM_HEAP                = "There is not enough heap memory available.";
        private const string ERM_LIST                = "List utility error.";
        private const string ERM_SQLCONNECT          = "Connection to SQL database failed.";
        private const string ERM_SQLQUERY            = "Query to SQL database failed.";
        private const string ERM_FILEOPEN            = "Specified file could not be opened.";
        private const string ERM_PING                = "Unable to ping one or more host in the global planning community.";
        private const string ERM_MSITE               = "Communication with the host has been disabled.";
        private const string ERM_MSITECFG            = "No site is defined as the local site.";
        private const string ERM_TIMEOUT             = "Requested action timed out.";
        private const string ERM_APSSRVAPI           = "APS Server api call failed.";
        private const string ERM_OPERCALC            = "Error loading opercalc DLL.";
        private const string ERM_BCP                 = "Check BCP log files for errors.";
        private const string ERM_NOTFOUND            = "No message.";

        private const string ERM_CLI_SENDREQCODE     = "Client error sending request code";
        private const string ERM_CLI_SENDINPUTS      = "Client error sending inputs";
        private const string ERM_CLI_RECVRETCODE     = "Client error receiving return code";
        private const string ERM_CLI_RECVOUTPUTS     = "Client error receiving ouputs";

        /*------------------------------------------------------------------------*/
        /* Field Maximum Sizes For Serialization.                                 */
        /*------------------------------------------------------------------------*/
        private const int MAX_OLXFSTR = 163;   /* string -> string                 */
        private const int MAX_OLXFSHO = 8;     /* short  -> string                 */
        private const int MAX_OLXFINT = 12;    /* int    -> string                 */
        private const int MAX_OLXFDBL = 22;    /* double -> string                 */
        private const int MAX_OLXNETMSG = 32768;  /* entire dbase entity -> string */

        private const int OL_END_LINE = -1;

        private byte[] olxnetmsg = new byte[MAX_OLXNETMSG+1];
        private ASCIIEncoding ascii = new ASCIIEncoding();

        /*------------------------------------------------------------------------*/
        /* Version Structure.                                                     */
        /*------------------------------------------------------------------------*/
        public class apsversion_s
        {
            public string codelabel;
            public int compnumber;
            public string prodtitle;
            public string prodversion;
        }

        /*------------------------------------------------------------------------*/
        /* Connection Structure.                                                  */
        /*------------------------------------------------------------------------*/
        public class rcon_s
        {
            public int local;                   /* set if host and port are dashes  */
            public Socket sock;                 /* local client socket              */
            public apsversion_s apsversion;     /* version struct                   */

            public rcon_s()
            {
                apsversion = new apsversion_s();
            }
        }

        /*------------------------------------------------------------------------*/
        /* Database Entity/Relation Structures and Value Definitions.             */
        /*------------------------------------------------------------------------*/
        public class resource_s
        {
            public int    resourcewidth;
            public int    depth;
            public int    inuse;
            public string resource;
            public int    sort;
            public int    resflags;
            public int    resattid_l;
            public int    respairvio_l;
            public int    ressendvio_l;
            public int    res22shf_l;
            public int    res22opn_l;
        }
        public const int VAL_RESFLAGS_SUPER = ((1 << 0));

        public class misc_s
        {
            public int      olxtitlewidth;
            public int      algsqldsnwidth;
            public int      algsqlaltnowidth;
            public int      algtimezonewidth;
            public int      algmfbshiftwidth;
            public int      algdefwhsewidth;
            public int      algsytelinesitewidth;
            public string   olxtitle;
            public int      alggranmins;
            public double   alghorizonsys;
            public double   alghorizonord;
            public int      algpushiters;
            public int      algpulliters;
            public int      algpullalliters;
            public double   alginfcapafter;
            public double   alginfmtlafter;
            public double   algbufscale;
            public int      algclearonfull;
            public int      algdebuglevel; 
            public int      algthirdpass; 
            public int      timenow;
            public int      algmsiteflags;
            public int      algssiteflags;
            public string   algsqldsn1; // double length
            public string   algsqldsn2; // double length
            public string   algsqldsn3; // double length
            public string   algsqlaltno;
            public int      algmaxnumwhatif;
            public int      algcurrnumwhatif;
            public int      algnxtodpnum;
            public int      algnxtschtag;
            public int      algnxtjobtag;
            public int      algnxtmessage;
            public int      algnxtwtdnum;
            public int      apsstatus;
            public int      algordstarttime;
            public double   algordoffset;
            public int      algsearchiters;
            public double   algprtsupplytol;
            public double   algprtfexptime;
            public double   algprtvexptime;
            public int      algiterdays;
            public int      algiterdaysctp;
            public string   algtimezone;
            public int      algsupplytime;
            public int      algdemandtime;
            public int      horizonoffset;
            public string   algmfbshift;
            public int      algfence30days;
            public int      algfence90days;
            public int      algconsmfg;
            public int      algconspurch;
            public int      algminworkhours;
            public int      algcplncategory;
            public string   algdefwhse;
            public string   algsytelinesite;
            public int      algpotolin;
            public int      algpotolout;
            public int      algjobtolin;
            public int      algjobtolout;
            public int      algssseqrule;
            public int      algtasknum;
        }
        public const int VAL_ALGDEBUGLEVEL_STARTUP   = ((1<<0));                 /* 1         */
        public const int VAL_ALGDEBUGLEVEL_WARNING   = ((1<<1));                 /* 2         */
        public const int VAL_ALGDEBUGLEVEL_ORDERID   = ((1<<2));                 /* 4         */
        public const int VAL_ALGDEBUGLEVEL_PUSHPULL  = ((1<<3));                 /* 8         */
        public const int VAL_ALGDEBUGLEVEL_USEWHAT   = ((1<<4));                 /* 16        */
        public const int VAL_ALGDEBUGLEVEL_OPNEEDED  = ((1<<5));                 /* 32        */
        public const int VAL_ALGDEBUGLEVEL_FINALRES  = ((1<<6));                 /* 64        */
        public const int VAL_ALGDEBUGLEVEL_ALLRES    = ((1<<7));                 /* 128       */
        public const int VAL_CHECKBOMRECURSION       = ((1<<8));                 /* 256       */
        public const int VAL_ALGDEBUGLEVEL_EVENTAT   = ((1<<9));                 /* 512       */
        public const int VAL_ALGDEBUGLEVEL_ORDCHANGE = ((1<<10));                /* 1024      */
        public const int VAL_ALGDEBUGLEVEL_PRTCHANGE = ((1<<11));                /* 2048      */
        public const int VAL_ALGDEBUGLEVEL_MODEL1    = ((1<<12));                /* 4096      */
        public const int VAL_ALGDEBUGLEVEL_MODEL2    = ((1<<13));                /* 8192      */
        public const int VAL_ALGDEBUGLEVEL_MODEL3    = ((1<<14));                /* 16384     */
        public const int VAL_ALGDEBUGLEVEL_SUPPLY    = ((1<<15));                /* 32768     */
        public const int VAL_ALGDEBUGLEVEL_TIMEFENCE = ((1<<16));                /* 65536     */
        public const int VAL_ALGDEBUGLEVEL_CRITPATH  = ((1<<17));                /* 131072    */

        public const int VAL_ALGSSITEFLAGS_WAITTIMES          = ((1 << 0));  //1
        public const int VAL_ALGSSITEFLAGS_PRTMAXALL          = ((1 << 1));  //2
        public const int VAL_ALGSSITEFLAGS_PURCHSUPSWITCH     = ((1 << 2));  //4
        public const int VAL_ALGSSITEFLAGS_MFGSUPSWITCH       = ((1 << 3));  //8
        public const int VAL_ALGSSITEFLAGS_ALTPARTUSELATEPULL = ((1 << 4));  //16
        public const int VAL_ALGSSITEFLAGS_EXPLEADTIME        = ((1 << 5));  //32
        public const int VAL_ALGSSITEFLAGS_SUPPLYTOL          = ((1 << 6));  //64
        public const int VAL_ALGSSITEFLAGS_POEXCEPTIONS       = ((1 << 7));  //128
        public const int VAL_ALGSSITEFLAGS_ALLOWFORECASTSUP   = ((1 << 8));  //256
        public const int VAL_ALGSSITEFLAGS_JITSCHEDULING      = ((1 << 9));  //512
        public const int VAL_ALGSSITEFLAGS_JOBSUPSWITCH       = ((1 << 10)); //1024
        public const int VAL_ALGSSITEFLAGS_SSRESERVEFORCTP    = ((1 << 11)); //2048
        public const int VAL_ALGSSITEFLAGS_TOPDOWNSUBJOBFIRM  = ((1 << 12)); //4096
        public const int VAL_ALGSSITEFLAGS_TOPDOWNSUBJOBREL   = ((1 << 13)); //8192
        public const int VAL_ALGSSITEFLAGS_ZEROOPR            = ((1 << 14)); //16384
        public const int VAL_ALGSSITEFLAGS_ISATPCTP           = ((1 << 15)); //32768 - set by IDO
        public const int VAL_ALGSSITEFLAGS_USEPLANOUTFORSCHED = ((1 << 16)); //65536
        public const int VAL_ALGSSITEFLAGS_MFGSS2             = ((1 << 17)); //131072
        public const int VAL_ALGSSITEFLAGS_MFGSSTIMENOW       = ((1 << 18)); //262144
        public const int VAL_ALGSSITEFLAGS_INCSUPINREADYCALC  = ((1 << 19)); //524288
        public const int VAL_ALGSSITEFLAGS_PLANSTOPPEDJOBS    = ((1 << 20)); //1,048,576
        public const int VAL_ALGSSITEFLAGS_PLANSTOPPEDCOS     = ((1 << 21)); //2,097,152
        public const int VAL_ALGSSITEFLAGS_PLANPLANNEDCOLINES = ((1 << 22)); //4,194,304
        public const int VAL_ALGSSITEFLAGS_PLANCREDITHOLDCOS  = ((1 << 23)); //8,388,608
        public const int VAL_ALGSSITEFLAGS_JITSCHEDRELSCHED   = ((1 << 24)); //16,777,216
        public const int VAL_ALGSSITEFLAGS_DAYSSUPPLYCONS     = ((1 << 25)); //33,554,431
        public const int VAL_ALGSSITEFLAGS_PLANWHSES          = ((1 << 26)); //67,108,864
        public const int VAL_ALGSSITEFLAGS_USEPREVSAFETYSTOCK = ((1 << 27)); //134,217,728
        public const int VAL_ALGSSITEFLAGS_SSBEFOREFORECASTS  = ((1 << 28)); //268,435,456
        
        public const int VAL_APSSTATUS_AVAILABLE     = 0;
        public const int VAL_APSSTATUS_DOWNLOADING   = 1;
        public const int VAL_APSSTATUS_INCRPLAN      = 2;
        public const int VAL_APSSTATUS_FULLPLAN      = 3;
        public const int VAL_APSSTATUS_GLBLPLAN      = 4;

        public const int VAL_ALGCONS_NONE         = 0;
        public const int VAL_ALGCONS_ONEDAY       = 1;
        public const int VAL_ALGCONS_DAYSSUPPLY   = 2;

        public const int VAL_ALGSSSEQRULE_ALPHABETICAL     = 0;
        public const int VAL_ALGSSSEQRULE_EARLIEST_TF      = 1;
        public const int VAL_ALGSSSEQRULE_LATEST_TF        = 2;
        public const int VAL_ALGSSSEQRULE_GREATEST_PERCENT = 3;
        public const int VAL_ALGSSSEQRULE_LEAST_PERCENT    = 4;

        public class miscout_s
        {
            public int algfullbeg;
            public int algfullbegreal;
            public int algfullend;
            public int algfullendreal;
            public int algincrbeg;
            public int algincrbegreal;
            public int algincrend;
            public int algincrendreal;
            public int algglblbeg;
            public int algglblbegreal;
            public int algglblend;
            public int algglblendreal;
        }

        public class message_s
        {
            public int    orderwidth;
            public int    partwidth;
            public int    parmwidth;
            public int    depth;
            public int    inuse;
            public int    messageidx;
            public int    message;
            public int    msgid;
            public int    msgtype;
            public string order;
            public string part;
            public string parm1;
            public string parm2;
            public string parm3;
            public string parm4;
        }
        public const int VAL_MSGTYPE_WARNING = 1;
        public const int VAL_MSGTYPE_ERROR   = 2;
        public const int VAL_MSGTYPE_BLOCKED = 3;

        public class category_s
        {
            public int    categorywidth;
            public int    depth;
            public int    inuse;
            public string category;
            public int    sort;
            public int    catflags;
            public double catbufpre;
            public double catbufpost;
            public double catinfcapafter;
            public int    catattid_l;
            public int    cat22res_l;
        }
        public const int VAL_CATFLAGS_USEQTIMEWHNINFINITE = ((1<<0));

        public class cat22res_s
        {
            public int    categorywidth;
            public int    resourcewidth;
            public int    depth;
            public int    inuse;
            public string category;
            public int    cat22residx;
            public string resource;
        }

        public class operation_s
        {
            public int    operationwidth;
            public int    oprworkcenterwidth;
            public int    oprsplitcatwidth;
            public int    depth;
            public int    inuse;
            public string operation;
            public int    sort;
            public int    oprflags;
            public double oprbufpre;
            public double oprsetup;
            public double oprcycle;
            public double oprbufpost;
            public double oprhorizon;
            public int    oprcrossbreaks;
            public double oprqueuetime;
            public double oprovlvalue;
            public int    oprovltype;
            public int    oprsplitrule;
            public string oprsplitcat;
            public double oprsplitsize;
            public int    opreffdate;
            public int    oprobsdate;
            public string oprworkcenter;
            public int    oprattid_l;
            public int    opr22oprg_l;
            public int    opr22cat_l;
        }
        public const int VAL_OPRFLAGS_QTYONE         = ((1<<0)); //1
        public const int VAL_OPRFLAGS_USERCALC       = ((1<<1)); //2
        
        public const int VAL_OPRCROSSBREAKS_SHIFT    = 0;
        public const int VAL_OPRCROSSBREAKS_SHIFTJOB = 1;
        public const int VAL_OPRCROSSBREAKS_NONE     = 2;

        public const int VAL_OPROVLTYPE_NONE         = 0;
        public const int VAL_OPROVLTYPE_NUMPARTS     = 1;
        public const int VAL_OPROVLTYPE_PCTSETCYC    = 2;
        public const int VAL_OPROVLTYPE_PCTCYC       = 3;
        public const int VAL_OPROVLTYPE_HRSSETCYC    = 4;
        public const int VAL_OPROVLTYPE_HRSCYC       = 5;
        public const int VAL_OPROVLTYPE_PARNOMERGE   = 6;
        public const int VAL_OPROVLTYPE_PARMERGE     = 7;
        public const int MIN_OPRSPLITRULE            = 0;
        public const int MAX_OPRSPLITRULE            = 4;
        public const int VAL_OPRSPLITRULE_NONE       = 0;
        public const int VAL_OPRSPLITRULE_SIZE       = 1;
        public const int VAL_OPRSPLITRULE_LOADS      = 2;
        public const int VAL_OPRSPLITRULE_GROUP      = 3;
        public const int VAL_OPRSPLITRULE_ALLGROUP   = 4;
        public const int DEF_OPRSPLITRULE            = 0;

        public class opr22cat_s
        {
            public int    operationwidth;
            public int    categorywidth;
            public int    depth;
            public int    inuse;
            public string operation;
            public int    opr22catidx;
            public string category;
        }

        public class part_s
        {
            public int      partwidth;
            public int      prtacqshiftwidth;
            public int      depth;
            public int      inuse;
            public string   part;
            public int      sort;
            public int      prtflags;
            public int      prtcategory;
            public int      prtlowlevel;
            public int      prtprecision;
            public double   prtminimum;
            public double   prtmultiple;
            public double   prtmax;
            public double   prtsupplytol;
            public double   prtfleadtime;
            public double   prtvleadtime;
            public double   prtexpfleadtime;
            public double   prtexpvleadtime;
            public double   prthorizon;
            public double   prtlosspercent;
            public double   prtlossquantity;
            public double   prtsafetystock;
            public double   prtinitinventory;
            public double   prtcurrinventory;
            public double   prtinventoryscr;     /* scrapped inventory for scr_part     */
            public string   prtacqshift;
            public int      prttfrule;
            public double   prttfvalue;
            public double   prtmoveinlimit;
            public double   prtmoveoutlimit;
            public int      prtepodate;
            public int      prtssdate;
            public int      prtdayssupply;
            public int      prtpotolin;
            public int      prtpotolout;
            public int      prtjobtolin;
            public int      prtjobtolout;
            public int      prtpurule;
            public double   prtpuvalue;
            public double   prtinheritedss;
            public int      prtattid_l;
            public int      prt22rte_l;
            public int      prt22bom_l;
            public int      prt22mpn_l;
            public int      prt22prtg_l;
            public int      prtaltpart_l;
            public int      prt22whs_l;
        }
        public const int VAL_PRTFLAGS_PURCHASED      = ((1<<0));  //1
        public const int VAL_PRTFLAGS_SKIPMFG        = ((1<<1));  //2
        public const int VAL_PRTFLAGS_SKIPPUR        = ((1<<2));  //4
        public const int VAL_PRTFLAGS_SKIPBLOTHRU    = ((1<<3));  //8
        public const int VAL_PRTFLAGS_SKIPPHANTOM    = ((1<<4));  //16
        public const int VAL_PRTFLAGS_UNCONSTRAIN    = ((1<<5));  //32
        public const int VAL_PRTFLAGS_UNRESMFGPART   = ((1<<6));  //64
        public const int VAL_PRTFLAGS_MRPPART        = ((1<<7));  //128
        public const int VAL_PRTFLAGS_SUPPLYTOL      = ((1<<8));  //256
        public const int VAL_PRTFLAGS_EXPLEADTIME    = ((1<<9));  //512
        public const int VAL_PRTFLAGS_SUPSWITCH      = ((1<<10)); //1024
        public const int VAL_PRTFLAGS_REORDERPOINT   = ((1<<11)); //2048
        public const int VAL_PRTFLAGS_FORECASTSUP    = ((1<<12)); //4096
        public const int VAL_PRTFLAGS_TRANSFER       = ((1<<13)); //8192
        public const int VAL_PRTFLAGS_CONSTRAINTOPO  = ((1<<14)); //16384
        public const int VAL_PRTFLAGS_CHARGE         = ((1<<15)); //32768
        public const int VAL_PRTFLAGS_ALTPART        = ((1<<30)); // Only used by SL integration

        public const int VAL_PRTTFRULE_NONE                = 0;
        public const int VAL_PRTTFRULE_LEADTIME            = 1;
        public const int VAL_PRTTFRULE_ACCUMULATED_LT      = 2;
        public const int VAL_PRTTFRULE_VALUE               = 3;
        public const int VAL_PRTTFRULE_PROT_LEADTIME       = 4;
        public const int VAL_PRTTFRULE_PROT_ACCUMULATED_LT = 5;
        public const int VAL_PRTTFRULE_PROT_VALUE          = 6;

        public const int VAL_PRTPURULE_NONE      = 0;
        public const int VAL_PRTPURULE_TIMENOW   = 1;
        public const int VAL_PRTPURULE_TIMEFENCE = 2;
        public const int VAL_PRTPURULE_VALUE     = 3;

        public class bom22prt_s
        {
            public int      bomwidth;
            public int      partwidth;
            public int      reforderwidth;
            public int      depth;
            public int      inuse;
            public string   bom;
            public int      bom22prtidx;
            public string   part;
            public double   bomprtqty;
            public double   bomprtlosspct;
            public double   bomprtlossqty;
            public int      bomprtmergefrom;
            public int      bomprtmergeto;
            public int      bomprtflags;
            public int      bomprtaltid;
            public int      bomprtseqno;
            public string   bomprtreforder;
            public int      bomprteffdate;
            public int      bomprtobsdate;
        }
        public const int VAL_BOMPRTFLAGS_PERLOTQ = ((1<<0));

        public class order_s
        {
            public int    orderwidth;
            public int    ordreforderwidth;
            public int    ordcustidwidth;
            public int    whsewidth;
            public int    depth;
            public int    inuse;
            public string order;
            public int    sort;
            public int    ordflags;
            public int    ordflags2;
            public int    ordcategory;
            public int    ordtype;
            public int    ordarivdate;
            public int    ordrequdate;
            public int    ordpromdate;
            public int    ordcalcdate;
            public string ordreforder;
            public int    ordstrtdate;
            public string ordcustid;
            public string whse;
            public int    ordattid_l;
            public int    ordlineitem_l;
            public int    ord22ordg_l;
            public int    ord22prtpur_l;
            public int    ord22mpn_l;
        }
        public const int VAL_ORDFLAGS_SUPPLY         = ((1<<0));  //1
        public const int VAL_ORDFLAGS_SKIPMFG        = ((1<<1));  //2
        public const int VAL_ORDFLAGS_SKIPPUR        = ((1<<2));  //4
        public const int VAL_ORDFLAGS_SCHEDULED      = ((1<<3));  //8   /* set by planner */
        public const int VAL_ORDFLAGS_SHIPPABLE      = ((1<<4));  //16  /* set by planner */
        public const int VAL_ORDFLAGS_BLOCKED        = ((1<<5));  //32  /* set by planner */
        public const int VAL_ORDFLAGS_NOFIN          = ((1<<6));  //64
        public const int VAL_ORDFLAGS_NOSUP          = ((1<<7));  //128
        public const int VAL_ORDFLAGS_REPLENISH      = ((1<<8));  //256
        public const int VAL_ORDFLAGS_NOSCRAP        = ((1<<9));  //512
        public const int VAL_ORDFLAGS_NOLOTSIZE      = ((1<<10)); //1024
        public const int VAL_ORDFLAGS_PULLUP         = ((1<<11)); //2048
        public const int VAL_ORDFLAGS_FROZEN         = ((1<<12)); //4096
        public const int VAL_ORDFLAGS_XFRDEMAND      = ((1<<13)); //8192
        public const int VAL_ORDFLAGS_XFRSUPPLY      = ((1<<14)); //16384
        public const int VAL_ORDFLAGS_REWORKJOB      = ((1<<15)); //32768
        public const int VAL_ORDFLAGS_RESERVEFORCTP  = ((1<<16)); //65536
        public const int VAL_ORDFLAGS_CTPQTYZERO     = ((1<<17)); //131072
        public const int VAL_ORDFLAGS_STOPAFTERPUSH  = ((1<<18)); //262144
        public const int VAL_ORDFLAGS_XREF           = ((1<<19)); //524288
        public const int VAL_ORDFLAGS_FIXEDSUPPLY    = ((1<<20)); //1048576
        public const int VAL_ORDFLAGS_FIXEDDEMANDS   = ((1<<21)); //2097152
        public const int VAL_ORDFLAGS_NOENDITEM      = ((1<<22)); //4194304
        public const int VAL_ORDFLAGS_BATCHPLAN      = ((1<<23)); //8388608
        public const int VAL_ORDFLAGS_COPRODUCT      = ((1<<24)); //16777216
        public const int VAL_ORDFLAGS_NOCTPDUEDATE   = ((1<<25)); //33554432 - Only used for SL integration
        public const int VAL_ORDFLAGS_STATUSSTOPPED  = ((1<<26)); //67,108,864
        public const int VAL_ORDFLAGS_STATUSPLANNED  = ((1<<27)); //134,217,728
        public const int VAL_ORDFLAGS_STATUSCREDITHOLD = ((1<<28)); //268,435,456
        public const int VAL_ORDFLAGS_WHSXFR           = ((1<<29)); //536,870,912
        public const int VAL_ORDFLAGS_JOBWITHPARTIALS  = ((1<<30)); //1,073,741,824 (scheduler use only)

        public const int VAL_ORDFLAGS2_CPLNXREF = ((1 << 5)); //32 (internal)

        public const int VAL_ORDCATEGORY_RELJOB        = -40;
        public const int VAL_ORDCATEGORY_FIXEDSUPPLIES = -30;
        public const int VAL_ORDCATEGORY_FIRMJOB       = -20;
        public const int VAL_ORDCATEGORY_FIXEDDEMANDS  = -10;
        public const int VAL_ORDCATEGORY_SUPPLY        = -30;
        public const int VAL_ORDCATEGORY_DYNAMICSSD    = -2;

        public const int DEF_ORDTYPE                        = 0;
        public const int VAL_ORDTYPE_UNKNOWN                = 0;
        public const int VAL_ORDTYPE_PLN                    = 10;
        public const int VAL_ORDTYPE_CPLN                   = 11;
        public const int VAL_ORDTYPE_PLN_INTRASITE          = 20;
        public const int VAL_ORDTYPE_PURCHASE_ORDER         = 50;
        public const int VAL_ORDTYPE_PURCHASE_REQUISITION   = 50;
        public const int VAL_ORDTYPE_TRANSFER_SUPPLY        = 50;
        public const int VAL_ORDTYPE_XFRSUPPLY              = 50;
        public const int VAL_ORDTYPE_RELEASED_SCHEDULED_JOB = 100;
        public const int VAL_ORDTYPE_CUSTOMER_ORDER         = 200;
        public const int VAL_ORDTYPE_PROJECT                = 200;
        public const int VAL_ORDTYPE_EDI_ORDER              = 210;
        public const int VAL_ORDTYPE_WEB_ORDER              = 220;
        public const int VAL_ORDTYPE_MPS                    = 230;
        public const int VAL_ORDTYPE_FIRM_JOB               = 240;
        public const int VAL_ORDTYPE_RELEASED_JOB           = 250;
        public const int VAL_ORDTYPE_SERVICE_ORDER          = 255;
        public const int VAL_ORDTYPE_PRODUCTION_SCHEDULE    = 260;
        public const int VAL_ORDTYPE_TRANSFER_DEMAND        = 270;
        public const int VAL_ORDTYPE_XFRDEMAND              = 270;
        public const int VAL_ORDTYPE_STOPPED_JOB            = 290;
        public const int VAL_ORDTYPE_FORECAST               = 300;
        public const int VAL_ORDTYPE_SAFETY_STOCK           = 310;
        public const int VAL_ORDTYPE_ESTIMATE_JOB           = 320;

        public const int VAL_ORD_NULL_DATE = 315730800; // 50 hours after 800101.000000 GMT

        public class ordlineitem_s
        {
            public int    orderwidth;
            public int    partwidth;
            public int    depth;
            public int    inuse;
            public string order;
            public int    ordlineitemidx;
            public string part;
            public double ordlinquantity;
            public int    ordlinpromdate;
            public int    ordlincalcdate;
        }

        public class errormsg_s
        {
            public int    msgwidth;
            public string msg1;
            public string msg2;
            public string msg3;
            public string msg4;
        }

        public class operplan_s
        {
            public int    operationwidth;
            public int    depth;
            public int    inuse;
            public int[]  operplan; //2
            public int    sort;
            public int    opnenddate;
            public int    opnflags;
            public double opnquantity;
            public int    opnstep;
            public int    opnsplit;
            public string operation;
            public int    matlplan;
            public int    opn22res_l;

            public operplan_s()
            {
                operplan = new int[2];
            }
        }
        public const int VAL_OPNFLAGS_START          = ((1<<0)); // 1
        public const int VAL_OPNFLAGS_END            = ((1<<1)); // 2
        public const int VAL_OPNFLAGS_FROZEN         = ((1<<2)); // 4

        public class opn22res_s
        {
            public int    resourcewidth;
            public int    depth;
            public int    inuse;
            public int[]  operplan; //2
            public int    opn22residx;
            public string resource;

            public opn22res_s()
            {
                operplan = new int[2];
            }
        }

        public class invplan_s
        {
            public int     operationwidth;
            public int     depth;
            public int     inuse;
            public int[]   invplan; //2
            public int     sort;
            public int     ipnstartdate;
            public int     ipnreldate;
            public int     ipntype;
            public int     ipnflags;
            public double  ipnorigqty;
            public double  ipnsupplyqty;
            public double  ipndemandqty;
            public double  ipnavailqty;
            public int     ipnstep;
            public string  operation;
            public int[]   ipn2supply; //2
            public int     matlplan;
            public int     ipn22ipnsup_l;

            public invplan_s()
            {
                invplan = new int[2];
                ipn2supply = new int[2];
            }
        }
        public const int VAL_IPNTYPE_USEFIN          = 1;
        public const int VAL_IPNTYPE_USEWIP          = 2;
        public const int VAL_IPNTYPE_USESUP          = 3;
        public const int VAL_IPNTYPE_XFRSUPPLY       = 4;
        public const int VAL_IPNTYPE_SUPPLY          = 5;
        public const int VAL_IPNTYPE_MFG             = 6;
        public const int VAL_IPNTYPE_PURCHASE        = 7;
        public const int VAL_IPNTYPE_UNCONSTRAINED   = 8;
        public const int VAL_IPNTYPE_NOTUSED         = 9;  // not used
        public const int VAL_IPNTYPE_BYPRODUCT       = 10;
        public const int VAL_IPNTYPE_USEMFG          = 11;
        public const int VAL_IPNTYPE_FORCEFIN        = 12;
        public const int VAL_IPNTYPE_MRPPART         = 13;
        public const int VAL_IPNTYPE_FORECASTSUPPLY  = 14;
        public const int VAL_IPNTYPE_RESERVEDSUPPLY  = 15;
        public const int VAL_IPNTYPE_ROUTECOMPLETED  = 16; // not used for now

        public const int VAL_IPNFLAGS_NOTIMEFENCE    = ((1<<0)); // 1   modifies any
        public const int VAL_IPNFLAGS_FROZEN         = ((1<<1)); // 2   modifies MFG
        public const int VAL_IPNFLAGS_XFRPURCHASE    = ((1<<2)); // 4   modifies PURCHASE
        public const int VAL_IPNFLAGS_RESERVEFORCTP  = ((1<<3)); // 8   modifies FORECASTSUPPLY, RESERVEDSUPPLY,
                                                                 //              PURCHASE, MFG
        public const int VAL_IPNFLAGS_EXPEDITED      = ((1<<4)); // 16  modifies PURCHASE, MFG
        public const int VAL_IPNFLAGS_SUPTOLERANCE   = ((1<<5)); // 32  modifies USESUP
        public const int VAL_IPNFLAGS_XREF           = ((1<<6)); // 64  modifies SUPPLY, MFG, USESUP
        public const int VAL_IPNFLAGS_DELSWAP        = ((1<<7)); // 128 modifies any
        public const int VAL_IPNFLAGS_NOPUTBACK      = ((1<<8)); // 256 modifies PURCHASE, UNCONSTRAINED

        public const int VAL_IPNFLAGS_CANNOTBECRIT   = ((1<<9));  // 512  modifies USESUP, USEFIN, FORCEFIN, UNCONSTRAINED
        public const int VAL_IPNFLAGS_FORECASTSUP    = ((1<<10)); // 1024 modifies USEMFG
        public const int VAL_IPNFLAGS_HADRESFORCTP   = ((1<<11)); // 2048 used to trace RESERVEFORCTP flag for regressions
        public const int VAL_IPNFLAGS_CPLNXREF       = ((1<<12)); // 4096 modifies USESUP, MFG, PURCHASE, UNCONSTRAINED
        public const int VAL_IPNFLAGS_FORCEDPURCHASE = ((1<<13)); // 8192 modifies PURCHASE (internal for regressions)

        public const int VAL_IPNFLAGS_DRILLDOWNOK    = ((1<<30)); // Only used by SL integration

        public const int MPNLOADPASS_WIDTH = 1;

        public class matlplan_s
        {
            public int    routewidth;
            public int    bomwidth;
            public int    orderwidth;
            public int    partwidth;
            public int    whsewidth;
            public int    depth;
            public int    inuse;
            public int    matlplan;
            public int    sort;
            public int    mpnparenttag;
            public int    mpnneeddate;
            public int    mpnflags;
            public double mpnorigqty;
            public double mpnadjqty;
            public int    mpnload;
            public string mpnloadpass;
            public int    mpnloaditers;
            public string route;
            public int    mpnparentstep;
            public string bom;
            public int    mpnparentseqno;
            public string order;
            public string part;
            public string whse;
            public int    mpn22ipn_l;
            public int    mpn22opn_l;
        }
        public const int VAL_MPNFLAGS_CRITPATH       = ((1<<0)); // 1
        public const int VAL_MPNFLAGS_ALTPART        = ((1<<1)); // 2
        public const int VAL_MPNFLAGS_MSITERECURSE   = ((1<<2)); // 4
        public const int VAL_MPNFLAGS_DELSWAP        = ((1<<3)); // 8
        public const int VAL_MPNFLAGS_HASSUPPLY      = ((1<<4)); // 16 (internal)
        public const int VAL_MPNFLAGS_PUSHCRITPATH   = ((1<<5)); // 32
        public const int VAL_MPNFLAGS_COPRODUCT      = ((1<<6)); // 64 (internal)
        public const int VAL_MPNFLAGS_FUTURE         = ((1<<7)); // 128
        public const int VAL_MPNFLAGS_EXPECTED       = ((1<<8)); // 256
        public const int VAL_MPNFLAGS_CONSOLIDATED   = ((1<<9)); // 512

        public class mpn22ipn_s
        {
            public int   depth;
            public int   inuse;
            public int   matlplan;
            public int   mpn22ipnidx;
            public int[] invplan; //2

            public mpn22ipn_s()
            {
                invplan = new int[2];
            }
        }

        public class mpn22opn_s
        {
            public int   depth;
            public int   inuse;
            public int   matlplan;
            public int   mpn22opnidx;
            public int[] operplan; //2

            public mpn22opn_s()
            {
                operplan = new int[2];
            }
        }

        public class ord22mpn_s
        {
            public int    orderwidth;
            public int    depth;
            public int    inuse;
            public string order;
            public int    ord22mpnidx;
            public int    matlplan;
        }

        public class consplan_s
        {
            public int    depth;
            public int    inuse;
            public int    consplan;
            public int    sort;
            public int    cpn22ord_l;
        }

        public class cpn22ord_s
        {
            public int orderwidth;
            public int depth;
            public int inuse;
            public int consplan;
            public int cpn22ordidx;
            public string order;
            public double cpnordqty;
        }

        public class ordwaithrs_s
        {
            public int    orderwidth;
            public int    ordwaitpartwidth;
            public int    ordwaitoperwidth;
            public int    ordwaitmtlwidth;
            public int    ordwaitcatwidth;
            public int    depth;
            public int    inuse;
            public string order;
            public int    ordwaithrsidx;
            public double ordwaithrs;
            public int    ordwaitflags;
            public int    ordwaittag;
            public string ordwaitpart;
            public string ordwaitoper;
            public string ordwaitmtl;
            public string ordwaitcat;
        }
        public const int     ORDWAITFLAGS_CAT      = ((1<<0));
        public const int     ORDWAITFLAGS_MTL      = ((1<<1));
        public const int     ORDWAITFLAGS_PUSHCAT  = ((1<<2));

        public class res22shf_s
        {
            public int    resourcewidth;
            public int    shiftwidth;
            public int    depth;
            public int    inuse;
            public string resource;
            public int    res22shfidx;
            public string shift;
        }

        public class ctpdetail_s
        {
            public double qtyinv;
            public double qtysup;
            public double qtymfg;
        }

        /*------------------------------------------------------------------------*/

        [SecurityCritical]
        private int net_recv(Socket soc, int len)
        {
            int idx, ret;

            if (len > MAX_OLXNETMSG + 1)
            {
                return(-1);
            }

            // Get length of buffer contents
            idx = 0;
            while (idx < MAX_OLXFINT + 1)
            {
                try
                {
                    ret = soc.Receive(olxnetmsg, idx, MAX_OLXFINT + 1 - idx, SocketFlags.None);
                }
                catch (SocketException ex)
                {
                    return (int)ex.SocketErrorCode;
                }
                idx = idx + ret;
            }
            idx = 0;
            net_recvpostint(ref idx, out len);

            idx = 0;
            while (idx < len)
            {
                try
                {
                    ret = soc.Receive(olxnetmsg, idx, len - idx, SocketFlags.None);
                }
                catch (SocketException ex)
                {
                    return (int)ex.SocketErrorCode;
                }
                idx = idx + ret;
            }

            return(1);
        }

        private void net_recvpostdbl(ref int idx, out double dbl)
        {
            char[] cValue = ascii.GetChars(olxnetmsg, idx, MAX_OLXFDBL);
            for (int i = 0; i < cValue.Length; i++)
                if (cValue[i] == '\0')
                    cValue[i] = ' ';
            string sValue = new string(cValue);
            dbl = double.Parse(sValue, CultureInfo.InvariantCulture);
            idx = idx + MAX_OLXFDBL + 1;
        }

        private void net_recvpostint(ref int idx, out int ival)
        {
            char[] cValue = ascii.GetChars(olxnetmsg, idx, MAX_OLXFINT);
            string sValue = new string(cValue);
            ival = int.Parse(sValue, CultureInfo.InvariantCulture);
            idx = idx + MAX_OLXFINT + 1;
        }

        private void net_recvpoststr(ref int idx, out string str, int max_len)
        {
            int i, iChar, len;
            char[] cValue;
            string s;
            
            // Get string length
            net_recvpostint(ref idx, out len);

            // Get string
            str = "";
            cValue = ascii.GetChars(olxnetmsg, idx, 4 * len);
            s = new string(cValue);
            for (i = 0; i < len && i < max_len; i++)
            {
                string s2 = s.Substring(i * 4, 4);
                iChar = int.Parse(s2, System.Globalization.NumberStyles.HexNumber);
                str += Convert.ToChar(iChar);
            }
            idx = idx + 4*len + 1;
        }

        private void net_recvprepstart(out int idx)
        {
            idx = 0;
            for (int i = 0; i < MAX_OLXNETMSG; i++)
                olxnetmsg[i] = 0;
        }

        private void net_recvprepdbl(ref int idx)
        {
            idx = idx + MAX_OLXFDBL + 1;
        }

        private void net_recvprepint(ref int idx)
        {
            idx = idx + MAX_OLXFINT+1;
        }

        private void net_recvprepstr(ref int idx, int len)
        {
            idx = idx + MAX_OLXFINT + 1 + len * 4 + 1;
        }

        [SecurityCritical]
        private int net_send(Socket soc, int len)
        {
            int idx, ret;

            if (len > MAX_OLXNETMSG+1)
            {
                return(-1);
            }

            // Send length of buffer contents
            byte[] bValue = ascii.GetBytes(len.ToString("D12") + '\0');
            idx = 0;
            while (idx < MAX_OLXFINT + 1)
            {
                try
                {
                    ret = soc.Send(bValue, idx, MAX_OLXFINT + 1 - idx, SocketFlags.None);
                }
                catch (SocketException ex)
                {
                    return (int)ex.SocketErrorCode;
                }
                idx = idx + ret;
            }
            if (idx != MAX_OLXFINT + 1)
            {
                return(-3);
            }

            // Send buffer contents
            idx = 0;
            while (idx < len)
            {
                try
                {
                    ret = soc.Send(olxnetmsg, idx, len - idx, SocketFlags.None);
                }
                catch (SocketException ex)
                {
                    return (int)ex.SocketErrorCode;
                }
                idx = idx + ret;
            }
            if (idx != len)
            {
                return(-3);
            }
            return(1);
        }

        private void net_sendprepstart(out int idx)
        {
            idx = 0;
            for (int i = 0; i < MAX_OLXNETMSG; i++)
                olxnetmsg[i] = 0;
        }

        private void net_sendprepdbl(ref int idx, double dbl)
        {
            byte[] bValue = ascii.GetBytes(dbl.ToString("0.00000000000000e+000", CultureInfo.InvariantCulture) + '\0');
            bValue.CopyTo(olxnetmsg, idx);
            idx = idx + MAX_OLXFDBL + 1;
        }

        private void net_sendprepint(ref int idx, int ival)
        {
            byte[] bValue = ascii.GetBytes(ival.ToString("############", CultureInfo.InvariantCulture) + '\0');
            bValue.CopyTo(olxnetmsg, idx);
            idx = idx + MAX_OLXFINT + 1;
        }

        private void net_sendprepstr(ref int idx, string str, int len)
        {
            if (string.IsNullOrEmpty(str)) str = "";

            int i, iChar;
            char cValue;

            // Prepend length to string
            len = str.Length;
            net_sendprepint(ref idx, len);

            for (i = 0; i < len; i++)
            {
                if (i < str.Length)
                {
                    cValue = str[i];
                    iChar = (int)cValue;
                }
                else
                {
                    iChar = 0;
                }

                if (iChar != 0)
                {
                    byte[] bValue = ascii.GetBytes(iChar.ToString("x4"));
                    bValue.CopyTo(olxnetmsg, idx);
                    idx += 4;
                }
                else
                {
                    byte[] bValue = ascii.GetBytes("0000");
                    bValue.CopyTo(olxnetmsg, idx);
                    idx += 4;
                }
            }
            byte[] bValue2 = ascii.GetBytes("\0");
            bValue2.CopyTo(olxnetmsg, idx);
            idx += 1;
        }

        [SecuritySafeCritical]
        public int cget_apsversion(rcon_s con, ref apsversion_s apsversion)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mget_apsversion(con, ref apsversion);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mget_apsversion(rcon_s con, ref apsversion_s apsversion)
        {
            int idx;
            int ret;
            int apiret;

            apsversion.codelabel = "";
            apsversion.compnumber = 0;
            apsversion.prodtitle = "";
            apsversion.prodversion = "";

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx,COMMAND_GET_VERSION);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cget_apsversion",1000,ret,ERM_CLI_SENDREQCODE);
                return(ERR_NETW);
            }

            /*-----------------------------------------------------------------------*/
            /* Recv return code                                                      */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cget_apsversion",1001,ret,ERM_CLI_RECVRETCODE);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx,out apiret);

            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepstr(ref idx,MAX_OLXFSTR);
            net_recvprepint(ref idx);
            net_recvprepstr(ref idx,MAX_OLXFSTR);
            net_recvprepstr(ref idx,MAX_OLXFSTR);

            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cget_apsversion",1002,ret,ERM_CLI_RECVOUTPUTS);
                return(ERR_NETW);
            }
            idx = 0;

            net_recvpoststr(ref idx, out apsversion.codelabel,MAX_OLXFSTR);
            net_recvpostint(ref idx, out apsversion.compnumber);
            net_recvpoststr(ref idx, out apsversion.prodtitle,MAX_OLXFSTR);
            net_recvpoststr(ref idx, out apsversion.prodversion,MAX_OLXFSTR);

            return(apiret);
        }

        [SecuritySafeCritical]
        public int cget_logfile(rcon_s con, ref string logfile_text)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mget_logfile(con, ref logfile_text);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mget_logfile(rcon_s con, ref string logfile_text)
        {
            int idx;
            int ret;
            int apiret;
            int len;
            string buf;

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx, COMMAND_GET_LOGFILE);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cget_logfile", 1000, ret, ERM_CLI_SENDREQCODE);
                return(ERR_NETW);
            }

            /*-----------------------------------------------------------------------*/
            /* Recv return code                                                      */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock, idx)) < 0)
            {
                logclierr("cget_logfile", 1002, ret, ERM_CLI_RECVRETCODE);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out apiret);

            if (apiret != ERR_OK)
            {
                return(apiret);
            }

            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            logfile_text = string.Empty;
            while (true)
            {
                /*-------------------------------------------------------------------*/
                /* Recv len or eol                                                   */
                /*-------------------------------------------------------------------*/
                net_recvprepstart(out idx);
                net_recvprepint(ref idx);
                if ((ret = net_recv(con.sock, idx)) < 0)
                {
                    logclierr("cget_logfile", 1003, ret, ERM_CLI_RECVRETCODE);
                    return(ERR_NETW);
                }
                idx = 0;
                net_recvpostint(ref idx, out len);

                if (len == OL_END_LINE) 
                {
                    break;
                }

                /*-------------------------------------------------------------------*/
                /* Recv buf                                                          */
                /*-------------------------------------------------------------------*/
                net_recvprepstart(out idx);
                net_recvprepstr(ref idx, len);
                if ((ret = net_recv(con.sock, idx)) < 0)
                {
                    logclierr("cget_logfile", 1004, ret, ERM_CLI_RECVOUTPUTS);
                    return(ERR_NETW);
                }
                idx = 0;
                net_recvpoststr(ref idx, out buf, len);

                logfile_text = logfile_text + buf + Environment.NewLine;
            }
 
            return(apiret);
        }

        [SecuritySafeCritical]
        public int cini_res22shf(rcon_s con, ref res22shf_s res22shf)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mini_res22shf(con, ref res22shf);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mini_res22shf(rcon_s con, ref res22shf_s res22shf)
        {
            int idx;
            int ret;

            res22shf = new res22shf_s();

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx, COMMAND_INI_RES22SHF);
            if ((ret = net_send(con.sock, idx)) < 0)
            {
                logclierr("cini_res22shf", 1000, ret, ERM_CLI_SENDREQCODE);
                return (ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock, idx)) < 0)
            {
                logclierr("cini_res22shf", 1001, ret, ERM_CLI_RECVOUTPUTS);
                return (ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out res22shf.resourcewidth);
            net_recvpostint(ref idx, out res22shf.shiftwidth);
            net_recvpostint(ref idx, out res22shf.depth);
            net_recvpostint(ref idx, out res22shf.inuse);
            return (1);
        }

        [SecuritySafeCritical]
        public int cget_res22shf(rcon_s con, ref res22shf_s res22shf)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mget_res22shf(con, ref res22shf);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mget_res22shf(rcon_s con, ref res22shf_s res22shf)
        {
            int idx;
            int ret;
            int apiret;

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx, COMMAND_GET_RES22SHF);
            if ((ret = net_send(con.sock, idx)) < 0)
            {
                logclierr("cget_res22shf", 1002, ret, ERM_CLI_SENDREQCODE);
                return (ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Send inputs                                                           */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepstr(ref idx, res22shf.resource, res22shf.resourcewidth);
            net_sendprepint(ref idx, res22shf.res22shfidx);
            if ((ret = net_send(con.sock, idx)) < 0)
            {
                logclierr("cget_res22shf", 1003, ret, ERM_CLI_SENDINPUTS);
                return (ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Recv return code                                                      */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock, idx)) < 0)
            {
                logclierr("cget_res22shf", 1004, ret, ERM_CLI_RECVRETCODE);
                return (ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out apiret);

            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepstr(ref idx, res22shf.shiftwidth);
            if ((ret = net_recv(con.sock, idx)) < 0)
            {
                logclierr("cget_res22shf", 1005, ret, ERM_CLI_RECVOUTPUTS);
                return (ERR_NETW);
            }
            idx = 0;
            net_recvpoststr(ref idx, out res22shf.shift, res22shf.shiftwidth);
            return (apiret);
        }

        [SecuritySafeCritical]
        public int cini_bom22prt(rcon_s con, out bom22prt_s bom22prt)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mini_bom22prt(con, out bom22prt);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mini_bom22prt(rcon_s con, out bom22prt_s bom22prt)
        {
            int idx;
            int ret;

            bom22prt = new bom22prt_s();

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx,COMMAND_INI_BOM22PRT);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cini_bom22prt",1000,ret,ERM_CLI_SENDREQCODE);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx); // reforderwidth
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cini_bom22prt",1001,ret,ERM_CLI_RECVOUTPUTS);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out bom22prt.bomwidth);
            net_recvpostint(ref idx, out bom22prt.partwidth);
            net_recvpostint(ref idx, out bom22prt.reforderwidth);
            net_recvpostint(ref idx, out bom22prt.depth);
            net_recvpostint(ref idx, out bom22prt.inuse);
            return(1);
        }

        [SecuritySafeCritical]
        public int cget_bom22prt(rcon_s con, ref bom22prt_s bom22prt)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mget_bom22prt(con, ref bom22prt);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mget_bom22prt(rcon_s con, ref bom22prt_s bom22prt)
        {
            int idx;
            int ret;
            int apiret;

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx,COMMAND_GET_BOM22PRT);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cget_bom22prt",1002,ret,ERM_CLI_SENDREQCODE);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Send inputs                                                           */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepstr(ref idx,bom22prt.bom,bom22prt.bomwidth);
            net_sendprepint(ref idx,bom22prt.bom22prtidx);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cget_bom22prt",1003,ret,ERM_CLI_SENDINPUTS);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Recv return code                                                      */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cget_bom22prt",1004,ret,ERM_CLI_RECVRETCODE);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out apiret);

            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepstr(ref idx,bom22prt.partwidth);
            net_recvprepdbl(ref idx);
            net_recvprepdbl(ref idx);
            net_recvprepdbl(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx); // bomprtseqno
            net_recvprepstr(ref idx,bom22prt.reforderwidth); // bomprtreforder
            net_recvprepint(ref idx); // bomprteffdate
            net_recvprepint(ref idx); // bomprtobsdate
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cget_bom22prt",1005,ret,ERM_CLI_RECVOUTPUTS);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpoststr(ref idx, out bom22prt.part, bom22prt.partwidth);
            net_recvpostdbl(ref idx, out bom22prt.bomprtqty);
            net_recvpostdbl(ref idx, out bom22prt.bomprtlosspct);
            net_recvpostdbl(ref idx, out bom22prt.bomprtlossqty);
            net_recvpostint(ref idx, out bom22prt.bomprtmergefrom);
            net_recvpostint(ref idx, out bom22prt.bomprtmergeto);
            net_recvpostint(ref idx, out bom22prt.bomprtflags);
            net_recvpostint(ref idx, out bom22prt.bomprtaltid);
            net_recvpostint(ref idx, out bom22prt.bomprtseqno);
            net_recvpoststr(ref idx, out bom22prt.bomprtreforder, bom22prt.reforderwidth);
            net_recvpostint(ref idx, out bom22prt.bomprteffdate);
            net_recvpostint(ref idx, out bom22prt.bomprtobsdate);
            return(apiret);
        }

        [SecuritySafeCritical]
        public int cini_category(rcon_s con, out category_s category)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mini_category(con, out category);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mini_category(rcon_s con, out category_s category)
        {
            int idx;
            int ret;

            category = new category_s();

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx,COMMAND_INI_CATEGORY);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cini_category",1000,ret,ERM_CLI_SENDREQCODE);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cini_category",1001,ret,ERM_CLI_RECVOUTPUTS);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out category.categorywidth);
            net_recvpostint(ref idx, out category.depth);
            net_recvpostint(ref idx, out category.inuse);
            return(1);
        }

        [SecuritySafeCritical]
        public int cget_category(rcon_s con, ref category_s category)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mget_category(con, ref category);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mget_category(rcon_s con, ref category_s category)
        {
            int idx;
            int ret;
            int apiret;

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx,COMMAND_GET_CATEGORY);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cget_category",1002,ret,ERM_CLI_SENDREQCODE);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Send inputs                                                           */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepstr(ref idx,category.category,category.categorywidth);
            net_sendprepint(ref idx,category.sort);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cget_category",1003,ret,ERM_CLI_SENDINPUTS);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Recv return code                                                      */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cget_category",1004,ret,ERM_CLI_RECVRETCODE);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out apiret);

            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepstr(ref idx,category.categorywidth);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepdbl(ref idx);
            net_recvprepdbl(ref idx);
            net_recvprepdbl(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cget_category",1005,ret,ERM_CLI_RECVOUTPUTS);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpoststr(ref idx, out category.category, category.categorywidth);
            net_recvpostint(ref idx, out category.catflags);
            net_recvpostdbl(ref idx, out category.catbufpre);
            net_recvpostdbl(ref idx, out category.catbufpost);
            net_recvpostdbl(ref idx, out category.catinfcapafter);
            net_recvpostint(ref idx, out category.catattid_l);
            net_recvpostint(ref idx, out category.cat22res_l);
            return(apiret);
        }

        [SecuritySafeCritical]
        public int cget_connection(out rcon_s con, string sHost, int iPort)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mget_connection(out con, sHost, iPort);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mget_connection(out rcon_s con, string sHost, int iPort)
        {
            int idx;
            int ret;
            apsversion_s apsversion = new apsversion_s();

            con = new rcon_s();
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
                    logclierr("cget_connection", 1001, ret, "Address not found");
                    return(ERR_NETW);
                }

                IPEndPoint ep = new IPEndPoint(ipAddress, iPort);
                con.sock.Connect(ep);
            }
            catch (Exception ex)
            {
                ret = -1;
                logclierr("cget_connection",1003,ret,ex.Message);
                return(ERR_NETW);
            }

            net_sendprepstart(out idx);
            net_sendprepint(ref idx,COMMAND_GET_CONNECTION);
            if (net_send(con.sock,idx) < 0)
            {
                ret = -1;
                logclierr("cget_connection",1010,ret,"send get_connection...");
                return(ERR_NETW);
            }

            /*-----------------------------------------------------------------------*/
            /* Recv return code                                                      */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock, idx)) < 0)
            {
                logclierr("cget_connection", 1004, ret, "getting connect results...");
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out ret);

            if (ret != ERR_OK)
                return(ret);

            /* ------------------------------------------------------------------- */
            /*    VERSION HANDSHAKE                                                */
            /* ------------------------------------------------------------------- */

            idx = 0;
            if ((ret = cget_apsversion(con, ref apsversion)) < 0)
            {
                logclierr("cget_connection",1011,ret,"get_apsversion server version...");
                return(ret);
            }
            con.apsversion.codelabel = apsversion.codelabel;
            con.apsversion.compnumber = apsversion.compnumber;
            con.apsversion.prodtitle = apsversion.prodtitle;
            con.apsversion.prodversion = apsversion.prodversion;

            if (apsversion.compnumber < MIN_COMPNUMBER ||
                apsversion.compnumber > MAX_COMPNUMBER) 
            {
                if ( (ret = cdel_connection(con) ) < 0)
                {
                    logclierr("cget_connection", 1012, ret, "send del_connection...");
                    return(ERR_VERSION);
                }       
                return(ERR_VERSION);
            }

            return(1);
        }

        [SecuritySafeCritical]
        public int cdel_connection(rcon_s con)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mdel_connection(con);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mdel_connection(rcon_s con)
        {
            int ret;
            int idx;

            net_sendprepstart(out idx);
            net_sendprepint(ref idx,COMMAND_DEL_CONNECTION);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cdel_connection",1014,ret,"send del_connection...");
                return(ERR_NETW);
            }

        /* Wait for return from Worker saying I got it then close socket */
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock,idx)) >= 0)
            {
                con.sock.Close();
                return(1);
            }

            logclierr("cdel_connection",1015,ret,"Closing connection with worker...");
            return(-1);
        }

        public int cata_timenum(string time)
        {
            return(erdb2j(time));
        }

        public int cata_numerictime(int time, out string stime)
        {
            stime = j2erdb(time);
            return(time);
        }

        [SecuritySafeCritical]
        public int cini_errormsg(rcon_s con, out errormsg_s errormsg)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mini_errormsg(con, out errormsg);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mini_errormsg(rcon_s con, out errormsg_s errormsg)
        {
            int idx;
            int ret;

            errormsg = new errormsg_s();

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx,COMMAND_INI_ERRORMSG);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cini_errormsg",1000,ret,ERM_CLI_SENDREQCODE);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cini_errormsg",1001,ret,ERM_CLI_RECVOUTPUTS);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out errormsg.msgwidth);
            return(1);
        }

        [SecuritySafeCritical]
        public int cget_errormsg(rcon_s con, ref errormsg_s errormsg)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mget_errormsg(con, ref errormsg);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mget_errormsg(rcon_s con, ref errormsg_s errormsg)
        {
            int idx;
            int ret;
            int apiret;

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx,COMMAND_GET_ERRORMSG);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cget_errormsg",1002,ret,ERM_CLI_SENDREQCODE);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Recv return code                                                      */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cget_errormsg",1004,ret,ERM_CLI_RECVRETCODE);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out apiret);

            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepstr(ref idx,errormsg.msgwidth);
            net_recvprepstr(ref idx,errormsg.msgwidth);
            net_recvprepstr(ref idx,errormsg.msgwidth);
            net_recvprepstr(ref idx,errormsg.msgwidth);
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cget_errormsg",1005,ret,ERM_CLI_RECVOUTPUTS);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpoststr(ref idx, out errormsg.msg1, errormsg.msgwidth);
            net_recvpoststr(ref idx, out errormsg.msg2, errormsg.msgwidth);
            net_recvpoststr(ref idx, out errormsg.msg3, errormsg.msgwidth);
            net_recvpoststr(ref idx, out errormsg.msg4, errormsg.msgwidth);
            return(apiret);
        }

        [SecuritySafeCritical]
        public int cini_invplan(rcon_s con, out invplan_s invplan)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mini_invplan(con, out invplan);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mini_invplan(rcon_s con, out invplan_s invplan)
        {
            int idx;
            int ret;

            invplan = new invplan_s();

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx,COMMAND_INI_INVPLAN);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cini_invplan",1000,ret,ERM_CLI_SENDREQCODE);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cini_invplan",1001,ret,ERM_CLI_RECVOUTPUTS);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out invplan.operationwidth);
            net_recvpostint(ref idx, out invplan.depth);
            net_recvpostint(ref idx, out invplan.inuse);
            return(1);
        }

        [SecuritySafeCritical]
        public int cget_invplan(rcon_s con, ref invplan_s invplan)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mget_invplan(con, ref invplan);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mget_invplan(rcon_s con, ref invplan_s invplan)
        {
            int idx;
            int ret;
            int apiret;

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx,COMMAND_GET_INVPLAN);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cget_invplan",1002,ret,ERM_CLI_SENDREQCODE);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Send inputs                                                           */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx,invplan.invplan[0]);
            net_sendprepint(ref idx,invplan.invplan[1]);
            net_sendprepint(ref idx,invplan.sort);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cget_invplan",1003,ret,ERM_CLI_SENDINPUTS);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Recv return code                                                      */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cget_invplan",1004,ret,ERM_CLI_RECVRETCODE);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out apiret);

            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepdbl(ref idx);
            net_recvprepdbl(ref idx);
            net_recvprepdbl(ref idx);
            net_recvprepdbl(ref idx);
            net_recvprepint(ref idx);
            net_recvprepstr(ref idx,invplan.operationwidth);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);

            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cget_invplan",1005,ret,ERM_CLI_RECVOUTPUTS);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out invplan.invplan[0]);
            net_recvpostint(ref idx, out invplan.invplan[1]);
            net_recvpostint(ref idx, out invplan.ipnstartdate);
            net_recvpostint(ref idx, out invplan.ipnreldate);
            net_recvpostint(ref idx, out invplan.ipntype);
            net_recvpostint(ref idx, out invplan.ipnflags);
            net_recvpostdbl(ref idx, out invplan.ipnorigqty);
            net_recvpostdbl(ref idx, out invplan.ipnsupplyqty);
            net_recvpostdbl(ref idx, out invplan.ipndemandqty);
            net_recvpostdbl(ref idx, out invplan.ipnavailqty);
            net_recvpostint(ref idx, out invplan.ipnstep);
            net_recvpoststr(ref idx, out invplan.operation, invplan.operationwidth);
            net_recvpostint(ref idx, out invplan.ipn2supply[0]);
            net_recvpostint(ref idx, out invplan.ipn2supply[1]);
            net_recvpostint(ref idx, out invplan.matlplan);
            net_recvpostint(ref idx, out invplan.ipn22ipnsup_l);
            return(apiret);
        }

        [SecurityCritical]
        private void logclierr(string mod, int loc, int err, string buf)
        {
            DateTime timenow = DateTime.Now;
            string sErrorFile;

            // sErrorFile = Environment.GetEnvironmentVariable(PDBPROJ) + "\\ol_error.txt";
            sErrorFile = "C:\\ProgramData\\Infor\\CSI\\APS\\ol_error.txt";


            try
            {
                StreamWriter sw = File.AppendText(sErrorFile);
                sw.WriteLine("-------------------------------------------------------------------------");
                sw.WriteLine("{0}", timenow.ToString("yyMMdd.HHmmss"));
                sw.WriteLine("Error at location {0} from program {1}.", loc, mod);
                sw.WriteLine("Error return code {0} from function {1}.", err, buf);
                sw.WriteLine("{0}", get_error_text(err));
                sw.Close();
            }
            catch
            {
                string sMsg = string.Format("file open error {0} on file ol_error.txt", err);

                if (!System.Diagnostics.EventLog.SourceExists("ERDBServer"))
                    System.Diagnostics.EventLog.CreateEventSource(
                       "ERDBServer", "Application");

                System.Diagnostics.EventLog EventLog1 = new System.Diagnostics.EventLog();
                EventLog1.Source = "ERDBServer";
                EventLog1.WriteEntry(sMsg);
            }
        }

        public string get_error_text(int iError)
        {
            if (iError <= ERR_ITEM && iError > ERR_ITEM + 100)
            {
                return(ERM_ITEM);
            }

            switch (iError)
            {
                case ERR_OK:             return("");
                case ERR_DNF:            return(ERM_DNF);
                case ERR_PNF:            return(ERM_PNF);
                case ERR_SORT:           return(ERM_SORT);
                case ERR_IDX:            return(ERM_IDX);
                case ERR_DUP:            return(ERM_DUP);
                case ERR_OVERLAP:        return(ERM_OVERLAP);
                case ERR_PUSHONE:        return(ERM_PUSHONE);
                case ERR_PUSHMEM:        return(ERM_PUSHMEM);
                case ERR_POPONE:         return(ERM_POPONE);
                case ERR_SAME:           return(ERM_SAME);
                case ERR_FULL:           return(ERM_FULL);
                case ERR_CFNF:           return(ERM_CFNF);
                case ERR_SFNF:           return(ERM_SFNF);
                case ERR_IDX2:           return(ERM_IDX2);
                case ERR_RTESCH:         return(ERM_RTESCH);
                case ERR_PRTORD:         return(ERM_PRTORD);
                case ERR_RECURSE:        return(ERM_RECURSE);
                case ERR_NOLINEITEM:     return(ERM_NOLINEITEM);
                case ERR_LOGIC:          return(ERM_LOGIC);
                case ERR_RESOURCE_OVERLAP: return(ERM_RESOURCE_OVERLAP);
                case ERR_KEY:            return(ERM_KEY);
                case ERR_ITEM:           return(ERM_ITEM);
                case ERR_REPORT1:        return(ERM_REPORT1);
                case ERR_REPORT2:        return(ERM_REPORT1);
                case ERR_REPORTDETAIL1:  return(ERM_REPORTDETAIL1);
                case ERR_REPORTDETAIL2:  return(ERM_REPORTDETAIL2);
                case ERR_DATABASE:       return(ERM_DATABASE);
                case ERR_FILE:           return(ERM_FILE);
                case ERR_NETW:           return(ERM_NETW);
                case ERR_APINOTINIT:     return(ERM_APINOTINIT);
                case ERR_SHFTIME:        return(ERM_SHFTIME);
                case ERR_RTEINUSE:       return(ERM_RTEINUSE);
                case ERR_PUSHMAX:        return(ERM_PUSHMAX);
                case ERR_CONNECT_PDBPROJ:    return(ERM_CONNECT_PDBPROJ);
                case ERR_CONNECT_CLOSEDB:    return(ERM_CONNECT_CLOSEDB);
                case ERR_CONNECT_PDBDB:      return(ERM_CONNECT_PDBDB);
                case ERR_CONNECT_OPENDB:     return(ERM_CONNECT_OPENDB);
                case ERR_CONNECT_CORRUPT:    return(ERM_CONNECT_CORRUPT);
                case ERR_CONNECT_NOTEXIST:   return(ERM_CONNECT_NOTEXIST);
                case ERR_VERSION:        return(ERM_VERSION);
                case ERR_HEAP:           return(ERM_HEAP);
                case ERR_LIST:           return(ERM_LIST);
                case ERR_SQLCONNECT:     return(ERM_SQLCONNECT);
                case ERR_SQLQUERY:       return(ERM_SQLQUERY);
                case ERR_FILEOPEN:       return(ERM_FILEOPEN);
                case ERR_PING:           return(ERM_PING);
                case ERR_MSITE:          return(ERM_MSITE);
                case ERR_MSITECFG:       return(ERM_MSITECFG);
                case ERR_TIMEOUT:        return(ERM_TIMEOUT);
                case ERR_APSSRVAPI:      return(ERM_APSSRVAPI);
                case ERR_OPERCALC:       return(ERM_OPERCALC);
                case ERR_BCP:            return(ERM_BCP);
                default:                 return(ERM_NOTFOUND);
            }
        }

        [SecuritySafeCritical]
        public int cini_matlplan(rcon_s con, out matlplan_s matlplan)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mini_matlplan(con, out matlplan);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mini_matlplan(rcon_s con, out matlplan_s matlplan)
        {
            int idx;
            int ret;

            matlplan = new matlplan_s();

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx,COMMAND_INI_MATLPLAN);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cini_matlplan",1000,ret,ERM_CLI_SENDREQCODE);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cini_matlplan",1001,ret,ERM_CLI_RECVOUTPUTS);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out matlplan.routewidth);
            net_recvpostint(ref idx, out matlplan.bomwidth);
            net_recvpostint(ref idx, out matlplan.orderwidth);
            net_recvpostint(ref idx, out matlplan.partwidth);
            net_recvpostint(ref idx, out matlplan.whsewidth);
            net_recvpostint(ref idx, out matlplan.depth);
            net_recvpostint(ref idx, out matlplan.inuse);
            return(1);
        }

        [SecuritySafeCritical]
        public int cget_matlplan(rcon_s con, ref matlplan_s matlplan)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mget_matlplan(con, ref matlplan);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mget_matlplan(rcon_s con, ref matlplan_s matlplan)
        {
            int idx;
            int ret;
            int apiret;

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx,COMMAND_GET_MATLPLAN);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cget_matlplan",1002,ret,ERM_CLI_SENDREQCODE);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Send inputs                                                           */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx,matlplan.matlplan);
            net_sendprepint(ref idx,matlplan.sort);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cget_matlplan",1003,ret,ERM_CLI_SENDINPUTS);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Recv return code                                                      */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cget_matlplan",1004,ret,ERM_CLI_RECVRETCODE);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out apiret);

            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepdbl(ref idx);
            net_recvprepdbl(ref idx);
            net_recvprepint(ref idx);
            net_recvprepstr(ref idx,MPNLOADPASS_WIDTH);
            net_recvprepint(ref idx);
            net_recvprepstr(ref idx,matlplan.routewidth);
            net_recvprepint(ref idx);
            net_recvprepstr(ref idx,matlplan.bomwidth);
            net_recvprepint(ref idx);
            net_recvprepstr(ref idx,matlplan.orderwidth);
            net_recvprepstr(ref idx,matlplan.partwidth);
            net_recvprepstr(ref idx,matlplan.whsewidth);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);

            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cget_matlplan",1005,ret,ERM_CLI_RECVOUTPUTS);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out matlplan.matlplan);
            net_recvpostint(ref idx, out matlplan.mpnparenttag);
            net_recvpostint(ref idx, out matlplan.mpnneeddate);
            net_recvpostint(ref idx, out matlplan.mpnflags);
            net_recvpostdbl(ref idx, out matlplan.mpnorigqty);
            net_recvpostdbl(ref idx, out matlplan.mpnadjqty);
            net_recvpostint(ref idx, out matlplan.mpnload);
            net_recvpoststr(ref idx, out matlplan.mpnloadpass, MPNLOADPASS_WIDTH);
            net_recvpostint(ref idx, out matlplan.mpnloaditers);
            net_recvpoststr(ref idx, out matlplan.route, matlplan.routewidth);
            net_recvpostint(ref idx, out matlplan.mpnparentstep);
            net_recvpoststr(ref idx, out matlplan.bom, matlplan.bomwidth);
            net_recvpostint(ref idx, out matlplan.mpnparentseqno);
            net_recvpoststr(ref idx, out matlplan.order, matlplan.orderwidth);
            net_recvpoststr(ref idx, out matlplan.part, matlplan.partwidth);
            net_recvpoststr(ref idx, out matlplan.whse, matlplan.whsewidth);
            net_recvpostint(ref idx, out matlplan.mpn22ipn_l);
            net_recvpostint(ref idx, out matlplan.mpn22opn_l);
            return(apiret);
        }

        [SecuritySafeCritical]
        public int cini_consplan(rcon_s con, out consplan_s consplan)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mini_consplan(con, out consplan);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mini_consplan(rcon_s con, out consplan_s consplan)
        {
            int idx;
            int ret;

            consplan = new consplan_s();

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx, COMMAND_INI_CONSPLAN);
            if ((ret = net_send(con.sock, idx)) < 0)
            {
                logclierr("cini_consplan", 1000, ret, ERM_CLI_SENDREQCODE);
                return (ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock, idx)) < 0)
            {
                logclierr("cini_consplan", 1001, ret, ERM_CLI_RECVOUTPUTS);
                return (ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out consplan.depth);
            net_recvpostint(ref idx, out consplan.inuse);
            return (1);
        }

        [SecuritySafeCritical]
        public int cget_consplan(rcon_s con, ref consplan_s consplan)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mget_consplan(con, ref consplan);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mget_consplan(rcon_s con, ref consplan_s consplan)
        {
            int idx;
            int ret;
            int apiret;

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx, COMMAND_GET_CONSPLAN);
            if ((ret = net_send(con.sock, idx)) < 0)
            {
                logclierr("cget_consplan", 1002, ret, ERM_CLI_SENDREQCODE);
                return (ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Send inputs                                                           */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx, consplan.consplan);
            net_sendprepint(ref idx, consplan.sort);
            if ((ret = net_send(con.sock, idx)) < 0)
            {
                logclierr("cget_consplan", 1003, ret, ERM_CLI_SENDINPUTS);
                return (ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Recv return code                                                      */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock, idx)) < 0)
            {
                logclierr("cget_consplan", 1004, ret, ERM_CLI_RECVRETCODE);
                return (ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out apiret);

            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);

            if ((ret = net_recv(con.sock, idx)) < 0)
            {
                logclierr("cget_consplan", 1005, ret, ERM_CLI_RECVOUTPUTS);
                return (ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out consplan.consplan);
            net_recvpostint(ref idx, out consplan.cpn22ord_l);
            return (apiret);
        }

        [SecuritySafeCritical]
        public int cini_cpn22ord(rcon_s con, out cpn22ord_s cpn22ord)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mini_cpn22ord(con, out cpn22ord);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mini_cpn22ord(rcon_s con, out cpn22ord_s cpn22ord)
        {
            int idx;
            int ret;

            cpn22ord = new cpn22ord_s();

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx, COMMAND_INI_CPN22ORD);
            if ((ret = net_send(con.sock, idx)) < 0)
            {
                logclierr("cini_cpn22ord", 1000, ret, ERM_CLI_SENDREQCODE);
                return (ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock, idx)) < 0)
            {
                logclierr("cini_cpn22ord", 1001, ret, ERM_CLI_RECVOUTPUTS);
                return (ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out cpn22ord.orderwidth);
            net_recvpostint(ref idx, out cpn22ord.depth);
            net_recvpostint(ref idx, out cpn22ord.inuse);
            return (1);
        }

        [SecuritySafeCritical]
        public int cget_cpn22ord(rcon_s con, ref cpn22ord_s cpn22ord)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mget_cpn22ord(con, ref cpn22ord);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mget_cpn22ord(rcon_s con, ref cpn22ord_s cpn22ord)
        {
            int idx;
            int ret;
            int apiret;

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx, COMMAND_GET_CPN22ORD);
            if ((ret = net_send(con.sock, idx)) < 0)
            {
                logclierr("cget_cpn22ord", 1002, ret, ERM_CLI_SENDREQCODE);
                return (ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Send inputs                                                           */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx, cpn22ord.consplan);
            net_sendprepint(ref idx, cpn22ord.cpn22ordidx);
            if ((ret = net_send(con.sock, idx)) < 0)
            {
                logclierr("cget_cpn22ord", 1003, ret, ERM_CLI_SENDINPUTS);
                return (ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Recv return code                                                      */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock, idx)) < 0)
            {
                logclierr("cget_cpn22ord", 1004, ret, ERM_CLI_RECVRETCODE);
                return (ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out apiret);

            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepstr(ref idx, cpn22ord.orderwidth);
            net_recvprepdbl(ref idx);
            if ((ret = net_recv(con.sock, idx)) < 0)
            {
                logclierr("cget_cpn22ord", 1005, ret, ERM_CLI_RECVOUTPUTS);
                return (ERR_NETW);
            }
            idx = 0;
            net_recvpoststr(ref idx, out cpn22ord.order, cpn22ord.orderwidth);
            net_recvpostdbl(ref idx, out cpn22ord.cpnordqty);
            return (apiret);
        }

        [SecuritySafeCritical]
        public int cini_misc(rcon_s con, out misc_s misc)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mini_misc(con, out misc);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mini_misc(rcon_s con, out misc_s misc)
        {
            int idx;
            int ret;

            misc = new misc_s();

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx,COMMAND_INI_MISC);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cini_misc",1000,ret,ERM_CLI_SENDREQCODE);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            idx = 0;
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx); // algtimezonewidth
            net_recvprepint(ref idx); // algmfbshiftwidth
            net_recvprepint(ref idx); // algdefwhsewidth
            net_recvprepint(ref idx); // algsytelinesitewidth
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cini_misc",1001,ret,ERM_CLI_RECVOUTPUTS);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out misc.olxtitlewidth);
            net_recvpostint(ref idx, out misc.algsqldsnwidth);
            net_recvpostint(ref idx, out misc.algsqlaltnowidth);
            net_recvpostint(ref idx, out misc.algtimezonewidth);
            net_recvpostint(ref idx, out misc.algmfbshiftwidth);
            net_recvpostint(ref idx, out misc.algdefwhsewidth);
            net_recvpostint(ref idx, out misc.algsytelinesitewidth);

            return(1);
        }

        [SecuritySafeCritical]
        public int cget_misc(rcon_s con, ref misc_s misc)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mget_misc(con, ref misc);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mget_misc(rcon_s con, ref misc_s misc)
        {
            int idx;
            int ret;
            int apiret;

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx,COMMAND_GET_MISC);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cget_misc",1002,ret,ERM_CLI_SENDREQCODE);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Send inputs                                                           */
            /*-----------------------------------------------------------------------*/

            /*-----------------------------------------------------------------------*/
            /* Recv return code                                                      */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cget_misc",1003,ret,ERM_CLI_RECVRETCODE);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out apiret);

            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepstr(ref idx,misc.olxtitlewidth);
            net_recvprepint(ref idx);
            net_recvprepdbl(ref idx);
            net_recvprepdbl(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepdbl(ref idx);
            net_recvprepdbl(ref idx);
            net_recvprepdbl(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepstr(ref idx,misc.algsqldsnwidth);
            net_recvprepstr(ref idx,misc.algsqldsnwidth);
            net_recvprepstr(ref idx,misc.algsqldsnwidth);
            net_recvprepstr(ref idx,misc.algsqlaltnowidth);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepdbl(ref idx);
            net_recvprepint(ref idx);
            net_recvprepdbl(ref idx);
            net_recvprepdbl(ref idx);
            net_recvprepdbl(ref idx);
            net_recvprepint(ref idx);                        // algiterdays
            net_recvprepint(ref idx);                        // algiterdaysctp
            net_recvprepstr(ref idx,misc.algtimezonewidth);  // algtimezone
            net_recvprepint(ref idx);                        // algsupplytime
            net_recvprepint(ref idx);                        // algdemandtime
            net_recvprepint(ref idx);                        // horizonoffset
            net_recvprepstr(ref idx,misc.algmfbshiftwidth);  // algmfbshift
            net_recvprepint(ref idx);                        // algfence30days
            net_recvprepint(ref idx);                        // algfence90days
            net_recvprepint(ref idx);                        // algconsmfg
            net_recvprepint(ref idx);                        // algconspurch
            net_recvprepint(ref idx);                        // algminworkhours
            net_recvprepint(ref idx);                        // algcplncategory
            net_recvprepstr(ref idx,misc.algdefwhsewidth);   // algdefwhse
            net_recvprepstr(ref idx,misc.algsytelinesitewidth); // algsytelinesite
            net_recvprepint(ref idx);                        // algpotolin
            net_recvprepint(ref idx);                        // algpotolout
            net_recvprepint(ref idx);                        // algjobtolin
            net_recvprepint(ref idx);                        // algjobtolout
            net_recvprepint(ref idx); // algssseqrule
            net_recvprepint(ref idx); // algtasknum
            if ((ret = net_recv(con.sock, idx)) < 0)
            {
                logclierr("cget_misc",1004,ret,ERM_CLI_RECVOUTPUTS);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpoststr(ref idx, out misc.olxtitle, misc.olxtitlewidth);
            net_recvpostint(ref idx, out misc.alggranmins);
            net_recvpostdbl(ref idx, out misc.alghorizonsys);
            net_recvpostdbl(ref idx, out misc.alghorizonord);
            net_recvpostint(ref idx, out misc.algpushiters);
            net_recvpostint(ref idx, out misc.algpulliters);
            net_recvpostint(ref idx, out misc.algpullalliters);
            net_recvpostdbl(ref idx, out misc.alginfcapafter);
            net_recvpostdbl(ref idx, out misc.alginfmtlafter);
            net_recvpostdbl(ref idx, out misc.algbufscale);
            net_recvpostint(ref idx, out misc.algclearonfull);
            net_recvpostint(ref idx, out misc.algdebuglevel);
            net_recvpostint(ref idx, out misc.algthirdpass);
            net_recvpostint(ref idx, out misc.timenow);
            net_recvpostint(ref idx, out misc.algmsiteflags);
            net_recvpostint(ref idx, out misc.algssiteflags);
            net_recvpoststr(ref idx, out misc.algsqldsn1, misc.algsqldsnwidth);
            net_recvpoststr(ref idx, out misc.algsqldsn2, misc.algsqldsnwidth);
            net_recvpoststr(ref idx, out misc.algsqldsn3, misc.algsqldsnwidth);
            net_recvpoststr(ref idx, out misc.algsqlaltno, misc.algsqlaltnowidth);
            net_recvpostint(ref idx, out misc.algmaxnumwhatif);
            net_recvpostint(ref idx, out misc.algcurrnumwhatif);
            net_recvpostint(ref idx, out misc.algnxtodpnum);
            net_recvpostint(ref idx, out misc.algnxtschtag);
            net_recvpostint(ref idx, out misc.algnxtjobtag);
            net_recvpostint(ref idx, out misc.algnxtmessage);
            net_recvpostint(ref idx, out misc.algnxtwtdnum);
            net_recvpostint(ref idx, out misc.apsstatus);
            net_recvpostint(ref idx, out misc.algordstarttime);
            net_recvpostdbl(ref idx, out misc.algordoffset);
            net_recvpostint(ref idx, out misc.algsearchiters);
            net_recvpostdbl(ref idx, out misc.algprtsupplytol);
            net_recvpostdbl(ref idx, out misc.algprtfexptime);
            net_recvpostdbl(ref idx, out misc.algprtvexptime);
            net_recvpostint(ref idx, out misc.algiterdays);
            net_recvpostint(ref idx, out misc.algiterdaysctp);
            net_recvpoststr(ref idx, out misc.algtimezone, misc.algtimezonewidth);
            net_recvpostint(ref idx, out misc.algsupplytime);
            net_recvpostint(ref idx, out misc.algdemandtime);
            net_recvpostint(ref idx, out misc.horizonoffset);
            net_recvpoststr(ref idx, out misc.algmfbshift, misc.algmfbshiftwidth);
            net_recvpostint(ref idx, out misc.algfence30days);
            net_recvpostint(ref idx, out misc.algfence90days);
            net_recvpostint(ref idx, out misc.algconsmfg);
            net_recvpostint(ref idx, out misc.algconspurch);
            net_recvpostint(ref idx, out misc.algminworkhours);
            net_recvpostint(ref idx, out misc.algcplncategory);
            net_recvpoststr(ref idx, out misc.algdefwhse, misc.algdefwhsewidth);
            net_recvpoststr(ref idx, out misc.algsytelinesite, misc.algsytelinesitewidth);
            net_recvpostint(ref idx, out misc.algpotolin);
            net_recvpostint(ref idx, out misc.algpotolout);
            net_recvpostint(ref idx, out misc.algjobtolin);
            net_recvpostint(ref idx, out misc.algjobtolout);
            net_recvpostint(ref idx, out misc.algssseqrule);
            net_recvpostint(ref idx, out misc.algtasknum);
            return (apiret);
        }

        [SecuritySafeCritical]
        public int cedt_misc(rcon_s con, ref misc_s misc)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = medt_misc(con, ref misc);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int medt_misc(rcon_s con, ref misc_s misc)
        {
            int idx;
            int ret;
            int apiret;

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx,COMMAND_EDT_MISC);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cedt_misc",1005,ret,ERM_CLI_SENDREQCODE);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Send inputs                                                           */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepstr(ref idx,misc.olxtitle,misc.olxtitlewidth);
            net_sendprepint(ref idx,misc.alggranmins);
            net_sendprepdbl(ref idx,misc.alghorizonsys);
            net_sendprepdbl(ref idx,misc.alghorizonord);
            net_sendprepint(ref idx,misc.algpushiters);
            net_sendprepint(ref idx,misc.algpulliters);
            net_sendprepint(ref idx,misc.algpullalliters);
            net_sendprepdbl(ref idx,misc.alginfcapafter);
            net_sendprepdbl(ref idx,misc.alginfmtlafter);
            net_sendprepdbl(ref idx,misc.algbufscale);
            net_sendprepint(ref idx,misc.algclearonfull);
            net_sendprepint(ref idx,misc.algdebuglevel);
            net_sendprepint(ref idx,misc.algthirdpass);
            net_sendprepint(ref idx,misc.timenow);
            net_sendprepint(ref idx,misc.algmsiteflags);
            net_sendprepint(ref idx,misc.algssiteflags);
            net_sendprepstr(ref idx, misc.algsqldsn1, misc.algsqldsnwidth);
            net_sendprepstr(ref idx, misc.algsqldsn2, misc.algsqldsnwidth);
            net_sendprepstr(ref idx, misc.algsqldsn3, misc.algsqldsnwidth);
            net_sendprepstr(ref idx,misc.algsqlaltno,misc.algsqlaltnowidth);
            net_sendprepint(ref idx,misc.algmaxnumwhatif);
            net_sendprepint(ref idx,misc.algcurrnumwhatif);
            net_sendprepint(ref idx,misc.algnxtodpnum);
            net_sendprepint(ref idx,misc.algnxtschtag);
            net_sendprepint(ref idx, misc.algnxtjobtag);
            net_sendprepint(ref idx, misc.algnxtmessage);
            net_sendprepint(ref idx, misc.algnxtwtdnum);
            net_sendprepint(ref idx, misc.apsstatus);
            net_sendprepint(ref idx,misc.algordstarttime);
            net_sendprepdbl(ref idx,misc.algordoffset);
            net_sendprepint(ref idx,misc.algsearchiters);
            net_sendprepdbl(ref idx,misc.algprtsupplytol);
            net_sendprepdbl(ref idx,misc.algprtfexptime);
            net_sendprepdbl(ref idx,misc.algprtvexptime);
            net_sendprepint(ref idx,misc.algiterdays);
            net_sendprepint(ref idx,misc.algiterdaysctp);
            net_sendprepstr(ref idx,misc.algtimezone,misc.algtimezonewidth);
            net_sendprepint(ref idx,misc.algsupplytime);
            net_sendprepint(ref idx,misc.algdemandtime);
            net_sendprepint(ref idx,misc.horizonoffset);
            net_sendprepstr(ref idx,misc.algmfbshift,misc.algmfbshiftwidth);
            net_sendprepint(ref idx, misc.algfence30days);
            net_sendprepint(ref idx, misc.algfence90days);
            net_sendprepint(ref idx, misc.algconsmfg);
            net_sendprepint(ref idx, misc.algconspurch);
            net_sendprepint(ref idx, misc.algminworkhours);
            net_sendprepint(ref idx, misc.algcplncategory);
            net_sendprepstr(ref idx, misc.algdefwhse, misc.algdefwhsewidth);
            net_sendprepstr(ref idx, misc.algsytelinesite, misc.algsytelinesitewidth);
            net_sendprepint(ref idx, misc.algpotolin);
            net_sendprepint(ref idx, misc.algpotolout);
            net_sendprepint(ref idx, misc.algjobtolin);
            net_sendprepint(ref idx, misc.algjobtolout);
            net_sendprepint(ref idx, misc.algssseqrule);
            net_sendprepint(ref idx, misc.algtasknum);

            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cedt_misc",1006,ret,ERM_CLI_SENDINPUTS);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Recv return code                                                      */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cedt_misc",1007,ret,ERM_CLI_RECVRETCODE);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out apiret);

            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            return(apiret);
        }

        [SecuritySafeCritical]
        public int cini_miscout(rcon_s con, out miscout_s miscout)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mini_miscout(con, out miscout);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mini_miscout(rcon_s con, out miscout_s miscout)
        {
            miscout = new miscout_s();

            return(1);
        }

        [SecuritySafeCritical]
        public int cget_miscout(rcon_s con, ref miscout_s miscout)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mget_miscout(con, ref miscout);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mget_miscout(rcon_s con, ref miscout_s miscout)
        {
            int idx;
            int ret;
            int apiret;

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx,COMMAND_GET_MISCOUT);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cget_miscout",1002,ret,ERM_CLI_SENDREQCODE);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Send inputs                                                           */
            /*-----------------------------------------------------------------------*/

            /*-----------------------------------------------------------------------*/
            /* Recv return code                                                      */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cget_miscout",1003,ret,ERM_CLI_RECVRETCODE);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out apiret);

            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cget_miscout",1004,ret,ERM_CLI_RECVOUTPUTS);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out miscout.algfullbeg);
            net_recvpostint(ref idx, out miscout.algfullbegreal);
            net_recvpostint(ref idx, out miscout.algfullend);
            net_recvpostint(ref idx, out miscout.algfullendreal);
            net_recvpostint(ref idx, out miscout.algincrbeg);
            net_recvpostint(ref idx, out miscout.algincrbegreal);
            net_recvpostint(ref idx, out miscout.algincrend);
            net_recvpostint(ref idx, out miscout.algincrendreal);
            net_recvpostint(ref idx, out miscout.algglblbeg);
            net_recvpostint(ref idx, out miscout.algglblbegreal);
            net_recvpostint(ref idx, out miscout.algglblend);
            net_recvpostint(ref idx, out miscout.algglblendreal);
            return(apiret);
        }

        [SecuritySafeCritical]
        public int cini_message(rcon_s con, out message_s message)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mini_message(con, out message);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mini_message(rcon_s con, out message_s message)
        {
            int idx;
            int ret;

            message = new message_s();

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx, COMMAND_INI_MESSAGE);
            if ((ret = net_send(con.sock, idx)) < 0)
            {
                logclierr("cini_message", 10001, ret, ERM_CLI_SENDREQCODE);
                return (ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock, idx)) < 0)
            {
                logclierr("cini_message", 10011, ret, ERM_CLI_RECVOUTPUTS);
                return (ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out message.orderwidth);
            net_recvpostint(ref idx, out message.partwidth);
            net_recvpostint(ref idx, out message.parmwidth);
            net_recvpostint(ref idx, out message.depth);
            net_recvpostint(ref idx, out message.inuse);
            return (1);
        }

        [SecuritySafeCritical]
        public int cget_message(rcon_s con, ref message_s message)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mget_message(con, ref message);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mget_message(rcon_s con, ref message_s message)
        {
            int idx;
            int ret;
            int apiret;

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx, COMMAND_GET_MESSAGE);
            if ((ret = net_send(con.sock, idx)) < 0)
            {
                logclierr("cget_message", 10021, ret, ERM_CLI_SENDREQCODE);
                return (ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Send inputs                                                           */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx, message.messageidx);
            if ((ret = net_send(con.sock, idx)) < 0)
            {
                logclierr("cget_message", 10031, ret, ERM_CLI_SENDINPUTS);
                return (ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Recv return code                                                      */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock, idx)) < 0)
            {
                logclierr("cget_message", 10041, ret, ERM_CLI_RECVRETCODE);
                return (ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out apiret);

            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepstr(ref idx, message.orderwidth);
            net_recvprepstr(ref idx, message.partwidth);
            net_recvprepstr(ref idx, message.parmwidth);
            net_recvprepstr(ref idx, message.parmwidth);
            net_recvprepstr(ref idx, message.parmwidth);
            net_recvprepstr(ref idx, message.parmwidth);

            if ((ret = net_recv(con.sock, idx)) < 0)
            {
                logclierr("cget_message", 10051, ret, ERM_CLI_RECVOUTPUTS);
                return (ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out message.message);
            net_recvpostint(ref idx, out message.msgid);
            net_recvpostint(ref idx, out message.msgtype);
            net_recvpoststr(ref idx, out message.order, message.orderwidth);
            net_recvpoststr(ref idx, out message.part, message.partwidth);
            net_recvpoststr(ref idx, out message.parm1, message.parmwidth);
            net_recvpoststr(ref idx, out message.parm2, message.parmwidth);
            net_recvpoststr(ref idx, out message.parm3, message.parmwidth);
            net_recvpoststr(ref idx, out message.parm4, message.parmwidth);
            return (apiret);
        }

        [SecuritySafeCritical]
        public int cini_mpn22ipn(rcon_s con, out mpn22ipn_s mpn22ipn)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mini_mpn22ipn(con, out mpn22ipn);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mini_mpn22ipn(rcon_s con, out mpn22ipn_s mpn22ipn)
        {
            int idx;
            int ret;

            mpn22ipn = new mpn22ipn_s();

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx,COMMAND_INI_MPN22IPN);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cini_mpn22ipn",1000,ret,ERM_CLI_SENDREQCODE);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cini_mpn22ipn",1001,ret,ERM_CLI_RECVOUTPUTS);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out mpn22ipn.depth);
            net_recvpostint(ref idx, out mpn22ipn.inuse);
            return(1);
        }

        [SecuritySafeCritical]
        public int cget_mpn22ipn(rcon_s con, ref mpn22ipn_s mpn22ipn)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mget_mpn22ipn(con, ref mpn22ipn);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mget_mpn22ipn(rcon_s con, ref mpn22ipn_s mpn22ipn)
        {
            int idx;
            int ret;
            int apiret;

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx,COMMAND_GET_MPN22IPN);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cget_mpn22ipn",1002,ret,ERM_CLI_SENDREQCODE);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Send inputs                                                           */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx,mpn22ipn.matlplan);
            net_sendprepint(ref idx,mpn22ipn.mpn22ipnidx);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cget_mpn22ipn",1003,ret,ERM_CLI_SENDINPUTS);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Recv return code                                                      */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cget_mpn22ipn",1004,ret,ERM_CLI_RECVRETCODE);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out apiret);

            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cget_mpn22ipn",1005,ret,ERM_CLI_RECVOUTPUTS);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out (mpn22ipn.invplan[0]));
            net_recvpostint(ref idx, out (mpn22ipn.invplan[1]));
            return(apiret);
        }

        [SecuritySafeCritical]
        public int cini_mpn22opn(rcon_s con, out mpn22opn_s mpn22opn)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mini_mpn22opn(con, out mpn22opn);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mini_mpn22opn(rcon_s con, out mpn22opn_s mpn22opn)
        {
            int idx;
            int ret;

            mpn22opn = new mpn22opn_s();

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx,COMMAND_INI_MPN22OPN);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cini_mpn22opn",1000,ret,ERM_CLI_SENDREQCODE);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cini_mpn22opn",1001,ret,ERM_CLI_RECVOUTPUTS);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out mpn22opn.depth);
            net_recvpostint(ref idx, out mpn22opn.inuse);
            return(1);
        }

        [SecuritySafeCritical]
        public int cget_mpn22opn(rcon_s con, ref mpn22opn_s mpn22opn)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mget_mpn22opn(con, ref mpn22opn);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mget_mpn22opn(rcon_s con, ref mpn22opn_s mpn22opn)
        {
            int idx;
            int ret;
            int apiret;

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx,COMMAND_GET_MPN22OPN);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cget_mpn22opn",1002,ret,ERM_CLI_SENDREQCODE);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Send inputs                                                           */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx,mpn22opn.matlplan);
            net_sendprepint(ref idx,mpn22opn.mpn22opnidx);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cget_mpn22opn",1003,ret,ERM_CLI_SENDINPUTS);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Recv return code                                                      */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cget_mpn22opn",1004,ret,ERM_CLI_RECVRETCODE);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out apiret);

            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cget_mpn22opn",1005,ret,ERM_CLI_RECVOUTPUTS);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out (mpn22opn.operplan[0]));
            net_recvpostint(ref idx, out (mpn22opn.operplan[1]));
            return(apiret);
        }

        [SecuritySafeCritical]
        public int cini_operation(rcon_s con, out operation_s operation)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mini_operation(con, out operation);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mini_operation(rcon_s con, out operation_s operation)
        {
            int idx;
            int ret;

            operation = new operation_s();

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx,COMMAND_INI_OPERATION);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cini_operation",1000,ret,ERM_CLI_SENDREQCODE);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock, idx)) < 0)
            {
                logclierr("cini_operation",1001,ret,ERM_CLI_RECVOUTPUTS);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out operation.operationwidth);
            net_recvpostint(ref idx, out operation.oprworkcenterwidth);
            net_recvpostint(ref idx, out operation.oprsplitcatwidth);
            net_recvpostint(ref idx, out operation.depth);
            net_recvpostint(ref idx, out operation.inuse);
            return(1);
        }

        [SecuritySafeCritical]
        public int cget_operation(rcon_s con, ref operation_s operation)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mget_operation(con, ref operation);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mget_operation(rcon_s con, ref operation_s operation)
        {
            int idx;
            int ret;
            int apiret;

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx,COMMAND_GET_OPERATION);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cget_operation",1002,ret,ERM_CLI_SENDREQCODE);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Send inputs                                                           */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepstr(ref idx,operation.operation,operation.operationwidth);
            net_sendprepint(ref idx,operation.sort);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cget_operation",1003,ret,ERM_CLI_SENDINPUTS);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Recv return code                                                      */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cget_operation",1004,ret,ERM_CLI_RECVRETCODE);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out apiret);

            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepstr(ref idx,operation.operationwidth);
            net_recvprepint(ref idx);
            net_recvprepdbl(ref idx);
            net_recvprepdbl(ref idx);
            net_recvprepdbl(ref idx);
            net_recvprepdbl(ref idx);
            net_recvprepdbl(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepdbl(ref idx);
            net_recvprepdbl(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepstr(ref idx, operation.oprsplitcatwidth);
            net_recvprepdbl(ref idx);
            net_recvprepint(ref idx); // opreffdate
            net_recvprepint(ref idx); // oprobsdate
            net_recvprepstr(ref idx, operation.oprworkcenterwidth);
            if ((ret = net_recv(con.sock, idx)) < 0)
            {
                logclierr("cget_operation",1005,ret,ERM_CLI_RECVOUTPUTS);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpoststr(ref idx, out operation.operation, operation.operationwidth);
            net_recvpostint(ref idx, out operation.oprflags);
            net_recvpostdbl(ref idx, out operation.oprbufpre);
            net_recvpostdbl(ref idx, out operation.oprsetup);
            net_recvpostdbl(ref idx, out operation.oprcycle);
            net_recvpostdbl(ref idx, out operation.oprbufpost);
            net_recvpostdbl(ref idx, out operation.oprhorizon);
            net_recvpostint(ref idx, out operation.oprcrossbreaks);
            net_recvpostint(ref idx, out operation.oprattid_l);
            net_recvpostint(ref idx, out operation.opr22oprg_l);
            net_recvpostint(ref idx, out operation.opr22cat_l);
            net_recvpostdbl(ref idx, out operation.oprqueuetime);
            net_recvpostdbl(ref idx, out operation.oprovlvalue);
            net_recvpostint(ref idx, out operation.oprovltype);
            net_recvpostint(ref idx, out operation.oprsplitrule);
            net_recvpoststr(ref idx, out operation.oprsplitcat, operation.oprsplitcatwidth);
            net_recvpostdbl(ref idx, out operation.oprsplitsize);
            net_recvpostint(ref idx, out operation.opreffdate);
            net_recvpostint(ref idx, out operation.oprobsdate);
            net_recvpoststr(ref idx, out operation.oprworkcenter, operation.oprworkcenterwidth);
            return (apiret);
        }

        [SecuritySafeCritical]
        public int cini_operplan(rcon_s con, out operplan_s operplan)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mini_operplan(con, out operplan);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mini_operplan(rcon_s con, out operplan_s operplan)
        {
            int idx;
            int ret;

            operplan = new operplan_s();

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx,COMMAND_INI_OPERPLAN);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cini_operplan",1000,ret,ERM_CLI_SENDREQCODE);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cini_operplan",1001,ret,ERM_CLI_RECVOUTPUTS);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out operplan.operationwidth);
            net_recvpostint(ref idx, out operplan.depth);
            net_recvpostint(ref idx, out operplan.inuse);
            return(1);
        }

        [SecuritySafeCritical]
        public int cget_operplan(rcon_s con, ref operplan_s operplan)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mget_operplan(con, ref operplan);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mget_operplan(rcon_s con, ref operplan_s operplan)
        {
            int idx;
            int ret;
            int apiret;

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx,COMMAND_GET_OPERPLAN);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cini_operation",1002,ret,ERM_CLI_SENDREQCODE);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Send inputs                                                           */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx,operplan.operplan[0]);
            net_sendprepint(ref idx,operplan.operplan[1]);
            net_sendprepint(ref idx,operplan.sort);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cget_operaplan",1003,ret,ERM_CLI_SENDINPUTS);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Recv return code                                                      */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cget_operaplan",1004,ret,ERM_CLI_RECVRETCODE);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out apiret);

            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepdbl(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepstr(ref idx, operplan.operationwidth);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);

            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cget_operaplan",1005,ret,ERM_CLI_RECVOUTPUTS);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out operplan.operplan[0]);
            net_recvpostint(ref idx, out operplan.operplan[1]);
            net_recvpostint(ref idx, out operplan.opnenddate);
            net_recvpostint(ref idx, out operplan.opnflags);
            net_recvpostdbl(ref idx, out operplan.opnquantity);
            net_recvpostint(ref idx, out operplan.opnstep);
            net_recvpostint(ref idx, out operplan.opnsplit);
            net_recvpoststr(ref idx, out operplan.operation, operplan.operationwidth);
            net_recvpostint(ref idx, out operplan.matlplan);
            net_recvpostint(ref idx, out operplan.opn22res_l);
            return(apiret);
        }

        [SecuritySafeCritical]
        public int cini_opn22res(rcon_s con, out opn22res_s opn22res)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mini_opn22res(con, out opn22res);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mini_opn22res(rcon_s con, out opn22res_s opn22res)
        {
            int idx;
            int ret;

            opn22res = new opn22res_s();

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx,COMMAND_INI_OPN22RES);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cini_opn22res",1000,ret,ERM_CLI_SENDREQCODE);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cini_opn22res",1001,ret,ERM_CLI_RECVOUTPUTS);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out opn22res.resourcewidth);
            net_recvpostint(ref idx, out opn22res.depth);
            net_recvpostint(ref idx, out opn22res.inuse);
            return(1);
        }

        [SecuritySafeCritical]
        public int cget_opn22res(rcon_s con, ref opn22res_s opn22res)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mget_opn22res(con, ref opn22res);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mget_opn22res(rcon_s con, ref opn22res_s opn22res)
        {
            int idx;
            int ret;
            int apiret;

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx,COMMAND_GET_OPN22RES);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cget_opn22res",1002,ret,ERM_CLI_SENDREQCODE);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Send inputs                                                           */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx,opn22res.operplan[0]);
            net_sendprepint(ref idx,opn22res.operplan[1]);
            net_sendprepint(ref idx,opn22res.opn22residx);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cget_opn22res",1003,ret,ERM_CLI_SENDINPUTS);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Recv return code                                                      */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cget_opn22res",1004,ret,ERM_CLI_RECVRETCODE);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out apiret);

            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepstr(ref idx,opn22res.resourcewidth);
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cget_opn22res",1005,ret,ERM_CLI_RECVOUTPUTS);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpoststr(ref idx, out opn22res.resource, opn22res.resourcewidth);
            return(apiret);
        }

        [SecuritySafeCritical]
        public int cini_opr22cat(rcon_s con, out opr22cat_s opr22cat)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mini_opr22cat(con, out opr22cat);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mini_opr22cat(rcon_s con, out opr22cat_s opr22cat)
        {
            int idx;
            int ret;

            opr22cat = new opr22cat_s();

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx,COMMAND_INI_OPR22CAT);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cini_opr22cat",1000,ret,ERM_CLI_SENDREQCODE);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cini_opr22cat",1001,ret,ERM_CLI_RECVOUTPUTS);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out opr22cat.operationwidth);
            net_recvpostint(ref idx, out opr22cat.categorywidth);
            net_recvpostint(ref idx, out opr22cat.depth);
            net_recvpostint(ref idx, out opr22cat.inuse);
            return(1);
        }

        [SecuritySafeCritical]
        public int cget_opr22cat(rcon_s con, ref opr22cat_s opr22cat)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mget_opr22cat(con, ref opr22cat);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mget_opr22cat(rcon_s con, ref opr22cat_s opr22cat)
        {
            int idx;
            int ret;
            int apiret;

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx,COMMAND_GET_OPR22CAT);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cget_opr22cat",1002,ret,ERM_CLI_SENDREQCODE);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Send inputs                                                           */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepstr(ref idx,opr22cat.operation,opr22cat.operationwidth);
            net_sendprepint(ref idx,opr22cat.opr22catidx);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cget_opr22cat",1003,ret,ERM_CLI_SENDINPUTS);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Recv return code                                                      */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cget_opr22cat",1004,ret,ERM_CLI_RECVRETCODE);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out apiret);

            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepstr(ref idx,opr22cat.categorywidth);
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cget_opr22cat",1005,ret,ERM_CLI_RECVOUTPUTS);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpoststr(ref idx, out opr22cat.category, opr22cat.categorywidth);
            return(apiret);
        }

        [SecuritySafeCritical]
        public int cini_ord22mpn(rcon_s con, out ord22mpn_s ord22mpn)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mini_ord22mpn(con, out ord22mpn);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mini_ord22mpn(rcon_s con, out ord22mpn_s ord22mpn)
        {
            int idx;
            int ret;

            ord22mpn = new ord22mpn_s();

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx,COMMAND_INI_ORD22MPN);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cini_ord22mpn",1000,ret,ERM_CLI_SENDREQCODE);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cini_ord22mpn",1001,ret,ERM_CLI_RECVOUTPUTS);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out ord22mpn.orderwidth);
            net_recvpostint(ref idx, out ord22mpn.depth);
            net_recvpostint(ref idx, out ord22mpn.inuse);
            return(1);
        }

        [SecuritySafeCritical]
        public int cget_ord22mpn(rcon_s con, ref ord22mpn_s ord22mpn)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mget_ord22mpn(con, ref ord22mpn);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mget_ord22mpn(rcon_s con, ref ord22mpn_s ord22mpn)
        {
            int idx;
            int ret;
            int apiret;

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx,COMMAND_GET_ORD22MPN);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cget_ord22mpn",1002,ret,ERM_CLI_SENDREQCODE);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Send inputs                                                           */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepstr(ref idx,ord22mpn.order,ord22mpn.orderwidth);
            net_sendprepint(ref idx,ord22mpn.ord22mpnidx);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cget_ord22mpn",1003,ret,ERM_CLI_SENDINPUTS);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Recv return code                                                      */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cget_ord22mpn",1004,ret,ERM_CLI_RECVRETCODE);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out apiret);

            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cget_ord22mpn",1005,ret,ERM_CLI_RECVOUTPUTS);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out (ord22mpn.matlplan));
            return(apiret);
        }

        [SecuritySafeCritical]
        public int cini_order(rcon_s con, out order_s order)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mini_order(con, out order);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mini_order(rcon_s con, out order_s order)
        {
            int idx;
            int ret;

            order = new order_s();

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx,COMMAND_INI_ORDER);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cini_order",1000,ret,ERM_CLI_SENDREQCODE);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cini_order",1001,ret,ERM_CLI_RECVOUTPUTS);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out order.orderwidth);
            net_recvpostint(ref idx, out order.ordreforderwidth);
            net_recvpostint(ref idx, out order.ordcustidwidth);
            net_recvpostint(ref idx, out order.whsewidth);
            net_recvpostint(ref idx, out order.depth);
            net_recvpostint(ref idx, out order.inuse);
            return(1);
        }

        [SecuritySafeCritical]
        public int cget_order(rcon_s con, ref order_s order)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mget_order(con, ref order);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mget_order(rcon_s con, ref order_s order)
        {
            int idx;
            int ret;
            int apiret;

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx,COMMAND_GET_ORDER);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cget_order",1002,ret,ERM_CLI_SENDREQCODE);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Send inputs                                                           */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepstr(ref idx,order.order,order.orderwidth);
            net_sendprepint(ref idx,order.sort);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cget_order",1003,ret,ERM_CLI_SENDINPUTS);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Recv return code                                                      */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cget_order",1004,ret,ERM_CLI_RECVRETCODE);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out apiret);

            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepstr(ref idx,order.orderwidth);
            net_recvprepint(ref idx); // ordflags
            net_recvprepint(ref idx); // ordflags2
            net_recvprepint(ref idx); // ordcategory
            net_recvprepint(ref idx); // ordtype
            net_recvprepint(ref idx); // ordarivdate
            net_recvprepint(ref idx); // ordrequdate
            net_recvprepint(ref idx); // ordpromdate
            net_recvprepint(ref idx); // ordcalcdate
            net_recvprepint(ref idx); // ordstrtdate
            net_recvprepstr(ref idx,order.ordreforderwidth); // ordreforder
            net_recvprepstr(ref idx,order.ordcustidwidth); // ordcustid
            net_recvprepstr(ref idx,order.whsewidth); // whse
            net_recvprepint(ref idx); // ordattid_l
            net_recvprepint(ref idx); // ordlineitem_l
            net_recvprepint(ref idx); // ord22ordg_l
            net_recvprepint(ref idx); // ord22mpn_l
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cget_order",1005,ret,ERM_CLI_RECVOUTPUTS);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpoststr(ref idx, out order.order, order.orderwidth);
            net_recvpostint(ref idx, out order.ordflags);
            net_recvpostint(ref idx, out order.ordflags2);
            net_recvpostint(ref idx, out order.ordcategory);
            net_recvpostint(ref idx, out order.ordtype);
            net_recvpostint(ref idx, out order.ordarivdate);
            net_recvpostint(ref idx, out order.ordrequdate);
            net_recvpostint(ref idx, out order.ordpromdate);
            net_recvpostint(ref idx, out order.ordcalcdate);
            net_recvpostint(ref idx, out order.ordstrtdate);
            net_recvpoststr(ref idx, out order.ordreforder, order.ordreforderwidth);
            net_recvpoststr(ref idx, out order.ordcustid, order.ordcustidwidth);
            net_recvpoststr(ref idx, out order.whse, order.whsewidth);
            net_recvpostint(ref idx, out order.ordattid_l);
            net_recvpostint(ref idx, out order.ordlineitem_l);
            net_recvpostint(ref idx, out order.ord22ordg_l);
            net_recvpostint(ref idx, out order.ord22mpn_l);
            return(apiret);
        }

        [SecuritySafeCritical]
        public int cadd_order(rcon_s con, order_s order)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = madd_order(con, order);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int madd_order(rcon_s con, order_s order)
        {
            int idx;
            int ret;
            int apiret;

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx,COMMAND_ADD_ORDER);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cadd_order",1006,ret,ERM_CLI_SENDREQCODE);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Send inputs                                                           */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepstr(ref idx,order.order,order.orderwidth);
            net_sendprepint(ref idx,order.ordflags);
            net_sendprepint(ref idx,order.ordflags2);
            net_sendprepint(ref idx,order.ordcategory);
            net_sendprepint(ref idx,order.ordtype);
            net_sendprepint(ref idx,order.ordarivdate);
            net_sendprepint(ref idx,order.ordrequdate);
            net_sendprepint(ref idx,order.ordpromdate);
            net_sendprepint(ref idx,order.ordstrtdate);
            net_sendprepstr(ref idx,order.ordreforder,order.ordreforderwidth);
            net_sendprepstr(ref idx, order.ordcustid, order.ordcustidwidth);
            net_sendprepstr(ref idx, order.whse, order.whsewidth);
            if ((ret = net_send(con.sock, idx)) < 0)
            {
                logclierr("cadd_order",1007,ret,ERM_CLI_SENDINPUTS);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Recv return code                                                      */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cadd_order",1008,ret,ERM_CLI_RECVRETCODE);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out apiret);

            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            return(apiret);
        }

        [SecuritySafeCritical]
        public int cedt_order(rcon_s con, ref order_s order)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = medt_order(con, ref order);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int medt_order(rcon_s con, ref order_s order)
        {
            int idx;
            int ret;
            int apiret;

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx,COMMAND_EDT_ORDER);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cedt_order",1009,ret,ERM_CLI_SENDREQCODE);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Send inputs                                                           */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepstr(ref idx, order.order, order.orderwidth);
            net_sendprepint(ref idx,order.ordflags);
            net_sendprepint(ref idx,order.ordflags2);
            net_sendprepint(ref idx,order.ordcategory);
            net_sendprepint(ref idx,order.ordtype);
            net_sendprepint(ref idx,order.ordarivdate);
            net_sendprepint(ref idx,order.ordrequdate);
            net_sendprepint(ref idx,order.ordpromdate);
            net_sendprepint(ref idx,order.ordstrtdate);
            net_sendprepstr(ref idx,order.ordreforder,order.ordreforderwidth);
            net_sendprepstr(ref idx,order.ordcustid,order.ordcustidwidth);
            net_sendprepstr(ref idx, order.whse, order.whsewidth);
            if ((ret = net_send(con.sock, idx)) < 0)
            {
                logclierr("cedt_order",1010,ret,ERM_CLI_SENDINPUTS);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Recv return code                                                      */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cedt_order",1011,ret,ERM_CLI_RECVRETCODE);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out apiret);

            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            return(apiret);
        }

        [SecuritySafeCritical]
        public int cdel_order(rcon_s con, order_s order)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mdel_order(con, order);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mdel_order(rcon_s con, order_s order)
        {
            int idx;
            int ret;
            int apiret;

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx,COMMAND_DEL_ORDER);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cdel_order",1012,ret,ERM_CLI_SENDREQCODE);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Send inputs                                                           */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepstr(ref idx,order.order,order.orderwidth);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cdel_order",1013,ret,ERM_CLI_SENDINPUTS);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Recv return code                                                      */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cdel_order",1014,ret,ERM_CLI_RECVRETCODE);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out apiret);

            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            return(apiret);
        }

        [SecuritySafeCritical]
        public int csch_order(rcon_s con, order_s order)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = msch_order(con, order);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int msch_order(rcon_s con, order_s order)
        {
            int idx;
            int ret;
            int apiret;

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx,COMMAND_SCH_ORDER);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("csch_order",1019,ret,ERM_CLI_SENDREQCODE);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Send inputs                                                           */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepstr(ref idx,order.order,order.orderwidth);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("csch_order",1020,ret,ERM_CLI_SENDINPUTS);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Recv return code                                                      */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("csch_order",1021,ret,ERM_CLI_RECVRETCODE);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out apiret);

            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            return(apiret);
        }

        [SecuritySafeCritical]
        public int csch_orderctp(rcon_s con, order_s order, ordlineitem_s ordlineitem, misc_s misc, out ctpdetail_s ctpdetail)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = msch_orderctp(con, order, ordlineitem, misc, out ctpdetail);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int msch_orderctp(rcon_s con, order_s order, ordlineitem_s ordlineitem, misc_s misc, out ctpdetail_s ctpdetail)
        {
            int idx;
            int ret;
            int apiret;

            ctpdetail = new ctpdetail_s();

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx, COMMAND_SCH_ORDERCTP);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("csch_orderctp",1039,ret,ERM_CLI_SENDREQCODE);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Send inputs                                                           */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepstr(ref idx, order.order, order.orderwidth);
            net_sendprepint(ref idx, order.ordflags);
            net_sendprepint(ref idx, order.ordflags2);
            net_sendprepint(ref idx, order.ordcategory);
            net_sendprepint(ref idx, order.ordtype);
            net_sendprepint(ref idx, order.ordarivdate);
            net_sendprepint(ref idx, order.ordrequdate);
            net_sendprepint(ref idx, order.ordpromdate);
            net_sendprepint(ref idx, order.ordstrtdate);
            net_sendprepstr(ref idx, order.ordreforder, order.ordreforderwidth);
            net_sendprepstr(ref idx, order.ordcustid, order.ordcustidwidth);
            net_sendprepstr(ref idx, order.whse, order.whsewidth);
            net_sendprepstr(ref idx, ordlineitem.part, ordlineitem.partwidth);
            net_sendprepdbl(ref idx, ordlineitem.ordlinquantity);
            net_sendprepint(ref idx, misc.algdebuglevel);
            net_sendprepint(ref idx, misc.algssiteflags);
            if ((ret = net_send(con.sock, idx)) < 0)
            {
                logclierr("csch_orderctp",1040,ret,ERM_CLI_SENDINPUTS);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Recv return code                                                      */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            net_recvprepdbl(ref idx);
            net_recvprepdbl(ref idx);
            net_recvprepdbl(ref idx);
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("csch_orderctp",1041,ret,ERM_CLI_RECVRETCODE);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out apiret);
            net_recvpostdbl(ref idx, out ctpdetail.qtyinv);
            net_recvpostdbl(ref idx, out ctpdetail.qtysup);
            net_recvpostdbl(ref idx, out ctpdetail.qtymfg);

            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            return(apiret);
        }

        [SecuritySafeCritical]
        public int cini_ordlineitem(rcon_s con, out ordlineitem_s ordlineitem)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mini_ordlineitem(con, out ordlineitem);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mini_ordlineitem(rcon_s con, out ordlineitem_s ordlineitem)
        {
            int idx;
            int ret;

            ordlineitem = new ordlineitem_s();

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx,COMMAND_INI_ORDLINEITEM);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cini_ordlineitem",1000,ret,ERM_CLI_SENDREQCODE);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cini_ordlineitem",1001,ret,ERM_CLI_RECVOUTPUTS);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out ordlineitem.orderwidth);
            net_recvpostint(ref idx, out ordlineitem.partwidth);
            net_recvpostint(ref idx, out ordlineitem.depth);
            net_recvpostint(ref idx, out ordlineitem.inuse);
            return(1);
        }

        [SecuritySafeCritical]
        public int cget_ordlineitem(rcon_s con, ref ordlineitem_s ordlineitem)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mget_ordlineitem(con, ref ordlineitem);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mget_ordlineitem(rcon_s con, ref ordlineitem_s ordlineitem)
        {
            int idx;
            int ret;
            int apiret;

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx,COMMAND_GET_ORDLINEITEM);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cget_ordlineitem",1002,ret,ERM_CLI_SENDREQCODE);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Send inputs                                                           */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepstr(ref idx,ordlineitem.order,ordlineitem.orderwidth);
            net_sendprepint(ref idx,ordlineitem.ordlineitemidx);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cget_ordlineitem",1003,ret,ERM_CLI_SENDINPUTS);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Recv return code                                                      */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cget_ordlineitem",1004,ret,ERM_CLI_RECVRETCODE);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out apiret);

            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepstr(ref idx,ordlineitem.partwidth);
            net_recvprepdbl(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cget_ordlineitem",1005,ret,ERM_CLI_RECVOUTPUTS);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpoststr(ref idx, out ordlineitem.part, ordlineitem.partwidth);
            net_recvpostdbl(ref idx, out ordlineitem.ordlinquantity);
            net_recvpostint(ref idx, out ordlineitem.ordlinpromdate);
            net_recvpostint(ref idx, out ordlineitem.ordlincalcdate);
            return(apiret);
        }

        [SecuritySafeCritical]
        public int cadd_ordlineitem(rcon_s con, ordlineitem_s ordlineitem)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = madd_ordlineitem(con, ordlineitem);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int madd_ordlineitem(rcon_s con, ordlineitem_s ordlineitem)
        {
            int idx;
            int ret;
            int apiret;

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx,COMMAND_ADD_ORDLINEITEM);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cadd_ordlineitem",1006,ret,ERM_CLI_SENDREQCODE);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Send inputs                                                           */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepstr(ref idx,ordlineitem.order,ordlineitem.orderwidth);
            net_sendprepint(ref idx,ordlineitem.ordlineitemidx);
            net_sendprepstr(ref idx,ordlineitem.part,ordlineitem.partwidth);
            net_sendprepdbl(ref idx,ordlineitem.ordlinquantity);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cadd_ordlineitem",1007,ret,ERM_CLI_SENDINPUTS);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Recv return code                                                      */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cadd_ordlineitem",1008,ret,ERM_CLI_RECVRETCODE);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out apiret);

            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            return(apiret);
        }

        [SecuritySafeCritical]
        public int cdel_ordlineitem(rcon_s con, ordlineitem_s ordlineitem)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mdel_ordlineitem(con, ordlineitem);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mdel_ordlineitem(rcon_s con, ordlineitem_s ordlineitem)
        {
            int idx;
            int ret;
            int apiret;

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx,COMMAND_DEL_ORDLINEITEM);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cdel_ordlineitem",1012,ret,ERM_CLI_SENDREQCODE);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Send inputs                                                           */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepstr(ref idx,ordlineitem.order,ordlineitem.orderwidth);
            net_sendprepint(ref idx,ordlineitem.ordlineitemidx);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cdel_ordlineitem",1013,ret,ERM_CLI_SENDINPUTS);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Recv return code                                                      */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cdel_ordlineitem",1014,ret,ERM_CLI_RECVRETCODE);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out apiret);

            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            return(apiret);
        }

        [SecuritySafeCritical]
        public int cini_ordwaithrs(rcon_s con, out ordwaithrs_s ordwaithrs)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mini_ordwaithrs(con, out ordwaithrs);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mini_ordwaithrs(rcon_s con, out ordwaithrs_s ordwaithrs)
        {
            int idx;
            int ret;

            ordwaithrs = new ordwaithrs_s();

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx,COMMAND_INI_ORDWAITHRS);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cini_ordwaithrs",1000,ret,ERM_CLI_SENDREQCODE);
                return(ERR_NETW);
            }
            
            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock,idx)) < 0) 
            {
                logclierr("cini_ordwaithrs",1001,ret,ERM_CLI_RECVOUTPUTS);
                return(ERR_NETW);
            }


            idx = 0;
            net_recvpostint(ref idx, out ordwaithrs.orderwidth);
            net_recvpostint(ref idx, out ordwaithrs.ordwaitpartwidth);
            net_recvpostint(ref idx, out ordwaithrs.ordwaitoperwidth);
            net_recvpostint(ref idx, out ordwaithrs.ordwaitmtlwidth);
            net_recvpostint(ref idx, out ordwaithrs.ordwaitcatwidth);

            net_recvpostint(ref idx, out ordwaithrs.depth);
            net_recvpostint(ref idx, out ordwaithrs.inuse);

            return(1);
        }

        [SecuritySafeCritical]
        public int cget_ordwaithrs(rcon_s con, ref ordwaithrs_s ordwaithrs)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mget_ordwaithrs(con, ref ordwaithrs);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mget_ordwaithrs(rcon_s con, ref ordwaithrs_s ordwaithrs)
        {
            int idx;
            int ret;
            int apiret;
            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx,COMMAND_GET_ORDWAITHRS);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cget_ordwaithrs",1002,ret,ERM_CLI_SENDREQCODE);
                return(ERR_NETW);
            }

            /*-----------------------------------------------------------------------*/
            /* Send inputs                                                           */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepstr(ref idx,ordwaithrs.order,ordwaithrs.orderwidth);
            net_sendprepint(ref idx,ordwaithrs.ordwaithrsidx);

            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cget_ordwaithrs",1003,ret,ERM_CLI_SENDINPUTS);
                return(ERR_NETW);
            }

            /*-----------------------------------------------------------------------*/
            /* Recv return code                                                      */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);

            if ((ret = net_recv(con.sock,idx)) < 0)
            {

                logclierr("cget_ordwaithrs",1004,ret,ERM_CLI_RECVRETCODE);
                return(ERR_NETW);
            }
            idx = 0;
         
            net_recvpostint(ref idx, out apiret);

            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepdbl(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepstr(ref idx,ordwaithrs.ordwaitpartwidth);
            net_recvprepstr(ref idx,ordwaithrs.ordwaitoperwidth);
            net_recvprepstr(ref idx,ordwaithrs.ordwaitmtlwidth);
            net_recvprepstr(ref idx,ordwaithrs.ordwaitcatwidth);


            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cget_ordwaithrs",1005,ret,ERM_CLI_RECVOUTPUTS);
                return(ERR_NETW);
            }


            idx = 0;
            net_recvpostdbl(ref idx, out ordwaithrs.ordwaithrs);
            net_recvpostint(ref idx, out ordwaithrs.ordwaitflags);
            net_recvpostint(ref idx, out ordwaithrs.ordwaittag);
            net_recvpoststr(ref idx, out ordwaithrs.ordwaitpart, ordwaithrs.ordwaitpartwidth);
            net_recvpoststr(ref idx, out ordwaithrs.ordwaitoper, ordwaithrs.ordwaitoperwidth);
            net_recvpoststr(ref idx, out ordwaithrs.ordwaitmtl, ordwaithrs.ordwaitmtlwidth);
            net_recvpoststr(ref idx, out ordwaithrs.ordwaitcat, ordwaithrs.ordwaitcatwidth);


            return(apiret);
        }

        [SecuritySafeCritical]
        public int cini_part(rcon_s con, out part_s part)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mini_part(con, out part);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mini_part(rcon_s con, out part_s part)
        {
            int idx;
            int ret;

            part = new part_s();

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx,COMMAND_INI_PART);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cini_part",1000,ret,ERM_CLI_SENDREQCODE);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cini_part",1001,ret,ERM_CLI_RECVOUTPUTS);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out part.partwidth);
            net_recvpostint(ref idx, out part.prtacqshiftwidth);
            net_recvpostint(ref idx, out part.depth);
            net_recvpostint(ref idx, out part.inuse);
            return(1);
        }

        [SecuritySafeCritical]
        public int cget_part(rcon_s con, ref part_s part)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mget_part(con, ref part);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mget_part(rcon_s con, ref part_s part)
        {
            int idx;
            int ret;
            int apiret;

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx,COMMAND_GET_PART);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cget_part",1002,ret,ERM_CLI_SENDREQCODE);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Send inputs                                                           */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepstr(ref idx,part.part,part.partwidth);
            net_sendprepint(ref idx,part.sort);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cget_part",1003,ret,ERM_CLI_SENDINPUTS);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Recv return code                                                      */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cget_part",1004,ret,ERM_CLI_RECVRETCODE);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out apiret);

            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepstr(ref idx,part.partwidth);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepdbl(ref idx);
            net_recvprepdbl(ref idx);
            net_recvprepdbl(ref idx);
            net_recvprepdbl(ref idx);
            net_recvprepdbl(ref idx);
            net_recvprepdbl(ref idx);
            net_recvprepdbl(ref idx);
            net_recvprepdbl(ref idx);
            net_recvprepdbl(ref idx);
            net_recvprepdbl(ref idx);
            net_recvprepdbl(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepdbl(ref idx);
            net_recvprepdbl(ref idx);
            net_recvprepdbl(ref idx);
            net_recvprepstr(ref idx,part.prtacqshiftwidth);
            net_recvprepint(ref idx);
            net_recvprepdbl(ref idx);
            net_recvprepdbl(ref idx);
            net_recvprepdbl(ref idx);
            net_recvprepint(ref idx); // prtepodate
            net_recvprepint(ref idx); // prtlowlevel
            net_recvprepint(ref idx); // prtssdate
            net_recvprepint(ref idx); // prtdayssupply
            net_recvprepint(ref idx); // prtpotolin
            net_recvprepint(ref idx); // prtpotolout
            net_recvprepint(ref idx); // prtjobtolin
            net_recvprepint(ref idx); // prtjobtolout
            net_recvprepint(ref idx); // prtpurule
            net_recvprepdbl(ref idx); // prtpuvalue
            net_recvprepdbl(ref idx); // prtinheritedss
            if ((ret = net_recv(con.sock, idx)) < 0)
            {
                logclierr("cget_part",1005,ret,ERM_CLI_RECVOUTPUTS);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpoststr(ref idx, out part.part, part.partwidth);
            net_recvpostint(ref idx, out part.prtflags);
            net_recvpostint(ref idx, out part.prtcategory);
            net_recvpostint(ref idx, out part.prtprecision);
            net_recvpostdbl(ref idx, out part.prtminimum);
            net_recvpostdbl(ref idx, out part.prtmultiple);
            net_recvpostdbl(ref idx, out part.prtmax);
            net_recvpostdbl(ref idx, out part.prtfleadtime);
            net_recvpostdbl(ref idx, out part.prtvleadtime);
            net_recvpostdbl(ref idx, out part.prthorizon);
            net_recvpostdbl(ref idx, out part.prtlosspercent);
            net_recvpostdbl(ref idx, out part.prtlossquantity);
            net_recvpostdbl(ref idx, out part.prtsafetystock);
            net_recvpostdbl(ref idx, out part.prtinitinventory);
            net_recvpostdbl(ref idx, out part.prtcurrinventory);
            net_recvpostint(ref idx, out part.prtattid_l);
            net_recvpostint(ref idx, out part.prt22rte_l);
            net_recvpostint(ref idx, out part.prt22bom_l);
            net_recvpostint(ref idx, out part.prt22mpn_l);
            net_recvpostint(ref idx, out part.prt22prtg_l);
            net_recvpostint(ref idx, out part.prtaltpart_l);
            net_recvpostint(ref idx, out part.prt22whs_l);
            net_recvpostdbl(ref idx, out part.prtsupplytol);
            net_recvpostdbl(ref idx, out part.prtexpfleadtime);
            net_recvpostdbl(ref idx, out part.prtexpvleadtime);
            net_recvpoststr(ref idx, out part.prtacqshift,part.prtacqshiftwidth);
            net_recvpostint(ref idx, out part.prttfrule);
            net_recvpostdbl(ref idx, out part.prttfvalue);
            net_recvpostdbl(ref idx, out part.prtmoveinlimit);
            net_recvpostdbl(ref idx, out part.prtmoveoutlimit);
            net_recvpostint(ref idx, out part.prtepodate);
            net_recvpostint(ref idx, out part.prtlowlevel);
            net_recvpostint(ref idx, out part.prtssdate);
            net_recvpostint(ref idx, out part.prtdayssupply);
            net_recvpostint(ref idx, out part.prtpotolin);
            net_recvpostint(ref idx, out part.prtpotolout);
            net_recvpostint(ref idx, out part.prtjobtolin);
            net_recvpostint(ref idx, out part.prtjobtolout);
    	    net_recvpostint(ref idx, out part.prtpurule);
            net_recvpostdbl(ref idx, out part.prtpuvalue);
            net_recvpostdbl(ref idx, out part.prtinheritedss);
            return (apiret);
        }

        [SecuritySafeCritical]
        public int cini_resource(rcon_s con, out resource_s resource)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mini_resource(con, out resource);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mini_resource(rcon_s con, out resource_s resource)
        {
            int idx;
            int ret;

            resource = new resource_s();

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx,COMMAND_INI_RESOURCE);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cini_resource",1000,ret,ERM_CLI_SENDREQCODE);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cini_resource",1001,ret,ERM_CLI_RECVOUTPUTS);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out resource.resourcewidth);
            net_recvpostint(ref idx, out resource.depth);
            net_recvpostint(ref idx, out resource.inuse);
            return(1);
        }

        [SecuritySafeCritical]
        public int cget_resource(rcon_s con, ref resource_s resource)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mget_resource(con, ref resource);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mget_resource(rcon_s con, ref resource_s resource)
        {
            int idx;
            int ret;
            int apiret;

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx,COMMAND_GET_RESOURCE);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cget_resource",1002,ret,ERM_CLI_SENDREQCODE);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Send inputs                                                           */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepstr(ref idx,resource.resource,resource.resourcewidth);
            net_sendprepint(ref idx,resource.sort);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cget_resource",1003,ret,ERM_CLI_SENDINPUTS);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Recv return code                                                      */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cget_resource",1004,ret,ERM_CLI_RECVRETCODE);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out apiret);

            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepstr(ref idx,resource.resourcewidth);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cget_resource",1005,ret,ERM_CLI_RECVOUTPUTS);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpoststr(ref idx, out resource.resource, resource.resourcewidth);
            net_recvpostint(ref idx, out resource.resflags);
            net_recvpostint(ref idx, out resource.resattid_l);
            net_recvpostint(ref idx, out resource.respairvio_l);
            net_recvpostint(ref idx, out resource.ressendvio_l);
            net_recvpostint(ref idx, out resource.res22shf_l);
            net_recvpostint(ref idx, out resource.res22opn_l);
            return(apiret);
        }

        [SecuritySafeCritical]
        public int cini_cat22res(rcon_s con, out cat22res_s cat22res)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mini_cat22res(con, out cat22res);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mini_cat22res(rcon_s con, out cat22res_s cat22res)
        {
            int idx;
            int ret;

            cat22res = new cat22res_s();

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx, COMMAND_INI_CAT22RES);
            if ((ret = net_send(con.sock, idx)) < 0)
            {
                logclierr("cini_cat22res", 1000, ret, ERM_CLI_SENDREQCODE);
                return (ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock, idx)) < 0)
            {
                logclierr("cini_cat22res", 1001, ret, ERM_CLI_RECVOUTPUTS);
                return (ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out cat22res.categorywidth);
            net_recvpostint(ref idx, out cat22res.resourcewidth);
            net_recvpostint(ref idx, out cat22res.depth);
            net_recvpostint(ref idx, out cat22res.inuse);
            return (1);
        }

        [SecuritySafeCritical]
        public int cget_cat22res(rcon_s con, ref cat22res_s cat22res)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mget_cat22res(con, ref cat22res);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mget_cat22res(rcon_s con, ref cat22res_s cat22res)
        {
            int idx;
            int ret;
            int apiret;

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx, COMMAND_GET_CAT22RES);
            if ((ret = net_send(con.sock, idx)) < 0)
            {
                logclierr("cget_cat22res", 1002, ret, ERM_CLI_SENDREQCODE);
                return (ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Send inputs                                                           */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepstr(ref idx, cat22res.category, cat22res.categorywidth);
            net_sendprepint(ref idx, cat22res.cat22residx);
            if ((ret = net_send(con.sock, idx)) < 0)
            {
                logclierr("cget_cat22res", 1003, ret, ERM_CLI_SENDINPUTS);
                return (ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Recv return code                                                      */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock, idx)) < 0)
            {
                logclierr("cget_cat22res", 1004, ret, ERM_CLI_RECVRETCODE);
                return (ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out apiret);

            /*-----------------------------------------------------------------------*/
            /* Recv outputs                                                          */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepstr(ref idx, cat22res.resourcewidth);
            if ((ret = net_recv(con.sock, idx)) < 0)
            {
                logclierr("cget_cat22res", 1005, ret, ERM_CLI_RECVOUTPUTS);
                return (ERR_NETW);
            }
            idx = 0;
            net_recvpoststr(ref idx, out cat22res.resource, cat22res.resourcewidth);
            return (apiret);
        }

        [SecuritySafeCritical]
        public int cnew_testdb(rcon_s con)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mnew_testdb(con);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mnew_testdb(rcon_s con)
        {
            int idx;
            int ret;
            int apiret;

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx,COMMAND_NEW_TESTDB);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cnew_testdb",1000,ret,ERM_CLI_SENDREQCODE);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Recv return code                                                      */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cnew_testdb",1001,ret,ERM_CLI_RECVRETCODE);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out apiret);

            return(apiret);
        }

        [SecuritySafeCritical]
        public int cdel_testdb(rcon_s con)
        {
            PermissionSet ft = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            ft.Assert();

            int ret = mdel_testdb(con);

            PermissionSet.RevertAssert();

            return (ret);
        }

        [SecurityCritical]
        private int mdel_testdb(rcon_s con)
        {
            int idx;
            int ret;
            int apiret;

            /*-----------------------------------------------------------------------*/
            /* Send request code                                                     */
            /*-----------------------------------------------------------------------*/
            net_sendprepstart(out idx);
            net_sendprepint(ref idx,COMMAND_DEL_TESTDB);
            if ((ret = net_send(con.sock,idx)) < 0)
            {
                logclierr("cdel_testdb",1004,ret,ERM_CLI_SENDREQCODE);
                return(ERR_NETW);
            }
            /*-----------------------------------------------------------------------*/
            /* Recv return code                                                      */
            /*-----------------------------------------------------------------------*/
            net_recvprepstart(out idx);
            net_recvprepint(ref idx);
            if ((ret = net_recv(con.sock,idx)) < 0)
            {
                logclierr("cdel_testdb",1005,ret,ERM_CLI_RECVRETCODE);
                return(ERR_NETW);
            }
            idx = 0;
            net_recvpostint(ref idx, out apiret);

            return(apiret);
        }

        private int erdb2j(string sTime)
        /*----------------------------------------------------------------------
            Function to convert an ERDB datetime string into a julian 
            date and time.
            RETURNS:
            The julian date and time.
        ----------------------------------------------------------------------*/
        {
            int y, mo, d, h, mi, s;

            erdb2di(sTime, out y, out mo, out d, out h, out mi, out s);

            if (sTime.Substring(0, 4) == "----")
                return(di2j(y, mo, d+1, h, mi, s));
            else
                return(di2j(y, mo, d, h, mi, s));
        }

        private void erdb2di(string sTime, out int y, out int mo, out int d, out int h, out int mi, out int s)
        /*----------------------------------------------------------------------
            Function to convert an ERDB datetime string into date and time
            integers.
            RETURNS: VOID.
        ----------------------------------------------------------------------*/
        {
            string year, mon, day, hour, min, sec;

            year = sTime.Substring(0, 2);
            mon = sTime.Substring(2, 2);
            day = sTime.Substring(4, 2);
            hour = sTime.Substring(7, 2);
            min = sTime.Substring(9, 2);
            sec = sTime.Substring(11, 2);

            if (year == "--")
            {
                y  = 70;
            }
            else
            {
                y  = int.Parse(year);
            }
            if (mon == "--")
            {
                mo = 1;
            }
            else
            {
                mo = int.Parse(mon);
            }
            d  = int.Parse(day);
            h  = int.Parse(hour);
            mi = int.Parse(min);
            s  = int.Parse(sec);

            if (y < 70)
                y += 2000;
            else
                y += 1900;

            if (y > 2037)
            {
                y = 2038;
                mo = d = 1;
                h = mi = s = 0;
            }
        }

        private const int SECS_PER_DAY = 86400;

        private int[] days_per_year = {
            365, 365, 366, 365, 365, 365, 366, 365, 365, 365, 366, 365,
            365, 365, 366, 365, 365, 365, 366, 365, 365, 365, 366, 365,
            365, 365, 366, 365, 365, 365, 366, 365, 365, 365, 366, 365,
            365, 365, 366, 365, 365, 365, 366, 365, 365, 365, 366, 365,
            365, 365, 366, 365, 365, 365, 366, 365, 365, 365, 366, 365,
            365, 365, 366, 365, 365, 365, 366, 365, 365 };

        private const int days_to_year_2000 = 365*23 + 366*7;

        private int di2j(int y, int mo, int d, int h, int mi, int s)
        /*----------------------------------------------------------------------
            Function to convert date and time integers into a julian
            date and time.
            RETURNS:
            The julian date and time.
        ----------------------------------------------------------------------*/
        {
            int year;
            int j;

            j = 0;

            /* Validate year. */

            if (y < 1970)
            {
                y = 1970;
                mo = d = 1;
                h = mi = s = 0;
            }
            else if (y > 2037)
            {
                y = 2038;
                mo = d = 1;
                h = mi = s = 0;
            }

            /* Add in complete years. */

            if (y > 2000)
            {
                year = 2000;
                j += days_to_year_2000 * SECS_PER_DAY;
            }
            else
            {
                year = 1970;
            }

            for (; year < y; year++)
            {
                j += days_per_year[year-1970] * SECS_PER_DAY;
            }

            /* Add in complete days in this year. */

            j += yearday(((y % 4) == 0), mo, d) * SECS_PER_DAY;

            /* Add in hours, minutes, and seconds. */

            j += h * 3600;
            j += mi * 60;
            j += s;

            return(j);
        }

        private int[] mdays = 
            { 0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334 };

        private int[] mdays_leap =
            { 0, 31, 60, 91, 121, 152, 182, 213, 244, 274, 305, 335 };

        private int yearday(bool leap, int m, int d)
        /*----------------------------------------------------------------------
            Function to return the day of the year (0-365) given the month
            (1-12), day of the month (1-31) and whether or not this is a
            leap year.
        ----------------------------------------------------------------------*/
        {
            /* Adjust day and month to be relative to zero. */

            --d; --m;

            /* Make sure month is in range for index. */

            if (m < 0 || m > 11)
                m = 0;

            /* Add days in completed months to days seen in this month. */

            if (leap)
            {
                d += mdays_leap[m];
            }
            else
            {
                d += mdays[m];
            }

            /* Return day of year. */

            return(d);
        }

        private const int NSTRBUF = 16;      /* Number of string buffers available. */

        private string[] buff = new string[NSTRBUF];
        private int bufidx = 0;

        private string j2erdb(int j)
        /*---------------------------------------------------------------------- 
            Function to convert a julian date and time into an ERDB datetime
            string (YYMMDD.hhmmss).
            NOTES:
            * This function has NSTRBUF internal string buffers.  If you 
              call this function more than NSTRBUF times during a program,
              (or function call), the strings returned by earlier calls, 
              will be overwritten. 
            RETURNS:
            A pointer to the date and time string.
        ----------------------------------------------------------------------*/
        {
            int y, mo, d, h, mi, s;

            bufidx = (bufidx+1) % NSTRBUF;

            j2di(j, out y, out mo, out d, out h, out mi, out s);

            y = y % 100;

            buff[bufidx] = y.ToString("00") + mo.ToString("00") + d.ToString("00") + "." +
                           h.ToString("00") + mi.ToString("00") + s.ToString("00");

            return(buff[bufidx]);
        }

        private void j2di(int j, out int y, out int mo, out int d, out int h, out int mi, out int s)
        /*----------------------------------------------------------------------
            Function to convert a julian date and time into date 
            and time integers.
            RETURNS: VOID.
        ----------------------------------------------------------------------*/
        {
            int year;
            int days, time;

            if (j < 0)
                j = 0;

            days = j / SECS_PER_DAY;
            time = j % SECS_PER_DAY;

            if (days > days_to_year_2000)
            {
                year = 2000;
                days -= days_to_year_2000;
            }
            else
            {
                year = 1970;
            }

            for (; year <= 2038; year++)
            {
                if (days < days_per_year[year - 1970])
                    break;
                days -= days_per_year[year - 1970];
            }

            /* Set year. */

            y = year;

            /* Set month and day. */

            monthday(((year % 4) == 0), days, out mo, out d);

            /* Set hours, minutes, and seconds. */

            h = (int)(time / 3600);
            time -= h * 3600;

            mi = (int)(time / 60);
            time -= mi * 60;

            s = (int)time;
        }

        private void monthday(bool leap, int yd, out int m, out int d)
        /*----------------------------------------------------------------------
            Function to return the month (1-12) and day of the month (1-31)
            given the day of the year (0-365) and whether or not this is a
            leap year.
        ----------------------------------------------------------------------*/
        {
            int i;

            /* Find month (break is to prevent index error in case of negative yd). */

            for (i = 11; i > 0; --i)
            {
                if (leap)
                {
                    if (yd >= mdays_leap[i])
                        break;
                }
                else
                {
                    if (yd >= mdays[i])
                        break;
                }
            }

            /* Subtract off cumulative days for month. */

            if (leap)
            {
                yd -= mdays_leap[i];
            }
            else
            {
                yd -= mdays[i];
            }

            /* Set month and day of month. */

            m = ++i;
            d = (int) ++yd;
        }

    }
}
