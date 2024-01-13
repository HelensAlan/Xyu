using System;
using System.Data;
using System.Data.SqlClient;
using SqlDataProvider.Data;

namespace Bussiness
{
	// Token: 0x0200000B RID: 11
	public class FeedbackBussiness : BaseBussiness
	{
		// Token: 0x06000088 RID: 136 RVA: 0x0000AD48 File Offset: 0x00008F48
		public bool Submit(FeedbackSubmit info)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@QuestionTitle", info.QuestionTitle),
					new SqlParameter("@QuestionContent", info.QuestionContent),
					new SqlParameter("@OccurrenceDate", info.OccurrenceDate),
					new SqlParameter("@QuestionType", info.QuestionType),
					new SqlParameter("@GoodsGetMethod", info.GoodsGetMethod),
					new SqlParameter("@GoodsGetDate", info.GoodsGetDate),
					new SqlParameter("@ChargeOrderID", info.ChargeOrderID),
					new SqlParameter("@ChargeMethod", info.ChargeMethod),
					new SqlParameter("@ChargeMoneys", info.ChargeMoneys),
					new SqlParameter("@ActivityIsError", info.ActivityIsError),
					new SqlParameter("@ActivityName", info.ActivityName),
					new SqlParameter("@ReportUserName", info.ReportUserName),
					new SqlParameter("@ReportUrl", info.ReportUrl),
					new SqlParameter("@UserFullName", info.UserFullName),
					new SqlParameter("@UserPhone", info.UserPhone),
					new SqlParameter("@ComplaintsTitle", info.ComplaintsTitle),
					new SqlParameter("@ComplaintsSource", info.ComplaintsSource),
					new SqlParameter("@UserID", info.UserID),
					new SqlParameter("@UserName", info.UserName),
					new SqlParameter("@UserNickName", info.UserNickName),
					new SqlParameter("@IsExist", info.IsExist)
				};
				result = this.db.RunProcedure("SP_Feedback_Submit_Add", para);
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			return result;
		}

		// Token: 0x06000089 RID: 137 RVA: 0x0000AF64 File Offset: 0x00009164
		public bool SubmitContinue(FeedbackSubmitContinue info)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@QuestionID", info.QuestionID),
					new SqlParameter("@UserID", info.UserID),
					new SqlParameter("@NickName", info.NickName),
					new SqlParameter("@ReplyID", info.ReplyID),
					new SqlParameter("@ReplyContent", info.ReplyContent)
				};
				result = this.db.RunProcedure("SP_Feedback_SubmitContinue_Add", para);
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			return result;
		}

		// Token: 0x0600008A RID: 138 RVA: 0x0000B02C File Offset: 0x0000922C
		public bool Appraisal(FeedbackAppraisal info)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@QuestionID", info.QuestionID),
					new SqlParameter("@ReplyID", info.ReplyID),
					new SqlParameter("@AppraisalGrade", info.AppraisalGrade),
					new SqlParameter("@AppraisalContent", info.AppraisalContent)
				};
				result = this.db.RunProcedure("SP_Feedback_Appraisal_Add", para);
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			return result;
		}

		// Token: 0x0600008B RID: 139 RVA: 0x0000B0DC File Offset: 0x000092DC
		public bool Reply(FeedbackRead info)
		{
			bool result = false;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@QuestionID", info.QuestionID),
					new SqlParameter("@ReplyID", info.ReplyID),
					new SqlParameter("@UserID", info.UserID),
					new SqlParameter("@OccurrenceDate", info.OccurrenceDate),
					new SqlParameter("@Title", info.Title),
					new SqlParameter("@QuestionContent", info.QuestionContent),
					new SqlParameter("@ReplyContent", info.ReplyContent)
				};
				result = this.db.RunProcedure("SP_Feedback_Reply", para);
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			return result;
		}

		// Token: 0x0600008C RID: 140 RVA: 0x0000B1CC File Offset: 0x000093CC
		public FeedbackRead Read(int userID)
		{
			FeedbackRead info = new FeedbackRead();
			SqlDataReader reader = null;
			try
			{
				(new SqlParameter[1])[0] = new SqlParameter("@UserID", userID);
				this.db.GetReader(ref reader, "SP_Feedback_Read");
				if (reader.Read())
				{
					info = new FeedbackRead
					{
						QuestionID = (int)reader["QuestionID"],
						ReplyID = (int)reader["ReplyID"],
						UserID = (int)reader["UserID"],
						OccurrenceDate = (string)reader["OccurrenceDate"],
						Title = (string)reader["Title"],
						QuestionContent = (string)reader["QuestionContent"],
						ReplyContent = (string)reader["ReplyContent"],
						IsExist = (bool)reader["IsExist"]
					};
				}
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
				{
					reader.Close();
				}
			}
			return info;
		}

		// Token: 0x0600008D RID: 141 RVA: 0x0000B338 File Offset: 0x00009538
		public int Check(int UserID)
		{
			int result = -1;
			try
			{
				SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@UserID", UserID),
					new SqlParameter("@Result", SqlDbType.Int)
				};
				para[1].Direction = ParameterDirection.ReturnValue;
				this.db.RunProcedure("SP_Feedback_Check", para);
				result = (int)para[1].Value;
			}
			catch (Exception e)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", e);
				}
			}
			return result;
		}
	}
}
