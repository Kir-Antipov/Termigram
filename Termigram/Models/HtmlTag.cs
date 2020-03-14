namespace Termigram.Models
{
    internal class HtmlTag
    {
        #region Var
        public readonly string Open;
        public readonly string Close;
        #endregion

        #region Init
        public HtmlTag(string tag)
        {
            Open = $"<{tag}>";
            Close = $"</{tag}>";
        }

        public static implicit operator HtmlTag(string tag) => new HtmlTag(tag);
        #endregion

        #region Functions
        public override string ToString() => Open;
        #endregion
    }
}
