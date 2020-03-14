using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Termigram.Models
{
    internal class MarkdownTag
    {
        #region Var
        private readonly Regex Regex;

        private static readonly HashSet<char> Operators = new HashSet<char> { '*', '[', ']', '(', ')' };
        #endregion

        #region Init
        public MarkdownTag(string tag) : this(tag, tag) { }

        public MarkdownTag(params string[] tags) => Regex = new Regex(string.Join(string.Empty, tags.Where((x, i) => i % 2 == 0).Zip(tags.Where((x, i) => i % 2 == 1), (open, close) => 
        {
            string openTag = Shield(open);
            string closeTag = Shield(close);

            return $@"{openTag}.*[^\\]{closeTag}";
        })), RegexOptions.Compiled | RegexOptions.Compiled);

        public static implicit operator MarkdownTag(string tag) => new MarkdownTag(tag);
        #endregion

        #region Functions
        private static string Shield(string tag) => string.Join(string.Empty, tag.Select(c => Operators.Contains(c) ? $"\\{c}" : $"{c}"));

        public bool IsMatch(string text) => Regex.IsMatch(text);
        #endregion
    }
}
