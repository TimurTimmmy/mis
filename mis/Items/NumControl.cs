using System;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace mis.Items
{
    public class NumControl
    {
        public static void NumsOnlyInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Regex.IsMatch(Convert.ToString(e.Text), "[^0-9\b]+");
        }
    }
}
