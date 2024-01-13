using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Bussiness.CenterService
{
	// Token: 0x0200002F RID: 47
	[GeneratedCode("System.Runtime.Serialization", "3.0.0.0")]
	[DebuggerStepThrough]
	[DataContract(Name = "ServerData", Namespace = "http://schemas.datacontract.org/2004/07/Center.Server")]
	[Serializable]
	public class ServerData : IExtensibleDataObject, INotifyPropertyChanged
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000250 RID: 592 RVA: 0x00021C78 File Offset: 0x0001FE78
		// (remove) Token: 0x06000251 RID: 593 RVA: 0x00021CB0 File Offset: 0x0001FEB0
		public event PropertyChangedEventHandler PropertyChanged;

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000252 RID: 594 RVA: 0x00021CE5 File Offset: 0x0001FEE5
		// (set) Token: 0x06000253 RID: 595 RVA: 0x00021CED File Offset: 0x0001FEED
		[Browsable(false)]
		public ExtensionDataObject ExtensionData
		{
			get
			{
				return this.extensionDataField;
			}
			set
			{
				this.extensionDataField = value;
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000254 RID: 596 RVA: 0x00021CF6 File Offset: 0x0001FEF6
		// (set) Token: 0x06000255 RID: 597 RVA: 0x00021CFE File Offset: 0x0001FEFE
		[DataMember]
		public int Id
		{
			get
			{
				return this.IdField;
			}
			set
			{
				if (!this.IdField.Equals(value))
				{
					this.IdField = value;
					this.RaisePropertyChanged("Id");
				}
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000256 RID: 598 RVA: 0x00021D20 File Offset: 0x0001FF20
		// (set) Token: 0x06000257 RID: 599 RVA: 0x00021D28 File Offset: 0x0001FF28
		[DataMember]
		public string Ip
		{
			get
			{
				return this.IpField;
			}
			set
			{
				if (this.IpField != value)
				{
					this.IpField = value;
					this.RaisePropertyChanged("Ip");
				}
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000258 RID: 600 RVA: 0x00021D45 File Offset: 0x0001FF45
		// (set) Token: 0x06000259 RID: 601 RVA: 0x00021D4D File Offset: 0x0001FF4D
		[DataMember]
		public int LowestLevel
		{
			get
			{
				return this.LowestLevelField;
			}
			set
			{
				if (!this.LowestLevelField.Equals(value))
				{
					this.LowestLevelField = value;
					this.RaisePropertyChanged("LowestLevel");
				}
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600025A RID: 602 RVA: 0x00021D6F File Offset: 0x0001FF6F
		// (set) Token: 0x0600025B RID: 603 RVA: 0x00021D77 File Offset: 0x0001FF77
		[DataMember]
		public int MustLevel
		{
			get
			{
				return this.MustLevelField;
			}
			set
			{
				if (!this.MustLevelField.Equals(value))
				{
					this.MustLevelField = value;
					this.RaisePropertyChanged("MustLevel");
				}
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600025C RID: 604 RVA: 0x00021D99 File Offset: 0x0001FF99
		// (set) Token: 0x0600025D RID: 605 RVA: 0x00021DA1 File Offset: 0x0001FFA1
		[DataMember]
		public string Name
		{
			get
			{
				return this.NameField;
			}
			set
			{
				if (this.NameField != value)
				{
					this.NameField = value;
					this.RaisePropertyChanged("Name");
				}
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600025E RID: 606 RVA: 0x00021DBE File Offset: 0x0001FFBE
		// (set) Token: 0x0600025F RID: 607 RVA: 0x00021DC6 File Offset: 0x0001FFC6
		[DataMember]
		public int Online
		{
			get
			{
				return this.OnlineField;
			}
			set
			{
				if (!this.OnlineField.Equals(value))
				{
					this.OnlineField = value;
					this.RaisePropertyChanged("Online");
				}
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000260 RID: 608 RVA: 0x00021DE8 File Offset: 0x0001FFE8
		// (set) Token: 0x06000261 RID: 609 RVA: 0x00021DF0 File Offset: 0x0001FFF0
		[DataMember]
		public int Port
		{
			get
			{
				return this.PortField;
			}
			set
			{
				if (!this.PortField.Equals(value))
				{
					this.PortField = value;
					this.RaisePropertyChanged("Port");
				}
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000262 RID: 610 RVA: 0x00021E12 File Offset: 0x00020012
		// (set) Token: 0x06000263 RID: 611 RVA: 0x00021E1A File Offset: 0x0002001A
		[DataMember]
		public int State
		{
			get
			{
				return this.StateField;
			}
			set
			{
				if (!this.StateField.Equals(value))
				{
					this.StateField = value;
					this.RaisePropertyChanged("State");
				}
			}
		}

		// Token: 0x06000264 RID: 612 RVA: 0x00021E3C File Offset: 0x0002003C
		protected void RaisePropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
			if (propertyChanged != null)
			{
				propertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		// Token: 0x040000E8 RID: 232
		[NonSerialized]
		private ExtensionDataObject extensionDataField;

		// Token: 0x040000E9 RID: 233
		[OptionalField]
		private int IdField;

		// Token: 0x040000EA RID: 234
		[OptionalField]
		private string IpField;

		// Token: 0x040000EB RID: 235
		[OptionalField]
		private int LowestLevelField;

		// Token: 0x040000EC RID: 236
		[OptionalField]
		private int MustLevelField;

		// Token: 0x040000ED RID: 237
		[OptionalField]
		private string NameField;

		// Token: 0x040000EE RID: 238
		[OptionalField]
		private int OnlineField;

		// Token: 0x040000EF RID: 239
		[OptionalField]
		private int PortField;

		// Token: 0x040000F0 RID: 240
		[OptionalField]
		private int StateField;
	}
}
