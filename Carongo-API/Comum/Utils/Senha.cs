using System;

namespace CodeTur.Comum.Utils
{
    public static class Senha
    {
        public static string Criptografar(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        public static bool Validar(string senha, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(senha, hash);
        }

        public static string Gerar()
        {
            string caracteres = "abcdefghijklmnopqrstuvwxyz123456789";
            string senha = "";

            Random random = new Random();

            for(int c = 0; c < 8; c++)
            {
                senha += caracteres.Substring(random.Next(0, caracteres.Length -1), 1);
            }

            return senha;
        }
    }
}