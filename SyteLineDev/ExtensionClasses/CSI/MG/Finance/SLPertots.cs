//PROJECT NAME: FinanceExt
//CLASS NAME: SLPertots.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Finance;
using CSI.MG;
using System.Runtime.InteropServices;
using OfficeIntegration = CSI.ExternalContracts.OfficeIntegration.Excel;
using CSI.Data.RecordSets;

namespace CSI.MG.Finance
{
	[IDOExtensionClass("SLPertots")]
	public class SLPertots : CSIExtensionClassBase, OfficeIntegration.ISLPertots
    {		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ExcelSyteLineGLBatchSqlSp([Optional] ref string Parms1,
		                                     [Optional] ref string Parms2,
		                                     [Optional] ref string Parms3,
		                                     [Optional] ref string Parms4,
		                                     [Optional] ref string Parms5,
		                                     [Optional] ref string Parms6,
		                                     [Optional] ref string Parms7,
		                                     [Optional] ref string Parms8,
		                                     [Optional] ref string Parms9,
		                                     [Optional] ref string Parms10,
		                                     [Optional] ref string Parms11,
		                                     [Optional] ref string Parms12,
		                                     [Optional] ref string Parms13,
		                                     [Optional] ref string Parms14,
		                                     [Optional] ref string Parms15,
		                                     [Optional] ref string Parms16,
		                                     [Optional] ref string Parms17,
		                                     [Optional] ref string Parms18,
		                                     [Optional] ref string Parms19,
		                                     [Optional] ref string Parms20,
		                                     [Optional] ref string Parms21,
		                                     [Optional] ref string Parms22,
		                                     [Optional] ref string Parms23,
		                                     [Optional] ref string Parms24,
		                                     [Optional] ref string Parms25,
		                                     [Optional] ref string Parms26,
		                                     [Optional] ref string Parms27,
		                                     [Optional] ref string Parms28,
		                                     [Optional] ref string Parms29,
		                                     [Optional] ref string Parms30,
		                                     [Optional] ref string Parms31,
		                                     [Optional] ref string Parms32,
		                                     [Optional] ref string Parms33,
		                                     [Optional] ref string Parms34,
		                                     [Optional] ref string Parms35,
		                                     [Optional] ref string Parms36,
		                                     [Optional] ref string Parms37,
		                                     [Optional] ref string Parms38,
		                                     [Optional] ref string Parms39,
		                                     [Optional] ref string Parms40,
		                                     [Optional] ref string Parms41,
		                                     [Optional] ref string Parms42,
		                                     [Optional] ref string Parms43,
		                                     [Optional] ref string Parms44,
		                                     [Optional] ref string Parms45,
		                                     [Optional] ref string Parms46,
		                                     [Optional] ref string Parms47,
		                                     [Optional] ref string Parms48,
		                                     [Optional] ref string Parms49,
		                                     [Optional] ref string Parms50,
		                                     [Optional] ref string Parms51,
		                                     [Optional] ref string Parms52,
		                                     [Optional] ref string Parms53,
		                                     [Optional] ref string Parms54,
		                                     [Optional] ref string Parms55,
		                                     [Optional] ref string Parms56,
		                                     [Optional] ref string Parms57,
		                                     [Optional] ref string Parms58,
		                                     [Optional] ref string Parms59,
		                                     [Optional] ref string Parms60,
		                                     [Optional] ref string Parms61,
		                                     [Optional] ref string Parms62,
		                                     [Optional] ref string Parms63,
		                                     [Optional] ref string Parms64,
		                                     [Optional] ref string Parms65,
		                                     [Optional] ref string Parms66,
		                                     [Optional] ref string Parms67,
		                                     [Optional] ref string Parms68,
		                                     [Optional] ref string Parms69,
		                                     [Optional] ref string Parms70,
		                                     [Optional] ref string Parms71,
		                                     [Optional] ref string Parms72,
		                                     [Optional] ref string Parms73,
		                                     [Optional] ref string Parms74,
		                                     [Optional] ref string Parms75,
		                                     [Optional] ref string Parms76,
		                                     [Optional] ref string Parms77,
		                                     [Optional] ref string Parms78,
		                                     [Optional] ref string Parms79,
		                                     [Optional] ref string Parms80,
		                                     [Optional] ref string Parms81,
		                                     [Optional] ref string Parms82,
		                                     [Optional] ref string Parms83,
		                                     [Optional] ref string Parms84,
		                                     [Optional] ref string Parms85,
		                                     [Optional] ref string Parms86,
		                                     [Optional] ref string Parms87,
		                                     [Optional] ref string Parms88,
		                                     [Optional] ref string Parms89,
		                                     [Optional] ref string Parms90,
		                                     [Optional] ref string Parms91,
		                                     [Optional] ref string Parms92,
		                                     [Optional] ref string Parms93,
		                                     [Optional] ref string Parms94,
		                                     [Optional] ref string Parms95,
		                                     [Optional] ref string Parms96,
		                                     [Optional] ref string Parms97,
		                                     [Optional] ref string Parms98,
		                                     [Optional] ref string Parms99,
		                                     [Optional] ref string Parms100,
		                                     [Optional] ref string Parms101,
		                                     [Optional] ref string Parms102,
		                                     [Optional] ref string Parms103,
		                                     [Optional] ref string Parms104,
		                                     [Optional] ref string Parms105,
		                                     [Optional] ref string Parms106,
		                                     [Optional] ref string Parms107,
		                                     [Optional] ref string Parms108,
		                                     [Optional] ref string Parms109,
		                                     [Optional] ref string Parms110,
		                                     [Optional] ref string Parms111,
		                                     [Optional] ref string Parms112,
		                                     [Optional] ref string Parms113,
		                                     [Optional] ref string Parms114,
		                                     [Optional] ref string Parms115,
		                                     [Optional] ref string Parms116,
		                                     [Optional] ref string Parms117,
		                                     [Optional] ref string Parms118,
		                                     [Optional] ref string Parms119,
		                                     [Optional] ref string Parms120,
		                                     [Optional] ref string Parms121,
		                                     [Optional] ref string Parms122,
		                                     [Optional] ref string Parms123,
		                                     [Optional] ref string Parms124,
		                                     [Optional] ref string Parms125,
		                                     [Optional] ref string Parms126,
		                                     [Optional] ref string Parms127,
		                                     [Optional] ref string Parms128,
		                                     [Optional] ref string Parms129,
		                                     [Optional] ref string Parms130,
		                                     [Optional] ref string Parms131,
		                                     [Optional] ref string Parms132,
		                                     [Optional] ref string Parms133,
		                                     [Optional] ref string Parms134,
		                                     [Optional] ref string Parms135,
		                                     [Optional] ref string Parms136,
		                                     [Optional] ref string Parms137,
		                                     [Optional] ref string Parms138,
		                                     [Optional] ref string Parms139,
		                                     [Optional] ref string Parms140,
		                                     [Optional] ref string Parms141,
		                                     [Optional] ref string Parms142,
		                                     [Optional] ref string Parms143,
		                                     [Optional] ref string Parms144,
		                                     [Optional] ref string Parms145,
		                                     [Optional] ref string Parms146,
		                                     [Optional] ref string Parms147,
		                                     [Optional] ref string Parms148,
		                                     [Optional] ref string Parms149,
		                                     [Optional] ref string Parms150,
		                                     [Optional] ref string Parms151,
		                                     [Optional] ref string Parms152,
		                                     [Optional] ref string Parms153,
		                                     [Optional] ref string Parms154,
		                                     [Optional] ref string Parms155,
		                                     [Optional] ref string Parms156,
		                                     [Optional] ref string Parms157,
		                                     [Optional] ref string Parms158,
		                                     [Optional] ref string Parms159,
		                                     [Optional] ref string Parms160,
		                                     [Optional] ref string Parms161,
		                                     [Optional] ref string Parms162,
		                                     [Optional] ref string Parms163,
		                                     [Optional] ref string Parms164,
		                                     [Optional] ref string Parms165,
		                                     [Optional] ref string Parms166,
		                                     [Optional] ref string Parms167,
		                                     [Optional] ref string Parms168,
		                                     [Optional] ref string Parms169,
		                                     [Optional] ref string Parms170,
		                                     [Optional] ref string Parms171,
		                                     [Optional] ref string Parms172,
		                                     [Optional] ref string Parms173,
		                                     [Optional] ref string Parms174,
		                                     [Optional] ref string Parms175,
		                                     [Optional] ref string Parms176,
		                                     [Optional] ref string Parms177,
		                                     [Optional] ref string Parms178,
		                                     [Optional] ref string Parms179,
		                                     [Optional] ref string Parms180,
		                                     [Optional] ref string Parms181,
		                                     [Optional] ref string Parms182,
		                                     [Optional] ref string Parms183,
		                                     [Optional] ref string Parms184,
		                                     [Optional] ref string Parms185,
		                                     [Optional] ref string Parms186,
		                                     [Optional] ref string Parms187,
		                                     [Optional] ref string Parms188,
		                                     [Optional] ref string Parms189,
		                                     [Optional] ref string Parms190,
		                                     [Optional] ref string Parms191,
		                                     [Optional] ref string Parms192,
		                                     [Optional] ref string Parms193,
		                                     [Optional] ref string Parms194,
		                                     [Optional] ref string Parms195,
		                                     [Optional] ref string Parms196,
		                                     [Optional] ref string Parms197,
		                                     [Optional] ref string Parms198,
		                                     [Optional] ref string Parms199,
		                                     [Optional] ref string Parms200,
		                                     [Optional] ref string Parms201,
		                                     [Optional] ref string Parms202,
		                                     [Optional] ref string Parms203,
		                                     [Optional] ref string Parms204,
		                                     [Optional] ref string Parms205,
		                                     [Optional] ref string Parms206,
		                                     [Optional] ref string Parms207,
		                                     [Optional] ref string Parms208,
		                                     [Optional] ref string Parms209,
		                                     [Optional] ref string Parms210,
		                                     [Optional] ref string Parms211,
		                                     [Optional] ref string Parms212,
		                                     [Optional] ref string Parms213,
		                                     [Optional] ref string Parms214,
		                                     [Optional] ref string Parms215,
		                                     [Optional] ref string Parms216,
		                                     [Optional] ref string Parms217,
		                                     [Optional] ref string Parms218,
		                                     [Optional] ref string Parms219,
		                                     [Optional] ref string Parms220,
		                                     [Optional] ref string Parms221,
		                                     [Optional] ref string Parms222,
		                                     [Optional] ref string Parms223,
		                                     [Optional] ref string Parms224,
		                                     [Optional] ref string Parms225,
		                                     [Optional] ref string Parms226,
		                                     [Optional] ref string Parms227,
		                                     [Optional] ref string Parms228,
		                                     [Optional] ref string Parms229,
		                                     [Optional] ref string Parms230,
		                                     [Optional] ref string Parms231,
		                                     [Optional] ref string Parms232,
		                                     [Optional] ref string Parms233,
		                                     [Optional] ref string Parms234,
		                                     [Optional] ref string Parms235,
		                                     [Optional] ref string Parms236,
		                                     [Optional] ref string Parms237,
		                                     [Optional] ref string Parms238,
		                                     [Optional] ref string Parms239,
		                                     [Optional] ref string Parms240,
		                                     [Optional] ref string Parms241,
		                                     [Optional] ref string Parms242,
		                                     [Optional] ref string Parms243,
		                                     [Optional] ref string Parms244,
		                                     [Optional] ref string Parms245,
		                                     [Optional] ref string Parms246,
		                                     [Optional] ref string Parms247,
		                                     [Optional] ref string Parms248,
		                                     [Optional] ref string Parms249,
		                                     [Optional] ref string Parms250,
		                                     [Optional] ref string Parms251,
		                                     [Optional] ref string Parms252,
		                                     [Optional] ref string Parms253,
		                                     [Optional] ref string Parms254,
		                                     [Optional] ref string Parms255,
		                                     [Optional] ref string Parms256,
		                                     [Optional] ref string Parms257,
		                                     [Optional] ref string Parms258,
		                                     [Optional] ref string Parms259,
		                                     [Optional] ref string Parms260,
		                                     [Optional] ref string Parms261,
		                                     [Optional] ref string Parms262,
		                                     [Optional] ref string Parms263,
		                                     [Optional] ref string Parms264,
		                                     [Optional] ref string Parms265,
		                                     [Optional] ref string Parms266,
		                                     [Optional] ref string Parms267,
		                                     [Optional] ref string Parms268,
		                                     [Optional] ref string Parms269,
		                                     [Optional] ref string Parms270,
		                                     [Optional] ref string Parms271,
		                                     [Optional] ref string Parms272,
		                                     [Optional] ref string Parms273,
		                                     [Optional] ref string Parms274,
		                                     [Optional] ref string Parms275,
		                                     [Optional] ref string Parms276,
		                                     [Optional] ref string Parms277,
		                                     [Optional] ref string Parms278,
		                                     [Optional] ref string Parms279,
		                                     [Optional] ref string Parms280,
		                                     [Optional] ref string Parms281,
		                                     [Optional] ref string Parms282,
		                                     [Optional] ref string Parms283,
		                                     [Optional] ref string Parms284,
		                                     [Optional] ref string Parms285,
		                                     [Optional] ref string Parms286,
		                                     [Optional] ref string Parms287,
		                                     [Optional] ref string Parms288,
		                                     [Optional] ref string Parms289,
		                                     [Optional] ref string Parms290,
		                                     [Optional] ref string Parms291,
		                                     [Optional] ref string Parms292,
		                                     [Optional] ref string Parms293,
		                                     [Optional] ref string Parms294,
		                                     [Optional] ref string Parms295,
		                                     [Optional] ref string Parms296,
		                                     [Optional] ref string Parms297,
		                                     [Optional] ref string Parms298,
		                                     [Optional] ref string Parms299,
		                                     [Optional] ref string Parms300,
		                                     [Optional] ref string Parms301,
		                                     [Optional] ref string Parms302,
		                                     [Optional] ref string Parms303,
		                                     [Optional] ref string Parms304,
		                                     [Optional] ref string Parms305,
		                                     [Optional] ref string Parms306,
		                                     [Optional] ref string Parms307,
		                                     [Optional] ref string Parms308,
		                                     [Optional] ref string Parms309,
		                                     [Optional] ref string Parms310,
		                                     [Optional] ref string Parms311,
		                                     [Optional] ref string Parms312,
		                                     [Optional] ref string Parms313,
		                                     [Optional] ref string Parms314,
		                                     [Optional] ref string Parms315,
		                                     [Optional] ref string Parms316,
		                                     [Optional] ref string Parms317,
		                                     [Optional] ref string Parms318,
		                                     [Optional] ref string Parms319,
		                                     [Optional] ref string Parms320,
		                                     [Optional] ref string Parms321,
		                                     [Optional] ref string Parms322,
		                                     [Optional] ref string Parms323,
		                                     [Optional] ref string Parms324,
		                                     [Optional] ref string Parms325,
		                                     [Optional] ref string Parms326,
		                                     [Optional] ref string Parms327,
		                                     [Optional] ref string Parms328,
		                                     [Optional] ref string Parms329,
		                                     [Optional] ref string Parms330,
		                                     [Optional] ref string Parms331,
		                                     [Optional] ref string Parms332,
		                                     [Optional] ref string Parms333,
		                                     [Optional] ref string Parms334,
		                                     [Optional] ref string Parms335,
		                                     [Optional] ref string Parms336,
		                                     [Optional] ref string Parms337,
		                                     [Optional] ref string Parms338,
		                                     [Optional] ref string Parms339,
		                                     [Optional] ref string Parms340,
		                                     [Optional] ref string Parms341,
		                                     [Optional] ref string Parms342,
		                                     [Optional] ref string Parms343,
		                                     [Optional] ref string Parms344,
		                                     [Optional] ref string Parms345,
		                                     [Optional] ref string Parms346,
		                                     [Optional] ref string Parms347,
		                                     [Optional] ref string Parms348,
		                                     [Optional] ref string Parms349,
		                                     [Optional] ref string Parms350,
		                                     [Optional] ref string Parms351,
		                                     [Optional] ref string Parms352,
		                                     [Optional] ref string Parms353,
		                                     [Optional] ref string Parms354,
		                                     [Optional] ref string Parms355,
		                                     [Optional] ref string Parms356,
		                                     [Optional] ref string Parms357,
		                                     [Optional] ref string Parms358,
		                                     [Optional] ref string Parms359,
		                                     [Optional] ref string Parms360,
		                                     [Optional] ref string Parms361,
		                                     [Optional] ref string Parms362,
		                                     [Optional] ref string Parms363,
		                                     [Optional] ref string Parms364,
		                                     [Optional] ref string Parms365,
		                                     [Optional] ref string Parms366,
		                                     [Optional] ref string Parms367,
		                                     [Optional] ref string Parms368,
		                                     [Optional] ref string Parms369,
		                                     [Optional] ref string Parms370,
		                                     [Optional] ref string Parms371,
		                                     [Optional] ref string Parms372,
		                                     [Optional] ref string Parms373,
		                                     [Optional] ref string Parms374,
		                                     [Optional] ref string Parms375,
		                                     [Optional] ref string Parms376,
		                                     [Optional] ref string Parms377,
		                                     [Optional] ref string Parms378,
		                                     [Optional] ref string Parms379,
		                                     [Optional] ref string Parms380,
		                                     [Optional] ref string Parms381,
		                                     [Optional] ref string Parms382,
		                                     [Optional] ref string Parms383,
		                                     [Optional] ref string Parms384,
		                                     [Optional] ref string Parms385,
		                                     [Optional] ref string Parms386,
		                                     [Optional] ref string Parms387,
		                                     [Optional] ref string Parms388,
		                                     [Optional] ref string Parms389,
		                                     [Optional] ref string Parms390,
		                                     [Optional] ref string Parms391,
		                                     [Optional] ref string Parms392,
		                                     [Optional] ref string Parms393,
		                                     [Optional] ref string Parms394,
		                                     [Optional] ref string Parms395,
		                                     [Optional] ref string Parms396,
		                                     [Optional] ref string Parms397,
		                                     [Optional] ref string Parms398,
		                                     [Optional] ref string Parms399,
		                                     [Optional] ref string Parms400,
		                                     [Optional] ref string Parms401,
		                                     [Optional] ref string Parms402,
		                                     [Optional] ref string Parms403,
		                                     [Optional] ref string Parms404,
		                                     [Optional] ref string Parms405,
		                                     [Optional] ref string Parms406,
		                                     [Optional] ref string Parms407,
		                                     [Optional] ref string Parms408,
		                                     [Optional] ref string Parms409,
		                                     [Optional] ref string Parms410,
		                                     [Optional] ref string Parms411,
		                                     [Optional] ref string Parms412,
		                                     [Optional] ref string Parms413,
		                                     [Optional] ref string Parms414,
		                                     [Optional] ref string Parms415,
		                                     [Optional] ref string Parms416,
		                                     [Optional] ref string Parms417,
		                                     [Optional] ref string Parms418,
		                                     [Optional] ref string Parms419,
		                                     [Optional] ref string Parms420,
		                                     [Optional] ref string Parms421,
		                                     [Optional] ref string Parms422,
		                                     [Optional] ref string Parms423,
		                                     [Optional] ref string Parms424,
		                                     [Optional] ref string Parms425,
		                                     [Optional] ref string Parms426,
		                                     [Optional] ref string Parms427,
		                                     [Optional] ref string Parms428,
		                                     [Optional] ref string Parms429,
		                                     [Optional] ref string Parms430,
		                                     [Optional] ref string Parms431,
		                                     [Optional] ref string Parms432,
		                                     [Optional] ref string Parms433,
		                                     [Optional] ref string Parms434,
		                                     [Optional] ref string Parms435,
		                                     [Optional] ref string Parms436,
		                                     [Optional] ref string Parms437,
		                                     [Optional] ref string Parms438,
		                                     [Optional] ref string Parms439,
		                                     [Optional] ref string Parms440,
		                                     [Optional] ref string Parms441,
		                                     [Optional] ref string Parms442,
		                                     [Optional] ref string Parms443,
		                                     [Optional] ref string Parms444,
		                                     [Optional] ref string Parms445,
		                                     [Optional] ref string Parms446,
		                                     [Optional] ref string Parms447,
		                                     [Optional] ref string Parms448,
		                                     [Optional] ref string Parms449,
		                                     [Optional] ref string Parms450,
		                                     [Optional] ref string Parms451,
		                                     [Optional] ref string Parms452,
		                                     [Optional] ref string Parms453,
		                                     [Optional] ref string Parms454,
		                                     [Optional] ref string Parms455,
		                                     [Optional] ref string Parms456,
		                                     [Optional] ref string Parms457,
		                                     [Optional] ref string Parms458,
		                                     [Optional] ref string Parms459,
		                                     [Optional] ref string Parms460,
		                                     [Optional] ref string Parms461,
		                                     [Optional] ref string Parms462,
		                                     [Optional] ref string Parms463,
		                                     [Optional] ref string Parms464,
		                                     [Optional] ref string Parms465,
		                                     [Optional] ref string Parms466,
		                                     [Optional] ref string Parms467,
		                                     [Optional] ref string Parms468,
		                                     [Optional] ref string Parms469,
		                                     [Optional] ref string Parms470,
		                                     [Optional] ref string Parms471,
		                                     [Optional] ref string Parms472,
		                                     [Optional] ref string Parms473,
		                                     [Optional] ref string Parms474,
		                                     [Optional] ref string Parms475,
		                                     [Optional] ref string Parms476,
		                                     [Optional] ref string Parms477,
		                                     [Optional] ref string Parms478,
		                                     [Optional] ref string Parms479,
		                                     [Optional] ref string Parms480,
		                                     [Optional] ref string Parms481,
		                                     [Optional] ref string Parms482,
		                                     [Optional] ref string Parms483,
		                                     [Optional] ref string Parms484,
		                                     [Optional] ref string Parms485,
		                                     [Optional] ref string Parms486,
		                                     [Optional] ref string Parms487,
		                                     [Optional] ref string Parms488,
		                                     [Optional] ref string Parms489,
		                                     [Optional] ref string Parms490,
		                                     [Optional] ref string Parms491,
		                                     [Optional] ref string Parms492,
		                                     [Optional] ref string Parms493,
		                                     [Optional] ref string Parms494,
		                                     [Optional] ref string Parms495,
		                                     [Optional] ref string Parms496,
		                                     [Optional] ref string Parms497,
		                                     [Optional] ref string Parms498,
		                                     [Optional] ref string Parms499,
		                                     [Optional] ref string Parms500,
		                                     [Optional] ref string Parms501,
		                                     [Optional] ref string Parms502,
		                                     [Optional] ref string Parms503,
		                                     [Optional] ref string Parms504,
		                                     [Optional] ref string Parms505,
		                                     [Optional] ref string Parms506,
		                                     [Optional] ref string Parms507,
		                                     [Optional] ref string Parms508,
		                                     [Optional] ref string Parms509,
		                                     [Optional] ref string Parms510,
		                                     [Optional] ref string Parms511,
		                                     [Optional] ref string Parms512,
		                                     [Optional] ref string Parms513,
		                                     [Optional] ref string Parms514,
		                                     [Optional] ref string Parms515,
		                                     [Optional] ref string Parms516,
		                                     [Optional] ref string Parms517,
		                                     [Optional] ref string Parms518,
		                                     [Optional] ref string Parms519,
		                                     [Optional] ref string Parms520,
		                                     [Optional] ref string Parms521,
		                                     [Optional] ref string Parms522,
		                                     [Optional] ref string Parms523,
		                                     [Optional] ref string Parms524,
		                                     [Optional] ref string Parms525,
		                                     [Optional] ref string Parms526,
		                                     [Optional] ref string Parms527,
		                                     [Optional] ref string Parms528,
		                                     [Optional] ref string Parms529,
		                                     [Optional] ref string Parms530,
		                                     [Optional] ref string Parms531,
		                                     [Optional] ref string Parms532,
		                                     [Optional] ref string Parms533,
		                                     [Optional] ref string Parms534,
		                                     [Optional] ref string Parms535,
		                                     [Optional] ref string Parms536,
		                                     [Optional] ref string Parms537,
		                                     [Optional] ref string Parms538,
		                                     [Optional] ref string Parms539,
		                                     [Optional] ref string Parms540,
		                                     [Optional] ref string Parms541,
		                                     [Optional] ref string Parms542,
		                                     [Optional] ref string Parms543,
		                                     [Optional] ref string Parms544,
		                                     [Optional] ref string Parms545,
		                                     [Optional] ref string Parms546,
		                                     [Optional] ref string Parms547,
		                                     [Optional] ref string Parms548,
		                                     [Optional] ref string Parms549,
		                                     [Optional] ref string Parms550,
		                                     [Optional] ref string Parms551,
		                                     [Optional] ref string Parms552,
		                                     [Optional] ref string Parms553,
		                                     [Optional] ref string Parms554,
		                                     [Optional] ref string Parms555,
		                                     [Optional] ref string Parms556,
		                                     [Optional] ref string Parms557,
		                                     [Optional] ref string Parms558,
		                                     [Optional] ref string Parms559,
		                                     [Optional] ref string Parms560,
		                                     [Optional] ref string Parms561,
		                                     [Optional] ref string Parms562,
		                                     [Optional] ref string Parms563,
		                                     [Optional] ref string Parms564,
		                                     [Optional] ref string Parms565,
		                                     [Optional] ref string Parms566,
		                                     [Optional] ref string Parms567,
		                                     [Optional] ref string Parms568,
		                                     [Optional] ref string Parms569,
		                                     [Optional] ref string Parms570,
		                                     [Optional] ref string Parms571,
		                                     [Optional] ref string Parms572,
		                                     [Optional] ref string Parms573,
		                                     [Optional] ref string Parms574,
		                                     [Optional] ref string Parms575,
		                                     [Optional] ref string Parms576,
		                                     [Optional] ref string Parms577,
		                                     [Optional] ref string Parms578,
		                                     [Optional] ref string Parms579,
		                                     [Optional] ref string Parms580,
		                                     [Optional] ref string Parms581,
		                                     [Optional] ref string Parms582,
		                                     [Optional] ref string Parms583,
		                                     [Optional] ref string Parms584,
		                                     [Optional] ref string Parms585,
		                                     [Optional] ref string Parms586,
		                                     [Optional] ref string Parms587,
		                                     [Optional] ref string Parms588,
		                                     [Optional] ref string Parms589,
		                                     [Optional] ref string Parms590,
		                                     [Optional] ref string Parms591,
		                                     [Optional] ref string Parms592,
		                                     [Optional] ref string Parms593,
		                                     [Optional] ref string Parms594,
		                                     [Optional] ref string Parms595,
		                                     [Optional] ref string Parms596,
		                                     [Optional] ref string Parms597,
		                                     [Optional] ref string Parms598,
		                                     [Optional] ref string Parms599,
		                                     [Optional] ref string Parms600,
		                                     [Optional] ref string Parms601,
		                                     [Optional] ref string Parms602,
		                                     [Optional] ref string Parms603,
		                                     [Optional] ref string Parms604,
		                                     [Optional] ref string Parms605,
		                                     [Optional] ref string Parms606,
		                                     [Optional] ref string Parms607,
		                                     [Optional] ref string Parms608,
		                                     [Optional] ref string Parms609,
		                                     [Optional] ref string Parms610,
		                                     [Optional] ref string Parms611,
		                                     [Optional] ref string Parms612,
		                                     [Optional] ref string Parms613,
		                                     [Optional] ref string Parms614,
		                                     [Optional] ref string Parms615,
		                                     [Optional] ref string Parms616,
		                                     [Optional] ref string Parms617,
		                                     [Optional] ref string Parms618,
		                                     [Optional] ref string Parms619,
		                                     [Optional] ref string Parms620,
		                                     [Optional] ref string Parms621,
		                                     [Optional] ref string Parms622,
		                                     [Optional] ref string Parms623,
		                                     [Optional] ref string Parms624,
		                                     [Optional] ref string Parms625,
		                                     [Optional] ref string Parms626,
		                                     [Optional] ref string Parms627,
		                                     [Optional] ref string Parms628,
		                                     [Optional] ref string Parms629,
		                                     [Optional] ref string Parms630,
		                                     [Optional] ref string Parms631,
		                                     [Optional] ref string Parms632,
		                                     [Optional] ref string Parms633,
		                                     [Optional] ref string Parms634,
		                                     [Optional] ref string Parms635,
		                                     [Optional] ref string Parms636,
		                                     [Optional] ref string Parms637,
		                                     [Optional] ref string Parms638,
		                                     [Optional] ref string Parms639,
		                                     [Optional] ref string Parms640,
		                                     [Optional] ref string Parms641,
		                                     [Optional] ref string Parms642,
		                                     [Optional] ref string Parms643,
		                                     [Optional] ref string Parms644,
		                                     [Optional] ref string Parms645,
		                                     [Optional] ref string Parms646,
		                                     [Optional] ref string Parms647,
		                                     [Optional] ref string Parms648,
		                                     [Optional] ref string Parms649,
		                                     [Optional] ref string Parms650,
		                                     [Optional] ref string Parms651,
		                                     [Optional] ref string Parms652,
		                                     [Optional] ref string Parms653,
		                                     [Optional] ref string Parms654,
		                                     [Optional] ref string Parms655,
		                                     [Optional] ref string Parms656,
		                                     [Optional] ref string Parms657,
		                                     [Optional] ref string Parms658,
		                                     [Optional] ref string Parms659,
		                                     [Optional] ref string Parms660,
		                                     [Optional] ref string Parms661,
		                                     [Optional] ref string Parms662,
		                                     [Optional] ref string Parms663,
		                                     [Optional] ref string Parms664,
		                                     [Optional] ref string Parms665,
		                                     [Optional] ref string Parms666,
		                                     [Optional] ref string Parms667,
		                                     [Optional] ref string Parms668,
		                                     [Optional] ref string Parms669,
		                                     [Optional] ref string Parms670,
		                                     [Optional] ref string Parms671,
		                                     [Optional] ref string Parms672,
		                                     [Optional] ref string Parms673,
		                                     [Optional] ref string Parms674,
		                                     [Optional] ref string Parms675,
		                                     [Optional] ref string Parms676,
		                                     [Optional] ref string Parms677,
		                                     [Optional] ref string Parms678,
		                                     [Optional] ref string Parms679,
		                                     [Optional] ref string Parms680,
		                                     [Optional] ref string Parms681,
		                                     [Optional] ref string Parms682,
		                                     [Optional] ref string Parms683,
		                                     [Optional] ref string Parms684,
		                                     [Optional] ref string Parms685,
		                                     [Optional] ref string Parms686,
		                                     [Optional] ref string Parms687,
		                                     [Optional] ref string Parms688,
		                                     [Optional] ref string Parms689,
		                                     [Optional] ref string Parms690,
		                                     [Optional] ref string Parms691,
		                                     [Optional] ref string Parms692,
		                                     [Optional] ref string Parms693,
		                                     [Optional] ref string Parms694,
		                                     [Optional] ref string Parms695,
		                                     [Optional] ref string Parms696,
		                                     [Optional] ref string Parms697,
		                                     [Optional] ref string Parms698,
		                                     [Optional] ref string Parms699,
		                                     [Optional] ref string Parms700,
		                                     [Optional] ref string Parms701,
		                                     [Optional] ref string Parms702,
		                                     [Optional] ref string Parms703,
		                                     [Optional] ref string Parms704,
		                                     [Optional] ref string Parms705,
		                                     [Optional] ref string Parms706,
		                                     [Optional] ref string Parms707,
		                                     [Optional] ref string Parms708,
		                                     [Optional] ref string Parms709,
		                                     [Optional] ref string Parms710,
		                                     [Optional] ref string Parms711,
		                                     [Optional] ref string Parms712,
		                                     [Optional] ref string Parms713,
		                                     [Optional] ref string Parms714,
		                                     [Optional] ref string Parms715,
		                                     [Optional] ref string Parms716,
		                                     [Optional] ref string Parms717,
		                                     [Optional] ref string Parms718,
		                                     [Optional] ref string Parms719,
		                                     [Optional] ref string Parms720,
		                                     [Optional] ref string Parms721,
		                                     [Optional] ref string Parms722,
		                                     [Optional] ref string Parms723,
		                                     [Optional] ref string Parms724,
		                                     [Optional] ref string Parms725,
		                                     [Optional] ref string Parms726,
		                                     [Optional] ref string Parms727,
		                                     [Optional] ref string Parms728,
		                                     [Optional] ref string Parms729,
		                                     [Optional] ref string Parms730,
		                                     [Optional] ref string Parms731,
		                                     [Optional] ref string Parms732,
		                                     [Optional] ref string Parms733,
		                                     [Optional] ref string Parms734,
		                                     [Optional] ref string Parms735,
		                                     [Optional] ref string Parms736,
		                                     [Optional] ref string Parms737,
		                                     [Optional] ref string Parms738,
		                                     [Optional] ref string Parms739,
		                                     [Optional] ref string Parms740,
		                                     [Optional] ref string Parms741,
		                                     [Optional] ref string Parms742,
		                                     [Optional] ref string Parms743,
		                                     [Optional] ref string Parms744,
		                                     [Optional] ref string Parms745,
		                                     [Optional] ref string Parms746,
		                                     [Optional] ref string Parms747,
		                                     [Optional] ref string Parms748,
		                                     [Optional] ref string Parms749,
		                                     [Optional] ref string Parms750,
		                                     [Optional] ref string Parms751,
		                                     [Optional] ref string Parms752,
		                                     [Optional] ref string Parms753,
		                                     [Optional] ref string Parms754,
		                                     [Optional] ref string Parms755,
		                                     [Optional] ref string Parms756,
		                                     [Optional] ref string Parms757,
		                                     [Optional] ref string Parms758,
		                                     [Optional] ref string Parms759,
		                                     [Optional] ref string Parms760,
		                                     [Optional] ref string Parms761,
		                                     [Optional] ref string Parms762,
		                                     [Optional] ref string Parms763,
		                                     [Optional] ref string Parms764,
		                                     [Optional] ref string Parms765,
		                                     [Optional] ref string Parms766,
		                                     [Optional] ref string Parms767,
		                                     [Optional] ref string Parms768,
		                                     [Optional] ref string Parms769,
		                                     [Optional] ref string Parms770,
		                                     [Optional] ref string Parms771,
		                                     [Optional] ref string Parms772,
		                                     [Optional] ref string Parms773,
		                                     [Optional] ref string Parms774,
		                                     [Optional] ref string Parms775,
		                                     [Optional] ref string Parms776,
		                                     [Optional] ref string Parms777,
		                                     [Optional] ref string Parms778,
		                                     [Optional] ref string Parms779,
		                                     [Optional] ref string Parms780,
		                                     [Optional] ref string Parms781,
		                                     [Optional] ref string Parms782,
		                                     [Optional] ref string Parms783,
		                                     [Optional] ref string Parms784,
		                                     [Optional] ref string Parms785,
		                                     [Optional] ref string Parms786,
		                                     [Optional] ref string Parms787,
		                                     [Optional] ref string Parms788,
		                                     [Optional] ref string Parms789,
		                                     [Optional] ref string Parms790,
		                                     [Optional] ref string Parms791,
		                                     [Optional] ref string Parms792,
		                                     [Optional] ref string Parms793,
		                                     [Optional] ref string Parms794,
		                                     [Optional] ref string Parms795,
		                                     [Optional] ref string Parms796,
		                                     [Optional] ref string Parms797,
		                                     [Optional] ref string Parms798,
		                                     [Optional] ref string Parms799,
		                                     [Optional] ref string Parms800,
		                                     [Optional] ref string Parms801,
		                                     [Optional] ref string Parms802,
		                                     [Optional] ref string Parms803,
		                                     [Optional] ref string Parms804,
		                                     [Optional] ref string Parms805,
		                                     [Optional] ref string Parms806,
		                                     [Optional] ref string Parms807,
		                                     [Optional] ref string Parms808,
		                                     [Optional] ref string Parms809,
		                                     [Optional] ref string Parms810,
		                                     [Optional] ref string Parms811,
		                                     [Optional] ref string Parms812,
		                                     [Optional] ref string Parms813,
		                                     [Optional] ref string Parms814,
		                                     [Optional] ref string Parms815,
		                                     [Optional] ref string Parms816,
		                                     [Optional] ref string Parms817,
		                                     [Optional] ref string Parms818,
		                                     [Optional] ref string Parms819,
		                                     [Optional] ref string Parms820,
		                                     [Optional] ref string Parms821,
		                                     [Optional] ref string Parms822,
		                                     [Optional] ref string Parms823,
		                                     [Optional] ref string Parms824,
		                                     [Optional] ref string Parms825,
		                                     [Optional] ref string Parms826,
		                                     [Optional] ref string Parms827,
		                                     [Optional] ref string Parms828,
		                                     [Optional] ref string Parms829,
		                                     [Optional] ref string Parms830,
		                                     [Optional] ref string Parms831,
		                                     [Optional] ref string Parms832,
		                                     [Optional] ref string Parms833,
		                                     [Optional] ref string Parms834,
		                                     [Optional] ref string Parms835,
		                                     [Optional] ref string Parms836,
		                                     [Optional] ref string Parms837,
		                                     [Optional] ref string Parms838,
		                                     [Optional] ref string Parms839,
		                                     [Optional] ref string Parms840,
		                                     [Optional] ref string Parms841,
		                                     [Optional] ref string Parms842,
		                                     [Optional] ref string Parms843,
		                                     [Optional] ref string Parms844,
		                                     [Optional] ref string Parms845,
		                                     [Optional] ref string Parms846,
		                                     [Optional] ref string Parms847,
		                                     [Optional] ref string Parms848,
		                                     [Optional] ref string Parms849,
		                                     [Optional] ref string Parms850,
		                                     [Optional] ref string Parms851,
		                                     [Optional] ref string Parms852,
		                                     [Optional] ref string Parms853,
		                                     [Optional] ref string Parms854,
		                                     [Optional] ref string Parms855,
		                                     [Optional] ref string Parms856,
		                                     [Optional] ref string Parms857,
		                                     [Optional] ref string Parms858,
		                                     [Optional] ref string Parms859,
		                                     [Optional] ref string Parms860,
		                                     [Optional] ref string Parms861,
		                                     [Optional] ref string Parms862,
		                                     [Optional] ref string Parms863,
		                                     [Optional] ref string Parms864,
		                                     [Optional] ref string Parms865,
		                                     [Optional] ref string Parms866,
		                                     [Optional] ref string Parms867,
		                                     [Optional] ref string Parms868,
		                                     [Optional] ref string Parms869,
		                                     [Optional] ref string Parms870,
		                                     [Optional] ref string Parms871,
		                                     [Optional] ref string Parms872,
		                                     [Optional] ref string Parms873,
		                                     [Optional] ref string Parms874,
		                                     [Optional] ref string Parms875,
		                                     [Optional] ref string Parms876,
		                                     [Optional] ref string Parms877,
		                                     [Optional] ref string Parms878,
		                                     [Optional] ref string Parms879,
		                                     [Optional] ref string Parms880,
		                                     [Optional] ref string Parms881,
		                                     [Optional] ref string Parms882,
		                                     [Optional] ref string Parms883,
		                                     [Optional] ref string Parms884,
		                                     [Optional] ref string Parms885,
		                                     [Optional] ref string Parms886,
		                                     [Optional] ref string Parms887,
		                                     [Optional] ref string Parms888,
		                                     [Optional] ref string Parms889,
		                                     [Optional] ref string Parms890,
		                                     [Optional] ref string Parms891,
		                                     [Optional] ref string Parms892,
		                                     [Optional] ref string Parms893,
		                                     [Optional] ref string Parms894,
		                                     [Optional] ref string Parms895,
		                                     [Optional] ref string Parms896,
		                                     [Optional] ref string Parms897,
		                                     [Optional] ref string Parms898,
		                                     [Optional] ref string Parms899,
		                                     [Optional] ref string Parms900,
		                                     [Optional] ref string Parms901,
		                                     [Optional] ref string Parms902,
		                                     [Optional] ref string Parms903,
		                                     [Optional] ref string Parms904,
		                                     [Optional] ref string Parms905,
		                                     [Optional] ref string Parms906,
		                                     [Optional] ref string Parms907,
		                                     [Optional] ref string Parms908,
		                                     [Optional] ref string Parms909,
		                                     [Optional] ref string Parms910,
		                                     [Optional] ref string Parms911,
		                                     [Optional] ref string Parms912,
		                                     [Optional] ref string Parms913,
		                                     [Optional] ref string Parms914,
		                                     [Optional] ref string Parms915,
		                                     [Optional] ref string Parms916,
		                                     [Optional] ref string Parms917,
		                                     [Optional] ref string Parms918,
		                                     [Optional] ref string Parms919,
		                                     [Optional] ref string Parms920,
		                                     [Optional] ref string Parms921,
		                                     [Optional] ref string Parms922,
		                                     [Optional] ref string Parms923,
		                                     [Optional] ref string Parms924,
		                                     [Optional] ref string Parms925,
		                                     [Optional] ref string Parms926,
		                                     [Optional] ref string Parms927,
		                                     [Optional] ref string Parms928,
		                                     [Optional] ref string Parms929,
		                                     [Optional] ref string Parms930,
		                                     [Optional] ref string Parms931,
		                                     [Optional] ref string Parms932,
		                                     [Optional] ref string Parms933,
		                                     [Optional] ref string Parms934,
		                                     [Optional] ref string Parms935,
		                                     [Optional] ref string Parms936,
		                                     [Optional] ref string Parms937,
		                                     [Optional] ref string Parms938,
		                                     [Optional] ref string Parms939,
		                                     [Optional] ref string Parms940,
		                                     [Optional] ref string Parms941,
		                                     [Optional] ref string Parms942,
		                                     [Optional] ref string Parms943,
		                                     [Optional] ref string Parms944,
		                                     [Optional] ref string Parms945,
		                                     [Optional] ref string Parms946,
		                                     [Optional] ref string Parms947,
		                                     [Optional] ref string Parms948,
		                                     [Optional] ref string Parms949,
		                                     [Optional] ref string Parms950,
		                                     [Optional] ref string Parms951,
		                                     [Optional] ref string Parms952,
		                                     [Optional] ref string Parms953,
		                                     [Optional] ref string Parms954,
		                                     [Optional] ref string Parms955,
		                                     [Optional] ref string Parms956,
		                                     [Optional] ref string Parms957,
		                                     [Optional] ref string Parms958,
		                                     [Optional] ref string Parms959,
		                                     [Optional] ref string Parms960,
		                                     [Optional] ref string Parms961,
		                                     [Optional] ref string Parms962,
		                                     [Optional] ref string Parms963,
		                                     [Optional] ref string Parms964,
		                                     [Optional] ref string Parms965,
		                                     [Optional] ref string Parms966,
		                                     [Optional] ref string Parms967,
		                                     [Optional] ref string Parms968,
		                                     [Optional] ref string Parms969,
		                                     [Optional] ref string Parms970,
		                                     [Optional] ref string Parms971,
		                                     [Optional] ref string Parms972,
		                                     [Optional] ref string Parms973,
		                                     [Optional] ref string Parms974,
		                                     [Optional] ref string Parms975,
		                                     [Optional] ref string Parms976,
		                                     [Optional] ref string Parms977,
		                                     [Optional] ref string Parms978,
		                                     [Optional] ref string Parms979,
		                                     [Optional] ref string Parms980,
		                                     [Optional] ref string Parms981,
		                                     [Optional] ref string Parms982,
		                                     [Optional] ref string Parms983,
		                                     [Optional] ref string Parms984,
		                                     [Optional] ref string Parms985,
		                                     [Optional] ref string Parms986,
		                                     [Optional] ref string Parms987,
		                                     [Optional] ref string Parms988,
		                                     [Optional] ref string Parms989,
		                                     [Optional] ref string Parms990,
		                                     [Optional] ref string Parms991,
		                                     [Optional] ref string Parms992,
		                                     [Optional] ref string Parms993,
		                                     [Optional] ref string Parms994,
		                                     [Optional] ref string Parms995,
		                                     [Optional] ref string Parms996,
		                                     [Optional] ref string Parms997,
		                                     [Optional] ref string Parms998,
		                                     [Optional] ref string Parms999,
		                                     [Optional] ref string Parms1000)
		{
            throw new NotImplementedException();

			//using(var MGAppDB = this.CreateAppDB())
			//{
			//	var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
			//	var iExcelSyteLineGLBatchSqlExt = new ExcelSyteLineGLBatchSqlFactory().Create(appDb);
				
			//	var result = iExcelSyteLineGLBatchSqlExt.ExcelSyteLineGLBatchSqlSp(Parms1,
			//	                                                                   Parms2,
			//	                                                                   Parms3,
			//	                                                                   Parms4,
			//	                                                                   Parms5,
			//	                                                                   Parms6,
			//	                                                                   Parms7,
			//	                                                                   Parms8,
			//	                                                                   Parms9,
			//	                                                                   Parms10,
			//	                                                                   Parms11,
			//	                                                                   Parms12,
			//	                                                                   Parms13,
			//	                                                                   Parms14,
			//	                                                                   Parms15,
			//	                                                                   Parms16,
			//	                                                                   Parms17,
			//	                                                                   Parms18,
			//	                                                                   Parms19,
			//	                                                                   Parms20,
			//	                                                                   Parms21,
			//	                                                                   Parms22,
			//	                                                                   Parms23,
			//	                                                                   Parms24,
			//	                                                                   Parms25,
			//	                                                                   Parms26,
			//	                                                                   Parms27,
			//	                                                                   Parms28,
			//	                                                                   Parms29,
			//	                                                                   Parms30,
			//	                                                                   Parms31,
			//	                                                                   Parms32,
			//	                                                                   Parms33,
			//	                                                                   Parms34,
			//	                                                                   Parms35,
			//	                                                                   Parms36,
			//	                                                                   Parms37,
			//	                                                                   Parms38,
			//	                                                                   Parms39,
			//	                                                                   Parms40,
			//	                                                                   Parms41,
			//	                                                                   Parms42,
			//	                                                                   Parms43,
			//	                                                                   Parms44,
			//	                                                                   Parms45,
			//	                                                                   Parms46,
			//	                                                                   Parms47,
			//	                                                                   Parms48,
			//	                                                                   Parms49,
			//	                                                                   Parms50,
			//	                                                                   Parms51,
			//	                                                                   Parms52,
			//	                                                                   Parms53,
			//	                                                                   Parms54,
			//	                                                                   Parms55,
			//	                                                                   Parms56,
			//	                                                                   Parms57,
			//	                                                                   Parms58,
			//	                                                                   Parms59,
			//	                                                                   Parms60,
			//	                                                                   Parms61,
			//	                                                                   Parms62,
			//	                                                                   Parms63,
			//	                                                                   Parms64,
			//	                                                                   Parms65,
			//	                                                                   Parms66,
			//	                                                                   Parms67,
			//	                                                                   Parms68,
			//	                                                                   Parms69,
			//	                                                                   Parms70,
			//	                                                                   Parms71,
			//	                                                                   Parms72,
			//	                                                                   Parms73,
			//	                                                                   Parms74,
			//	                                                                   Parms75,
			//	                                                                   Parms76,
			//	                                                                   Parms77,
			//	                                                                   Parms78,
			//	                                                                   Parms79,
			//	                                                                   Parms80,
			//	                                                                   Parms81,
			//	                                                                   Parms82,
			//	                                                                   Parms83,
			//	                                                                   Parms84,
			//	                                                                   Parms85,
			//	                                                                   Parms86,
			//	                                                                   Parms87,
			//	                                                                   Parms88,
			//	                                                                   Parms89,
			//	                                                                   Parms90,
			//	                                                                   Parms91,
			//	                                                                   Parms92,
			//	                                                                   Parms93,
			//	                                                                   Parms94,
			//	                                                                   Parms95,
			//	                                                                   Parms96,
			//	                                                                   Parms97,
			//	                                                                   Parms98,
			//	                                                                   Parms99,
			//	                                                                   Parms100,
			//	                                                                   Parms101,
			//	                                                                   Parms102,
			//	                                                                   Parms103,
			//	                                                                   Parms104,
			//	                                                                   Parms105,
			//	                                                                   Parms106,
			//	                                                                   Parms107,
			//	                                                                   Parms108,
			//	                                                                   Parms109,
			//	                                                                   Parms110,
			//	                                                                   Parms111,
			//	                                                                   Parms112,
			//	                                                                   Parms113,
			//	                                                                   Parms114,
			//	                                                                   Parms115,
			//	                                                                   Parms116,
			//	                                                                   Parms117,
			//	                                                                   Parms118,
			//	                                                                   Parms119,
			//	                                                                   Parms120,
			//	                                                                   Parms121,
			//	                                                                   Parms122,
			//	                                                                   Parms123,
			//	                                                                   Parms124,
			//	                                                                   Parms125,
			//	                                                                   Parms126,
			//	                                                                   Parms127,
			//	                                                                   Parms128,
			//	                                                                   Parms129,
			//	                                                                   Parms130,
			//	                                                                   Parms131,
			//	                                                                   Parms132,
			//	                                                                   Parms133,
			//	                                                                   Parms134,
			//	                                                                   Parms135,
			//	                                                                   Parms136,
			//	                                                                   Parms137,
			//	                                                                   Parms138,
			//	                                                                   Parms139,
			//	                                                                   Parms140,
			//	                                                                   Parms141,
			//	                                                                   Parms142,
			//	                                                                   Parms143,
			//	                                                                   Parms144,
			//	                                                                   Parms145,
			//	                                                                   Parms146,
			//	                                                                   Parms147,
			//	                                                                   Parms148,
			//	                                                                   Parms149,
			//	                                                                   Parms150,
			//	                                                                   Parms151,
			//	                                                                   Parms152,
			//	                                                                   Parms153,
			//	                                                                   Parms154,
			//	                                                                   Parms155,
			//	                                                                   Parms156,
			//	                                                                   Parms157,
			//	                                                                   Parms158,
			//	                                                                   Parms159,
			//	                                                                   Parms160,
			//	                                                                   Parms161,
			//	                                                                   Parms162,
			//	                                                                   Parms163,
			//	                                                                   Parms164,
			//	                                                                   Parms165,
			//	                                                                   Parms166,
			//	                                                                   Parms167,
			//	                                                                   Parms168,
			//	                                                                   Parms169,
			//	                                                                   Parms170,
			//	                                                                   Parms171,
			//	                                                                   Parms172,
			//	                                                                   Parms173,
			//	                                                                   Parms174,
			//	                                                                   Parms175,
			//	                                                                   Parms176,
			//	                                                                   Parms177,
			//	                                                                   Parms178,
			//	                                                                   Parms179,
			//	                                                                   Parms180,
			//	                                                                   Parms181,
			//	                                                                   Parms182,
			//	                                                                   Parms183,
			//	                                                                   Parms184,
			//	                                                                   Parms185,
			//	                                                                   Parms186,
			//	                                                                   Parms187,
			//	                                                                   Parms188,
			//	                                                                   Parms189,
			//	                                                                   Parms190,
			//	                                                                   Parms191,
			//	                                                                   Parms192,
			//	                                                                   Parms193,
			//	                                                                   Parms194,
			//	                                                                   Parms195,
			//	                                                                   Parms196,
			//	                                                                   Parms197,
			//	                                                                   Parms198,
			//	                                                                   Parms199,
			//	                                                                   Parms200,
			//	                                                                   Parms201,
			//	                                                                   Parms202,
			//	                                                                   Parms203,
			//	                                                                   Parms204,
			//	                                                                   Parms205,
			//	                                                                   Parms206,
			//	                                                                   Parms207,
			//	                                                                   Parms208,
			//	                                                                   Parms209,
			//	                                                                   Parms210,
			//	                                                                   Parms211,
			//	                                                                   Parms212,
			//	                                                                   Parms213,
			//	                                                                   Parms214,
			//	                                                                   Parms215,
			//	                                                                   Parms216,
			//	                                                                   Parms217,
			//	                                                                   Parms218,
			//	                                                                   Parms219,
			//	                                                                   Parms220,
			//	                                                                   Parms221,
			//	                                                                   Parms222,
			//	                                                                   Parms223,
			//	                                                                   Parms224,
			//	                                                                   Parms225,
			//	                                                                   Parms226,
			//	                                                                   Parms227,
			//	                                                                   Parms228,
			//	                                                                   Parms229,
			//	                                                                   Parms230,
			//	                                                                   Parms231,
			//	                                                                   Parms232,
			//	                                                                   Parms233,
			//	                                                                   Parms234,
			//	                                                                   Parms235,
			//	                                                                   Parms236,
			//	                                                                   Parms237,
			//	                                                                   Parms238,
			//	                                                                   Parms239,
			//	                                                                   Parms240,
			//	                                                                   Parms241,
			//	                                                                   Parms242,
			//	                                                                   Parms243,
			//	                                                                   Parms244,
			//	                                                                   Parms245,
			//	                                                                   Parms246,
			//	                                                                   Parms247,
			//	                                                                   Parms248,
			//	                                                                   Parms249,
			//	                                                                   Parms250,
			//	                                                                   Parms251,
			//	                                                                   Parms252,
			//	                                                                   Parms253,
			//	                                                                   Parms254,
			//	                                                                   Parms255,
			//	                                                                   Parms256,
			//	                                                                   Parms257,
			//	                                                                   Parms258,
			//	                                                                   Parms259,
			//	                                                                   Parms260,
			//	                                                                   Parms261,
			//	                                                                   Parms262,
			//	                                                                   Parms263,
			//	                                                                   Parms264,
			//	                                                                   Parms265,
			//	                                                                   Parms266,
			//	                                                                   Parms267,
			//	                                                                   Parms268,
			//	                                                                   Parms269,
			//	                                                                   Parms270,
			//	                                                                   Parms271,
			//	                                                                   Parms272,
			//	                                                                   Parms273,
			//	                                                                   Parms274,
			//	                                                                   Parms275,
			//	                                                                   Parms276,
			//	                                                                   Parms277,
			//	                                                                   Parms278,
			//	                                                                   Parms279,
			//	                                                                   Parms280,
			//	                                                                   Parms281,
			//	                                                                   Parms282,
			//	                                                                   Parms283,
			//	                                                                   Parms284,
			//	                                                                   Parms285,
			//	                                                                   Parms286,
			//	                                                                   Parms287,
			//	                                                                   Parms288,
			//	                                                                   Parms289,
			//	                                                                   Parms290,
			//	                                                                   Parms291,
			//	                                                                   Parms292,
			//	                                                                   Parms293,
			//	                                                                   Parms294,
			//	                                                                   Parms295,
			//	                                                                   Parms296,
			//	                                                                   Parms297,
			//	                                                                   Parms298,
			//	                                                                   Parms299,
			//	                                                                   Parms300,
			//	                                                                   Parms301,
			//	                                                                   Parms302,
			//	                                                                   Parms303,
			//	                                                                   Parms304,
			//	                                                                   Parms305,
			//	                                                                   Parms306,
			//	                                                                   Parms307,
			//	                                                                   Parms308,
			//	                                                                   Parms309,
			//	                                                                   Parms310,
			//	                                                                   Parms311,
			//	                                                                   Parms312,
			//	                                                                   Parms313,
			//	                                                                   Parms314,
			//	                                                                   Parms315,
			//	                                                                   Parms316,
			//	                                                                   Parms317,
			//	                                                                   Parms318,
			//	                                                                   Parms319,
			//	                                                                   Parms320,
			//	                                                                   Parms321,
			//	                                                                   Parms322,
			//	                                                                   Parms323,
			//	                                                                   Parms324,
			//	                                                                   Parms325,
			//	                                                                   Parms326,
			//	                                                                   Parms327,
			//	                                                                   Parms328,
			//	                                                                   Parms329,
			//	                                                                   Parms330,
			//	                                                                   Parms331,
			//	                                                                   Parms332,
			//	                                                                   Parms333,
			//	                                                                   Parms334,
			//	                                                                   Parms335,
			//	                                                                   Parms336,
			//	                                                                   Parms337,
			//	                                                                   Parms338,
			//	                                                                   Parms339,
			//	                                                                   Parms340,
			//	                                                                   Parms341,
			//	                                                                   Parms342,
			//	                                                                   Parms343,
			//	                                                                   Parms344,
			//	                                                                   Parms345,
			//	                                                                   Parms346,
			//	                                                                   Parms347,
			//	                                                                   Parms348,
			//	                                                                   Parms349,
			//	                                                                   Parms350,
			//	                                                                   Parms351,
			//	                                                                   Parms352,
			//	                                                                   Parms353,
			//	                                                                   Parms354,
			//	                                                                   Parms355,
			//	                                                                   Parms356,
			//	                                                                   Parms357,
			//	                                                                   Parms358,
			//	                                                                   Parms359,
			//	                                                                   Parms360,
			//	                                                                   Parms361,
			//	                                                                   Parms362,
			//	                                                                   Parms363,
			//	                                                                   Parms364,
			//	                                                                   Parms365,
			//	                                                                   Parms366,
			//	                                                                   Parms367,
			//	                                                                   Parms368,
			//	                                                                   Parms369,
			//	                                                                   Parms370,
			//	                                                                   Parms371,
			//	                                                                   Parms372,
			//	                                                                   Parms373,
			//	                                                                   Parms374,
			//	                                                                   Parms375,
			//	                                                                   Parms376,
			//	                                                                   Parms377,
			//	                                                                   Parms378,
			//	                                                                   Parms379,
			//	                                                                   Parms380,
			//	                                                                   Parms381,
			//	                                                                   Parms382,
			//	                                                                   Parms383,
			//	                                                                   Parms384,
			//	                                                                   Parms385,
			//	                                                                   Parms386,
			//	                                                                   Parms387,
			//	                                                                   Parms388,
			//	                                                                   Parms389,
			//	                                                                   Parms390,
			//	                                                                   Parms391,
			//	                                                                   Parms392,
			//	                                                                   Parms393,
			//	                                                                   Parms394,
			//	                                                                   Parms395,
			//	                                                                   Parms396,
			//	                                                                   Parms397,
			//	                                                                   Parms398,
			//	                                                                   Parms399,
			//	                                                                   Parms400,
			//	                                                                   Parms401,
			//	                                                                   Parms402,
			//	                                                                   Parms403,
			//	                                                                   Parms404,
			//	                                                                   Parms405,
			//	                                                                   Parms406,
			//	                                                                   Parms407,
			//	                                                                   Parms408,
			//	                                                                   Parms409,
			//	                                                                   Parms410,
			//	                                                                   Parms411,
			//	                                                                   Parms412,
			//	                                                                   Parms413,
			//	                                                                   Parms414,
			//	                                                                   Parms415,
			//	                                                                   Parms416,
			//	                                                                   Parms417,
			//	                                                                   Parms418,
			//	                                                                   Parms419,
			//	                                                                   Parms420,
			//	                                                                   Parms421,
			//	                                                                   Parms422,
			//	                                                                   Parms423,
			//	                                                                   Parms424,
			//	                                                                   Parms425,
			//	                                                                   Parms426,
			//	                                                                   Parms427,
			//	                                                                   Parms428,
			//	                                                                   Parms429,
			//	                                                                   Parms430,
			//	                                                                   Parms431,
			//	                                                                   Parms432,
			//	                                                                   Parms433,
			//	                                                                   Parms434,
			//	                                                                   Parms435,
			//	                                                                   Parms436,
			//	                                                                   Parms437,
			//	                                                                   Parms438,
			//	                                                                   Parms439,
			//	                                                                   Parms440,
			//	                                                                   Parms441,
			//	                                                                   Parms442,
			//	                                                                   Parms443,
			//	                                                                   Parms444,
			//	                                                                   Parms445,
			//	                                                                   Parms446,
			//	                                                                   Parms447,
			//	                                                                   Parms448,
			//	                                                                   Parms449,
			//	                                                                   Parms450,
			//	                                                                   Parms451,
			//	                                                                   Parms452,
			//	                                                                   Parms453,
			//	                                                                   Parms454,
			//	                                                                   Parms455,
			//	                                                                   Parms456,
			//	                                                                   Parms457,
			//	                                                                   Parms458,
			//	                                                                   Parms459,
			//	                                                                   Parms460,
			//	                                                                   Parms461,
			//	                                                                   Parms462,
			//	                                                                   Parms463,
			//	                                                                   Parms464,
			//	                                                                   Parms465,
			//	                                                                   Parms466,
			//	                                                                   Parms467,
			//	                                                                   Parms468,
			//	                                                                   Parms469,
			//	                                                                   Parms470,
			//	                                                                   Parms471,
			//	                                                                   Parms472,
			//	                                                                   Parms473,
			//	                                                                   Parms474,
			//	                                                                   Parms475,
			//	                                                                   Parms476,
			//	                                                                   Parms477,
			//	                                                                   Parms478,
			//	                                                                   Parms479,
			//	                                                                   Parms480,
			//	                                                                   Parms481,
			//	                                                                   Parms482,
			//	                                                                   Parms483,
			//	                                                                   Parms484,
			//	                                                                   Parms485,
			//	                                                                   Parms486,
			//	                                                                   Parms487,
			//	                                                                   Parms488,
			//	                                                                   Parms489,
			//	                                                                   Parms490,
			//	                                                                   Parms491,
			//	                                                                   Parms492,
			//	                                                                   Parms493,
			//	                                                                   Parms494,
			//	                                                                   Parms495,
			//	                                                                   Parms496,
			//	                                                                   Parms497,
			//	                                                                   Parms498,
			//	                                                                   Parms499,
			//	                                                                   Parms500,
			//	                                                                   Parms501,
			//	                                                                   Parms502,
			//	                                                                   Parms503,
			//	                                                                   Parms504,
			//	                                                                   Parms505,
			//	                                                                   Parms506,
			//	                                                                   Parms507,
			//	                                                                   Parms508,
			//	                                                                   Parms509,
			//	                                                                   Parms510,
			//	                                                                   Parms511,
			//	                                                                   Parms512,
			//	                                                                   Parms513,
			//	                                                                   Parms514,
			//	                                                                   Parms515,
			//	                                                                   Parms516,
			//	                                                                   Parms517,
			//	                                                                   Parms518,
			//	                                                                   Parms519,
			//	                                                                   Parms520,
			//	                                                                   Parms521,
			//	                                                                   Parms522,
			//	                                                                   Parms523,
			//	                                                                   Parms524,
			//	                                                                   Parms525,
			//	                                                                   Parms526,
			//	                                                                   Parms527,
			//	                                                                   Parms528,
			//	                                                                   Parms529,
			//	                                                                   Parms530,
			//	                                                                   Parms531,
			//	                                                                   Parms532,
			//	                                                                   Parms533,
			//	                                                                   Parms534,
			//	                                                                   Parms535,
			//	                                                                   Parms536,
			//	                                                                   Parms537,
			//	                                                                   Parms538,
			//	                                                                   Parms539,
			//	                                                                   Parms540,
			//	                                                                   Parms541,
			//	                                                                   Parms542,
			//	                                                                   Parms543,
			//	                                                                   Parms544,
			//	                                                                   Parms545,
			//	                                                                   Parms546,
			//	                                                                   Parms547,
			//	                                                                   Parms548,
			//	                                                                   Parms549,
			//	                                                                   Parms550,
			//	                                                                   Parms551,
			//	                                                                   Parms552,
			//	                                                                   Parms553,
			//	                                                                   Parms554,
			//	                                                                   Parms555,
			//	                                                                   Parms556,
			//	                                                                   Parms557,
			//	                                                                   Parms558,
			//	                                                                   Parms559,
			//	                                                                   Parms560,
			//	                                                                   Parms561,
			//	                                                                   Parms562,
			//	                                                                   Parms563,
			//	                                                                   Parms564,
			//	                                                                   Parms565,
			//	                                                                   Parms566,
			//	                                                                   Parms567,
			//	                                                                   Parms568,
			//	                                                                   Parms569,
			//	                                                                   Parms570,
			//	                                                                   Parms571,
			//	                                                                   Parms572,
			//	                                                                   Parms573,
			//	                                                                   Parms574,
			//	                                                                   Parms575,
			//	                                                                   Parms576,
			//	                                                                   Parms577,
			//	                                                                   Parms578,
			//	                                                                   Parms579,
			//	                                                                   Parms580,
			//	                                                                   Parms581,
			//	                                                                   Parms582,
			//	                                                                   Parms583,
			//	                                                                   Parms584,
			//	                                                                   Parms585,
			//	                                                                   Parms586,
			//	                                                                   Parms587,
			//	                                                                   Parms588,
			//	                                                                   Parms589,
			//	                                                                   Parms590,
			//	                                                                   Parms591,
			//	                                                                   Parms592,
			//	                                                                   Parms593,
			//	                                                                   Parms594,
			//	                                                                   Parms595,
			//	                                                                   Parms596,
			//	                                                                   Parms597,
			//	                                                                   Parms598,
			//	                                                                   Parms599,
			//	                                                                   Parms600,
			//	                                                                   Parms601,
			//	                                                                   Parms602,
			//	                                                                   Parms603,
			//	                                                                   Parms604,
			//	                                                                   Parms605,
			//	                                                                   Parms606,
			//	                                                                   Parms607,
			//	                                                                   Parms608,
			//	                                                                   Parms609,
			//	                                                                   Parms610,
			//	                                                                   Parms611,
			//	                                                                   Parms612,
			//	                                                                   Parms613,
			//	                                                                   Parms614,
			//	                                                                   Parms615,
			//	                                                                   Parms616,
			//	                                                                   Parms617,
			//	                                                                   Parms618,
			//	                                                                   Parms619,
			//	                                                                   Parms620,
			//	                                                                   Parms621,
			//	                                                                   Parms622,
			//	                                                                   Parms623,
			//	                                                                   Parms624,
			//	                                                                   Parms625,
			//	                                                                   Parms626,
			//	                                                                   Parms627,
			//	                                                                   Parms628,
			//	                                                                   Parms629,
			//	                                                                   Parms630,
			//	                                                                   Parms631,
			//	                                                                   Parms632,
			//	                                                                   Parms633,
			//	                                                                   Parms634,
			//	                                                                   Parms635,
			//	                                                                   Parms636,
			//	                                                                   Parms637,
			//	                                                                   Parms638,
			//	                                                                   Parms639,
			//	                                                                   Parms640,
			//	                                                                   Parms641,
			//	                                                                   Parms642,
			//	                                                                   Parms643,
			//	                                                                   Parms644,
			//	                                                                   Parms645,
			//	                                                                   Parms646,
			//	                                                                   Parms647,
			//	                                                                   Parms648,
			//	                                                                   Parms649,
			//	                                                                   Parms650,
			//	                                                                   Parms651,
			//	                                                                   Parms652,
			//	                                                                   Parms653,
			//	                                                                   Parms654,
			//	                                                                   Parms655,
			//	                                                                   Parms656,
			//	                                                                   Parms657,
			//	                                                                   Parms658,
			//	                                                                   Parms659,
			//	                                                                   Parms660,
			//	                                                                   Parms661,
			//	                                                                   Parms662,
			//	                                                                   Parms663,
			//	                                                                   Parms664,
			//	                                                                   Parms665,
			//	                                                                   Parms666,
			//	                                                                   Parms667,
			//	                                                                   Parms668,
			//	                                                                   Parms669,
			//	                                                                   Parms670,
			//	                                                                   Parms671,
			//	                                                                   Parms672,
			//	                                                                   Parms673,
			//	                                                                   Parms674,
			//	                                                                   Parms675,
			//	                                                                   Parms676,
			//	                                                                   Parms677,
			//	                                                                   Parms678,
			//	                                                                   Parms679,
			//	                                                                   Parms680,
			//	                                                                   Parms681,
			//	                                                                   Parms682,
			//	                                                                   Parms683,
			//	                                                                   Parms684,
			//	                                                                   Parms685,
			//	                                                                   Parms686,
			//	                                                                   Parms687,
			//	                                                                   Parms688,
			//	                                                                   Parms689,
			//	                                                                   Parms690,
			//	                                                                   Parms691,
			//	                                                                   Parms692,
			//	                                                                   Parms693,
			//	                                                                   Parms694,
			//	                                                                   Parms695,
			//	                                                                   Parms696,
			//	                                                                   Parms697,
			//	                                                                   Parms698,
			//	                                                                   Parms699,
			//	                                                                   Parms700,
			//	                                                                   Parms701,
			//	                                                                   Parms702,
			//	                                                                   Parms703,
			//	                                                                   Parms704,
			//	                                                                   Parms705,
			//	                                                                   Parms706,
			//	                                                                   Parms707,
			//	                                                                   Parms708,
			//	                                                                   Parms709,
			//	                                                                   Parms710,
			//	                                                                   Parms711,
			//	                                                                   Parms712,
			//	                                                                   Parms713,
			//	                                                                   Parms714,
			//	                                                                   Parms715,
			//	                                                                   Parms716,
			//	                                                                   Parms717,
			//	                                                                   Parms718,
			//	                                                                   Parms719,
			//	                                                                   Parms720,
			//	                                                                   Parms721,
			//	                                                                   Parms722,
			//	                                                                   Parms723,
			//	                                                                   Parms724,
			//	                                                                   Parms725,
			//	                                                                   Parms726,
			//	                                                                   Parms727,
			//	                                                                   Parms728,
			//	                                                                   Parms729,
			//	                                                                   Parms730,
			//	                                                                   Parms731,
			//	                                                                   Parms732,
			//	                                                                   Parms733,
			//	                                                                   Parms734,
			//	                                                                   Parms735,
			//	                                                                   Parms736,
			//	                                                                   Parms737,
			//	                                                                   Parms738,
			//	                                                                   Parms739,
			//	                                                                   Parms740,
			//	                                                                   Parms741,
			//	                                                                   Parms742,
			//	                                                                   Parms743,
			//	                                                                   Parms744,
			//	                                                                   Parms745,
			//	                                                                   Parms746,
			//	                                                                   Parms747,
			//	                                                                   Parms748,
			//	                                                                   Parms749,
			//	                                                                   Parms750,
			//	                                                                   Parms751,
			//	                                                                   Parms752,
			//	                                                                   Parms753,
			//	                                                                   Parms754,
			//	                                                                   Parms755,
			//	                                                                   Parms756,
			//	                                                                   Parms757,
			//	                                                                   Parms758,
			//	                                                                   Parms759,
			//	                                                                   Parms760,
			//	                                                                   Parms761,
			//	                                                                   Parms762,
			//	                                                                   Parms763,
			//	                                                                   Parms764,
			//	                                                                   Parms765,
			//	                                                                   Parms766,
			//	                                                                   Parms767,
			//	                                                                   Parms768,
			//	                                                                   Parms769,
			//	                                                                   Parms770,
			//	                                                                   Parms771,
			//	                                                                   Parms772,
			//	                                                                   Parms773,
			//	                                                                   Parms774,
			//	                                                                   Parms775,
			//	                                                                   Parms776,
			//	                                                                   Parms777,
			//	                                                                   Parms778,
			//	                                                                   Parms779,
			//	                                                                   Parms780,
			//	                                                                   Parms781,
			//	                                                                   Parms782,
			//	                                                                   Parms783,
			//	                                                                   Parms784,
			//	                                                                   Parms785,
			//	                                                                   Parms786,
			//	                                                                   Parms787,
			//	                                                                   Parms788,
			//	                                                                   Parms789,
			//	                                                                   Parms790,
			//	                                                                   Parms791,
			//	                                                                   Parms792,
			//	                                                                   Parms793,
			//	                                                                   Parms794,
			//	                                                                   Parms795,
			//	                                                                   Parms796,
			//	                                                                   Parms797,
			//	                                                                   Parms798,
			//	                                                                   Parms799,
			//	                                                                   Parms800,
			//	                                                                   Parms801,
			//	                                                                   Parms802,
			//	                                                                   Parms803,
			//	                                                                   Parms804,
			//	                                                                   Parms805,
			//	                                                                   Parms806,
			//	                                                                   Parms807,
			//	                                                                   Parms808,
			//	                                                                   Parms809,
			//	                                                                   Parms810,
			//	                                                                   Parms811,
			//	                                                                   Parms812,
			//	                                                                   Parms813,
			//	                                                                   Parms814,
			//	                                                                   Parms815,
			//	                                                                   Parms816,
			//	                                                                   Parms817,
			//	                                                                   Parms818,
			//	                                                                   Parms819,
			//	                                                                   Parms820,
			//	                                                                   Parms821,
			//	                                                                   Parms822,
			//	                                                                   Parms823,
			//	                                                                   Parms824,
			//	                                                                   Parms825,
			//	                                                                   Parms826,
			//	                                                                   Parms827,
			//	                                                                   Parms828,
			//	                                                                   Parms829,
			//	                                                                   Parms830,
			//	                                                                   Parms831,
			//	                                                                   Parms832,
			//	                                                                   Parms833,
			//	                                                                   Parms834,
			//	                                                                   Parms835,
			//	                                                                   Parms836,
			//	                                                                   Parms837,
			//	                                                                   Parms838,
			//	                                                                   Parms839,
			//	                                                                   Parms840,
			//	                                                                   Parms841,
			//	                                                                   Parms842,
			//	                                                                   Parms843,
			//	                                                                   Parms844,
			//	                                                                   Parms845,
			//	                                                                   Parms846,
			//	                                                                   Parms847,
			//	                                                                   Parms848,
			//	                                                                   Parms849,
			//	                                                                   Parms850,
			//	                                                                   Parms851,
			//	                                                                   Parms852,
			//	                                                                   Parms853,
			//	                                                                   Parms854,
			//	                                                                   Parms855,
			//	                                                                   Parms856,
			//	                                                                   Parms857,
			//	                                                                   Parms858,
			//	                                                                   Parms859,
			//	                                                                   Parms860,
			//	                                                                   Parms861,
			//	                                                                   Parms862,
			//	                                                                   Parms863,
			//	                                                                   Parms864,
			//	                                                                   Parms865,
			//	                                                                   Parms866,
			//	                                                                   Parms867,
			//	                                                                   Parms868,
			//	                                                                   Parms869,
			//	                                                                   Parms870,
			//	                                                                   Parms871,
			//	                                                                   Parms872,
			//	                                                                   Parms873,
			//	                                                                   Parms874,
			//	                                                                   Parms875,
			//	                                                                   Parms876,
			//	                                                                   Parms877,
			//	                                                                   Parms878,
			//	                                                                   Parms879,
			//	                                                                   Parms880,
			//	                                                                   Parms881,
			//	                                                                   Parms882,
			//	                                                                   Parms883,
			//	                                                                   Parms884,
			//	                                                                   Parms885,
			//	                                                                   Parms886,
			//	                                                                   Parms887,
			//	                                                                   Parms888,
			//	                                                                   Parms889,
			//	                                                                   Parms890,
			//	                                                                   Parms891,
			//	                                                                   Parms892,
			//	                                                                   Parms893,
			//	                                                                   Parms894,
			//	                                                                   Parms895,
			//	                                                                   Parms896,
			//	                                                                   Parms897,
			//	                                                                   Parms898,
			//	                                                                   Parms899,
			//	                                                                   Parms900,
			//	                                                                   Parms901,
			//	                                                                   Parms902,
			//	                                                                   Parms903,
			//	                                                                   Parms904,
			//	                                                                   Parms905,
			//	                                                                   Parms906,
			//	                                                                   Parms907,
			//	                                                                   Parms908,
			//	                                                                   Parms909,
			//	                                                                   Parms910,
			//	                                                                   Parms911,
			//	                                                                   Parms912,
			//	                                                                   Parms913,
			//	                                                                   Parms914,
			//	                                                                   Parms915,
			//	                                                                   Parms916,
			//	                                                                   Parms917,
			//	                                                                   Parms918,
			//	                                                                   Parms919,
			//	                                                                   Parms920,
			//	                                                                   Parms921,
			//	                                                                   Parms922,
			//	                                                                   Parms923,
			//	                                                                   Parms924,
			//	                                                                   Parms925,
			//	                                                                   Parms926,
			//	                                                                   Parms927,
			//	                                                                   Parms928,
			//	                                                                   Parms929,
			//	                                                                   Parms930,
			//	                                                                   Parms931,
			//	                                                                   Parms932,
			//	                                                                   Parms933,
			//	                                                                   Parms934,
			//	                                                                   Parms935,
			//	                                                                   Parms936,
			//	                                                                   Parms937,
			//	                                                                   Parms938,
			//	                                                                   Parms939,
			//	                                                                   Parms940,
			//	                                                                   Parms941,
			//	                                                                   Parms942,
			//	                                                                   Parms943,
			//	                                                                   Parms944,
			//	                                                                   Parms945,
			//	                                                                   Parms946,
			//	                                                                   Parms947,
			//	                                                                   Parms948,
			//	                                                                   Parms949,
			//	                                                                   Parms950,
			//	                                                                   Parms951,
			//	                                                                   Parms952,
			//	                                                                   Parms953,
			//	                                                                   Parms954,
			//	                                                                   Parms955,
			//	                                                                   Parms956,
			//	                                                                   Parms957,
			//	                                                                   Parms958,
			//	                                                                   Parms959,
			//	                                                                   Parms960,
			//	                                                                   Parms961,
			//	                                                                   Parms962,
			//	                                                                   Parms963,
			//	                                                                   Parms964,
			//	                                                                   Parms965,
			//	                                                                   Parms966,
			//	                                                                   Parms967,
			//	                                                                   Parms968,
			//	                                                                   Parms969,
			//	                                                                   Parms970,
			//	                                                                   Parms971,
			//	                                                                   Parms972,
			//	                                                                   Parms973,
			//	                                                                   Parms974,
			//	                                                                   Parms975,
			//	                                                                   Parms976,
			//	                                                                   Parms977,
			//	                                                                   Parms978,
			//	                                                                   Parms979,
			//	                                                                   Parms980,
			//	                                                                   Parms981,
			//	                                                                   Parms982,
			//	                                                                   Parms983,
			//	                                                                   Parms984,
			//	                                                                   Parms985,
			//	                                                                   Parms986,
			//	                                                                   Parms987,
			//	                                                                   Parms988,
			//	                                                                   Parms989,
			//	                                                                   Parms990,
			//	                                                                   Parms991,
			//	                                                                   Parms992,
			//	                                                                   Parms993,
			//	                                                                   Parms994,
			//	                                                                   Parms995,
			//	                                                                   Parms996,
			//	                                                                   Parms997,
			//	                                                                   Parms998,
			//	                                                                   Parms999,
			//	                                                                   Parms1000);
				
			//	int Severity = result.ReturnCode.Value;
			//	Parms1 = result.Parms1;
			//	Parms2 = result.Parms2;
			//	Parms3 = result.Parms3;
			//	Parms4 = result.Parms4;
			//	Parms5 = result.Parms5;
			//	Parms6 = result.Parms6;
			//	Parms7 = result.Parms7;
			//	Parms8 = result.Parms8;
			//	Parms9 = result.Parms9;
			//	Parms10 = result.Parms10;
			//	Parms11 = result.Parms11;
			//	Parms12 = result.Parms12;
			//	Parms13 = result.Parms13;
			//	Parms14 = result.Parms14;
			//	Parms15 = result.Parms15;
			//	Parms16 = result.Parms16;
			//	Parms17 = result.Parms17;
			//	Parms18 = result.Parms18;
			//	Parms19 = result.Parms19;
			//	Parms20 = result.Parms20;
			//	Parms21 = result.Parms21;
			//	Parms22 = result.Parms22;
			//	Parms23 = result.Parms23;
			//	Parms24 = result.Parms24;
			//	Parms25 = result.Parms25;
			//	Parms26 = result.Parms26;
			//	Parms27 = result.Parms27;
			//	Parms28 = result.Parms28;
			//	Parms29 = result.Parms29;
			//	Parms30 = result.Parms30;
			//	Parms31 = result.Parms31;
			//	Parms32 = result.Parms32;
			//	Parms33 = result.Parms33;
			//	Parms34 = result.Parms34;
			//	Parms35 = result.Parms35;
			//	Parms36 = result.Parms36;
			//	Parms37 = result.Parms37;
			//	Parms38 = result.Parms38;
			//	Parms39 = result.Parms39;
			//	Parms40 = result.Parms40;
			//	Parms41 = result.Parms41;
			//	Parms42 = result.Parms42;
			//	Parms43 = result.Parms43;
			//	Parms44 = result.Parms44;
			//	Parms45 = result.Parms45;
			//	Parms46 = result.Parms46;
			//	Parms47 = result.Parms47;
			//	Parms48 = result.Parms48;
			//	Parms49 = result.Parms49;
			//	Parms50 = result.Parms50;
			//	Parms51 = result.Parms51;
			//	Parms52 = result.Parms52;
			//	Parms53 = result.Parms53;
			//	Parms54 = result.Parms54;
			//	Parms55 = result.Parms55;
			//	Parms56 = result.Parms56;
			//	Parms57 = result.Parms57;
			//	Parms58 = result.Parms58;
			//	Parms59 = result.Parms59;
			//	Parms60 = result.Parms60;
			//	Parms61 = result.Parms61;
			//	Parms62 = result.Parms62;
			//	Parms63 = result.Parms63;
			//	Parms64 = result.Parms64;
			//	Parms65 = result.Parms65;
			//	Parms66 = result.Parms66;
			//	Parms67 = result.Parms67;
			//	Parms68 = result.Parms68;
			//	Parms69 = result.Parms69;
			//	Parms70 = result.Parms70;
			//	Parms71 = result.Parms71;
			//	Parms72 = result.Parms72;
			//	Parms73 = result.Parms73;
			//	Parms74 = result.Parms74;
			//	Parms75 = result.Parms75;
			//	Parms76 = result.Parms76;
			//	Parms77 = result.Parms77;
			//	Parms78 = result.Parms78;
			//	Parms79 = result.Parms79;
			//	Parms80 = result.Parms80;
			//	Parms81 = result.Parms81;
			//	Parms82 = result.Parms82;
			//	Parms83 = result.Parms83;
			//	Parms84 = result.Parms84;
			//	Parms85 = result.Parms85;
			//	Parms86 = result.Parms86;
			//	Parms87 = result.Parms87;
			//	Parms88 = result.Parms88;
			//	Parms89 = result.Parms89;
			//	Parms90 = result.Parms90;
			//	Parms91 = result.Parms91;
			//	Parms92 = result.Parms92;
			//	Parms93 = result.Parms93;
			//	Parms94 = result.Parms94;
			//	Parms95 = result.Parms95;
			//	Parms96 = result.Parms96;
			//	Parms97 = result.Parms97;
			//	Parms98 = result.Parms98;
			//	Parms99 = result.Parms99;
			//	Parms100 = result.Parms100;
			//	Parms101 = result.Parms101;
			//	Parms102 = result.Parms102;
			//	Parms103 = result.Parms103;
			//	Parms104 = result.Parms104;
			//	Parms105 = result.Parms105;
			//	Parms106 = result.Parms106;
			//	Parms107 = result.Parms107;
			//	Parms108 = result.Parms108;
			//	Parms109 = result.Parms109;
			//	Parms110 = result.Parms110;
			//	Parms111 = result.Parms111;
			//	Parms112 = result.Parms112;
			//	Parms113 = result.Parms113;
			//	Parms114 = result.Parms114;
			//	Parms115 = result.Parms115;
			//	Parms116 = result.Parms116;
			//	Parms117 = result.Parms117;
			//	Parms118 = result.Parms118;
			//	Parms119 = result.Parms119;
			//	Parms120 = result.Parms120;
			//	Parms121 = result.Parms121;
			//	Parms122 = result.Parms122;
			//	Parms123 = result.Parms123;
			//	Parms124 = result.Parms124;
			//	Parms125 = result.Parms125;
			//	Parms126 = result.Parms126;
			//	Parms127 = result.Parms127;
			//	Parms128 = result.Parms128;
			//	Parms129 = result.Parms129;
			//	Parms130 = result.Parms130;
			//	Parms131 = result.Parms131;
			//	Parms132 = result.Parms132;
			//	Parms133 = result.Parms133;
			//	Parms134 = result.Parms134;
			//	Parms135 = result.Parms135;
			//	Parms136 = result.Parms136;
			//	Parms137 = result.Parms137;
			//	Parms138 = result.Parms138;
			//	Parms139 = result.Parms139;
			//	Parms140 = result.Parms140;
			//	Parms141 = result.Parms141;
			//	Parms142 = result.Parms142;
			//	Parms143 = result.Parms143;
			//	Parms144 = result.Parms144;
			//	Parms145 = result.Parms145;
			//	Parms146 = result.Parms146;
			//	Parms147 = result.Parms147;
			//	Parms148 = result.Parms148;
			//	Parms149 = result.Parms149;
			//	Parms150 = result.Parms150;
			//	Parms151 = result.Parms151;
			//	Parms152 = result.Parms152;
			//	Parms153 = result.Parms153;
			//	Parms154 = result.Parms154;
			//	Parms155 = result.Parms155;
			//	Parms156 = result.Parms156;
			//	Parms157 = result.Parms157;
			//	Parms158 = result.Parms158;
			//	Parms159 = result.Parms159;
			//	Parms160 = result.Parms160;
			//	Parms161 = result.Parms161;
			//	Parms162 = result.Parms162;
			//	Parms163 = result.Parms163;
			//	Parms164 = result.Parms164;
			//	Parms165 = result.Parms165;
			//	Parms166 = result.Parms166;
			//	Parms167 = result.Parms167;
			//	Parms168 = result.Parms168;
			//	Parms169 = result.Parms169;
			//	Parms170 = result.Parms170;
			//	Parms171 = result.Parms171;
			//	Parms172 = result.Parms172;
			//	Parms173 = result.Parms173;
			//	Parms174 = result.Parms174;
			//	Parms175 = result.Parms175;
			//	Parms176 = result.Parms176;
			//	Parms177 = result.Parms177;
			//	Parms178 = result.Parms178;
			//	Parms179 = result.Parms179;
			//	Parms180 = result.Parms180;
			//	Parms181 = result.Parms181;
			//	Parms182 = result.Parms182;
			//	Parms183 = result.Parms183;
			//	Parms184 = result.Parms184;
			//	Parms185 = result.Parms185;
			//	Parms186 = result.Parms186;
			//	Parms187 = result.Parms187;
			//	Parms188 = result.Parms188;
			//	Parms189 = result.Parms189;
			//	Parms190 = result.Parms190;
			//	Parms191 = result.Parms191;
			//	Parms192 = result.Parms192;
			//	Parms193 = result.Parms193;
			//	Parms194 = result.Parms194;
			//	Parms195 = result.Parms195;
			//	Parms196 = result.Parms196;
			//	Parms197 = result.Parms197;
			//	Parms198 = result.Parms198;
			//	Parms199 = result.Parms199;
			//	Parms200 = result.Parms200;
			//	Parms201 = result.Parms201;
			//	Parms202 = result.Parms202;
			//	Parms203 = result.Parms203;
			//	Parms204 = result.Parms204;
			//	Parms205 = result.Parms205;
			//	Parms206 = result.Parms206;
			//	Parms207 = result.Parms207;
			//	Parms208 = result.Parms208;
			//	Parms209 = result.Parms209;
			//	Parms210 = result.Parms210;
			//	Parms211 = result.Parms211;
			//	Parms212 = result.Parms212;
			//	Parms213 = result.Parms213;
			//	Parms214 = result.Parms214;
			//	Parms215 = result.Parms215;
			//	Parms216 = result.Parms216;
			//	Parms217 = result.Parms217;
			//	Parms218 = result.Parms218;
			//	Parms219 = result.Parms219;
			//	Parms220 = result.Parms220;
			//	Parms221 = result.Parms221;
			//	Parms222 = result.Parms222;
			//	Parms223 = result.Parms223;
			//	Parms224 = result.Parms224;
			//	Parms225 = result.Parms225;
			//	Parms226 = result.Parms226;
			//	Parms227 = result.Parms227;
			//	Parms228 = result.Parms228;
			//	Parms229 = result.Parms229;
			//	Parms230 = result.Parms230;
			//	Parms231 = result.Parms231;
			//	Parms232 = result.Parms232;
			//	Parms233 = result.Parms233;
			//	Parms234 = result.Parms234;
			//	Parms235 = result.Parms235;
			//	Parms236 = result.Parms236;
			//	Parms237 = result.Parms237;
			//	Parms238 = result.Parms238;
			//	Parms239 = result.Parms239;
			//	Parms240 = result.Parms240;
			//	Parms241 = result.Parms241;
			//	Parms242 = result.Parms242;
			//	Parms243 = result.Parms243;
			//	Parms244 = result.Parms244;
			//	Parms245 = result.Parms245;
			//	Parms246 = result.Parms246;
			//	Parms247 = result.Parms247;
			//	Parms248 = result.Parms248;
			//	Parms249 = result.Parms249;
			//	Parms250 = result.Parms250;
			//	Parms251 = result.Parms251;
			//	Parms252 = result.Parms252;
			//	Parms253 = result.Parms253;
			//	Parms254 = result.Parms254;
			//	Parms255 = result.Parms255;
			//	Parms256 = result.Parms256;
			//	Parms257 = result.Parms257;
			//	Parms258 = result.Parms258;
			//	Parms259 = result.Parms259;
			//	Parms260 = result.Parms260;
			//	Parms261 = result.Parms261;
			//	Parms262 = result.Parms262;
			//	Parms263 = result.Parms263;
			//	Parms264 = result.Parms264;
			//	Parms265 = result.Parms265;
			//	Parms266 = result.Parms266;
			//	Parms267 = result.Parms267;
			//	Parms268 = result.Parms268;
			//	Parms269 = result.Parms269;
			//	Parms270 = result.Parms270;
			//	Parms271 = result.Parms271;
			//	Parms272 = result.Parms272;
			//	Parms273 = result.Parms273;
			//	Parms274 = result.Parms274;
			//	Parms275 = result.Parms275;
			//	Parms276 = result.Parms276;
			//	Parms277 = result.Parms277;
			//	Parms278 = result.Parms278;
			//	Parms279 = result.Parms279;
			//	Parms280 = result.Parms280;
			//	Parms281 = result.Parms281;
			//	Parms282 = result.Parms282;
			//	Parms283 = result.Parms283;
			//	Parms284 = result.Parms284;
			//	Parms285 = result.Parms285;
			//	Parms286 = result.Parms286;
			//	Parms287 = result.Parms287;
			//	Parms288 = result.Parms288;
			//	Parms289 = result.Parms289;
			//	Parms290 = result.Parms290;
			//	Parms291 = result.Parms291;
			//	Parms292 = result.Parms292;
			//	Parms293 = result.Parms293;
			//	Parms294 = result.Parms294;
			//	Parms295 = result.Parms295;
			//	Parms296 = result.Parms296;
			//	Parms297 = result.Parms297;
			//	Parms298 = result.Parms298;
			//	Parms299 = result.Parms299;
			//	Parms300 = result.Parms300;
			//	Parms301 = result.Parms301;
			//	Parms302 = result.Parms302;
			//	Parms303 = result.Parms303;
			//	Parms304 = result.Parms304;
			//	Parms305 = result.Parms305;
			//	Parms306 = result.Parms306;
			//	Parms307 = result.Parms307;
			//	Parms308 = result.Parms308;
			//	Parms309 = result.Parms309;
			//	Parms310 = result.Parms310;
			//	Parms311 = result.Parms311;
			//	Parms312 = result.Parms312;
			//	Parms313 = result.Parms313;
			//	Parms314 = result.Parms314;
			//	Parms315 = result.Parms315;
			//	Parms316 = result.Parms316;
			//	Parms317 = result.Parms317;
			//	Parms318 = result.Parms318;
			//	Parms319 = result.Parms319;
			//	Parms320 = result.Parms320;
			//	Parms321 = result.Parms321;
			//	Parms322 = result.Parms322;
			//	Parms323 = result.Parms323;
			//	Parms324 = result.Parms324;
			//	Parms325 = result.Parms325;
			//	Parms326 = result.Parms326;
			//	Parms327 = result.Parms327;
			//	Parms328 = result.Parms328;
			//	Parms329 = result.Parms329;
			//	Parms330 = result.Parms330;
			//	Parms331 = result.Parms331;
			//	Parms332 = result.Parms332;
			//	Parms333 = result.Parms333;
			//	Parms334 = result.Parms334;
			//	Parms335 = result.Parms335;
			//	Parms336 = result.Parms336;
			//	Parms337 = result.Parms337;
			//	Parms338 = result.Parms338;
			//	Parms339 = result.Parms339;
			//	Parms340 = result.Parms340;
			//	Parms341 = result.Parms341;
			//	Parms342 = result.Parms342;
			//	Parms343 = result.Parms343;
			//	Parms344 = result.Parms344;
			//	Parms345 = result.Parms345;
			//	Parms346 = result.Parms346;
			//	Parms347 = result.Parms347;
			//	Parms348 = result.Parms348;
			//	Parms349 = result.Parms349;
			//	Parms350 = result.Parms350;
			//	Parms351 = result.Parms351;
			//	Parms352 = result.Parms352;
			//	Parms353 = result.Parms353;
			//	Parms354 = result.Parms354;
			//	Parms355 = result.Parms355;
			//	Parms356 = result.Parms356;
			//	Parms357 = result.Parms357;
			//	Parms358 = result.Parms358;
			//	Parms359 = result.Parms359;
			//	Parms360 = result.Parms360;
			//	Parms361 = result.Parms361;
			//	Parms362 = result.Parms362;
			//	Parms363 = result.Parms363;
			//	Parms364 = result.Parms364;
			//	Parms365 = result.Parms365;
			//	Parms366 = result.Parms366;
			//	Parms367 = result.Parms367;
			//	Parms368 = result.Parms368;
			//	Parms369 = result.Parms369;
			//	Parms370 = result.Parms370;
			//	Parms371 = result.Parms371;
			//	Parms372 = result.Parms372;
			//	Parms373 = result.Parms373;
			//	Parms374 = result.Parms374;
			//	Parms375 = result.Parms375;
			//	Parms376 = result.Parms376;
			//	Parms377 = result.Parms377;
			//	Parms378 = result.Parms378;
			//	Parms379 = result.Parms379;
			//	Parms380 = result.Parms380;
			//	Parms381 = result.Parms381;
			//	Parms382 = result.Parms382;
			//	Parms383 = result.Parms383;
			//	Parms384 = result.Parms384;
			//	Parms385 = result.Parms385;
			//	Parms386 = result.Parms386;
			//	Parms387 = result.Parms387;
			//	Parms388 = result.Parms388;
			//	Parms389 = result.Parms389;
			//	Parms390 = result.Parms390;
			//	Parms391 = result.Parms391;
			//	Parms392 = result.Parms392;
			//	Parms393 = result.Parms393;
			//	Parms394 = result.Parms394;
			//	Parms395 = result.Parms395;
			//	Parms396 = result.Parms396;
			//	Parms397 = result.Parms397;
			//	Parms398 = result.Parms398;
			//	Parms399 = result.Parms399;
			//	Parms400 = result.Parms400;
			//	Parms401 = result.Parms401;
			//	Parms402 = result.Parms402;
			//	Parms403 = result.Parms403;
			//	Parms404 = result.Parms404;
			//	Parms405 = result.Parms405;
			//	Parms406 = result.Parms406;
			//	Parms407 = result.Parms407;
			//	Parms408 = result.Parms408;
			//	Parms409 = result.Parms409;
			//	Parms410 = result.Parms410;
			//	Parms411 = result.Parms411;
			//	Parms412 = result.Parms412;
			//	Parms413 = result.Parms413;
			//	Parms414 = result.Parms414;
			//	Parms415 = result.Parms415;
			//	Parms416 = result.Parms416;
			//	Parms417 = result.Parms417;
			//	Parms418 = result.Parms418;
			//	Parms419 = result.Parms419;
			//	Parms420 = result.Parms420;
			//	Parms421 = result.Parms421;
			//	Parms422 = result.Parms422;
			//	Parms423 = result.Parms423;
			//	Parms424 = result.Parms424;
			//	Parms425 = result.Parms425;
			//	Parms426 = result.Parms426;
			//	Parms427 = result.Parms427;
			//	Parms428 = result.Parms428;
			//	Parms429 = result.Parms429;
			//	Parms430 = result.Parms430;
			//	Parms431 = result.Parms431;
			//	Parms432 = result.Parms432;
			//	Parms433 = result.Parms433;
			//	Parms434 = result.Parms434;
			//	Parms435 = result.Parms435;
			//	Parms436 = result.Parms436;
			//	Parms437 = result.Parms437;
			//	Parms438 = result.Parms438;
			//	Parms439 = result.Parms439;
			//	Parms440 = result.Parms440;
			//	Parms441 = result.Parms441;
			//	Parms442 = result.Parms442;
			//	Parms443 = result.Parms443;
			//	Parms444 = result.Parms444;
			//	Parms445 = result.Parms445;
			//	Parms446 = result.Parms446;
			//	Parms447 = result.Parms447;
			//	Parms448 = result.Parms448;
			//	Parms449 = result.Parms449;
			//	Parms450 = result.Parms450;
			//	Parms451 = result.Parms451;
			//	Parms452 = result.Parms452;
			//	Parms453 = result.Parms453;
			//	Parms454 = result.Parms454;
			//	Parms455 = result.Parms455;
			//	Parms456 = result.Parms456;
			//	Parms457 = result.Parms457;
			//	Parms458 = result.Parms458;
			//	Parms459 = result.Parms459;
			//	Parms460 = result.Parms460;
			//	Parms461 = result.Parms461;
			//	Parms462 = result.Parms462;
			//	Parms463 = result.Parms463;
			//	Parms464 = result.Parms464;
			//	Parms465 = result.Parms465;
			//	Parms466 = result.Parms466;
			//	Parms467 = result.Parms467;
			//	Parms468 = result.Parms468;
			//	Parms469 = result.Parms469;
			//	Parms470 = result.Parms470;
			//	Parms471 = result.Parms471;
			//	Parms472 = result.Parms472;
			//	Parms473 = result.Parms473;
			//	Parms474 = result.Parms474;
			//	Parms475 = result.Parms475;
			//	Parms476 = result.Parms476;
			//	Parms477 = result.Parms477;
			//	Parms478 = result.Parms478;
			//	Parms479 = result.Parms479;
			//	Parms480 = result.Parms480;
			//	Parms481 = result.Parms481;
			//	Parms482 = result.Parms482;
			//	Parms483 = result.Parms483;
			//	Parms484 = result.Parms484;
			//	Parms485 = result.Parms485;
			//	Parms486 = result.Parms486;
			//	Parms487 = result.Parms487;
			//	Parms488 = result.Parms488;
			//	Parms489 = result.Parms489;
			//	Parms490 = result.Parms490;
			//	Parms491 = result.Parms491;
			//	Parms492 = result.Parms492;
			//	Parms493 = result.Parms493;
			//	Parms494 = result.Parms494;
			//	Parms495 = result.Parms495;
			//	Parms496 = result.Parms496;
			//	Parms497 = result.Parms497;
			//	Parms498 = result.Parms498;
			//	Parms499 = result.Parms499;
			//	Parms500 = result.Parms500;
			//	Parms501 = result.Parms501;
			//	Parms502 = result.Parms502;
			//	Parms503 = result.Parms503;
			//	Parms504 = result.Parms504;
			//	Parms505 = result.Parms505;
			//	Parms506 = result.Parms506;
			//	Parms507 = result.Parms507;
			//	Parms508 = result.Parms508;
			//	Parms509 = result.Parms509;
			//	Parms510 = result.Parms510;
			//	Parms511 = result.Parms511;
			//	Parms512 = result.Parms512;
			//	Parms513 = result.Parms513;
			//	Parms514 = result.Parms514;
			//	Parms515 = result.Parms515;
			//	Parms516 = result.Parms516;
			//	Parms517 = result.Parms517;
			//	Parms518 = result.Parms518;
			//	Parms519 = result.Parms519;
			//	Parms520 = result.Parms520;
			//	Parms521 = result.Parms521;
			//	Parms522 = result.Parms522;
			//	Parms523 = result.Parms523;
			//	Parms524 = result.Parms524;
			//	Parms525 = result.Parms525;
			//	Parms526 = result.Parms526;
			//	Parms527 = result.Parms527;
			//	Parms528 = result.Parms528;
			//	Parms529 = result.Parms529;
			//	Parms530 = result.Parms530;
			//	Parms531 = result.Parms531;
			//	Parms532 = result.Parms532;
			//	Parms533 = result.Parms533;
			//	Parms534 = result.Parms534;
			//	Parms535 = result.Parms535;
			//	Parms536 = result.Parms536;
			//	Parms537 = result.Parms537;
			//	Parms538 = result.Parms538;
			//	Parms539 = result.Parms539;
			//	Parms540 = result.Parms540;
			//	Parms541 = result.Parms541;
			//	Parms542 = result.Parms542;
			//	Parms543 = result.Parms543;
			//	Parms544 = result.Parms544;
			//	Parms545 = result.Parms545;
			//	Parms546 = result.Parms546;
			//	Parms547 = result.Parms547;
			//	Parms548 = result.Parms548;
			//	Parms549 = result.Parms549;
			//	Parms550 = result.Parms550;
			//	Parms551 = result.Parms551;
			//	Parms552 = result.Parms552;
			//	Parms553 = result.Parms553;
			//	Parms554 = result.Parms554;
			//	Parms555 = result.Parms555;
			//	Parms556 = result.Parms556;
			//	Parms557 = result.Parms557;
			//	Parms558 = result.Parms558;
			//	Parms559 = result.Parms559;
			//	Parms560 = result.Parms560;
			//	Parms561 = result.Parms561;
			//	Parms562 = result.Parms562;
			//	Parms563 = result.Parms563;
			//	Parms564 = result.Parms564;
			//	Parms565 = result.Parms565;
			//	Parms566 = result.Parms566;
			//	Parms567 = result.Parms567;
			//	Parms568 = result.Parms568;
			//	Parms569 = result.Parms569;
			//	Parms570 = result.Parms570;
			//	Parms571 = result.Parms571;
			//	Parms572 = result.Parms572;
			//	Parms573 = result.Parms573;
			//	Parms574 = result.Parms574;
			//	Parms575 = result.Parms575;
			//	Parms576 = result.Parms576;
			//	Parms577 = result.Parms577;
			//	Parms578 = result.Parms578;
			//	Parms579 = result.Parms579;
			//	Parms580 = result.Parms580;
			//	Parms581 = result.Parms581;
			//	Parms582 = result.Parms582;
			//	Parms583 = result.Parms583;
			//	Parms584 = result.Parms584;
			//	Parms585 = result.Parms585;
			//	Parms586 = result.Parms586;
			//	Parms587 = result.Parms587;
			//	Parms588 = result.Parms588;
			//	Parms589 = result.Parms589;
			//	Parms590 = result.Parms590;
			//	Parms591 = result.Parms591;
			//	Parms592 = result.Parms592;
			//	Parms593 = result.Parms593;
			//	Parms594 = result.Parms594;
			//	Parms595 = result.Parms595;
			//	Parms596 = result.Parms596;
			//	Parms597 = result.Parms597;
			//	Parms598 = result.Parms598;
			//	Parms599 = result.Parms599;
			//	Parms600 = result.Parms600;
			//	Parms601 = result.Parms601;
			//	Parms602 = result.Parms602;
			//	Parms603 = result.Parms603;
			//	Parms604 = result.Parms604;
			//	Parms605 = result.Parms605;
			//	Parms606 = result.Parms606;
			//	Parms607 = result.Parms607;
			//	Parms608 = result.Parms608;
			//	Parms609 = result.Parms609;
			//	Parms610 = result.Parms610;
			//	Parms611 = result.Parms611;
			//	Parms612 = result.Parms612;
			//	Parms613 = result.Parms613;
			//	Parms614 = result.Parms614;
			//	Parms615 = result.Parms615;
			//	Parms616 = result.Parms616;
			//	Parms617 = result.Parms617;
			//	Parms618 = result.Parms618;
			//	Parms619 = result.Parms619;
			//	Parms620 = result.Parms620;
			//	Parms621 = result.Parms621;
			//	Parms622 = result.Parms622;
			//	Parms623 = result.Parms623;
			//	Parms624 = result.Parms624;
			//	Parms625 = result.Parms625;
			//	Parms626 = result.Parms626;
			//	Parms627 = result.Parms627;
			//	Parms628 = result.Parms628;
			//	Parms629 = result.Parms629;
			//	Parms630 = result.Parms630;
			//	Parms631 = result.Parms631;
			//	Parms632 = result.Parms632;
			//	Parms633 = result.Parms633;
			//	Parms634 = result.Parms634;
			//	Parms635 = result.Parms635;
			//	Parms636 = result.Parms636;
			//	Parms637 = result.Parms637;
			//	Parms638 = result.Parms638;
			//	Parms639 = result.Parms639;
			//	Parms640 = result.Parms640;
			//	Parms641 = result.Parms641;
			//	Parms642 = result.Parms642;
			//	Parms643 = result.Parms643;
			//	Parms644 = result.Parms644;
			//	Parms645 = result.Parms645;
			//	Parms646 = result.Parms646;
			//	Parms647 = result.Parms647;
			//	Parms648 = result.Parms648;
			//	Parms649 = result.Parms649;
			//	Parms650 = result.Parms650;
			//	Parms651 = result.Parms651;
			//	Parms652 = result.Parms652;
			//	Parms653 = result.Parms653;
			//	Parms654 = result.Parms654;
			//	Parms655 = result.Parms655;
			//	Parms656 = result.Parms656;
			//	Parms657 = result.Parms657;
			//	Parms658 = result.Parms658;
			//	Parms659 = result.Parms659;
			//	Parms660 = result.Parms660;
			//	Parms661 = result.Parms661;
			//	Parms662 = result.Parms662;
			//	Parms663 = result.Parms663;
			//	Parms664 = result.Parms664;
			//	Parms665 = result.Parms665;
			//	Parms666 = result.Parms666;
			//	Parms667 = result.Parms667;
			//	Parms668 = result.Parms668;
			//	Parms669 = result.Parms669;
			//	Parms670 = result.Parms670;
			//	Parms671 = result.Parms671;
			//	Parms672 = result.Parms672;
			//	Parms673 = result.Parms673;
			//	Parms674 = result.Parms674;
			//	Parms675 = result.Parms675;
			//	Parms676 = result.Parms676;
			//	Parms677 = result.Parms677;
			//	Parms678 = result.Parms678;
			//	Parms679 = result.Parms679;
			//	Parms680 = result.Parms680;
			//	Parms681 = result.Parms681;
			//	Parms682 = result.Parms682;
			//	Parms683 = result.Parms683;
			//	Parms684 = result.Parms684;
			//	Parms685 = result.Parms685;
			//	Parms686 = result.Parms686;
			//	Parms687 = result.Parms687;
			//	Parms688 = result.Parms688;
			//	Parms689 = result.Parms689;
			//	Parms690 = result.Parms690;
			//	Parms691 = result.Parms691;
			//	Parms692 = result.Parms692;
			//	Parms693 = result.Parms693;
			//	Parms694 = result.Parms694;
			//	Parms695 = result.Parms695;
			//	Parms696 = result.Parms696;
			//	Parms697 = result.Parms697;
			//	Parms698 = result.Parms698;
			//	Parms699 = result.Parms699;
			//	Parms700 = result.Parms700;
			//	Parms701 = result.Parms701;
			//	Parms702 = result.Parms702;
			//	Parms703 = result.Parms703;
			//	Parms704 = result.Parms704;
			//	Parms705 = result.Parms705;
			//	Parms706 = result.Parms706;
			//	Parms707 = result.Parms707;
			//	Parms708 = result.Parms708;
			//	Parms709 = result.Parms709;
			//	Parms710 = result.Parms710;
			//	Parms711 = result.Parms711;
			//	Parms712 = result.Parms712;
			//	Parms713 = result.Parms713;
			//	Parms714 = result.Parms714;
			//	Parms715 = result.Parms715;
			//	Parms716 = result.Parms716;
			//	Parms717 = result.Parms717;
			//	Parms718 = result.Parms718;
			//	Parms719 = result.Parms719;
			//	Parms720 = result.Parms720;
			//	Parms721 = result.Parms721;
			//	Parms722 = result.Parms722;
			//	Parms723 = result.Parms723;
			//	Parms724 = result.Parms724;
			//	Parms725 = result.Parms725;
			//	Parms726 = result.Parms726;
			//	Parms727 = result.Parms727;
			//	Parms728 = result.Parms728;
			//	Parms729 = result.Parms729;
			//	Parms730 = result.Parms730;
			//	Parms731 = result.Parms731;
			//	Parms732 = result.Parms732;
			//	Parms733 = result.Parms733;
			//	Parms734 = result.Parms734;
			//	Parms735 = result.Parms735;
			//	Parms736 = result.Parms736;
			//	Parms737 = result.Parms737;
			//	Parms738 = result.Parms738;
			//	Parms739 = result.Parms739;
			//	Parms740 = result.Parms740;
			//	Parms741 = result.Parms741;
			//	Parms742 = result.Parms742;
			//	Parms743 = result.Parms743;
			//	Parms744 = result.Parms744;
			//	Parms745 = result.Parms745;
			//	Parms746 = result.Parms746;
			//	Parms747 = result.Parms747;
			//	Parms748 = result.Parms748;
			//	Parms749 = result.Parms749;
			//	Parms750 = result.Parms750;
			//	Parms751 = result.Parms751;
			//	Parms752 = result.Parms752;
			//	Parms753 = result.Parms753;
			//	Parms754 = result.Parms754;
			//	Parms755 = result.Parms755;
			//	Parms756 = result.Parms756;
			//	Parms757 = result.Parms757;
			//	Parms758 = result.Parms758;
			//	Parms759 = result.Parms759;
			//	Parms760 = result.Parms760;
			//	Parms761 = result.Parms761;
			//	Parms762 = result.Parms762;
			//	Parms763 = result.Parms763;
			//	Parms764 = result.Parms764;
			//	Parms765 = result.Parms765;
			//	Parms766 = result.Parms766;
			//	Parms767 = result.Parms767;
			//	Parms768 = result.Parms768;
			//	Parms769 = result.Parms769;
			//	Parms770 = result.Parms770;
			//	Parms771 = result.Parms771;
			//	Parms772 = result.Parms772;
			//	Parms773 = result.Parms773;
			//	Parms774 = result.Parms774;
			//	Parms775 = result.Parms775;
			//	Parms776 = result.Parms776;
			//	Parms777 = result.Parms777;
			//	Parms778 = result.Parms778;
			//	Parms779 = result.Parms779;
			//	Parms780 = result.Parms780;
			//	Parms781 = result.Parms781;
			//	Parms782 = result.Parms782;
			//	Parms783 = result.Parms783;
			//	Parms784 = result.Parms784;
			//	Parms785 = result.Parms785;
			//	Parms786 = result.Parms786;
			//	Parms787 = result.Parms787;
			//	Parms788 = result.Parms788;
			//	Parms789 = result.Parms789;
			//	Parms790 = result.Parms790;
			//	Parms791 = result.Parms791;
			//	Parms792 = result.Parms792;
			//	Parms793 = result.Parms793;
			//	Parms794 = result.Parms794;
			//	Parms795 = result.Parms795;
			//	Parms796 = result.Parms796;
			//	Parms797 = result.Parms797;
			//	Parms798 = result.Parms798;
			//	Parms799 = result.Parms799;
			//	Parms800 = result.Parms800;
			//	Parms801 = result.Parms801;
			//	Parms802 = result.Parms802;
			//	Parms803 = result.Parms803;
			//	Parms804 = result.Parms804;
			//	Parms805 = result.Parms805;
			//	Parms806 = result.Parms806;
			//	Parms807 = result.Parms807;
			//	Parms808 = result.Parms808;
			//	Parms809 = result.Parms809;
			//	Parms810 = result.Parms810;
			//	Parms811 = result.Parms811;
			//	Parms812 = result.Parms812;
			//	Parms813 = result.Parms813;
			//	Parms814 = result.Parms814;
			//	Parms815 = result.Parms815;
			//	Parms816 = result.Parms816;
			//	Parms817 = result.Parms817;
			//	Parms818 = result.Parms818;
			//	Parms819 = result.Parms819;
			//	Parms820 = result.Parms820;
			//	Parms821 = result.Parms821;
			//	Parms822 = result.Parms822;
			//	Parms823 = result.Parms823;
			//	Parms824 = result.Parms824;
			//	Parms825 = result.Parms825;
			//	Parms826 = result.Parms826;
			//	Parms827 = result.Parms827;
			//	Parms828 = result.Parms828;
			//	Parms829 = result.Parms829;
			//	Parms830 = result.Parms830;
			//	Parms831 = result.Parms831;
			//	Parms832 = result.Parms832;
			//	Parms833 = result.Parms833;
			//	Parms834 = result.Parms834;
			//	Parms835 = result.Parms835;
			//	Parms836 = result.Parms836;
			//	Parms837 = result.Parms837;
			//	Parms838 = result.Parms838;
			//	Parms839 = result.Parms839;
			//	Parms840 = result.Parms840;
			//	Parms841 = result.Parms841;
			//	Parms842 = result.Parms842;
			//	Parms843 = result.Parms843;
			//	Parms844 = result.Parms844;
			//	Parms845 = result.Parms845;
			//	Parms846 = result.Parms846;
			//	Parms847 = result.Parms847;
			//	Parms848 = result.Parms848;
			//	Parms849 = result.Parms849;
			//	Parms850 = result.Parms850;
			//	Parms851 = result.Parms851;
			//	Parms852 = result.Parms852;
			//	Parms853 = result.Parms853;
			//	Parms854 = result.Parms854;
			//	Parms855 = result.Parms855;
			//	Parms856 = result.Parms856;
			//	Parms857 = result.Parms857;
			//	Parms858 = result.Parms858;
			//	Parms859 = result.Parms859;
			//	Parms860 = result.Parms860;
			//	Parms861 = result.Parms861;
			//	Parms862 = result.Parms862;
			//	Parms863 = result.Parms863;
			//	Parms864 = result.Parms864;
			//	Parms865 = result.Parms865;
			//	Parms866 = result.Parms866;
			//	Parms867 = result.Parms867;
			//	Parms868 = result.Parms868;
			//	Parms869 = result.Parms869;
			//	Parms870 = result.Parms870;
			//	Parms871 = result.Parms871;
			//	Parms872 = result.Parms872;
			//	Parms873 = result.Parms873;
			//	Parms874 = result.Parms874;
			//	Parms875 = result.Parms875;
			//	Parms876 = result.Parms876;
			//	Parms877 = result.Parms877;
			//	Parms878 = result.Parms878;
			//	Parms879 = result.Parms879;
			//	Parms880 = result.Parms880;
			//	Parms881 = result.Parms881;
			//	Parms882 = result.Parms882;
			//	Parms883 = result.Parms883;
			//	Parms884 = result.Parms884;
			//	Parms885 = result.Parms885;
			//	Parms886 = result.Parms886;
			//	Parms887 = result.Parms887;
			//	Parms888 = result.Parms888;
			//	Parms889 = result.Parms889;
			//	Parms890 = result.Parms890;
			//	Parms891 = result.Parms891;
			//	Parms892 = result.Parms892;
			//	Parms893 = result.Parms893;
			//	Parms894 = result.Parms894;
			//	Parms895 = result.Parms895;
			//	Parms896 = result.Parms896;
			//	Parms897 = result.Parms897;
			//	Parms898 = result.Parms898;
			//	Parms899 = result.Parms899;
			//	Parms900 = result.Parms900;
			//	Parms901 = result.Parms901;
			//	Parms902 = result.Parms902;
			//	Parms903 = result.Parms903;
			//	Parms904 = result.Parms904;
			//	Parms905 = result.Parms905;
			//	Parms906 = result.Parms906;
			//	Parms907 = result.Parms907;
			//	Parms908 = result.Parms908;
			//	Parms909 = result.Parms909;
			//	Parms910 = result.Parms910;
			//	Parms911 = result.Parms911;
			//	Parms912 = result.Parms912;
			//	Parms913 = result.Parms913;
			//	Parms914 = result.Parms914;
			//	Parms915 = result.Parms915;
			//	Parms916 = result.Parms916;
			//	Parms917 = result.Parms917;
			//	Parms918 = result.Parms918;
			//	Parms919 = result.Parms919;
			//	Parms920 = result.Parms920;
			//	Parms921 = result.Parms921;
			//	Parms922 = result.Parms922;
			//	Parms923 = result.Parms923;
			//	Parms924 = result.Parms924;
			//	Parms925 = result.Parms925;
			//	Parms926 = result.Parms926;
			//	Parms927 = result.Parms927;
			//	Parms928 = result.Parms928;
			//	Parms929 = result.Parms929;
			//	Parms930 = result.Parms930;
			//	Parms931 = result.Parms931;
			//	Parms932 = result.Parms932;
			//	Parms933 = result.Parms933;
			//	Parms934 = result.Parms934;
			//	Parms935 = result.Parms935;
			//	Parms936 = result.Parms936;
			//	Parms937 = result.Parms937;
			//	Parms938 = result.Parms938;
			//	Parms939 = result.Parms939;
			//	Parms940 = result.Parms940;
			//	Parms941 = result.Parms941;
			//	Parms942 = result.Parms942;
			//	Parms943 = result.Parms943;
			//	Parms944 = result.Parms944;
			//	Parms945 = result.Parms945;
			//	Parms946 = result.Parms946;
			//	Parms947 = result.Parms947;
			//	Parms948 = result.Parms948;
			//	Parms949 = result.Parms949;
			//	Parms950 = result.Parms950;
			//	Parms951 = result.Parms951;
			//	Parms952 = result.Parms952;
			//	Parms953 = result.Parms953;
			//	Parms954 = result.Parms954;
			//	Parms955 = result.Parms955;
			//	Parms956 = result.Parms956;
			//	Parms957 = result.Parms957;
			//	Parms958 = result.Parms958;
			//	Parms959 = result.Parms959;
			//	Parms960 = result.Parms960;
			//	Parms961 = result.Parms961;
			//	Parms962 = result.Parms962;
			//	Parms963 = result.Parms963;
			//	Parms964 = result.Parms964;
			//	Parms965 = result.Parms965;
			//	Parms966 = result.Parms966;
			//	Parms967 = result.Parms967;
			//	Parms968 = result.Parms968;
			//	Parms969 = result.Parms969;
			//	Parms970 = result.Parms970;
			//	Parms971 = result.Parms971;
			//	Parms972 = result.Parms972;
			//	Parms973 = result.Parms973;
			//	Parms974 = result.Parms974;
			//	Parms975 = result.Parms975;
			//	Parms976 = result.Parms976;
			//	Parms977 = result.Parms977;
			//	Parms978 = result.Parms978;
			//	Parms979 = result.Parms979;
			//	Parms980 = result.Parms980;
			//	Parms981 = result.Parms981;
			//	Parms982 = result.Parms982;
			//	Parms983 = result.Parms983;
			//	Parms984 = result.Parms984;
			//	Parms985 = result.Parms985;
			//	Parms986 = result.Parms986;
			//	Parms987 = result.Parms987;
			//	Parms988 = result.Parms988;
			//	Parms989 = result.Parms989;
			//	Parms990 = result.Parms990;
			//	Parms991 = result.Parms991;
			//	Parms992 = result.Parms992;
			//	Parms993 = result.Parms993;
			//	Parms994 = result.Parms994;
			//	Parms995 = result.Parms995;
			//	Parms996 = result.Parms996;
			//	Parms997 = result.Parms997;
			//	Parms998 = result.Parms998;
			//	Parms999 = result.Parms999;
			//	Parms1000 = result.Parms1000;
			//	return Severity;
			//}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ExcelFetchString(string Text,
		                            string LanguageCode,
		                            string UserName,
		                            string PrimarygroupName,
		                            int? ScopeType,
		                            ref string InterpretedText,
		                            ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iExcelFetchStringExt = new ExcelFetchStringFactory().Create(appDb);
				
				var result = iExcelFetchStringExt.ExcelFetchStringSp(Text,
				                                                     LanguageCode,
				                                                     UserName,
				                                                     PrimarygroupName,
				                                                     ScopeType,
				                                                     InterpretedText,
				                                                     Infobar);
				
				int Severity = result.ReturnCode.Value;
				InterpretedText = result.InterpretedText;
				Infobar = result.Infobar;
				return Severity;
			}
		}

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ExcelGetAvgEndCurrentRateSp(string PSite,
        string PFromCurrCode,
        [Optional] string PToCurrCode,
        [Optional, DefaultParameterValue((byte)1)] byte? PUseBuyRate,
        DateTime? PStartDate,
        DateTime? PEndDate,
        ref decimal? PAvgRate,
        ref decimal? PEndRate,
        ref decimal? PCurrentRate,
        ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iExcelGetAvgEndCurrentRateExt = new ExcelGetAvgEndCurrentRateFactory().Create(appDb);

                var result = iExcelGetAvgEndCurrentRateExt.ExcelGetAvgEndCurrentRateSp(PSite,
                PFromCurrCode,
                PToCurrCode,
                PUseBuyRate,
                PStartDate,
                PEndDate,
                PAvgRate,
                PEndRate,
                PCurrentRate,
                Infobar);

                int Severity = result.ReturnCode.Value;
                PAvgRate = result.PAvgRate;
                PEndRate = result.PEndRate;
                PCurrentRate = result.PCurrentRate;
                Infobar = result.Infobar;
                return Severity;
            }
        }

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ExcelGetPeriodAvgEndRatesForYearSp([Optional] string PSite,
		string PFromCurrCode,
		[Optional] string PToCurrCode,
		[Optional, DefaultParameterValue(1)] int? PUseBuyRate,
		int? PFiscalYear,
		ref decimal? PAvgRate01,
		ref decimal? PEndRate01,
		ref decimal? PAvgRate02,
		ref decimal? PEndRate02,
		ref decimal? PAvgRate03,
		ref decimal? PEndRate03,
		ref decimal? PAvgRate04,
		ref decimal? PEndRate04,
		ref decimal? PAvgRate05,
		ref decimal? PEndRate05,
		ref decimal? PAvgRate06,
		ref decimal? PEndRate06,
		ref decimal? PAvgRate07,
		ref decimal? PEndRate07,
		ref decimal? PAvgRate08,
		ref decimal? PEndRate08,
		ref decimal? PAvgRate09,
		ref decimal? PEndRate09,
		ref decimal? PAvgRate10,
		ref decimal? PEndRate10,
		ref decimal? PAvgRate11,
		ref decimal? PEndRate11,
		ref decimal? PAvgRate12,
		ref decimal? PEndRate12,
		ref decimal? PAvgRate13,
		ref decimal? PEndRate13,
		ref decimal? PCurrentRate,
		ref string Infobar)
		{
			var iExcelGetPeriodAvgEndRatesForYearExt = new ExcelGetPeriodAvgEndRatesForYearFactory().Create(this, true);
			
			var result = iExcelGetPeriodAvgEndRatesForYearExt.ExcelGetPeriodAvgEndRatesForYearSp(PSite,
			PFromCurrCode,
			PToCurrCode,
			PUseBuyRate,
			PFiscalYear,
			PAvgRate01,
			PEndRate01,
			PAvgRate02,
			PEndRate02,
			PAvgRate03,
			PEndRate03,
			PAvgRate04,
			PEndRate04,
			PAvgRate05,
			PEndRate05,
			PAvgRate06,
			PEndRate06,
			PAvgRate07,
			PEndRate07,
			PAvgRate08,
			PEndRate08,
			PAvgRate09,
			PEndRate09,
			PAvgRate10,
			PEndRate10,
			PAvgRate11,
			PEndRate11,
			PAvgRate12,
			PEndRate12,
			PAvgRate13,
			PEndRate13,
			PCurrentRate,
			Infobar);
			
			int Severity = result.ReturnCode.Value;
			PAvgRate01 = result.PAvgRate01;
			PEndRate01 = result.PEndRate01;
			PAvgRate02 = result.PAvgRate02;
			PEndRate02 = result.PEndRate02;
			PAvgRate03 = result.PAvgRate03;
			PEndRate03 = result.PEndRate03;
			PAvgRate04 = result.PAvgRate04;
			PEndRate04 = result.PEndRate04;
			PAvgRate05 = result.PAvgRate05;
			PEndRate05 = result.PEndRate05;
			PAvgRate06 = result.PAvgRate06;
			PEndRate06 = result.PEndRate06;
			PAvgRate07 = result.PAvgRate07;
			PEndRate07 = result.PEndRate07;
			PAvgRate08 = result.PAvgRate08;
			PEndRate08 = result.PEndRate08;
			PAvgRate09 = result.PAvgRate09;
			PEndRate09 = result.PEndRate09;
			PAvgRate10 = result.PAvgRate10;
			PEndRate10 = result.PEndRate10;
			PAvgRate11 = result.PAvgRate11;
			PEndRate11 = result.PEndRate11;
			PAvgRate12 = result.PAvgRate12;
			PEndRate12 = result.PEndRate12;
			PAvgRate13 = result.PAvgRate13;
			PEndRate13 = result.PEndRate13;
			PCurrentRate = result.PCurrentRate;
			Infobar = result.Infobar;
			return Severity;
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ExcelSyteLineGLSp(ref string Queryname,
		string QueryStr,
		[Optional] string QAccountCode,
		[Optional] string QPeriod,
		[Optional] string QYear,
		[Optional] string UnitCode,
		[Optional] string BalType)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iExcelSyteLineGLExt = new ExcelSyteLineGLFactory().Create(appDb);
				
				var result = iExcelSyteLineGLExt.ExcelSyteLineGLSp(Queryname,
				QueryStr,
				QAccountCode,
				QPeriod,
				QYear,
				UnitCode,
				BalType);
				
				int Severity = result.ReturnCode.Value;
				Queryname = result.Queryname;
				return Severity;
			}
		}

    }
}
