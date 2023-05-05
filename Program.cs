namespace PasswordGenerator
{
    internal class PasswordGenerator
    {
        private static void Main(string[] args)
        {
            if(IsInvalid(args))
            {
                ErrorMessage();
                return;
            }
            var num = Convert.ToInt32(args[0]);
            var str = args[1];

            var password = string.Empty;
            foreach (var x in str)
            {
                if (x == 'L') password += RandomUpperCaseLetter();
                if (x == 'l') password += RandomLowerCaseLetter();
                if (x == 'd') password += RandomLowerDigit();
                if (x == 's') password += RandomSpecialCharacter();
            }

            while (password.Length < num)
            {
                int rdm = new Random().Next(0, 3);
                if (rdm == 0) password += RandomUpperCaseLetter();
                if (rdm == 1) password += RandomLowerDigit();
                if (rdm == 2) password += RandomLowerCaseLetter();
            }

            Console.WriteLine(password);

        }



        private static bool IsInvalid(string[] args)
        {
            if (args.Length != 2) return true;

            var num = args[0];
            var str = args[1];

            return num.Any(x => !char.IsDigit(x)) ||
                   str.Any(x => x is not ('l' or 'L' or 'd' or 's'));
        }

        private static char RandomUpperCaseLetter()
        {
            return RandomLetterGenerator('A','Z');
        }

        private static char RandomLowerCaseLetter()
        {
            return RandomLetterGenerator('a','z');
        }

        private static char RandomLetterGenerator(char min, char max)
        {
            return (char) new Random().Next(min, max);
        }

        private static char RandomLowerDigit()
        {
            return new Random().Next(0, 10).ToString()[0];
        }

        private static char RandomSpecialCharacter()
        {
            const string specialChars = "!@#$%^&*()[]{}_-+=';/<>";
            return specialChars[new Random().Next(0, specialChars.Length-1)];
        }

        private static void ErrorMessage()
        {
            Console.WriteLine("PasswordGenerator");
            Console.WriteLine("Options:");
            Console.WriteLine("- l = lower case letter");
            Console.WriteLine("- L = upper case letter");
            Console.WriteLine("- d = digit");
            Console.WriteLine("- s = special character (!@#$%^&*()[]{}_-+=';/<>");
            Console.WriteLine();
            Console.WriteLine("Example: PasswordGenerator 14 Llssdd");
            Console.WriteLine("         Min. 1 lower case");
            Console.WriteLine("         Min. 1 upper case");
            Console.WriteLine("         Min. 2 special characters");
            Console.WriteLine("         Min. 2 digits");
        }
    }
}