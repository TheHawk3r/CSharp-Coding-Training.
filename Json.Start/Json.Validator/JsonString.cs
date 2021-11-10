using System;

namespace Json
{
    public static class JsonString
    {
        private const int HexNumberLength = 6;

        public static bool IsJsonString(string input)
        {
            if (input == null)
            {
                return false;
            }

            if (input.Contains(@"\x"))
            {
                return false;
            }

            if (input.EndsWith("\\\""))
            {
                return false;
            }

            return InputIsDoubleQuoted(input)
                && InputHasStartAndEndQuotes(input)
                && !InputHasControlCharacters(input)
                && !StringEndsWithAFinishedHexNumber(input);
        }

        public static bool StringEndsWithAFinishedHexNumber(string input)
        {
            const bool f = false;
            if (input == null)
            {
                return false;
            }

            return input.LastIndexOf("\\u") >= input.Length - HexNumberLength
                && input.LastIndexOf("\\u") != -1
                ? input.LastIndexOf("\\u") >= input.Length - HexNumberLength
                : f;
        }

        public static bool InputIsDoubleQuoted(string input)
        {
            if (input == null)
            {
                return false;
            }

            return input.StartsWith("\"") && input.EndsWith('\"');
        }

        public static bool InputIsNotEmpty(string input)
        {
            return input != string.Empty;
        }

        public static bool InputHasStartAndEndQuotes(string input)
        {
            if (input == null)
            {
                return false;
            }

            return input.StartsWith("\"") && input.EndsWith("\"") && input.Length != 1;
        }

        public static bool InputIsNull(string input)
        {
            return input == null;
        }

        public static bool InputHasControlCharacters(string input)
        {
            if (input == null)
            {
                return false;
            }

            foreach (char c in input)
            {
                if (char.IsControl(c))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
