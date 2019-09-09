using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class LevelMenuController : MonoBehaviour
{
	public GameObject lock1;

	public GameObject lock2;

	public GameObject lock3;

	public GameObject lock4;

	public GameObject lock5;

	public GameObject lock6;

	public GameObject lock7;

	public GameObject lock8;

	public GameObject lock9;

	public GameObject lock10;

	public GameObject lock11;

	public GameObject lock12;

	public GameObject lock13;

	public GameObject lock14;

	public GameObject lock15;

	public GameObject lock16;

	public GameObject lock17;

	public GameObject lock18;

	public GameObject lock19;

	public GameObject lock20;

	public GameObject lock21;

	public GameObject lock22;

	public GameObject lock23;

	public GameObject lock24;

	public GameObject lock25;

	public GameObject lock26;

	public GameObject lock27;

	public GameObject lock28;

	public GameObject lock29;

	public GameObject lock30;

	public GameObject lock31;

	public GameObject lock32;

	public GameObject lock33;

	public GameObject lock34;

	public GameObject lock35;

	public GameObject lock36;

	public GameObject lock113;

	public GameObject lock114;

	public GameObject lock115;

	public GameObject lock116;

	public GameObject lock117;

	public GameObject lock118;

	public GameObject lock119;

	public GameObject lock120;

	public GameObject lock121;

	public GameObject lock122;

	public GameObject lock123;

	public GameObject lock124;

	public GameObject lock125;

	public GameObject lock126;

	public GameObject lock127;

	public GameObject lock128;

	public GameObject lock129;

	public GameObject lock130;

	public GameObject lock131;

	public GameObject lock132;

	public GameObject lock133;

	public GameObject lock134;

	public GameObject lock135;

	public GameObject lock136;

	public GameObject lock137;

	public GameObject lock138;

	public GameObject lock139;

	public GameObject lock140;

	public GameObject lock141;

	public GameObject lock142;

	public GameObject lock143;

	public GameObject lock144;

	public GameObject lock145;

	public GameObject lock146;

	public GameObject lock147;

	public GameObject lock148;

	public GameObject lock149;

	public GameObject lock150;

	public GameObject lock213;

	public GameObject lock214;

	public GameObject lock215;

	public GameObject lock216;

	public GameObject lock217;

	public GameObject lock218;

	public GameObject lock219;

	public GameObject lock220;

	public GameObject lock221;

	public GameObject lock222;

	public GameObject lock223;

	public GameObject lock224;

	public GameObject level1_0star;

	public GameObject level1_1star;

	public GameObject level1_2star;

	public GameObject level1_3star;

	public GameObject level2_0star;

	public GameObject level2_1star;

	public GameObject level2_2star;

	public GameObject level2_3star;

	public GameObject level3_0star;

	public GameObject level3_1star;

	public GameObject level3_2star;

	public GameObject level3_3star;

	public GameObject level4_0star;

	public GameObject level4_1star;

	public GameObject level4_2star;

	public GameObject level4_3star;

	public GameObject level5_0star;

	public GameObject level5_1star;

	public GameObject level5_2star;

	public GameObject level5_3star;

	public GameObject level6_0star;

	public GameObject level6_1star;

	public GameObject level6_2star;

	public GameObject level6_3star;

	public GameObject level7_0star;

	public GameObject level7_1star;

	public GameObject level7_2star;

	public GameObject level7_3star;

	public GameObject level8_0star;

	public GameObject level8_1star;

	public GameObject level8_2star;

	public GameObject level8_3star;

	public GameObject level9_0star;

	public GameObject level9_1star;

	public GameObject level9_2star;

	public GameObject level9_3star;

	public GameObject level10_0star;

	public GameObject level10_1star;

	public GameObject level10_2star;

	public GameObject level10_3star;

	public GameObject level11_0star;

	public GameObject level11_1star;

	public GameObject level11_2star;

	public GameObject level11_3star;

	public GameObject level12_0star;

	public GameObject level12_1star;

	public GameObject level12_2star;

	public GameObject level12_3star;

	public GameObject level13_0star;

	public GameObject level13_1star;

	public GameObject level13_2star;

	public GameObject level13_3star;

	public GameObject level14_0star;

	public GameObject level14_1star;

	public GameObject level14_2star;

	public GameObject level14_3star;

	public GameObject level15_0star;

	public GameObject level15_1star;

	public GameObject level15_2star;

	public GameObject level15_3star;

	public GameObject level16_0star;

	public GameObject level16_1star;

	public GameObject level16_2star;

	public GameObject level16_3star;

	public GameObject level17_0star;

	public GameObject level17_1star;

	public GameObject level17_2star;

	public GameObject level17_3star;

	public GameObject level18_0star;

	public GameObject level18_1star;

	public GameObject level18_2star;

	public GameObject level18_3star;

	public GameObject level19_0star;

	public GameObject level19_1star;

	public GameObject level19_2star;

	public GameObject level19_3star;

	public GameObject level20_0star;

	public GameObject level20_1star;

	public GameObject level20_2star;

	public GameObject level20_3star;

	public GameObject level21_0star;

	public GameObject level21_1star;

	public GameObject level21_2star;

	public GameObject level21_3star;

	public GameObject level22_0star;

	public GameObject level22_1star;

	public GameObject level22_2star;

	public GameObject level22_3star;

	public GameObject level23_0star;

	public GameObject level23_1star;

	public GameObject level23_2star;

	public GameObject level23_3star;

	public GameObject level24_0star;

	public GameObject level24_1star;

	public GameObject level24_2star;

	public GameObject level24_3star;

	public GameObject level25_0star;

	public GameObject level25_1star;

	public GameObject level25_2star;

	public GameObject level25_3star;

	public GameObject level26_0star;

	public GameObject level26_1star;

	public GameObject level26_2star;

	public GameObject level26_3star;

	public GameObject level27_0star;

	public GameObject level27_1star;

	public GameObject level27_2star;

	public GameObject level27_3star;

	public GameObject level28_0star;

	public GameObject level28_1star;

	public GameObject level28_2star;

	public GameObject level28_3star;

	public GameObject level29_0star;

	public GameObject level29_1star;

	public GameObject level29_2star;

	public GameObject level29_3star;

	public GameObject level31_0star;

	public GameObject level31_1star;

	public GameObject level31_2star;

	public GameObject level31_3star;

	public GameObject level32_0star;

	public GameObject level32_1star;

	public GameObject level32_2star;

	public GameObject level32_3star;

	public GameObject level33_0star;

	public GameObject level33_1star;

	public GameObject level33_2star;

	public GameObject level33_3star;

	public GameObject level34_0star;

	public GameObject level34_1star;

	public GameObject level34_2star;

	public GameObject level34_3star;

	public GameObject level35_0star;

	public GameObject level35_1star;

	public GameObject level35_2star;

	public GameObject level35_3star;

	public GameObject level36_0star;

	public GameObject level36_1star;

	public GameObject level36_2star;

	public GameObject level36_3star;

	public GameObject level30_0star;

	public GameObject level30_1star;

	public GameObject level30_2star;

	public GameObject level30_3star;

	public GameObject level113_0star;

	public GameObject level113_1star;

	public GameObject level113_2star;

	public GameObject level113_3star;

	public GameObject level114_0star;

	public GameObject level114_1star;

	public GameObject level114_2star;

	public GameObject level114_3star;

	public GameObject level115_0star;

	public GameObject level115_1star;

	public GameObject level115_2star;

	public GameObject level115_3star;

	public GameObject level116_0star;

	public GameObject level116_1star;

	public GameObject level116_2star;

	public GameObject level116_3star;

	public GameObject level117_0star;

	public GameObject level117_1star;

	public GameObject level117_2star;

	public GameObject level117_3star;

	public GameObject level118_0star;

	public GameObject level118_1star;

	public GameObject level118_2star;

	public GameObject level118_3star;

	public GameObject level119_0star;

	public GameObject level119_1star;

	public GameObject level119_2star;

	public GameObject level119_3star;

	public GameObject level120_0star;

	public GameObject level120_1star;

	public GameObject level120_2star;

	public GameObject level120_3star;

	public GameObject level121_0star;

	public GameObject level121_1star;

	public GameObject level121_2star;

	public GameObject level121_3star;

	public GameObject level122_0star;

	public GameObject level122_1star;

	public GameObject level122_2star;

	public GameObject level122_3star;

	public GameObject level123_0star;

	public GameObject level123_1star;

	public GameObject level123_2star;

	public GameObject level123_3star;

	public GameObject level124_0star;

	public GameObject level124_1star;

	public GameObject level124_2star;

	public GameObject level124_3star;

	public GameObject level125_0star;

	public GameObject level125_1star;

	public GameObject level125_2star;

	public GameObject level125_3star;

	public GameObject level126_0star;

	public GameObject level126_1star;

	public GameObject level126_2star;

	public GameObject level126_3star;

	public GameObject level127_0star;

	public GameObject level127_1star;

	public GameObject level127_2star;

	public GameObject level127_3star;

	public GameObject level128_0star;

	public GameObject level128_1star;

	public GameObject level128_2star;

	public GameObject level128_3star;

	public GameObject level129_0star;

	public GameObject level129_1star;

	public GameObject level129_2star;

	public GameObject level129_3star;

	public GameObject level130_0star;

	public GameObject level130_1star;

	public GameObject level130_2star;

	public GameObject level130_3star;

	public GameObject level131_0star;

	public GameObject level131_1star;

	public GameObject level131_2star;

	public GameObject level131_3star;

	public GameObject level132_0star;

	public GameObject level132_1star;

	public GameObject level132_2star;

	public GameObject level132_3star;

	public GameObject level133_0star;

	public GameObject level133_1star;

	public GameObject level133_2star;

	public GameObject level133_3star;

	public GameObject level134_0star;

	public GameObject level134_1star;

	public GameObject level134_2star;

	public GameObject level134_3star;

	public GameObject level135_0star;

	public GameObject level135_1star;

	public GameObject level135_2star;

	public GameObject level135_3star;

	public GameObject level136_0star;

	public GameObject level136_1star;

	public GameObject level136_2star;

	public GameObject level136_3star;

	public GameObject level137_0star;

	public GameObject level137_1star;

	public GameObject level137_2star;

	public GameObject level137_3star;

	public GameObject level138_0star;

	public GameObject level138_1star;

	public GameObject level138_2star;

	public GameObject level138_3star;

	public GameObject level139_0star;

	public GameObject level139_1star;

	public GameObject level139_2star;

	public GameObject level139_3star;

	public GameObject level140_0star;

	public GameObject level140_1star;

	public GameObject level140_2star;

	public GameObject level140_3star;

	public GameObject level141_0star;

	public GameObject level141_1star;

	public GameObject level141_2star;

	public GameObject level141_3star;

	public GameObject level142_0star;

	public GameObject level142_1star;

	public GameObject level142_2star;

	public GameObject level142_3star;

	public GameObject level143_0star;

	public GameObject level143_1star;

	public GameObject level143_2star;

	public GameObject level143_3star;

	public GameObject level144_0star;

	public GameObject level144_1star;

	public GameObject level144_2star;

	public GameObject level144_3star;

	public GameObject level145_0star;

	public GameObject level145_1star;

	public GameObject level145_2star;

	public GameObject level145_3star;

	public GameObject level146_0star;

	public GameObject level146_1star;

	public GameObject level146_2star;

	public GameObject level146_3star;

	public GameObject level147_0star;

	public GameObject level147_1star;

	public GameObject level147_2star;

	public GameObject level147_3star;

	public GameObject level148_0star;

	public GameObject level148_1star;

	public GameObject level148_2star;

	public GameObject level148_3star;

	public GameObject level149_0star;

	public GameObject level149_1star;

	public GameObject level149_2star;

	public GameObject level149_3star;

	public GameObject level150_0star;

	public GameObject level150_1star;

	public GameObject level150_2star;

	public GameObject level150_3star;

	public GameObject level213_0star;

	public GameObject level213_1star;

	public GameObject level213_2star;

	public GameObject level213_3star;

	public GameObject level214_0star;

	public GameObject level214_1star;

	public GameObject level214_2star;

	public GameObject level214_3star;

	public GameObject level215_0star;

	public GameObject level215_1star;

	public GameObject level215_2star;

	public GameObject level215_3star;

	public GameObject level216_0star;

	public GameObject level216_1star;

	public GameObject level216_2star;

	public GameObject level216_3star;

	public GameObject level217_0star;

	public GameObject level217_1star;

	public GameObject level217_2star;

	public GameObject level217_3star;

	public GameObject level218_0star;

	public GameObject level218_1star;

	public GameObject level218_2star;

	public GameObject level218_3star;

	public GameObject level219_0star;

	public GameObject level219_1star;

	public GameObject level219_2star;

	public GameObject level219_3star;

	public GameObject level220_0star;

	public GameObject level220_1star;

	public GameObject level220_2star;

	public GameObject level220_3star;

	public GameObject level221_0star;

	public GameObject level221_1star;

	public GameObject level221_2star;

	public GameObject level221_3star;

	public GameObject level222_0star;

	public GameObject level222_1star;

	public GameObject level222_2star;

	public GameObject level222_3star;

	public GameObject level223_0star;

	public GameObject level223_1star;

	public GameObject level223_2star;

	public GameObject level223_3star;

	public GameObject level224_0star;

	public GameObject level224_1star;

	public GameObject level224_2star;

	public GameObject level224_3star;

	public Text nStarCount;

	public Text dStartCount;

	public Text sStarCount;

	public GameObject nWorld;

	public GameObject sWorld;

	public GameObject dWorld;

	private void awake()
	{
	}

	private void OnApplicationPause(bool pauseStatus)
	{
		if (pauseStatus)
		{
			try
			{
				Analytics.CustomEvent(Global.world + "_DeviceHome", new Dictionary<string, object>
				{
					{
						"DeviceHome",
						"Level Select Scene"
					}
				});
			}
			catch (Exception)
			{
			}
		}
	}

	private void Start()
	{
		Global.tutorialDisplaye = false;
		nStarCount.text = string.Empty + MainMenuController.getNatureStars();
		dStartCount.text = string.Empty + MainMenuController.getDesertStars();
		sStarCount.text = string.Empty + MainMenuController.getSnowStars();
		try
		{
			if (AdScript.bannerAd1 == null || Global.currentLevel != 0)
			{
			}
			if (AdScript.bannerAd2 != null)
			{
			}
			if (AdScript.adView != null)
			{
				AdScript.adView.Dispose();
			}
		}
		catch (Exception)
		{
		}
		if (Global.world.Equals("N"))
		{
			nWorld.SetActive(value: true);
			sWorld.SetActive(value: false);
			dWorld.SetActive(value: false);
		}
		else if (Global.world.Equals("S"))
		{
			nWorld.SetActive(value: false);
			sWorld.SetActive(value: true);
			dWorld.SetActive(value: false);
		}
		else if (Global.world.Equals("D"))
		{
			nWorld.SetActive(value: false);
			sWorld.SetActive(value: false);
			dWorld.SetActive(value: true);
		}
		level1_0star.SetActive(value: true);
		if (PlayerPrefs.HasKey("level1"))
		{
			lock2.SetActive(value: false);
			level2_0star.SetActive(value: true);
			level1_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level1"))
			{
			case 3:
				level1_3star.SetActive(value: true);
				break;
			case 2:
				level1_2star.SetActive(value: true);
				break;
			case 1:
				level1_1star.SetActive(value: true);
				break;
			default:
				level1_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level2"))
		{
			lock2.SetActive(value: false);
			level3_0star.SetActive(value: true);
			lock3.SetActive(value: false);
			level2_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level2"))
			{
			case 3:
				level2_3star.SetActive(value: true);
				break;
			case 2:
				level2_2star.SetActive(value: true);
				break;
			case 1:
				level2_1star.SetActive(value: true);
				break;
			default:
				level2_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level3"))
		{
			lock4.SetActive(value: false);
			level4_0star.SetActive(value: true);
			level3_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level3"))
			{
			case 3:
				level3_3star.SetActive(value: true);
				break;
			case 2:
				level3_2star.SetActive(value: true);
				break;
			case 1:
				level3_1star.SetActive(value: true);
				break;
			default:
				level3_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level4"))
		{
			lock5.SetActive(value: false);
			level4_0star.SetActive(value: false);
			level5_0star.SetActive(value: true);
			switch (PlayerPrefs.GetInt("level4"))
			{
			case 3:
				level4_3star.SetActive(value: true);
				break;
			case 2:
				level4_2star.SetActive(value: true);
				break;
			case 1:
				level4_1star.SetActive(value: true);
				break;
			default:
				level4_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level5"))
		{
			level6_0star.SetActive(value: true);
			lock6.SetActive(value: false);
			level5_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level5"))
			{
			case 3:
				level5_3star.SetActive(value: true);
				break;
			case 2:
				level5_2star.SetActive(value: true);
				break;
			case 1:
				level5_1star.SetActive(value: true);
				break;
			default:
				level5_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level6"))
		{
			level7_0star.SetActive(value: true);
			lock7.SetActive(value: false);
			level6_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level6"))
			{
			case 3:
				level6_3star.SetActive(value: true);
				break;
			case 2:
				level6_2star.SetActive(value: true);
				break;
			case 1:
				level6_1star.SetActive(value: true);
				break;
			default:
				level6_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level7"))
		{
			level8_0star.SetActive(value: true);
			lock8.SetActive(value: false);
			level7_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level7"))
			{
			case 3:
				level7_3star.SetActive(value: true);
				break;
			case 2:
				level7_2star.SetActive(value: true);
				break;
			case 1:
				level7_1star.SetActive(value: true);
				break;
			default:
				level7_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level8"))
		{
			level9_0star.SetActive(value: true);
			lock9.SetActive(value: false);
			level8_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level8"))
			{
			case 3:
				level8_3star.SetActive(value: true);
				break;
			case 2:
				level8_2star.SetActive(value: true);
				break;
			case 1:
				level8_1star.SetActive(value: true);
				break;
			default:
				level8_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level9"))
		{
			level10_0star.SetActive(value: true);
			lock10.SetActive(value: false);
			level9_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level9"))
			{
			case 3:
				level9_3star.SetActive(value: true);
				break;
			case 2:
				level9_2star.SetActive(value: true);
				break;
			case 1:
				level9_1star.SetActive(value: true);
				break;
			default:
				level9_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level10"))
		{
			level11_0star.SetActive(value: true);
			lock11.SetActive(value: false);
			level10_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level10"))
			{
			case 3:
				level10_3star.SetActive(value: true);
				break;
			case 2:
				level10_2star.SetActive(value: true);
				break;
			case 1:
				level10_1star.SetActive(value: true);
				break;
			default:
				level10_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level11"))
		{
			level12_0star.SetActive(value: true);
			lock12.SetActive(value: false);
			level11_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level11"))
			{
			case 3:
				level11_3star.SetActive(value: true);
				break;
			case 2:
				level11_2star.SetActive(value: true);
				break;
			case 1:
				level11_1star.SetActive(value: true);
				break;
			default:
				level11_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level12"))
		{
			level13_0star.SetActive(value: true);
			lock13.SetActive(value: false);
			level12_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level12"))
			{
			case 3:
				level12_3star.SetActive(value: true);
				break;
			case 2:
				level12_2star.SetActive(value: true);
				break;
			case 1:
				level12_1star.SetActive(value: true);
				break;
			default:
				level12_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level13"))
		{
			level14_0star.SetActive(value: true);
			lock14.SetActive(value: false);
			level13_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level13"))
			{
			case 3:
				level13_3star.SetActive(value: true);
				break;
			case 2:
				level13_2star.SetActive(value: true);
				break;
			case 1:
				level13_1star.SetActive(value: true);
				break;
			default:
				level13_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level14"))
		{
			level15_0star.SetActive(value: true);
			lock15.SetActive(value: false);
			level14_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level14"))
			{
			case 3:
				level14_3star.SetActive(value: true);
				break;
			case 2:
				level14_2star.SetActive(value: true);
				break;
			case 1:
				level14_1star.SetActive(value: true);
				break;
			default:
				level14_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level15"))
		{
			level16_0star.SetActive(value: true);
			lock16.SetActive(value: false);
			level15_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level15"))
			{
			case 3:
				level15_3star.SetActive(value: true);
				break;
			case 2:
				level15_2star.SetActive(value: true);
				break;
			case 1:
				level15_1star.SetActive(value: true);
				break;
			default:
				level15_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level16"))
		{
			level17_0star.SetActive(value: true);
			lock17.SetActive(value: false);
			level16_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level16"))
			{
			case 3:
				level16_3star.SetActive(value: true);
				break;
			case 2:
				level16_2star.SetActive(value: true);
				break;
			case 1:
				level16_1star.SetActive(value: true);
				break;
			default:
				level16_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level17"))
		{
			level18_0star.SetActive(value: true);
			lock18.SetActive(value: false);
			level17_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level17"))
			{
			case 3:
				level17_3star.SetActive(value: true);
				break;
			case 2:
				level17_2star.SetActive(value: true);
				break;
			case 1:
				level17_1star.SetActive(value: true);
				break;
			default:
				level17_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level18"))
		{
			level19_0star.SetActive(value: true);
			lock19.SetActive(value: false);
			level18_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level18"))
			{
			case 3:
				level18_3star.SetActive(value: true);
				break;
			case 2:
				level18_2star.SetActive(value: true);
				break;
			case 1:
				level18_1star.SetActive(value: true);
				break;
			default:
				level18_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level19"))
		{
			level20_0star.SetActive(value: true);
			lock20.SetActive(value: false);
			level19_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level19"))
			{
			case 3:
				level19_3star.SetActive(value: true);
				break;
			case 2:
				level19_2star.SetActive(value: true);
				break;
			case 1:
				level19_1star.SetActive(value: true);
				break;
			default:
				level19_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level20"))
		{
			level21_0star.SetActive(value: true);
			lock21.SetActive(value: false);
			level20_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level20"))
			{
			case 3:
				level20_3star.SetActive(value: true);
				break;
			case 2:
				level20_2star.SetActive(value: true);
				break;
			case 1:
				level20_1star.SetActive(value: true);
				break;
			default:
				level20_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level21"))
		{
			level22_0star.SetActive(value: true);
			lock22.SetActive(value: false);
			level21_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level21"))
			{
			case 3:
				level21_3star.SetActive(value: true);
				break;
			case 2:
				level21_2star.SetActive(value: true);
				break;
			case 1:
				level21_1star.SetActive(value: true);
				break;
			default:
				level21_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level22"))
		{
			level22_0star.SetActive(value: true);
			lock23.SetActive(value: false);
			level22_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level22"))
			{
			case 3:
				level22_3star.SetActive(value: true);
				break;
			case 2:
				level22_2star.SetActive(value: true);
				break;
			case 1:
				level22_1star.SetActive(value: true);
				break;
			default:
				level22_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level23"))
		{
			level24_0star.SetActive(value: true);
			lock24.SetActive(value: false);
			level23_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level23"))
			{
			case 3:
				level23_3star.SetActive(value: true);
				break;
			case 2:
				level23_2star.SetActive(value: true);
				break;
			case 1:
				level23_1star.SetActive(value: true);
				break;
			default:
				level23_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level24"))
		{
			level25_0star.SetActive(value: true);
			lock25.SetActive(value: false);
			level24_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level24"))
			{
			case 3:
				level24_3star.SetActive(value: true);
				break;
			case 2:
				level24_2star.SetActive(value: true);
				break;
			case 1:
				level24_1star.SetActive(value: true);
				break;
			default:
				level24_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level25"))
		{
			level26_0star.SetActive(value: true);
			lock26.SetActive(value: false);
			level25_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level25"))
			{
			case 3:
				level25_3star.SetActive(value: true);
				break;
			case 2:
				level25_2star.SetActive(value: true);
				break;
			case 1:
				level25_1star.SetActive(value: true);
				break;
			default:
				level25_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level26"))
		{
			level27_0star.SetActive(value: true);
			lock27.SetActive(value: false);
			level26_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level26"))
			{
			case 3:
				level26_3star.SetActive(value: true);
				break;
			case 2:
				level26_2star.SetActive(value: true);
				break;
			case 1:
				level26_1star.SetActive(value: true);
				break;
			default:
				level26_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level27"))
		{
			level28_0star.SetActive(value: true);
			lock28.SetActive(value: false);
			level27_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level27"))
			{
			case 3:
				level27_3star.SetActive(value: true);
				break;
			case 2:
				level27_2star.SetActive(value: true);
				break;
			case 1:
				level27_1star.SetActive(value: true);
				break;
			default:
				level27_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level28"))
		{
			level29_0star.SetActive(value: true);
			lock29.SetActive(value: false);
			level28_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level28"))
			{
			case 3:
				level28_3star.SetActive(value: true);
				break;
			case 2:
				level28_2star.SetActive(value: true);
				break;
			case 1:
				level28_1star.SetActive(value: true);
				break;
			default:
				level28_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level29"))
		{
			level30_0star.SetActive(value: true);
			lock30.SetActive(value: false);
			level29_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level29"))
			{
			case 3:
				level29_3star.SetActive(value: true);
				break;
			case 2:
				level29_2star.SetActive(value: true);
				break;
			case 1:
				level29_1star.SetActive(value: true);
				break;
			default:
				level29_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level30"))
		{
			level31_0star.SetActive(value: true);
			lock31.SetActive(value: false);
			level30_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level30"))
			{
			case 3:
				level30_3star.SetActive(value: true);
				break;
			case 2:
				level30_2star.SetActive(value: true);
				break;
			case 1:
				level30_1star.SetActive(value: true);
				break;
			default:
				level30_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level31"))
		{
			level32_0star.SetActive(value: true);
			lock32.SetActive(value: false);
			level31_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level31"))
			{
			case 3:
				level31_3star.SetActive(value: true);
				break;
			case 2:
				level31_2star.SetActive(value: true);
				break;
			case 1:
				level31_1star.SetActive(value: true);
				break;
			default:
				level31_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level32"))
		{
			level33_0star.SetActive(value: true);
			lock33.SetActive(value: false);
			level32_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level32"))
			{
			case 3:
				level32_3star.SetActive(value: true);
				break;
			case 2:
				level32_2star.SetActive(value: true);
				break;
			case 1:
				level32_1star.SetActive(value: true);
				break;
			default:
				level32_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level33"))
		{
			level34_0star.SetActive(value: true);
			lock34.SetActive(value: false);
			level33_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level33"))
			{
			case 3:
				level33_3star.SetActive(value: true);
				break;
			case 2:
				level33_2star.SetActive(value: true);
				break;
			case 1:
				level33_1star.SetActive(value: true);
				break;
			default:
				level33_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level34"))
		{
			level35_0star.SetActive(value: true);
			lock35.SetActive(value: false);
			level34_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level34"))
			{
			case 3:
				level34_3star.SetActive(value: true);
				break;
			case 2:
				level34_2star.SetActive(value: true);
				break;
			case 1:
				level34_1star.SetActive(value: true);
				break;
			default:
				level34_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level35"))
		{
			level36_0star.SetActive(value: true);
			lock36.SetActive(value: false);
			level35_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level35"))
			{
			case 3:
				level35_3star.SetActive(value: true);
				break;
			case 2:
				level35_2star.SetActive(value: true);
				break;
			case 1:
				level35_1star.SetActive(value: true);
				break;
			default:
				level35_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level12"))
		{
			level113_0star.SetActive(value: true);
			lock113.SetActive(value: false);
		}
		if (PlayerPrefs.HasKey("level24"))
		{
			level213_0star.SetActive(value: true);
			lock213.SetActive(value: false);
		}
		if (PlayerPrefs.HasKey("level113"))
		{
			level114_0star.SetActive(value: true);
			lock114.SetActive(value: false);
			level113_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level113"))
			{
			case 3:
				level113_3star.SetActive(value: true);
				break;
			case 2:
				level113_2star.SetActive(value: true);
				break;
			case 1:
				level113_1star.SetActive(value: true);
				break;
			default:
				level113_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level114"))
		{
			level115_0star.SetActive(value: true);
			lock115.SetActive(value: false);
			level114_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level114"))
			{
			case 3:
				level114_3star.SetActive(value: true);
				break;
			case 2:
				level114_2star.SetActive(value: true);
				break;
			case 1:
				level114_1star.SetActive(value: true);
				break;
			default:
				level114_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level115"))
		{
			level116_0star.SetActive(value: true);
			lock116.SetActive(value: false);
			level115_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level115"))
			{
			case 3:
				level115_3star.SetActive(value: true);
				break;
			case 2:
				level115_2star.SetActive(value: true);
				break;
			case 1:
				level115_1star.SetActive(value: true);
				break;
			default:
				level115_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level116"))
		{
			level117_0star.SetActive(value: true);
			lock117.SetActive(value: false);
			level116_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level116"))
			{
			case 3:
				level116_3star.SetActive(value: true);
				break;
			case 2:
				level116_2star.SetActive(value: true);
				break;
			case 1:
				level116_1star.SetActive(value: true);
				break;
			default:
				level115_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level117"))
		{
			level118_0star.SetActive(value: true);
			lock118.SetActive(value: false);
			level117_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level117"))
			{
			case 3:
				level117_3star.SetActive(value: true);
				break;
			case 2:
				level117_2star.SetActive(value: true);
				break;
			case 1:
				level117_1star.SetActive(value: true);
				break;
			default:
				level117_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level118"))
		{
			level119_0star.SetActive(value: true);
			lock119.SetActive(value: false);
			level118_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level118"))
			{
			case 3:
				level118_3star.SetActive(value: true);
				break;
			case 2:
				level118_2star.SetActive(value: true);
				break;
			case 1:
				level118_1star.SetActive(value: true);
				break;
			default:
				level118_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level119"))
		{
			level120_0star.SetActive(value: true);
			lock120.SetActive(value: false);
			level119_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level119"))
			{
			case 3:
				level119_3star.SetActive(value: true);
				break;
			case 2:
				level119_2star.SetActive(value: true);
				break;
			case 1:
				level119_1star.SetActive(value: true);
				break;
			default:
				level119_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level120"))
		{
			level121_0star.SetActive(value: true);
			lock121.SetActive(value: false);
			level120_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level120"))
			{
			case 3:
				level120_3star.SetActive(value: true);
				break;
			case 2:
				level120_2star.SetActive(value: true);
				break;
			case 1:
				level120_1star.SetActive(value: true);
				break;
			default:
				level120_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level121"))
		{
			level122_0star.SetActive(value: true);
			lock122.SetActive(value: false);
			level121_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level121"))
			{
			case 3:
				level121_3star.SetActive(value: true);
				break;
			case 2:
				level121_2star.SetActive(value: true);
				break;
			case 1:
				level121_1star.SetActive(value: true);
				break;
			default:
				level121_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level122"))
		{
			level123_0star.SetActive(value: true);
			lock123.SetActive(value: false);
			level122_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level122"))
			{
			case 3:
				level122_3star.SetActive(value: true);
				break;
			case 2:
				level122_2star.SetActive(value: true);
				break;
			case 1:
				level122_1star.SetActive(value: true);
				break;
			default:
				level122_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level123"))
		{
			level124_0star.SetActive(value: true);
			lock124.SetActive(value: false);
			level123_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level123"))
			{
			case 3:
				level123_3star.SetActive(value: true);
				break;
			case 2:
				level123_2star.SetActive(value: true);
				break;
			case 1:
				level123_1star.SetActive(value: true);
				break;
			default:
				level123_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level124"))
		{
			level125_0star.SetActive(value: true);
			lock125.SetActive(value: false);
			level124_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level124"))
			{
			case 3:
				level124_3star.SetActive(value: true);
				break;
			case 2:
				level124_2star.SetActive(value: true);
				break;
			case 1:
				level124_1star.SetActive(value: true);
				break;
			default:
				level124_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level125"))
		{
			level126_0star.SetActive(value: true);
			lock126.SetActive(value: false);
			level125_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level125"))
			{
			case 3:
				level125_3star.SetActive(value: true);
				break;
			case 2:
				level125_2star.SetActive(value: true);
				break;
			case 1:
				level125_1star.SetActive(value: true);
				break;
			default:
				level125_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level126"))
		{
			level127_0star.SetActive(value: true);
			lock127.SetActive(value: false);
			level126_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level126"))
			{
			case 3:
				level126_3star.SetActive(value: true);
				break;
			case 2:
				level126_2star.SetActive(value: true);
				break;
			case 1:
				level126_1star.SetActive(value: true);
				break;
			default:
				level127_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level127"))
		{
			level128_0star.SetActive(value: true);
			lock128.SetActive(value: false);
			level127_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level127"))
			{
			case 3:
				level127_3star.SetActive(value: true);
				break;
			case 2:
				level127_2star.SetActive(value: true);
				break;
			case 1:
				level127_1star.SetActive(value: true);
				break;
			default:
				level127_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level128"))
		{
			level129_0star.SetActive(value: true);
			lock129.SetActive(value: false);
			level128_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level128"))
			{
			case 3:
				level128_3star.SetActive(value: true);
				break;
			case 2:
				level128_2star.SetActive(value: true);
				break;
			case 1:
				level128_1star.SetActive(value: true);
				break;
			default:
				level128_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level129"))
		{
			level130_0star.SetActive(value: true);
			lock130.SetActive(value: false);
			level129_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level129"))
			{
			case 3:
				level129_3star.SetActive(value: true);
				break;
			case 2:
				level129_2star.SetActive(value: true);
				break;
			case 1:
				level129_1star.SetActive(value: true);
				break;
			default:
				level129_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level130"))
		{
			level131_0star.SetActive(value: true);
			lock131.SetActive(value: false);
			level130_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level130"))
			{
			case 3:
				level130_3star.SetActive(value: true);
				break;
			case 2:
				level130_2star.SetActive(value: true);
				break;
			case 1:
				level130_1star.SetActive(value: true);
				break;
			default:
				level130_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level131"))
		{
			level132_0star.SetActive(value: true);
			lock132.SetActive(value: false);
			level131_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level131"))
			{
			case 3:
				level131_3star.SetActive(value: true);
				break;
			case 2:
				level131_2star.SetActive(value: true);
				break;
			case 1:
				level131_1star.SetActive(value: true);
				break;
			default:
				level131_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level132"))
		{
			level133_0star.SetActive(value: true);
			lock133.SetActive(value: false);
			level132_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level132"))
			{
			case 3:
				level132_3star.SetActive(value: true);
				break;
			case 2:
				level132_2star.SetActive(value: true);
				break;
			case 1:
				level132_1star.SetActive(value: true);
				break;
			default:
				level132_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level133"))
		{
			level134_0star.SetActive(value: true);
			lock134.SetActive(value: false);
			level133_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level133"))
			{
			case 3:
				level133_3star.SetActive(value: true);
				break;
			case 2:
				level133_2star.SetActive(value: true);
				break;
			case 1:
				level133_1star.SetActive(value: true);
				break;
			default:
				level133_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level134"))
		{
			level135_0star.SetActive(value: true);
			lock135.SetActive(value: false);
			level134_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level134"))
			{
			case 3:
				level134_3star.SetActive(value: true);
				break;
			case 2:
				level134_2star.SetActive(value: true);
				break;
			case 1:
				level134_1star.SetActive(value: true);
				break;
			default:
				level134_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level135"))
		{
			level136_0star.SetActive(value: true);
			lock136.SetActive(value: false);
			level135_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level135"))
			{
			case 3:
				level135_3star.SetActive(value: true);
				break;
			case 2:
				level135_2star.SetActive(value: true);
				break;
			case 1:
				level135_1star.SetActive(value: true);
				break;
			default:
				level135_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level136"))
		{
			level137_0star.SetActive(value: true);
			lock137.SetActive(value: false);
			level136_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level136"))
			{
			case 3:
				level136_3star.SetActive(value: true);
				break;
			case 2:
				level136_2star.SetActive(value: true);
				break;
			case 1:
				level136_1star.SetActive(value: true);
				break;
			default:
				level136_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level137"))
		{
			level138_0star.SetActive(value: true);
			lock138.SetActive(value: false);
			level137_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level137"))
			{
			case 3:
				level137_3star.SetActive(value: true);
				break;
			case 2:
				level137_2star.SetActive(value: true);
				break;
			case 1:
				level137_1star.SetActive(value: true);
				break;
			default:
				level137_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level138"))
		{
			level139_0star.SetActive(value: true);
			lock139.SetActive(value: false);
			level138_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level138"))
			{
			case 3:
				level138_3star.SetActive(value: true);
				break;
			case 2:
				level138_2star.SetActive(value: true);
				break;
			case 1:
				level138_1star.SetActive(value: true);
				break;
			default:
				level138_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level139"))
		{
			level140_0star.SetActive(value: true);
			lock140.SetActive(value: false);
			level139_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level139"))
			{
			case 3:
				level139_3star.SetActive(value: true);
				break;
			case 2:
				level139_2star.SetActive(value: true);
				break;
			case 1:
				level139_1star.SetActive(value: true);
				break;
			default:
				level139_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level140"))
		{
			level141_0star.SetActive(value: true);
			lock141.SetActive(value: false);
			level140_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level140"))
			{
			case 3:
				level140_3star.SetActive(value: true);
				break;
			case 2:
				level140_2star.SetActive(value: true);
				break;
			case 1:
				level140_1star.SetActive(value: true);
				break;
			default:
				level140_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level141"))
		{
			level142_0star.SetActive(value: true);
			lock142.SetActive(value: false);
			level141_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level141"))
			{
			case 3:
				level141_3star.SetActive(value: true);
				break;
			case 2:
				level141_2star.SetActive(value: true);
				break;
			case 1:
				level141_1star.SetActive(value: true);
				break;
			default:
				level141_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level142"))
		{
			level143_0star.SetActive(value: true);
			lock143.SetActive(value: false);
			level142_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level142"))
			{
			case 3:
				level142_3star.SetActive(value: true);
				break;
			case 2:
				level142_2star.SetActive(value: true);
				break;
			case 1:
				level142_1star.SetActive(value: true);
				break;
			default:
				level142_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level143"))
		{
			level144_0star.SetActive(value: true);
			lock144.SetActive(value: false);
			level143_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level143"))
			{
			case 3:
				level143_3star.SetActive(value: true);
				break;
			case 2:
				level143_2star.SetActive(value: true);
				break;
			case 1:
				level143_1star.SetActive(value: true);
				break;
			default:
				level143_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level144"))
		{
			level145_0star.SetActive(value: true);
			lock145.SetActive(value: false);
			level144_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level144"))
			{
			case 3:
				level144_3star.SetActive(value: true);
				break;
			case 2:
				level144_2star.SetActive(value: true);
				break;
			case 1:
				level144_1star.SetActive(value: true);
				break;
			default:
				level144_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level145"))
		{
			level146_0star.SetActive(value: true);
			lock146.SetActive(value: false);
			level145_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level145"))
			{
			case 3:
				level145_3star.SetActive(value: true);
				break;
			case 2:
				level145_2star.SetActive(value: true);
				break;
			case 1:
				level145_1star.SetActive(value: true);
				break;
			default:
				level145_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level146"))
		{
			level147_0star.SetActive(value: true);
			lock147.SetActive(value: false);
			level146_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level146"))
			{
			case 3:
				level146_3star.SetActive(value: true);
				break;
			case 2:
				level146_2star.SetActive(value: true);
				break;
			case 1:
				level146_1star.SetActive(value: true);
				break;
			default:
				level146_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level147"))
		{
			level148_0star.SetActive(value: true);
			lock148.SetActive(value: false);
			level147_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level147"))
			{
			case 3:
				level147_3star.SetActive(value: true);
				break;
			case 2:
				level147_2star.SetActive(value: true);
				break;
			case 1:
				level147_1star.SetActive(value: true);
				break;
			default:
				level147_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level148"))
		{
			level149_0star.SetActive(value: true);
			lock149.SetActive(value: false);
			level148_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level148"))
			{
			case 3:
				level148_3star.SetActive(value: true);
				break;
			case 2:
				level148_2star.SetActive(value: true);
				break;
			case 1:
				level148_1star.SetActive(value: true);
				break;
			default:
				level148_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level149"))
		{
			level150_0star.SetActive(value: true);
			lock150.SetActive(value: false);
			level149_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level149"))
			{
			case 3:
				level149_3star.SetActive(value: true);
				break;
			case 2:
				level149_2star.SetActive(value: true);
				break;
			case 1:
				level149_1star.SetActive(value: true);
				break;
			default:
				level149_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level150"))
		{
			level150_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level150"))
			{
			case 3:
				level150_3star.SetActive(value: true);
				break;
			case 2:
				level150_2star.SetActive(value: true);
				break;
			case 1:
				level150_1star.SetActive(value: true);
				break;
			default:
				level150_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level213"))
		{
			level214_0star.SetActive(value: true);
			lock214.SetActive(value: false);
			level213_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level213"))
			{
			case 3:
				level213_3star.SetActive(value: true);
				break;
			case 2:
				level213_2star.SetActive(value: true);
				break;
			case 1:
				level213_1star.SetActive(value: true);
				break;
			default:
				level213_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level214"))
		{
			level215_0star.SetActive(value: true);
			lock215.SetActive(value: false);
			level214_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level214"))
			{
			case 3:
				level214_3star.SetActive(value: true);
				break;
			case 2:
				level214_2star.SetActive(value: true);
				break;
			case 1:
				level214_1star.SetActive(value: true);
				break;
			default:
				level214_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level215"))
		{
			level216_0star.SetActive(value: true);
			lock216.SetActive(value: false);
			level215_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level215"))
			{
			case 3:
				level215_3star.SetActive(value: true);
				break;
			case 2:
				level215_2star.SetActive(value: true);
				break;
			case 1:
				level215_1star.SetActive(value: true);
				break;
			default:
				level215_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level216"))
		{
			level217_0star.SetActive(value: true);
			lock217.SetActive(value: false);
			level216_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level216"))
			{
			case 3:
				level216_3star.SetActive(value: true);
				break;
			case 2:
				level216_2star.SetActive(value: true);
				break;
			case 1:
				level116_1star.SetActive(value: true);
				break;
			default:
				level215_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level217"))
		{
			level218_0star.SetActive(value: true);
			lock218.SetActive(value: false);
			level217_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level217"))
			{
			case 3:
				level217_3star.SetActive(value: true);
				break;
			case 2:
				level217_2star.SetActive(value: true);
				break;
			case 1:
				level217_1star.SetActive(value: true);
				break;
			default:
				level217_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level218"))
		{
			level219_0star.SetActive(value: true);
			lock219.SetActive(value: false);
			level218_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level218"))
			{
			case 3:
				level218_3star.SetActive(value: true);
				break;
			case 2:
				level218_2star.SetActive(value: true);
				break;
			case 1:
				level218_1star.SetActive(value: true);
				break;
			default:
				level218_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level219"))
		{
			level220_0star.SetActive(value: true);
			lock220.SetActive(value: false);
			level219_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level219"))
			{
			case 3:
				level219_3star.SetActive(value: true);
				break;
			case 2:
				level219_2star.SetActive(value: true);
				break;
			case 1:
				level219_1star.SetActive(value: true);
				break;
			default:
				level219_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level220"))
		{
			level221_0star.SetActive(value: true);
			lock221.SetActive(value: false);
			level220_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level220"))
			{
			case 3:
				level220_3star.SetActive(value: true);
				break;
			case 2:
				level220_2star.SetActive(value: true);
				break;
			case 1:
				level220_1star.SetActive(value: true);
				break;
			default:
				level220_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level221"))
		{
			level222_0star.SetActive(value: true);
			lock222.SetActive(value: false);
			level221_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level221"))
			{
			case 3:
				level221_3star.SetActive(value: true);
				break;
			case 2:
				level221_2star.SetActive(value: true);
				break;
			case 1:
				level221_1star.SetActive(value: true);
				break;
			default:
				level221_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level222"))
		{
			level223_0star.SetActive(value: true);
			lock223.SetActive(value: false);
			level222_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level222"))
			{
			case 3:
				level222_3star.SetActive(value: true);
				break;
			case 2:
				level222_2star.SetActive(value: true);
				break;
			case 1:
				level222_1star.SetActive(value: true);
				break;
			default:
				level222_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level223"))
		{
			level224_0star.SetActive(value: true);
			lock224.SetActive(value: false);
			level223_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level223"))
			{
			case 3:
				level223_3star.SetActive(value: true);
				break;
			case 2:
				level223_2star.SetActive(value: true);
				break;
			case 1:
				level223_1star.SetActive(value: true);
				break;
			default:
				level223_0star.SetActive(value: true);
				break;
			}
		}
		if (PlayerPrefs.HasKey("level224"))
		{
			level224_0star.SetActive(value: false);
			switch (PlayerPrefs.GetInt("level224"))
			{
			case 3:
				level224_3star.SetActive(value: true);
				break;
			case 2:
				level224_2star.SetActive(value: true);
				break;
			case 1:
				level224_1star.SetActive(value: true);
				break;
			default:
				level224_0star.SetActive(value: true);
				break;
			}
		}
	}

	public void PlayGame()
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1 && AudioManager.Instance != null)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		if (!lock1.activeSelf)
		{
			SceneLoader.LoadAScene("LEVEL1");
		}
	}

	public void PlayGame2()
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1 && AudioManager.Instance != null)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		if (!lock2.activeSelf)
		{
			SceneLoader.LoadAScene("LEVEL2");
		}
	}

	public void PlayGame3()
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1 && AudioManager.Instance != null)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		if (!lock3.activeSelf)
		{
			SceneLoader.LoadAScene("LEVEL3");
		}
	}

	public void PlayGame4()
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1 && AudioManager.Instance != null)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		if (!lock4.activeSelf)
		{
			SceneLoader.LoadAScene("LEVEL4");
		}
	}

	public void PlayGame5()
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1 && AudioManager.Instance != null)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		if (!lock5.activeSelf)
		{
			SceneLoader.LoadAScene("LEVEL5");
		}
	}

	public void loadLevel6()
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1 && AudioManager.Instance != null)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		if (!lock6.activeSelf)
		{
			SceneLoader.LoadAScene("LEVEL6");
		}
	}

	public void PlayGame7()
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1 && AudioManager.Instance != null)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		if (!lock7.activeSelf)
		{
			SceneLoader.LoadAScene("LEVEL7");
		}
	}

	public void PlayGame8()
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1 && AudioManager.Instance != null)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		if (!lock8.activeSelf)
		{
			SceneLoader.LoadAScene("LEVEL8");
		}
	}

	public void PlayGame9()
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1 && AudioManager.Instance != null)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		if (!lock9.activeSelf)
		{
			SceneLoader.LoadAScene("LEVEL9");
		}
	}

	public void PlayGame10()
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1 && AudioManager.Instance != null)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		if (!lock10.activeSelf)
		{
			SceneLoader.LoadAScene("LEVEL10");
		}
	}

	public void PlayGame11()
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1 && AudioManager.Instance != null)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		if (!lock11.activeSelf)
		{
			SceneLoader.LoadAScene("LEVEL11");
		}
	}

	public void PlayGame12()
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1 && AudioManager.Instance != null)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		if (!lock12.activeSelf)
		{
			SceneLoader.LoadAScene("LEVEL12");
		}
	}

	public void PlayGame13()
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1 && AudioManager.Instance != null && AudioManager.Instance != null)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		if (!lock13.activeSelf)
		{
			SceneLoader.LoadAScene("LEVEL13");
		}
	}

	public void PlayGame14()
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1 && AudioManager.Instance != null && AudioManager.Instance != null)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		if (!lock14.activeSelf)
		{
			SceneLoader.LoadAScene("LEVEL14");
		}
	}

	public void PlayGame15()
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1 && AudioManager.Instance != null && AudioManager.Instance != null)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		if (!lock15.activeSelf)
		{
			SceneLoader.LoadAScene("LEVEL15");
		}
	}

	public void PlayGame16()
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1 && AudioManager.Instance != null && AudioManager.Instance != null)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		if (!lock16.activeSelf)
		{
			SceneLoader.LoadAScene("LEVEL16");
		}
	}

	public void PlayGame17()
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1 && AudioManager.Instance != null && AudioManager.Instance != null)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		if (!lock17.activeSelf)
		{
			SceneLoader.LoadAScene("LEVEL17");
		}
	}

	public void PlayGame18()
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1 && AudioManager.Instance != null && AudioManager.Instance != null)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		if (!lock18.activeSelf)
		{
			SceneLoader.LoadAScene("LEVEL18");
		}
	}

	public void PlayGame19()
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1 && AudioManager.Instance != null && AudioManager.Instance != null)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		if (!lock19.activeSelf)
		{
			SceneLoader.LoadAScene("LEVEL19");
		}
	}

	public void PlayGame20()
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1 && AudioManager.Instance != null)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		if (!lock20.activeSelf)
		{
			SceneLoader.LoadAScene("LEVEL20");
		}
	}

	public void PlayGame21()
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1 && AudioManager.Instance != null)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		if (!lock21.activeSelf)
		{
			SceneLoader.LoadAScene("LEVEL21");
		}
	}

	public void PlayGame22()
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1 && AudioManager.Instance != null)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		if (!lock22.activeSelf)
		{
			SceneLoader.LoadAScene("LEVEL22");
		}
	}

	public void PlayGame23()
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1 && AudioManager.Instance != null)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		if (!lock23.activeSelf)
		{
			SceneLoader.LoadAScene("LEVEL23");
		}
	}

	public void PlayGame24()
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1 && AudioManager.Instance != null)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		if (!lock24.activeSelf)
		{
			SceneLoader.LoadAScene("LEVEL24");
		}
	}

	public void PlayGame25()
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1 && AudioManager.Instance != null)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		if (!lock25.activeSelf)
		{
			SceneLoader.LoadAScene("LEVEL25");
		}
	}

	public void PlayGame26()
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1 && AudioManager.Instance != null)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		if (!lock26.activeSelf)
		{
			SceneLoader.LoadAScene("LEVEL26");
		}
	}

	public void PlayGame27()
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1 && AudioManager.Instance != null)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		if (!lock27.activeSelf)
		{
			SceneLoader.LoadAScene("LEVEL27");
		}
	}

	public void PlayGame28()
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1 && AudioManager.Instance != null)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		if (!lock28.activeSelf)
		{
			SceneLoader.LoadAScene("LEVEL28");
		}
	}

	public void PlayGame29()
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1 && AudioManager.Instance != null)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		if (!lock29.activeSelf)
		{
			SceneLoader.LoadAScene("LEVEL29");
		}
	}

	public void PlayGame30()
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1 && AudioManager.Instance != null)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		if (!lock30.activeSelf)
		{
			SceneLoader.LoadAScene("LEVEL30");
		}
	}

	public void PlayGame31()
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1 && AudioManager.Instance != null)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		if (!lock31.activeSelf)
		{
			SceneLoader.LoadAScene("LEVEL31");
		}
	}

	public void PlayGame32()
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1 && AudioManager.Instance != null)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		if (!lock32.activeSelf)
		{
			SceneLoader.LoadAScene("LEVEL32");
		}
	}

	public void PlayGame33()
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1 && AudioManager.Instance != null)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		if (!lock33.activeSelf)
		{
			SceneLoader.LoadAScene("LEVEL33");
		}
	}

	public void PlayGame34()
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1 && AudioManager.Instance != null)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		if (!lock34.activeSelf)
		{
			SceneLoader.LoadAScene("LEVEL34");
		}
	}

	public void PlayGame35()
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1 && AudioManager.Instance != null)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		if (!lock35.activeSelf)
		{
			SceneLoader.LoadAScene("LEVEL35");
		}
	}

	public void PlayGame36()
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1 && AudioManager.Instance != null)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		if (!lock36.activeSelf)
		{
			SceneLoader.LoadAScene("LEVEL36");
		}
	}

	public void GoBack()
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1 && AudioManager.Instance != null)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		UnityEngine.SceneManagement.SceneManager.LoadScene("LEVEL_SELECT_new");
	}

	public void GoToMenu()
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1 && AudioManager.Instance != null)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		Global.exitLevel = Global.currentLevel;
		Global.currentLevel = 1;
		Global.fromLevelSelection = true;
		UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
	}

	private void Update()
	{
		if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
		{
			Global.exitLevel = Global.currentLevel;
			Global.currentLevel = 1;
			Global.fromLevelSelection = true;
			SceneLoader.LoadAScene("MainMenu");
		}
	}

	public void LoadLevel(int level)
	{
		int @int = PlayerPrefs.GetInt("SOUND");
		if (@int == 1 && AudioManager.Instance != null)
		{
			AudioManager.Instance.ClickSound.Play();
		}
		if (level == 113 && PlayerPrefs.HasKey("level12"))
		{
			SceneLoader.LoadAScene("LEVEL" + level);
		}
		if (level == 213)
		{
			if (PlayerPrefs.HasKey("level24"))
			{
				SceneLoader.LoadAScene("LEVEL" + level);
			}
		}
		else if (PlayerPrefs.HasKey("level" + (level - 1)))
		{
			SceneLoader.LoadAScene("LEVEL" + level);
		}
	}
}
