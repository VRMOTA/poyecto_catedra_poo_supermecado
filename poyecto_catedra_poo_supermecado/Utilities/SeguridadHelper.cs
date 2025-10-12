using System;
using System.Security.Cryptography;

namespace poyecto_catedra_poo_supermecado.Utilities
{
    public static class SeguridadHelper
    {
        private const int SaltSize = 16; // bytes de sal
        private const int HashSize = 32; // bytes de hash
        private const int Iterations = 150000; // puedes ajustar según rendimiento

        /// <summary>
        /// Genera un hash seguro de la contraseña con sal aleatoria.
        /// Formato: iteraciones.salt.hash
        /// </summary>
        public static string HashPassword(string password)
        {
            if (password == null) throw new ArgumentNullException(nameof(password));

            // Generar sal aleatoria
            byte[] salt = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            // Generar hash PBKDF2
            byte[] hash;
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256))
            {
                hash = pbkdf2.GetBytes(HashSize);
            }

            // Retornar formato "iteraciones.salt.hash"
            return $"{Iterations}.{Convert.ToBase64String(salt)}.{Convert.ToBase64String(hash)}";
        }

        /// <summary>
        /// Verifica si la contraseña ingresada coincide con el hash almacenado.
        /// </summary>
        public static bool VerifyPassword(string password, string storedHash)
        {
            if (password == null) throw new ArgumentNullException(nameof(password));
            if (storedHash == null) throw new ArgumentNullException(nameof(storedHash));

            var parts = storedHash.Split('.');
            if (parts.Length != 3) return false;

            int iterations = int.Parse(parts[0]);
            byte[] salt = Convert.FromBase64String(parts[1]);
            byte[] hash = Convert.FromBase64String(parts[2]);

            byte[] computedHash;
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256))
            {
                computedHash = pbkdf2.GetBytes(hash.Length);
            }

            // Comparación segura
            return FixedTimeEquals(computedHash, hash);
        }

        /// <summary>
        /// Comparación segura de dos arrays en tiempo constante para evitar timing attacks
        /// </summary>
        private static bool FixedTimeEquals(byte[] a, byte[] b)
        {
            if (a.Length != b.Length) return false;
            int diff = 0;
            for (int i = 0; i < a.Length; i++)
            {
                diff |= a[i] ^ b[i];
            }
            return diff == 0;
        }
    }
}
