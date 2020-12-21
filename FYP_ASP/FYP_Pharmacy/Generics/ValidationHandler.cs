using Generics.Cache;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Generics
{
    public class ValidationHandler
    {
        public MessageCollection messageCollection = new MessageCollection();
        public string PageName { get; set; }
        public void CheckNull(ref TextBox textBox, string FieldName)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text) && string.IsNullOrWhiteSpace(textBox.Attributes["value"]))
            {
                messageCollection.addMessage(new Message()
                {
                    Context = "ValidationHandler",
                    ErrorCode = ErrorCache.NullError,
                    ErrorMessage = FieldName + ErrorCache.getErrorMessage(ErrorCache.NullError),
                    isError = true,
                    LogType = Enums.LogType.Exception,
                    WebPage = PageName
                });
            }
        }
        public void CheckNull(ref DropDownList dropDownList, string FieldName)
        {
            if (string.IsNullOrWhiteSpace(dropDownList.SelectedValue))
            {
                messageCollection.addMessage(new Message()
                {
                    Context = "ValidationHandler",
                    ErrorCode = ErrorCache.NullError,
                    ErrorMessage = FieldName + ErrorCache.getErrorMessage(ErrorCache.NullError),
                    isError = true,
                    LogType = Enums.LogType.Exception,
                    WebPage = PageName
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
                    LogType = Enums.LogType.Exception,
                    WebPage = PageName
                });
            }
        }
        public void CheckNumber(ref TextBox textBox, string FieldName)
        {
            int number;
            if (!string.IsNullOrWhiteSpace(textBox.Text))
            {
                if (!int.TryParse(textBox.Text, out number))
                {
                    messageCollection.addMessage(new Message()
                    {
                        Context = "ValidationHandler",
                        ErrorCode = ErrorCache.NumberError,
                        ErrorMessage = FieldName + ErrorCache.getErrorMessage(ErrorCache.NumberError),
                        isError = true,
                        LogType = Enums.LogType.Exception,
                        WebPage = PageName
                    });
                }
            }
        }
        public void CheckMaxLength(ref TextBox textBox, string FieldName, int MaxLength)
        {
            if (textBox.Text.Length > MaxLength)
            {
                messageCollection.addMessage(new Message()
                {
                    Context = "ValidationHandler",
                    ErrorCode = ErrorCache.MaxCharacterError,
                    ErrorMessage = FieldName + ErrorCache.getErrorMessage(ErrorCache.MaxCharacterError),
                    isError = true,
                    LogType = Enums.LogType.Exception,
                    WebPage = PageName
                });
            }
        }

        public void CheckDateComparison(ref TextBox textBox, ref TextBox textBox2)
        {
            if (Convert.ToDateTime(textBox.Text) < Convert.ToDateTime(textBox2.Text))
            {
                messageCollection.addMessage(new Message()
                {
                    Context = "ValidationHandler",
                    ErrorCode = ErrorCache.InvalidDateError,
                    ErrorMessage = ErrorCache.getErrorMessage(ErrorCache.InvalidDateError),
                    isError = true,
                    LogType = Enums.LogType.Exception,
                    WebPage = PageName
                });
            }
        }
        public void CheckDate(ref TextBox textBox, string FieldName)
        {
            if (Convert.ToDateTime(textBox.Text) < DateTime.Now)
            {
                messageCollection.addMessage(new Message()
                {
                    Context = "ValidationHandler",
                    ErrorCode = ErrorCache.InvalidDateError,
                    ErrorMessage = FieldName + ":" + ErrorCache.getErrorMessage(ErrorCache.InvalidDateError),
                    isError = true,
                    LogType = Enums.LogType.Exception,
                    WebPage = PageName
                });
            }
        }
    }
}
