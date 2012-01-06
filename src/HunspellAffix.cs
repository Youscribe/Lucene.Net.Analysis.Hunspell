using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Lucene.Net.Analysis.Hunspell {
    /// <summary>
    ///   Wrapper class representing a hunspell affix.
    /// </summary>
    [DebuggerDisplay("{Condition}")]
    public class HunspellAffix {
        private String _condition;
        private Regex _conditionPattern;

        /// <summary>
        ///   The append defined for the affix.
        /// </summary>
        public String Append { get; set; }

        /// <summary>
        ///   The flags defined for the affix append.
        /// </summary>
        public Char[] AppendFlags { get; set; }

        /// <summary>
        ///   The condition that must be met before the affix can be applied.
        /// </summary>
        public String Condition {
            get { return _condition; }
        }

        /// <summary>
        ///   The affix flag.
        /// </summary>
        public Char Flag { get; set; }

        /// <summary>
        ///   Whether the affix is defined as cross product.
        /// </summary>
        public Boolean IsCrossProduct { get; set; }

        /// <summary>
        ///   The stripping characters defined for the affix.
        /// </summary>
        public String Strip { get; set; }

        /// <summary>
        ///   Checks whether the String defined by the provided char array, offset 
        ///   and length, meets the condition of this affix.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if the String meets the condition, <c>false</c> otherwise.
        /// </returns>
        public Boolean CheckCondition(String text) {
            if (text == null)
                throw new ArgumentNullException("text");

            return _conditionPattern.IsMatch(text);
        }

        /// <summary>
        ///   Sets the condition that must be met before the affix can be applied.
        /// </summary>
        /// <param name="condition">Condition to be met before affix application.</param>
        /// <param name="pattern">Condition as a regular expression pattern.</param>
        public void SetCondition(String condition, String pattern) {
            if (condition == null) throw new ArgumentNullException("condition");
            if (pattern == null) throw new ArgumentNullException("pattern");

            _condition = condition;
            _conditionPattern = new Regex(pattern);
        }
    }
}