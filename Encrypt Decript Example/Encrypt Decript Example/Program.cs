using System.Text;
class Pogram
{
    public string key = "THISisAEncryptkey";
    public static void Main(string[] args)
    {
        Pogram p = new Pogram();

        Console.WriteLine("Enter text to Encrypt: ");
        string? textToEncrypt = Console.ReadLine();

        Console.WriteLine(p.Encrypt(textToEncrypt));
        Console.WriteLine("Enter text to Decrypt: ");

        string? textToDecrypt = Console.ReadLine();
        Console.WriteLine(p.Decrypt(textToDecrypt));
    }
    public string Encrypt(string plainText)
    {
        StringBuilder cipherText = new StringBuilder();
        int keyIndex = 0;

        foreach (char character in plainText)
        {
            if (char.IsLetter(character))
            {
                char baseChar = char.IsUpper(character) ? 'A' : 'a';
                int offset = this.key[keyIndex % this.key.Length] - baseChar;
                char encryptedChar = (char)((character - baseChar + offset) % 26 + baseChar);
                cipherText.Append(encryptedChar);
                keyIndex++;
            }
            else
            {
                cipherText.Append(character);
            }
        }
        return cipherText.ToString();
    }

    public string Decrypt(string cipherText)
    {
        StringBuilder decryptedText = new StringBuilder();
        int keyIndex = 0;

        foreach (char character in cipherText)
        {
            if (char.IsLetter(character))
            {
                char baseChar = char.IsUpper(character) ? 'A' : 'a';
                int offset = this.key[keyIndex % this.key.Length] - baseChar;
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