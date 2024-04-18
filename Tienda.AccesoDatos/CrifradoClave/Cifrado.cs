using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.AccesoDatos.CrifradoClave
{
    public class Cifrado
    {
        //preguntar porque un array de bytes funciona en vez de un string
        private static byte[] _key = new byte[32] { 0x2b, 0x7e, 0x15, 0x16, 0x28, 0xae, 0xd2, 0xa6, 0xab, 0xf7, 0x15, 0x88, 0x09, 0xcf, 0x4f, 0x3c, 0x2b, 0x7e, 0x15, 0x16, 0x28, 0xae, 0xd2, 0xa6, 0xab, 0xf7, 0x15, 0x88, 0x09, 0xcf, 0x4f, 0x3c };
        //private static readonly byte[] _key = Encoding.UTF8.GetBytes("ocbjPHc5pVm619wyRwf8d9kFt53409S"); 
        private static readonly byte[] _iv = Encoding.UTF8.GetBytes("dpw9kUmc3cG6jt5b");

        public static string EncriptarClave(string clave)
        {
            //AES es un algoritmo de cifrado de información que se utiliza para proteger datos confidenciales.
            using Aes aesAlg = Aes.Create();

            aesAlg.Key = _key;
            aesAlg.IV = _iv;

            // Se crea un objeto de tipo ICryptoTransform para realizar la transformación de los datos
            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            // toma una cadena de texto, la encripta utilizando el AES y la guarda en un MemoryStream en forma de datos encriptados
            // MemoryStream es una secuencia de bytes en la memoria que se puede leer y escribir de forma rápida
            using MemoryStream msEncrypt = new MemoryStream();
            using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
            {
                using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(clave);
                    csEncrypt.Write(bytes, 0, bytes.Length);
                    csEncrypt.FlushFinalBlock();
                }
            }
            // Convierte los datos encriptados en un string en base64
            // para que se pueda almacenar en la base de datos, ya que los datos encriptados no siempre se puede representar en texto plano
            return Convert.ToBase64String(msEncrypt.ToArray());
        }

        public static string DesencriptarClave(string claveEncriptada)
        {
            using Aes aesAlg = Aes.Create();
            aesAlg.Key = _key;
            aesAlg.IV = _iv;

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(claveEncriptada));
            using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
            {
                using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                {
                    return srDecrypt.ReadToEnd();
                }
            }
        }
    }
}
