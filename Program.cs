namespace PasswordGenerator
{
    internal class PasswordGenerator
    {
        private static void Main(string[] args)
        {
            if(IsInputInvalid(args))
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



        private static bool IsInputInvalid(string[] args)
        {
            if (args.Length != 2) return true;

            return args[0].Any(x => !char.IsDigit(x)) ||
                   args[1].Any(x => x is not ('l' or 'L' or 'd' or 's'));

            //.Any() går igjennom alle elementer i arrays (strings er arrays av characters) og gir en bool basert på om den finner noe
            //Men 'x => condition' som parameter gjør at den finner en bool om hvert element tilfredstiller en condition, likt som en if 
            //Første linje sjekker om x ikke inneholder tall
            //Andre linje sjekker om noen av x ikke er en av våre godtatte input tegn
            // || gjør at om noen av disse linjene blir true så returnes true, fordi:
            // true || false == true
            // true || true == true
            // false || false == false
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