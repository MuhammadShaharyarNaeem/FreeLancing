using EmailingProject.Generics.Cache;
using System;
using System.Data;

namespace EmailingProject.Generics
{
    public class ValidationHandler
    {
        public MessageCollection messageCollection = new MessageCollection();
        public void CheckNull(string value, string FieldName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                messageCollection.addMessage(new Message()
                {
                    Context = "ValidationHandler",
                    ErrorCode = ErrorCache.NullError,
                    ErrorMessage = FieldName + ErrorCache.getErrorMessage(ErrorCache.NullError),
                    isError = true,
                    LogType = Enums.LogType.Exception
                });
            }
        }
        public void CheckNull(ref DataTable dt, string FieldName)
        {
            if (dt is null || dt.Rows.Count <= 0)
            {
                messageCollection.addMessage(new Message()
                {
                    Context = "ValidationHandler",
                    ErrorCode = ErrorCache.NullError,
                    ErrorMessage = FieldName + ErrorCache.getErrorMessage(ErrorCache.NullError),
                    isError = true,
                    LogType = Enums.LogType.Exception
                });
            }
        }
        public void CheckNumber(string value, string FieldName)
        {
            int number;
            if (!string.IsNullOrWhiteSpace(value))
            {
                if (!int.TryParse(value, out number))
                {
                    messageCollection.addMessage(new Message()
                    {
                        Context = "ValidationHandler",
                        ErrorCode = ErrorCache.NumberError,
                        ErrorMessage = FieldName + ErrorCache.getErrorMessage(ErrorCache.NumberError),
                        isError = true,
                        LogType = Enums.LogType.Exception
                        
                    });
                }
            }
        }
        public void CheckMaxLength(string value, string FieldName, int MaxLength)
        {
            if (value.Length > MaxLength)
            {
                messageCollection.addMessage(new Message()
                {
                    Context = "ValidationHandler",
                    ErrorCode = ErrorCache.MaxCharacterError,
                    ErrorMessage = FieldName + ErrorCache.getErrorMessage(ErrorCache.MaxCharacterError),
                    isError = true,
                    LogType = Enums.LogType.Exception
                    
                });
            }
        }

        public void CheckDateComparison(DateTime value, DateTime value2)
        {
            if (value < value2)
            {
                messageCollection.addMessage(new Message()
                {
                    Context = "ValidationHandler",
                    ErrorCode = ErrorCache.InvalidDateError,
                    ErrorMessage = ErrorCache.getErrorMessage(ErrorCache.InvalidDateError),
                    isError = true,
                    LogType = Enums.LogType.Exception
                    
                });
            }
        }
        public void CheckDate(DateTime value, string FieldName)
        {
            if (value < DateTime.Now)
            {
                messageCollection.addMessage(new Message()
                {
                    Context = "ValidationHandler",
                    ErrorCode = ErrorCache.InvalidDateError,
                    ErrorMessage = FieldName + ":" + ErrorCache.getErrorMessage(ErrorCache.InvalidDateError),
                    isError = true,
                    LogType = Enums.LogType.Exception
                    
                });
            }
        }
    }
}
