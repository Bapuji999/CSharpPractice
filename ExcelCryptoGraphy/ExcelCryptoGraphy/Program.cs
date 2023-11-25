using OfficeOpenXml;
using System.Security.Cryptography;
using System.Text;

namespace ExcelCryptoGraphy
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "C:\\Users\\bapuj\\Downloads\\demo01.xlsx";
            DecryptAndStore(filePath);
        }
        static void DecryptAndStore(string filePath)
        {
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                string key = "b14ca5898a4e4133bbce2ea2315a1916";
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                var worksheet = package.Workbook.Worksheets[0];
                string[] columnToDecrypt = { "G", "I", "K"};
                string[] columnToStoreDecrypted = { "F", "H", "J" };
                for(int i = 0; i< columnToDecrypt.Length; i++)
                {
                    for (int row = 3; row <= worksheet.Dimension.Rows; row++)
                    {
                        string encryptedValue = worksheet.Cells[row, GetColumnNumber(columnToDecrypt[i])].Text;
                        string decryptedValue = DecryptString(key, encryptedValue);
                        worksheet.Cells[row, GetColumnNumber(columnToStoreDecrypted[i])].Value = decryptedValue;
                    }
                }
                int GetColumnNumber(string columnName)
                {
                    int result = 0;
                    foreach (char c in columnName)
                    {
                        result *= 26;
                        result += c - 'A' + 1;
                    }
                    return result;
                }
                package.Save();
            }
        }
        public static string DecryptString(string key, string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
        public static string Decrypt(string key, string cipherText)
        {
            StringBuilder decryptedText = new StringBuilder();
            int keyIndex = 0;

            foreach (char character in cipherText)
            {
                if (char.IsLetter(character))
                {
                    char baseChar = char.IsUpper(character) ? 'A' : 'a';
                    int offset = key[keyIndex % key.Length] - baseChar;
                    char decryptedChar = (char)((character - baseChar - offset + 26) % 26 + baseChar);
                    decryptedText.Append(decryptedChar);
                    keyIndex++;
                }
                else
                {
                    decryptedText.Append(character);
                }
            }
            return decryptedText.ToString();
        }
    }
}