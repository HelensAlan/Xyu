using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using Bussiness;
using log4net;
using SqlDataProvider.Data;

// Token: 0x02000002 RID: 2
public class PetMgr
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
	public static bool Init()
	{
		return PetMgr.ReLoad();
	}

	// Token: 0x06000002 RID: 2 RVA: 0x00002058 File Offset: 0x00000258
	public static bool ReLoad()
	{
		try
		{
			try
			{
				using (ProduceBussiness produceBussiness = new ProduceBussiness())
				{
					Dictionary<string, PetConfigInfo> petConfigDic = produceBussiness.GetAllPetConfig().ToDictionary((PetConfigInfo x) => x.Name);
					Dictionary<int, PetLevelInfo> petLevelDic = produceBussiness.GetAllPetLevel().ToDictionary((PetLevelInfo x) => x.Level);
					Dictionary<int, PetSkillElementInfo> petSkillElementDic = produceBussiness.GetAllPetSkillElementInfo().ToDictionary((PetSkillElementInfo x) => x.ID);
					Dictionary<int, PetSkillInfo> petSkillDic = produceBussiness.GetAllPetSkillInfo().ToDictionary((PetSkillInfo x) => x.ID);
					Dictionary<int, PetSkillTemplateInfo> petSkillTemplateDic = produceBussiness.GetAllPetSkillTemplateInfo().ToDictionary((PetSkillTemplateInfo x) => x.SkillID);
					Dictionary<int, PetTemplateInfo> petTemplateDic = produceBussiness.GetAllPetTemplateInfo().ToDictionary((PetTemplateInfo x) => x.TemplateID);
					Dictionary<int, PetFightPropertyInfo> petFightPropertyDic = produceBussiness.GetAllPetFightProperty().ToDictionary((PetFightPropertyInfo x) => x.ID);
					Dictionary<int, PetStarExpInfo> petStarExpDic = produceBussiness.GetAllPetStarExp().ToDictionary((PetStarExpInfo x) => x.OldID);
					PetMgr._petConfigDic = petConfigDic;
					PetMgr._petLevelDic = petLevelDic;
					PetMgr._petSkillElementDic = petSkillElementDic;
					PetMgr._petSkillDic = petSkillDic;
					PetMgr._petSkillTemplateDic = petSkillTemplateDic;
					PetMgr._petTemplateDic = petTemplateDic;
					PetMgr._petFightPropertyDic = petFightPropertyDic;
					PetMgr._petStarExpDic = petStarExpDic;
					List<GameNeedPetSkillInfo> needPetSkillInfoList = PetMgr.LoadGameNeedPetSkill();
					if (needPetSkillInfoList.Count > 0)
					{
						Interlocked.Exchange<List<GameNeedPetSkillInfo>>(ref PetMgr.list_0, needPetSkillInfoList);
					}
					return true;
				}
			}
			catch
			{
			}
		}
		catch (Exception ex)
		{
			if (PetMgr._log.IsErrorEnabled)
			{
				PetMgr._log.Error("PetMgr", ex);
			}
		}
		return false;
	}

	// Token: 0x06000003 RID: 3 RVA: 0x0000229C File Offset: 0x0000049C
	public static PetStarExpInfo[] GetPetStarExp()
	{
		return PetMgr._petStarExpDic.Values.ToArray<PetStarExpInfo>();
	}

	// Token: 0x06000004 RID: 4 RVA: 0x000022B0 File Offset: 0x000004B0
	public static PetStarExpInfo FindPetStarExp(int oldID)
	{
		PetMgr._lock.AcquireWriterLock(-1);
		try
		{
			if (PetMgr._petStarExpDic.ContainsKey(oldID))
			{
				return PetMgr._petStarExpDic[oldID];
			}
		}
		finally
		{
			PetMgr._lock.ReleaseWriterLock();
		}
		return null;
	}

	// Token: 0x06000005 RID: 5 RVA: 0x00002304 File Offset: 0x00000504
	public static PetFightPropertyInfo FindFightProperty(int level)
	{
		PetMgr._lock.AcquireWriterLock(-1);
		try
		{
			if (PetMgr._petFightPropertyDic.ContainsKey(level))
			{
				return PetMgr._petFightPropertyDic[level];
			}
		}
		finally
		{
			PetMgr._lock.ReleaseWriterLock();
		}
		return null;
	}

	// Token: 0x06000006 RID: 6 RVA: 0x00002358 File Offset: 0x00000558
	public static int GetEvolutionGP(int level)
	{
		PetFightPropertyInfo petFightPropertyInfo = PetMgr.FindFightProperty(level + 1);
		if (petFightPropertyInfo == null)
		{
			return -1;
		}
		return petFightPropertyInfo.Exp;
	}

	// Token: 0x06000007 RID: 7 RVA: 0x0000236D File Offset: 0x0000056D
	public static int GetEvolutionMax()
	{
		return PetMgr._petFightPropertyDic.Count;
	}

	// Token: 0x06000008 RID: 8 RVA: 0x0000237C File Offset: 0x0000057C
	public static int GetEvolutionGrade(int GP)
	{
		int count = PetMgr._petFightPropertyDic.Count;
		if (GP >= PetMgr.FindFightProperty(count).Exp)
		{
			return count;
		}
		int level = 1;
		while (level <= count)
		{
			PetFightPropertyInfo fightProperty = PetMgr.FindFightProperty(level);
			if (fightProperty == null)
			{
				return 1;
			}
			if (GP < fightProperty.Exp)
			{
				if (level - 1 >= 0)
				{
					return level - 1;
				}
				return 0;
			}
			else
			{
				level++;
			}
		}
		return 0;
	}

	// Token: 0x06000009 RID: 9 RVA: 0x000023D2 File Offset: 0x000005D2
	public static PetConfigInfo FindConfig(string key)
	{
		if (PetMgr._petConfigDic == null)
		{
			PetMgr.Init();
		}
		if (PetMgr._petConfigDic.ContainsKey(key))
		{
			return PetMgr._petConfigDic[key];
		}
		return null;
	}

	// Token: 0x0600000A RID: 10 RVA: 0x000023FB File Offset: 0x000005FB
	public static PetLevelInfo FindPetLevel(int level)
	{
		if (PetMgr._petLevelDic == null)
		{
			PetMgr.Init();
		}
		if (PetMgr._petLevelDic.ContainsKey(level))
		{
			return PetMgr._petLevelDic[level];
		}
		return null;
	}

	// Token: 0x0600000B RID: 11 RVA: 0x00002424 File Offset: 0x00000624
	public static PetSkillElementInfo FindPetSkillElement(int SkillID)
	{
		if (PetMgr._petSkillElementDic == null)
		{
			PetMgr.Init();
		}
		if (PetMgr._petSkillElementDic.ContainsKey(SkillID))
		{
			return PetMgr._petSkillElementDic[SkillID];
		}
		return null;
	}

	// Token: 0x0600000C RID: 12 RVA: 0x0000244D File Offset: 0x0000064D
	public static PetSkillInfo FindPetSkill(int SkillID)
	{
		if (PetMgr._petSkillDic == null)
		{
			PetMgr.Init();
		}
		if (PetMgr._petSkillDic.ContainsKey(SkillID))
		{
			return PetMgr._petSkillDic[SkillID];
		}
		return null;
	}

	// Token: 0x0600000D RID: 13 RVA: 0x00002478 File Offset: 0x00000678
	public static PetSkillInfo[] GetPetSkills()
	{
		List<PetSkillInfo> petSkillInfoList = new List<PetSkillInfo>();
		if (PetMgr._petSkillDic == null)
		{
			PetMgr.Init();
		}
		foreach (PetSkillInfo petSkillInfo in PetMgr._petSkillDic.Values)
		{
			petSkillInfoList.Add(petSkillInfo);
		}
		return petSkillInfoList.ToArray();
	}

	// Token: 0x0600000E RID: 14 RVA: 0x000024E8 File Offset: 0x000006E8
	public static PetSkillTemplateInfo GetPetSkillTemplate(int ID)
	{
		if (PetMgr._petSkillTemplateDic == null)
		{
			PetMgr.Init();
		}
		if (PetMgr._petSkillTemplateDic.ContainsKey(ID))
		{
			return PetMgr._petSkillTemplateDic[ID];
		}
		return null;
	}

	// Token: 0x0600000F RID: 15 RVA: 0x00002514 File Offset: 0x00000714
	public static PetTemplateInfo FindPetTemplate(int TemplateID)
	{
		PetMgr._lock.AcquireWriterLock(-1);
		try
		{
			if (PetMgr._petTemplateDic.ContainsKey(TemplateID))
			{
				return PetMgr._petTemplateDic[TemplateID];
			}
		}
		finally
		{
			PetMgr._lock.ReleaseWriterLock();
		}
		return null;
	}

	// Token: 0x06000010 RID: 16 RVA: 0x00002568 File Offset: 0x00000768
	public static PetTemplateInfo FindPetTemplateByKind(int star, int kindId)
	{
		foreach (PetTemplateInfo petTemplateInfo in PetMgr._petTemplateDic.Values)
		{
			if (petTemplateInfo.KindID == kindId && star == petTemplateInfo.StarLevel)
			{
				return petTemplateInfo;
			}
		}
		return null;
	}

	// Token: 0x06000011 RID: 17 RVA: 0x000025D4 File Offset: 0x000007D4
	public static List<int> GetPetSkillByKindID(int KindID, int lv, int playerLevel)
	{
		List<int> intList = new List<int>();
		List<string> stringList = new List<string>();
		PetSkillTemplateInfo[] petSkillByKindId = PetMgr.GetPetSkillByKindID(KindID);
		int num4 = ((lv > playerLevel) ? playerLevel : lv);
		for (int index = 1; index <= num4; index++)
		{
			foreach (PetSkillTemplateInfo skillTemplateInfo in petSkillByKindId)
			{
				if (skillTemplateInfo.MinLevel == index)
				{
					string deleteSkillIds = skillTemplateInfo.DeleteSkillIDs;
					char[] chArray = new char[] { ',' };
					foreach (string str in deleteSkillIds.Split(chArray))
					{
						stringList.Add(str);
					}
					intList.Add(skillTemplateInfo.SkillID);
				}
			}
		}
		foreach (string s in stringList)
		{
			if (!string.IsNullOrEmpty(s))
			{
				int num5 = int.Parse(s);
				intList.Remove(num5);
			}
		}
		intList.Sort();
		return intList;
	}

	// Token: 0x06000012 RID: 18 RVA: 0x000026E8 File Offset: 0x000008E8
	public static PetSkillTemplateInfo[] GetPetSkillByKindID(int KindID)
	{
		List<PetSkillTemplateInfo> skillTemplateInfoList = new List<PetSkillTemplateInfo>();
		foreach (PetSkillTemplateInfo skillTemplateInfo in PetMgr._petSkillTemplateDic.Values)
		{
			if (skillTemplateInfo.KindID == KindID)
			{
				skillTemplateInfoList.Add(skillTemplateInfo);
			}
		}
		return skillTemplateInfoList.ToArray();
	}

	// Token: 0x06000013 RID: 19 RVA: 0x00002754 File Offset: 0x00000954
	public static List<PetInfo> CreateFirstAdoptList(int userID, int playerLevel)
	{
		List<int> intList = new List<int> { 100301, 110301, 120301, 130301 };
		List<PetInfo> usersPetInfoList = new List<PetInfo>();
		for (int place = 0; place < intList.Count; place++)
		{
			PetInfo pet = PetMgr.CreatePet(PetMgr.FindPetTemplate(intList[place]), userID, place, playerLevel);
			usersPetInfoList.Add(pet);
		}
		return usersPetInfoList;
	}

	// Token: 0x06000014 RID: 20 RVA: 0x000027C8 File Offset: 0x000009C8
	public static int UpdateEvolution(int TemplateID, int lv)
	{
		string str = TemplateID.ToString();
		int int32_3 = Convert.ToInt32(PetMgr.FindConfig("EvolutionLevel1").Value);
		int int32_4 = Convert.ToInt32(PetMgr.FindConfig("EvolutionLevel2").Value);
		PetTemplateInfo petTemplateInfo = PetMgr.FindPetTemplate((str.Substring(str.Length - 1, 1) == "1") ? ((lv < int32_3) ? TemplateID : ((lv >= int32_4) ? (TemplateID + 2) : (TemplateID + 1))) : ((!(str.Substring(str.Length - 1, 1) == "2")) ? TemplateID : (TemplateID + 1)));
		if (petTemplateInfo == null)
		{
			return TemplateID;
		}
		return petTemplateInfo.TemplateID;
	}

	// Token: 0x06000015 RID: 21 RVA: 0x00002868 File Offset: 0x00000A68
	public static string UpdateSkillPet(int Level, int TemplateID, int playerLevel)
	{
		PetTemplateInfo petTemplate = PetMgr.FindPetTemplate(TemplateID);
		if (petTemplate == null)
		{
			PetMgr._log.Error("Pet not found: " + TemplateID.ToString());
			return "";
		}
		List<int> petSkillByKindId = PetMgr.GetPetSkillByKindID(petTemplate.KindID, Level, playerLevel);
		string str = petSkillByKindId[0].ToString() + ",0";
		for (int index = 1; index < petSkillByKindId.Count; index++)
		{
			str = string.Concat(new string[]
			{
				str,
				"|",
				petSkillByKindId[index].ToString(),
				",",
				index.ToString()
			});
		}
		return str;
	}

	// Token: 0x06000016 RID: 22 RVA: 0x0000291C File Offset: 0x00000B1C
	public static int GetLevel(int GP, int playerLevel)
	{
		if (GP >= PetMgr.FindPetLevel(playerLevel).GP)
		{
			return playerLevel;
		}
		int level2 = 1;
		while (level2 <= playerLevel)
		{
			if (GP < PetMgr.FindPetLevel(level2).GP)
			{
				if (level2 - 1 != 0)
				{
					return level2 - 1;
				}
				return 1;
			}
			else
			{
				level2++;
			}
		}
		return 1;
	}

	// Token: 0x06000017 RID: 23 RVA: 0x00002960 File Offset: 0x00000B60
	public static int GetGP(int level, int playerLevel)
	{
		for (int level2 = 1; level2 <= playerLevel; level2++)
		{
			if (level == PetMgr.FindPetLevel(level2).Level)
			{
				return PetMgr.FindPetLevel(level2).GP;
			}
		}
		return 0;
	}

	// Token: 0x06000018 RID: 24 RVA: 0x00002994 File Offset: 0x00000B94
	public static void GetEvolutionPropArr(PetInfo _petInfo, PetTemplateInfo petTempleteInfo, ref double[] propArr, ref double[] growArr)
	{
		double[] numArray11 = new double[]
		{
			(double)(_petInfo.Blood * 100),
			(double)(_petInfo.Attack * 100),
			(double)(_petInfo.Defence * 100),
			(double)(_petInfo.Agility * 100),
			(double)(_petInfo.Luck * 100)
		};
		double[] numArray12 = new double[]
		{
			(double)_petInfo.BloodGrow,
			(double)_petInfo.AttackGrow,
			(double)_petInfo.DefenceGrow,
			(double)_petInfo.AgilityGrow,
			(double)_petInfo.LuckGrow
		};
		double[] numArray13 = new double[]
		{
			(double)petTempleteInfo.HighBlood,
			(double)petTempleteInfo.HighAttack,
			(double)petTempleteInfo.HighDefence,
			(double)petTempleteInfo.HighAgility,
			(double)petTempleteInfo.HighLuck
		};
		double[] propArr2 = new double[]
		{
			(double)petTempleteInfo.HighBloodGrow,
			(double)petTempleteInfo.HighAttackGrow,
			(double)petTempleteInfo.HighDefenceGrow,
			(double)petTempleteInfo.HighAgilityGrow,
			(double)petTempleteInfo.HighLuckGrow
		};
		double[] numArray14 = numArray13;
		double[] addedPropArr5 = PetMgr.GetAddedPropArr(1, propArr2);
		double[] numArray15 = numArray13;
		double[] addedPropArr6 = PetMgr.GetAddedPropArr(2, propArr2);
		double[] numArray16 = numArray13;
		double[] addedPropArr7 = PetMgr.GetAddedPropArr(3, propArr2);
		if (_petInfo.Level < 30)
		{
			for (int index3 = 0; index3 < numArray14.Length; index3++)
			{
				numArray14[index3] += (double)(_petInfo.Level - 1) * addedPropArr5[index3] - numArray11[index3];
				addedPropArr5[index3] -= numArray12[index3];
				numArray14[index3] = Math.Ceiling(numArray14[index3] / 10.0) / 10.0;
				addedPropArr5[index3] = Math.Ceiling(addedPropArr5[index3] / 10.0) / 10.0;
			}
			propArr = numArray14;
			growArr = addedPropArr5;
			return;
		}
		if (_petInfo.Level < 50)
		{
			for (int index4 = 0; index4 < numArray15.Length; index4++)
			{
				numArray15[index4] += (double)(_petInfo.Level - 30) * addedPropArr6[index4] + 29.0 * addedPropArr5[index4] - numArray11[index4];
				addedPropArr6[index4] -= numArray12[index4];
				numArray15[index4] = Math.Ceiling(numArray15[index4] / 10.0) / 10.0;
				addedPropArr6[index4] = Math.Ceiling(addedPropArr6[index4] / 10.0) / 10.0;
			}
			propArr = numArray15;
			growArr = addedPropArr6;
			return;
		}
		for (int index5 = 0; index5 < numArray16.Length; index5++)
		{
			numArray16[index5] += (double)(_petInfo.Level - 50) * addedPropArr7[index5] + 20.0 * addedPropArr6[index5] + 29.0 * addedPropArr5[index5] - numArray11[index5];
			addedPropArr7[index5] -= numArray12[index5];
			numArray16[index5] = Math.Ceiling(numArray16[index5] / 10.0) / 10.0;
			addedPropArr7[index5] = Math.Ceiling(addedPropArr7[index5] / 10.0) / 10.0;
		}
		propArr = numArray16;
		growArr = addedPropArr7;
	}

	// Token: 0x06000019 RID: 25 RVA: 0x00002CD0 File Offset: 0x00000ED0
	public static double[] GetAddedPropArr(int grade, double[] propArr)
	{
		double[] array = new double[5];
		array[0] = propArr[0] * Math.Pow(2.0, (double)(grade - 1));
		double[] numArray = array;
		for (int index = 1; index < 5; index++)
		{
			numArray[index] = propArr[index] * Math.Pow(1.5, (double)(grade - 1));
		}
		return numArray;
	}

	// Token: 0x0600001A RID: 26 RVA: 0x00002D24 File Offset: 0x00000F24
	public static PetInfo CreatePet(PetTemplateInfo info, int userID, int place, int playerLevel)
	{
		PetInfo petInfo = new PetInfo(info);
		double num = (double)info.StarLevel * 0.1;
		Random random = new Random();
		petInfo.BloodGrow = (int)Math.Ceiling((double)(random.Next((int)((double)info.HighBlood / (1.7 - num)), info.HighBlood - (int)((double)info.HighBlood / 17.1)) / 10));
		petInfo.AttackGrow = random.Next((int)((double)info.HighAttack / (1.7 - num)), info.HighAttack - (int)((double)info.HighAttack / 17.1));
		petInfo.DefenceGrow = random.Next((int)((double)info.HighDefence / (1.7 - num)), info.HighDefence - (int)((double)info.HighDefence / 17.1));
		petInfo.AgilityGrow = random.Next((int)((double)info.HighAgility / (1.7 - num)), info.HighAgility - (int)((double)info.HighAgility / 17.1));
		petInfo.LuckGrow = random.Next((int)((double)info.HighLuck / (1.7 - num)), info.HighLuck - (int)((double)info.HighLuck / 17.1));
		petInfo.ID = 0;
		petInfo.Hunger = 10000;
		petInfo.TemplateID = info.TemplateID;
		petInfo.Name = info.Name;
		petInfo.UserID = userID;
		petInfo.Place = place;
		petInfo.Level = 1;
		petInfo.BuildProp();
		petInfo.Skill = PetMgr.UpdateSkillPet(1, info.TemplateID, playerLevel);
		petInfo.IsExist = true;
		petInfo.GP = 0;
		petInfo.MP = info.MP;
		petInfo.PetHappyStar = 4;
		petInfo.InitSkillEquip();
		return petInfo;
	}

	// Token: 0x0600001B RID: 27 RVA: 0x00002EF5 File Offset: 0x000010F5
	public static GameNeedPetSkillInfo[] GetGameNeedPetSkill()
	{
		return PetMgr.list_0.ToArray();
	}

	// Token: 0x0600001C RID: 28 RVA: 0x00002F04 File Offset: 0x00001104
	public static List<GameNeedPetSkillInfo> LoadGameNeedPetSkill()
	{
		List<GameNeedPetSkillInfo> needPetSkillInfoList = new List<GameNeedPetSkillInfo>();
		List<string> result = new List<string>();
		foreach (PetSkillInfo petSkillInfo in PetMgr._petSkillDic.Values)
		{
			string effectPic2 = petSkillInfo.EffectPic;
			if (!string.IsNullOrEmpty(effectPic2) && !result.Contains(effectPic2))
			{
				needPetSkillInfoList.Add(new GameNeedPetSkillInfo
				{
					Pic = petSkillInfo.Pic,
					EffectPic = petSkillInfo.EffectPic
				});
				result.Add(effectPic2);
			}
		}
		foreach (PetSkillElementInfo skillElementInfo in PetMgr._petSkillElementDic.Values)
		{
			string effectPic3 = skillElementInfo.EffectPic;
			if (!string.IsNullOrEmpty(effectPic3) && !result.Contains(effectPic3))
			{
				needPetSkillInfoList.Add(new GameNeedPetSkillInfo
				{
					Pic = skillElementInfo.Pic,
					EffectPic = skillElementInfo.EffectPic
				});
				result.Add(effectPic3);
			}
		}
		return needPetSkillInfoList;
	}

	// Token: 0x04000001 RID: 1
	private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

	// Token: 0x04000002 RID: 2
	private static Dictionary<string, PetConfigInfo> _petConfigDic;

	// Token: 0x04000003 RID: 3
	private static Dictionary<int, PetLevelInfo> _petLevelDic;

	// Token: 0x04000004 RID: 4
	private static Dictionary<int, PetSkillElementInfo> _petSkillElementDic;

	// Token: 0x04000005 RID: 5
	private static Dictionary<int, PetSkillInfo> _petSkillDic;

	// Token: 0x04000006 RID: 6
	private static Dictionary<int, PetSkillTemplateInfo> _petSkillTemplateDic;

	// Token: 0x04000007 RID: 7
	private static Dictionary<int, PetTemplateInfo> _petTemplateDic;

	// Token: 0x04000008 RID: 8
	private static Dictionary<int, PetFightPropertyInfo> _petFightPropertyDic;

	// Token: 0x04000009 RID: 9
	private static Dictionary<int, PetStarExpInfo> _petStarExpDic;

	// Token: 0x0400000A RID: 10
	private static List<GameNeedPetSkillInfo> list_0 = new List<GameNeedPetSkillInfo>();

	// Token: 0x0400000B RID: 11
	private static ThreadSafeRandom _random = new ThreadSafeRandom();

	// Token: 0x0400000C RID: 12
	private static ReaderWriterLock _lock = new ReaderWriterLock();
}
