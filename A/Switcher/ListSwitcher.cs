using A.UnitTree;

namespace A.Switcher
{
    public class ListSwitcher: SwithCase
    {
        public static ListSwitcher listSwitcher;
        public static void DoSwitch(List<UnitStatus> list)
        {
            foreach(UnitStatus item in list)
            {
                item.Status = SwitchAB("Active", "Blocked", item.Status);
            }
        }
    }
}
