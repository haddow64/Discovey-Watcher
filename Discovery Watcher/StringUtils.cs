using System.Text;

namespace DSW
{
    static class StringUtils
    {

        public static string EscapeLikeValue(string value)
        {
            var sb = new StringBuilder(value.Length);
            foreach (char c in value)
            {
                switch (c)
                {
                    case ']':
                    case '[':
                    case '%':
                    case '*':
                        sb.Append("[").Append(c).Append("]");
                        break;
                    case '\'':
                        sb.Append("''");
                        break;
                    default:
                        sb.Append(c);
                        break;
                }
            }
            return sb.ToString();
        }

        public static string TrimDown(string str)
        {
            return str.Trim().ToLower();
        }

    }
}
