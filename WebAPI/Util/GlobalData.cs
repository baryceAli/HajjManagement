namespace WebAPI.Util
{
    public static class GlobalData
    {
        public static int CurrentCountryId { get; set; }
        public static string EmailPassword { get; set; }
        public static string GenerateRandomPassword(int length = 8)
        {
            if (length < 3)
                throw new ArgumentException("Password length must be at least 3.");

            const string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string lower = "abcdefghijklmnopqrstuvwxyz";
            const string digits = "0123456789";

            var random = new Random();

            // Ensure at least one of each required character type
            var passwordChars = new char[length];
            passwordChars[0] = upper[random.Next(upper.Length)];
            passwordChars[1] = lower[random.Next(lower.Length)];
            passwordChars[2] = digits[random.Next(digits.Length)];

            // Fill remaining positions with random characters from all sets
            string allChars = upper + lower + digits;
            for (int i = 3; i < length; i++)
            {
                passwordChars[i] = allChars[random.Next(allChars.Length)];
            }

            // Shuffle to avoid predictable positions
            return new string(passwordChars.OrderBy(x => random.Next()).ToArray());
        }
    }
}
