using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Lsj.Util.Text;

namespace SqlDataProvider.Data
{
	// Token: 0x02000049 RID: 73
	public class PetInfo : DataObject
	{
		// Token: 0x060006EF RID: 1775 RVA: 0x00006798 File Offset: 0x00004998
		public PetInfo(PetTemplateInfo templateInfo)
		{
			this._template = templateInfo;
			this._templateID = templateInfo.TemplateID;
			this._id = -1;
			this._name = "";
			this._userID = -1;
			this._attack = -1;
			this._defence = -1;
			this._luck = -1;
			this._agility = -1;
			this._blood = -1;
			this._damage = -1;
			this._guard = -1;
			this._attackGrow = -1;
			this._defenceGrow = -1;
			this._luckGrow = -1;
			this._agilityGrow = -1;
			this._bloodGrow = -1;
			this._damageGrow = -1;
			this._guardGrow = -1;
			this._level = -1;
			this._gp = -1;
			this._maxGP = -1;
			this._hunger = -1;
			this._petHappyStar = -1;
			this._mp = -1;
			this._isEquip = false;
			this._place = -1;
			this._isExist = false;
			this._skill = "";
			this._skillEquip = "";
			this._currentStarExp = -1;
			this._breakGrade = -1;
			this._breakAttack = -1;
			this._breakDefence = -1;
			this._breakAgility = -1;
			this._breakLuck = -1;
			this._breakBlood = -1;
			this._eQPets = "";
			this._baseProp = "";
		}

		// Token: 0x17000350 RID: 848
		// (get) Token: 0x060006F0 RID: 1776 RVA: 0x000068D5 File Offset: 0x00004AD5
		// (set) Token: 0x060006F1 RID: 1777 RVA: 0x000068DD File Offset: 0x00004ADD
		public bool IsOwnerVIP4 { get; set; }

		// Token: 0x060006F2 RID: 1778 RVA: 0x000068E8 File Offset: 0x00004AE8
		public void BuildProp()
		{
			double[] result = new double[]
			{
				(double)(this._bloodGrow * 10),
				(double)this._attackGrow,
				(double)this._defenceGrow,
				(double)this._agilityGrow,
				(double)this._luckGrow
			};
			double[] grow = new double[]
			{
				(double)this._bloodGrow,
				(double)this._attackGrow,
				(double)this._defenceGrow,
				(double)this._agilityGrow,
				(double)this._luckGrow
			};
			double[] grow2 = this.CalculateGrow(1, grow);
			double[] grow3 = this.CalculateGrow(2, grow);
			double[] grow4 = this.CalculateGrow(3, grow);
			if (this.Level < 30)
			{
				for (int i = 0; i < result.Length; i++)
				{
					result[i] += (double)(this.Level - 1) * grow2[i];
					result[i] = Math.Ceiling(result[i] / 10.0) / 10.0;
				}
			}
			else if (this.Level < 50)
			{
				for (int j = 0; j < result.Length; j++)
				{
					result[j] += (double)(this.Level - 30) * grow3[j] + 29.0 * grow2[j];
					result[j] = Math.Ceiling(result[j] / 10.0) / 10.0;
				}
			}
			else
			{
				for (int index = 0; index < result.Length; index++)
				{
					result[index] += (double)(this.Level - 50) * grow4[index] + 20.0 * grow3[index] + 29.0 * grow2[index];
					result[index] = Math.Ceiling(result[index] / 10.0) / 10.0;
				}
			}
			this.Blood = (int)result[0];
			this.Attack = (int)result[1];
			this.Defence = (int)result[2];
			this.Agility = (int)result[3];
			this.Luck = (int)result[4];
		}

		// Token: 0x060006F3 RID: 1779 RVA: 0x00006AEC File Offset: 0x00004CEC
		private double[] CalculateGrow(int i, double[] array)
		{
			double[] result = new double[array.Length];
			result[0] = array[0] * Math.Pow(2.0, (double)(i - 1));
			for (int index = 1; index < array.Length; index++)
			{
				result[index] = array[index] * Math.Pow(1.5, (double)(i - 1));
			}
			return result;
		}

		// Token: 0x17000351 RID: 849
		// (get) Token: 0x060006F4 RID: 1780 RVA: 0x00006B44 File Offset: 0x00004D44
		public int SkillEquipCount
		{
			get
			{
				int skillEquipCount = 1;
				if (this.Level >= 50)
				{
					if (this.IsOwnerVIP4)
					{
						skillEquipCount = 5;
					}
					else
					{
						skillEquipCount = 4;
					}
				}
				else if (this.Level >= 30)
				{
					skillEquipCount = 3;
				}
				else if (this.Level >= 20)
				{
					skillEquipCount = 2;
				}
				return skillEquipCount;
			}
		}

		// Token: 0x060006F5 RID: 1781 RVA: 0x00006B88 File Offset: 0x00004D88
		public void InitSkillEquip()
		{
			this.SkillEquip = "0,0|0,1|0,2|0,3|0,4";
		}

		// Token: 0x060006F6 RID: 1782 RVA: 0x00006B98 File Offset: 0x00004D98
		[return: TupleElementNames(new string[] { "skill", "pos" })]
		public List<ValueTuple<int, int>> GetSkillEquip()
		{
			int[] allSkill = (from x in this._skill.Split(new char[] { '|' })
				select x.Split(new char[] { ',' })[0] into x
				select x.ConvertToInt()).ToArray<int>();
			string[] _skillEquipArray = this._skillEquip.Split(new char[] { '|' });
			if (_skillEquipArray.Length != 5)
			{
				this.InitSkillEquip();
				_skillEquipArray = this._skillEquip.Split(new char[] { '|' });
			}
			List<ValueTuple<int, int>> result = new List<ValueTuple<int, int>>();
			for (int index = 0; index < this.SkillEquipCount; index++)
			{
				int skill = _skillEquipArray[index].Split(new char[] { ',' })[0].ConvertToInt();
				if (allSkill.Contains(skill))
				{
					result.Add(new ValueTuple<int, int>(skill, index));
				}
				else
				{
					result.Add(new ValueTuple<int, int>(0, index));
				}
			}
			return result;
		}

		// Token: 0x060006F7 RID: 1783 RVA: 0x00006C9E File Offset: 0x00004E9E
		public List<string> GetSkill()
		{
			return this._skill.Split(new char[] { '|' }).ToList<string>();
		}

		// Token: 0x060006F8 RID: 1784 RVA: 0x00006CBC File Offset: 0x00004EBC
		public bool EquipSkill(int skill, int pos)
		{
			string[] _skillEquipArray = this._skillEquip.Split(new char[] { '|' });
			if (_skillEquipArray.Length != 5)
			{
				this.InitSkillEquip();
				return false;
			}
			string text = _skillEquipArray[pos];
			if (!(from x in this._skill.Split(new char[] { '|' })
				select x.Split(new char[] { ',' })[0]).Contains(skill.ToString()))
			{
				return false;
			}
			if (pos < this.SkillEquipCount)
			{
				_skillEquipArray[pos] = string.Format("{0},{1}", skill, pos);
				this._skillEquip = string.Join("|", _skillEquipArray);
				return true;
			}
			return false;
		}

		// Token: 0x060006F9 RID: 1785 RVA: 0x00006D74 File Offset: 0x00004F74
		public int MaxLevel()
		{
			switch (this._breakGrade)
			{
			case 1:
				return 63;
			case 2:
				return 65;
			case 3:
				return 68;
			case 4:
				return 70;
			default:
				return 60;
			}
		}

		// Token: 0x17000352 RID: 850
		// (get) Token: 0x060006FA RID: 1786 RVA: 0x00006DB0 File Offset: 0x00004FB0
		// (set) Token: 0x060006FB RID: 1787 RVA: 0x00006DB8 File Offset: 0x00004FB8
		public int ID
		{
			get
			{
				return this._id;
			}
			set
			{
				if (this._id != value)
				{
					this._id = value;
					base.IsDirty = true;
				}
			}
		}

		// Token: 0x17000353 RID: 851
		// (get) Token: 0x060006FC RID: 1788 RVA: 0x00006DD1 File Offset: 0x00004FD1
		public PetTemplateInfo Template
		{
			get
			{
				return this._template;
			}
		}

		// Token: 0x17000354 RID: 852
		// (get) Token: 0x060006FD RID: 1789 RVA: 0x00006DD9 File Offset: 0x00004FD9
		// (set) Token: 0x060006FE RID: 1790 RVA: 0x00006DE1 File Offset: 0x00004FE1
		public int TemplateID
		{
			get
			{
				return this._templateID;
			}
			set
			{
				if (this._templateID != value)
				{
					this._templateID = value;
					base.IsDirty = true;
				}
			}
		}

		// Token: 0x17000355 RID: 853
		// (get) Token: 0x060006FF RID: 1791 RVA: 0x00006DFA File Offset: 0x00004FFA
		// (set) Token: 0x06000700 RID: 1792 RVA: 0x00006E02 File Offset: 0x00005002
		public string Name
		{
			get
			{
				return this._name;
			}
			set
			{
				if (this._name != value)
				{
					this._name = value;
					base.IsDirty = true;
				}
			}
		}

		// Token: 0x17000356 RID: 854
		// (get) Token: 0x06000701 RID: 1793 RVA: 0x00006E20 File Offset: 0x00005020
		// (set) Token: 0x06000702 RID: 1794 RVA: 0x00006E28 File Offset: 0x00005028
		public int UserID
		{
			get
			{
				return this._userID;
			}
			set
			{
				if (this._userID != value)
				{
					this._userID = value;
					base.IsDirty = true;
				}
			}
		}

		// Token: 0x17000357 RID: 855
		// (get) Token: 0x06000703 RID: 1795 RVA: 0x00006E41 File Offset: 0x00005041
		// (set) Token: 0x06000704 RID: 1796 RVA: 0x00006E49 File Offset: 0x00005049
		public int Attack
		{
			get
			{
				return this._attack;
			}
			set
			{
				if (this._attack != value)
				{
					this._attack = value;
					base.IsDirty = true;
				}
			}
		}

		// Token: 0x17000358 RID: 856
		// (get) Token: 0x06000705 RID: 1797 RVA: 0x00006E62 File Offset: 0x00005062
		// (set) Token: 0x06000706 RID: 1798 RVA: 0x00006E6A File Offset: 0x0000506A
		public int Defence
		{
			get
			{
				return this._defence;
			}
			set
			{
				if (this._defence != value)
				{
					this._defence = value;
					base.IsDirty = true;
				}
			}
		}

		// Token: 0x17000359 RID: 857
		// (get) Token: 0x06000707 RID: 1799 RVA: 0x00006E83 File Offset: 0x00005083
		// (set) Token: 0x06000708 RID: 1800 RVA: 0x00006E8B File Offset: 0x0000508B
		public int Luck
		{
			get
			{
				return this._luck;
			}
			set
			{
				if (this._luck != value)
				{
					this._luck = value;
					base.IsDirty = true;
				}
			}
		}

		// Token: 0x1700035A RID: 858
		// (get) Token: 0x06000709 RID: 1801 RVA: 0x00006EA4 File Offset: 0x000050A4
		// (set) Token: 0x0600070A RID: 1802 RVA: 0x00006EAC File Offset: 0x000050AC
		public int Agility
		{
			get
			{
				return this._agility;
			}
			set
			{
				if (this._agility != value)
				{
					this._agility = value;
					base.IsDirty = true;
				}
			}
		}

		// Token: 0x1700035B RID: 859
		// (get) Token: 0x0600070B RID: 1803 RVA: 0x00006EC5 File Offset: 0x000050C5
		// (set) Token: 0x0600070C RID: 1804 RVA: 0x00006ECD File Offset: 0x000050CD
		public int Blood
		{
			get
			{
				return this._blood;
			}
			set
			{
				if (this._blood != value)
				{
					this._blood = value;
					base.IsDirty = true;
				}
			}
		}

		// Token: 0x1700035C RID: 860
		// (get) Token: 0x0600070D RID: 1805 RVA: 0x00006EE6 File Offset: 0x000050E6
		// (set) Token: 0x0600070E RID: 1806 RVA: 0x00006EEE File Offset: 0x000050EE
		public int Damage
		{
			get
			{
				return this._damage;
			}
			set
			{
				if (this._damage != value)
				{
					this._damage = value;
					base.IsDirty = true;
				}
			}
		}

		// Token: 0x1700035D RID: 861
		// (get) Token: 0x0600070F RID: 1807 RVA: 0x00006F07 File Offset: 0x00005107
		// (set) Token: 0x06000710 RID: 1808 RVA: 0x00006F0F File Offset: 0x0000510F
		public int Guard
		{
			get
			{
				return this._guard;
			}
			set
			{
				if (this._guard != value)
				{
					this._guard = value;
					base.IsDirty = true;
				}
			}
		}

		// Token: 0x1700035E RID: 862
		// (get) Token: 0x06000711 RID: 1809 RVA: 0x00006F28 File Offset: 0x00005128
		// (set) Token: 0x06000712 RID: 1810 RVA: 0x00006F30 File Offset: 0x00005130
		public int AttackGrow
		{
			get
			{
				return this._attackGrow;
			}
			set
			{
				if (this._attackGrow != value)
				{
					this._attackGrow = value;
					base.IsDirty = true;
				}
			}
		}

		// Token: 0x1700035F RID: 863
		// (get) Token: 0x06000713 RID: 1811 RVA: 0x00006F49 File Offset: 0x00005149
		// (set) Token: 0x06000714 RID: 1812 RVA: 0x00006F51 File Offset: 0x00005151
		public int DefenceGrow
		{
			get
			{
				return this._defenceGrow;
			}
			set
			{
				if (this._defenceGrow != value)
				{
					this._defenceGrow = value;
					base.IsDirty = true;
				}
			}
		}

		// Token: 0x17000360 RID: 864
		// (get) Token: 0x06000715 RID: 1813 RVA: 0x00006F6A File Offset: 0x0000516A
		// (set) Token: 0x06000716 RID: 1814 RVA: 0x00006F72 File Offset: 0x00005172
		public int LuckGrow
		{
			get
			{
				return this._luckGrow;
			}
			set
			{
				if (this._luckGrow != value)
				{
					this._luckGrow = value;
					base.IsDirty = true;
				}
			}
		}

		// Token: 0x17000361 RID: 865
		// (get) Token: 0x06000717 RID: 1815 RVA: 0x00006F8B File Offset: 0x0000518B
		// (set) Token: 0x06000718 RID: 1816 RVA: 0x00006F93 File Offset: 0x00005193
		public int AgilityGrow
		{
			get
			{
				return this._agilityGrow;
			}
			set
			{
				if (this._agilityGrow != value)
				{
					this._agilityGrow = value;
					base.IsDirty = true;
				}
			}
		}

		// Token: 0x17000362 RID: 866
		// (get) Token: 0x06000719 RID: 1817 RVA: 0x00006FAC File Offset: 0x000051AC
		// (set) Token: 0x0600071A RID: 1818 RVA: 0x00006FB4 File Offset: 0x000051B4
		public int BloodGrow
		{
			get
			{
				return this._bloodGrow;
			}
			set
			{
				if (this._bloodGrow != value)
				{
					this._bloodGrow = value;
					base.IsDirty = true;
				}
			}
		}

		// Token: 0x17000363 RID: 867
		// (get) Token: 0x0600071B RID: 1819 RVA: 0x00006FCD File Offset: 0x000051CD
		// (set) Token: 0x0600071C RID: 1820 RVA: 0x00006FD5 File Offset: 0x000051D5
		public int DamageGrow
		{
			get
			{
				return this._damageGrow;
			}
			set
			{
				if (this._damageGrow != value)
				{
					this._damageGrow = value;
					base.IsDirty = true;
				}
			}
		}

		// Token: 0x17000364 RID: 868
		// (get) Token: 0x0600071D RID: 1821 RVA: 0x00006FEE File Offset: 0x000051EE
		// (set) Token: 0x0600071E RID: 1822 RVA: 0x00006FF6 File Offset: 0x000051F6
		public int GuardGrow
		{
			get
			{
				return this._guardGrow;
			}
			set
			{
				if (this._guardGrow != value)
				{
					this._guardGrow = value;
					base.IsDirty = true;
				}
			}
		}

		// Token: 0x17000365 RID: 869
		// (get) Token: 0x0600071F RID: 1823 RVA: 0x0000700F File Offset: 0x0000520F
		// (set) Token: 0x06000720 RID: 1824 RVA: 0x00007017 File Offset: 0x00005217
		public int Level
		{
			get
			{
				return this._level;
			}
			set
			{
				if (this._level != value)
				{
					this._level = value;
					base.IsDirty = true;
				}
			}
		}

		// Token: 0x17000366 RID: 870
		// (get) Token: 0x06000721 RID: 1825 RVA: 0x00007030 File Offset: 0x00005230
		// (set) Token: 0x06000722 RID: 1826 RVA: 0x00007038 File Offset: 0x00005238
		public int GP
		{
			get
			{
				return this._gp;
			}
			set
			{
				if (this._gp != value)
				{
					this._gp = value;
					base.IsDirty = true;
				}
			}
		}

		// Token: 0x17000367 RID: 871
		// (get) Token: 0x06000723 RID: 1827 RVA: 0x00007051 File Offset: 0x00005251
		// (set) Token: 0x06000724 RID: 1828 RVA: 0x00007059 File Offset: 0x00005259
		public int MaxGP
		{
			get
			{
				return this._maxGP;
			}
			set
			{
				if (this._maxGP != value)
				{
					this._maxGP = value;
					base.IsDirty = true;
				}
			}
		}

		// Token: 0x17000368 RID: 872
		// (get) Token: 0x06000725 RID: 1829 RVA: 0x00007072 File Offset: 0x00005272
		// (set) Token: 0x06000726 RID: 1830 RVA: 0x0000707A File Offset: 0x0000527A
		public int Hunger
		{
			get
			{
				return this._hunger;
			}
			set
			{
				if (this._hunger != value)
				{
					this._hunger = value;
					base.IsDirty = true;
				}
			}
		}

		// Token: 0x17000369 RID: 873
		// (get) Token: 0x06000727 RID: 1831 RVA: 0x00007093 File Offset: 0x00005293
		// (set) Token: 0x06000728 RID: 1832 RVA: 0x0000709B File Offset: 0x0000529B
		public int PetHappyStar
		{
			get
			{
				return this._petHappyStar;
			}
			set
			{
				if (this._petHappyStar != value)
				{
					this._petHappyStar = value;
					base.IsDirty = true;
				}
			}
		}

		// Token: 0x1700036A RID: 874
		// (get) Token: 0x06000729 RID: 1833 RVA: 0x000070B4 File Offset: 0x000052B4
		// (set) Token: 0x0600072A RID: 1834 RVA: 0x000070BC File Offset: 0x000052BC
		public int MP
		{
			get
			{
				return this._mp;
			}
			set
			{
				if (this._mp != value)
				{
					this._mp = value;
					base.IsDirty = true;
				}
			}
		}

		// Token: 0x1700036B RID: 875
		// (get) Token: 0x0600072B RID: 1835 RVA: 0x000070D5 File Offset: 0x000052D5
		// (set) Token: 0x0600072C RID: 1836 RVA: 0x000070DD File Offset: 0x000052DD
		public bool IsEquip
		{
			get
			{
				return this._isEquip;
			}
			set
			{
				if (this._isEquip != value)
				{
					this._isEquip = value;
					base.IsDirty = true;
				}
			}
		}

		// Token: 0x1700036C RID: 876
		// (get) Token: 0x0600072D RID: 1837 RVA: 0x000070F6 File Offset: 0x000052F6
		// (set) Token: 0x0600072E RID: 1838 RVA: 0x000070FE File Offset: 0x000052FE
		public int Place
		{
			get
			{
				return this._place;
			}
			set
			{
				if (this._place != value)
				{
					this._place = value;
					base.IsDirty = true;
				}
			}
		}

		// Token: 0x1700036D RID: 877
		// (get) Token: 0x0600072F RID: 1839 RVA: 0x00007117 File Offset: 0x00005317
		// (set) Token: 0x06000730 RID: 1840 RVA: 0x0000711F File Offset: 0x0000531F
		public bool IsExist
		{
			get
			{
				return this._isExist;
			}
			set
			{
				if (this._isExist != value)
				{
					this._isExist = value;
					base.IsDirty = true;
				}
			}
		}

		// Token: 0x1700036E RID: 878
		// (get) Token: 0x06000731 RID: 1841 RVA: 0x00007138 File Offset: 0x00005338
		// (set) Token: 0x06000732 RID: 1842 RVA: 0x00007140 File Offset: 0x00005340
		public string Skill
		{
			get
			{
				return this._skill;
			}
			set
			{
				if (this._skill != value)
				{
					this._skill = value;
					base.IsDirty = true;
				}
			}
		}

		// Token: 0x1700036F RID: 879
		// (get) Token: 0x06000733 RID: 1843 RVA: 0x0000715E File Offset: 0x0000535E
		// (set) Token: 0x06000734 RID: 1844 RVA: 0x00007166 File Offset: 0x00005366
		public string SkillEquip
		{
			get
			{
				return this._skillEquip;
			}
			set
			{
				if (this._skillEquip != value)
				{
					this._skillEquip = value;
					base.IsDirty = true;
				}
			}
		}

		// Token: 0x17000370 RID: 880
		// (get) Token: 0x06000735 RID: 1845 RVA: 0x00007184 File Offset: 0x00005384
		// (set) Token: 0x06000736 RID: 1846 RVA: 0x0000718C File Offset: 0x0000538C
		public int CurrentStarExp
		{
			get
			{
				return this._currentStarExp;
			}
			set
			{
				if (this._currentStarExp != value)
				{
					this._currentStarExp = value;
					base.IsDirty = true;
				}
			}
		}

		// Token: 0x17000371 RID: 881
		// (get) Token: 0x06000737 RID: 1847 RVA: 0x000071A5 File Offset: 0x000053A5
		// (set) Token: 0x06000738 RID: 1848 RVA: 0x000071AD File Offset: 0x000053AD
		public int BreakGrade
		{
			get
			{
				return this._breakGrade;
			}
			set
			{
				if (this._breakGrade != value)
				{
					this._breakGrade = value;
					base.IsDirty = true;
				}
			}
		}

		// Token: 0x17000372 RID: 882
		// (get) Token: 0x06000739 RID: 1849 RVA: 0x000071C6 File Offset: 0x000053C6
		// (set) Token: 0x0600073A RID: 1850 RVA: 0x000071CE File Offset: 0x000053CE
		public int BreakAttack
		{
			get
			{
				return this._breakAttack;
			}
			set
			{
				if (this._breakAttack != value)
				{
					this._breakAttack = value;
					base.IsDirty = true;
				}
			}
		}

		// Token: 0x17000373 RID: 883
		// (get) Token: 0x0600073B RID: 1851 RVA: 0x000071E7 File Offset: 0x000053E7
		// (set) Token: 0x0600073C RID: 1852 RVA: 0x000071EF File Offset: 0x000053EF
		public int BreakDefence
		{
			get
			{
				return this._breakDefence;
			}
			set
			{
				if (this._breakDefence != value)
				{
					this._breakDefence = value;
					base.IsDirty = true;
				}
			}
		}

		// Token: 0x17000374 RID: 884
		// (get) Token: 0x0600073D RID: 1853 RVA: 0x00007208 File Offset: 0x00005408
		// (set) Token: 0x0600073E RID: 1854 RVA: 0x00007210 File Offset: 0x00005410
		public int BreakAgility
		{
			get
			{
				return this._breakAgility;
			}
			set
			{
				if (this._breakAgility != value)
				{
					this._breakAgility = value;
					base.IsDirty = true;
				}
			}
		}

		// Token: 0x17000375 RID: 885
		// (get) Token: 0x0600073F RID: 1855 RVA: 0x00007229 File Offset: 0x00005429
		// (set) Token: 0x06000740 RID: 1856 RVA: 0x00007231 File Offset: 0x00005431
		public int BreakLuck
		{
			get
			{
				return this._breakLuck;
			}
			set
			{
				if (this._breakLuck != value)
				{
					this._breakLuck = value;
					base.IsDirty = true;
				}
			}
		}

		// Token: 0x17000376 RID: 886
		// (get) Token: 0x06000741 RID: 1857 RVA: 0x0000724A File Offset: 0x0000544A
		// (set) Token: 0x06000742 RID: 1858 RVA: 0x00007252 File Offset: 0x00005452
		public int BreakBlood
		{
			get
			{
				return this._breakBlood;
			}
			set
			{
				if (this._breakBlood != value)
				{
					this._breakBlood = value;
					base.IsDirty = true;
				}
			}
		}

		// Token: 0x17000377 RID: 887
		// (get) Token: 0x06000743 RID: 1859 RVA: 0x0000726B File Offset: 0x0000546B
		// (set) Token: 0x06000744 RID: 1860 RVA: 0x00007273 File Offset: 0x00005473
		public string EQPets
		{
			get
			{
				return this._eQPets;
			}
			set
			{
				if (this._eQPets != value)
				{
					this._eQPets = value;
					base.IsDirty = true;
				}
			}
		}

		// Token: 0x17000378 RID: 888
		// (get) Token: 0x06000745 RID: 1861 RVA: 0x00007291 File Offset: 0x00005491
		// (set) Token: 0x06000746 RID: 1862 RVA: 0x00007299 File Offset: 0x00005499
		public string BaseProp
		{
			get
			{
				return this._baseProp;
			}
			set
			{
				if (this._baseProp != value)
				{
					this._baseProp = value;
					base.IsDirty = true;
				}
			}
		}

		// Token: 0x040003D8 RID: 984
		private PetTemplateInfo _template;

		// Token: 0x040003D9 RID: 985
		private int _id;

		// Token: 0x040003DA RID: 986
		private int _templateID;

		// Token: 0x040003DB RID: 987
		private string _name;

		// Token: 0x040003DC RID: 988
		private int _userID;

		// Token: 0x040003DD RID: 989
		private int _attack;

		// Token: 0x040003DE RID: 990
		private int _defence;

		// Token: 0x040003DF RID: 991
		private int _luck;

		// Token: 0x040003E0 RID: 992
		private int _agility;

		// Token: 0x040003E1 RID: 993
		private int _blood;

		// Token: 0x040003E2 RID: 994
		private int _damage;

		// Token: 0x040003E3 RID: 995
		private int _guard;

		// Token: 0x040003E4 RID: 996
		private int _attackGrow;

		// Token: 0x040003E5 RID: 997
		private int _defenceGrow;

		// Token: 0x040003E6 RID: 998
		private int _luckGrow;

		// Token: 0x040003E7 RID: 999
		private int _agilityGrow;

		// Token: 0x040003E8 RID: 1000
		private int _bloodGrow;

		// Token: 0x040003E9 RID: 1001
		private int _damageGrow;

		// Token: 0x040003EA RID: 1002
		private int _guardGrow;

		// Token: 0x040003EB RID: 1003
		private int _level;

		// Token: 0x040003EC RID: 1004
		private int _gp;

		// Token: 0x040003ED RID: 1005
		private int _maxGP;

		// Token: 0x040003EE RID: 1006
		private int _hunger;

		// Token: 0x040003EF RID: 1007
		private int _petHappyStar;

		// Token: 0x040003F0 RID: 1008
		private int _mp;

		// Token: 0x040003F1 RID: 1009
		private bool _isEquip;

		// Token: 0x040003F2 RID: 1010
		private int _place;

		// Token: 0x040003F3 RID: 1011
		private bool _isExist;

		// Token: 0x040003F4 RID: 1012
		private string _skill;

		// Token: 0x040003F5 RID: 1013
		private string _skillEquip;

		// Token: 0x040003F6 RID: 1014
		private int _currentStarExp;

		// Token: 0x040003F7 RID: 1015
		private int _breakGrade;

		// Token: 0x040003F8 RID: 1016
		private int _breakAttack;

		// Token: 0x040003F9 RID: 1017
		private int _breakDefence;

		// Token: 0x040003FA RID: 1018
		private int _breakAgility;

		// Token: 0x040003FB RID: 1019
		private int _breakLuck;

		// Token: 0x040003FC RID: 1020
		private int _breakBlood;

		// Token: 0x040003FD RID: 1021
		private string _eQPets;

		// Token: 0x040003FE RID: 1022
		private string _baseProp;
	}
}
