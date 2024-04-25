namespace FormsMovieDB.Classes
{
    sealed class UserInputValidator
    {
        private char[] _forbiddenSymbols = new char[] { '\'', '\"' };

        private int _maxUsernameLength = 45;

        private int _maxEmailLength = 45;

        private int _minPasswordLength = 6;
        private int _maxPasswordLength = 45;

        public bool ValidInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            foreach (char symbol in input)
            {
                foreach (char forbiddenSymbol in _forbiddenSymbols)
                {
                    if (symbol == forbiddenSymbol)
                        return false;
                }
            }

            return true;
        }

        public bool ValidUsername(string input)
        {
            if (ValidInput(input) == false)
                return false;

            if (input.Length >= _maxUsernameLength)
                return false;

            return true;
        }

        public bool ValidEmail(string input)
        {
            if (ValidInput(input) == false)
                return false;

            if (input.Length >= _maxEmailLength)
                return false;

            if (input.Contains("@") == false && input.Contains(".") == false)
                return false;

            return true;
        }

        public bool ValidPassword(string input)
        {
            if (ValidInput(input) == false)
                return false;

            if (string.IsNullOrWhiteSpace(input))
                return false;

            if (input.Length < _minPasswordLength)
                return false;

            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsUpper(input[i]))
                    break;
                else if (i == input.Length)
                    return false;
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsLower(input[i]))
                    break;
                else if (i == input.Length)
                    return false;
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsPunctuation(input[i]))
                    break;
                else if (i == input.Length)
                    return false;
            }

            return true;
        }
    }
}
