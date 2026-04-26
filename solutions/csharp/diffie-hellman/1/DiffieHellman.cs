using System.Numerics;
using System.Security.Cryptography;

public static class DiffieHellman
{
    public static BigInteger PrivateKey(BigInteger primeP)
    {
        // Find the size of the byte array needed to represent the primeP
        var size = primeP.ToByteArray(true, true).Length;
        byte[] bytes;
        BigInteger key;
        // Create a random number generator
        using (var rng = RandomNumberGenerator.Create())
            // Generate a random number
            do
            {
                bytes = new byte[size];
                rng.GetBytes(bytes);
                key = new BigInteger(bytes);
                // Ensure that the generated number is in range
                // and that it is not equal to 2 or primeP - 1
            } while (key <= 2 || key >= primeP - 1);

        return key;
    }

    public static BigInteger PublicKey(
        BigInteger primeP,
        BigInteger primeG,
        BigInteger privateKey
    ) => BigInteger.ModPow(primeG, privateKey, primeP);

    public static BigInteger Secret(
        BigInteger primeP,
        BigInteger publicKey,
        BigInteger privateKey
    ) => BigInteger.ModPow(publicKey, privateKey, primeP);
}
