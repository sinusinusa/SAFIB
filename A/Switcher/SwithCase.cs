namespace A.Switcher
{
    public class SwithCase
    {
        public static String SwitchAB (string phaseA, string phaseB, string current)
        {
            if(current == phaseA)
            {
                return phaseB;
            }
            if (current == phaseB)
            {
                return phaseA;
            }
            else
            {
                return current;
            }
        }
    }
}
