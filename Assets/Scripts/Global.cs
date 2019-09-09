using System.Collections;
using UnityEngine;

public class Global : MonoBehaviour
{
	public static int gTotalMissingCount = 1;

	public static int gTotalFailBlastCount = 1;

	public static int gGameLife = 3;

	public static int gSpecialBubbleCount = 0;

	public static int gMissingCount = 0;

	public static int gFailBlastCount = 0;

	public static int gGamePoint = 0;

	public static int gGameScore = 0;

	public static int count = 0;

	public static int birdCount = 0;

	public static int TotalbirdCount = 0;

	public static int target = 0;

	public static int currentLevel = 0;

	public static int[] gBubblePoints = new int[8]
	{
		10,
		20,
		50,
		-1,
		30,
		-1,
		40,
		-1
	};

	public static bool gMusicFlag = true;

	public static bool isSkipActive = false;

	public static bool isContinuePopActive = false;

	public static bool isRewardVidAvail = false;

	public static int[] gBasketBottleId = new int[8]
	{
		0,
		0,
		0,
		1,
		0,
		1,
		0,
		0
	};

	public static float[] gBasketBottlePos = new float[8]
	{
		-0.7f,
		-0.49f,
		-0.32f,
		0f,
		-0.14f,
		0f,
		0.04f,
		0.18f
	};

	public static ArrayList botList = new ArrayList();

	public static ArrayList brokenBotList = new ArrayList();

	public static string world = "N";

	public static bool isEditor = false;

	public static bool fromLevelSelection = false;

	public static float lastAdDisplayTime = 0f;

	public static bool rewardUsed = false;

	public static bool tutorialDisplaye = false;

	public static int exitLevel = 1;

	public static int retryCount;

	public static bool isFirstTime = true;

	public static bool isLaunchAdDisplayed = false;

	public static float bottleCollisionTime = 0f;

	public static bool isBottleCollission = false;

	public static int retryCount1 = 3;

	public static int retryCount2 = 3;

	public static int retryCount3 = 2;

	public static int retryCount4 = 2;

	public static int noOfTries = 0;

	public static int bannerLevel = 3;

	public static float AdInterval = 60f;

	public static float AdGap1 = 60f;

	public static float AdGap2 = 55f;

	public static float AdGap3 = 50f;

	public static float AdGap4 = 50f;

	public static float backFillAdGap = 60f;

	public static float backFillAdGapToContinue = 180f;

	public static float const1 = 30f;

	public static bool backFillAds = true;

	public static bool loadedFromServer = false;
}
