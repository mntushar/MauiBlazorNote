using MauiBlazorNote.Library;

namespace MauiBlazorNote.Pages
{
    public partial class EncryptText
    {
        protected string Text { get; set; }
        protected string UserKey { get; set; }
        protected string OutputType { get; set; }
        protected string Output { get; set; }
        protected bool IsEncrypt { get; set; } = true;
        protected bool IsDecrypt { get; set; }

        protected void AesSubmit()
        {
            if (IsEncrypt)
                GetEncryptText();
            else if (IsDecrypt)
                GetDecryptText();
        }

        protected void ChangeEncryptType(bool isType)
        {
            IsEncrypt = isType;
            IsDecrypt = false;
        }

        protected void ChangeDecryptType(bool isType)
        {
            IsDecrypt = isType;
            IsEncrypt = false;
        }

        protected void GetEncryptText()
        {
            OutputType = "Encrypted";

            if (!string.IsNullOrEmpty(Text) && !string.IsNullOrEmpty(UserKey))
                Output = AesCryptography.GetEncrypt(Text, UserKey);
        }

        protected void GetDecryptText()
        {
            OutputType = "Decrypted";

            if (!string.IsNullOrEmpty(Text) && !string.IsNullOrEmpty(UserKey))
                Output = AesCryptography.GetDecrypt(Text, UserKey);
        }
    }
}
