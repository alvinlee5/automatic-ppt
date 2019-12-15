namespace AutoPoint
{
    internal class ListBoxItem
    {
        public string DisplayMember { get; set; }
        public string ValueMember { get; set; }

        public ListBoxItem(string displayMember, string valueMember)
        {
            DisplayMember = displayMember;
            ValueMember = valueMember;
        }

        public override string ToString()
        {
            return DisplayMember;
        }
    }
}