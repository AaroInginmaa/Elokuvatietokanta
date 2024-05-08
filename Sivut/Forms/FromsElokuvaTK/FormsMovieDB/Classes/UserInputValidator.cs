using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

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
            string regex = @"^[\w.-]+@[\w.-]+.\w{2,}$";
            if (!Regex.IsMatch(input, regex, RegexOptions.IgnoreCase))
            {
                PopupNotifier popup = new PopupNotifier();
                popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
                popup.HeaderHeight = 20;
                popup.BodyColor = Color.Red;
                popup.ShowCloseButton = false;
                popup.TitleColor = Color.White;
                popup.TitleText = "Error";
                popup.ContentText = "Incorrect email";
                popup.Popup();
                return false;
            }
            return true;
        }
        public bool ValidPassword(string input)
        {
            if (ValidInput(input) == false)
                return false;
            if (string.IsNullOrWhiteSpace(input))
            {

            }
            if (input.Length < 8)
            {
                PopupNotifier popup = new PopupNotifier();
                popup.ContentFont = new System.Drawing.Font("Tahoma", 8F);
                popup.HeaderHeight = 20;
                popup.BodyColor = Color.Red;
                popup.ShowCloseButton = false;
                popup.TitleColor = Color.White;
                popup.TitleText = "Error";
                popup.ContentText = "Password must be 8 characters long";
                popup.Popup();
                return false;
            }
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
