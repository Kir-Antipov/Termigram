using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Termigram.Models
{
    internal class MarkdownTag
    {
        #region Var
        private readonly Regex Regex;

        private static readonly HashSet<char> Operators = new HashSet<char> { '*', '.', '[', ']', '(', ')', '^', '\\', '?' };
        #endregion

        #region Init
        public MarkdownTag(string tag) : this(tag, tag) { }

        public MarkdownTag(params string[] tags) => Regex = new Regex(string.Join(string.Empty, tags.Where((x, i) => i % 2 == 0).Zip(tags.Where((x, i) => i % 2 == 1), (open, close) => 
        {
            string openTag = string.Join(string.Empty, open.Select(c => Operators.Contains(c) ? $"\\{c}" : $"{c}"));
            string closeTag = string.Join(string.Empty, close.Select(c => Operators.Contains(c) ? $"\\{c}" : $"{c}"));
            return $@"{openTag}.*[^\\]{closeTag}";
        })), RegexOptions.Compiled | RegexOptions.Compiled);

        public static implicit operator MarkdownTag(string tag) => new MarkdownTag(tag);
        #endregion

        #region Functions
        public bool IsMatch(string text) => Regex.IsMatch(text);
        #endregion
    }
}
