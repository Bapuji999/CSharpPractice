namespace BasicandOOPsPart1Practice
{
    class ConditionalStatement
    {
        void example()
        {
            int point = 0;

            //If Elase Statement
            if (point == 0)
            {
                return;
            }

            //Nested If
            if (point == 0)
            {
                return;
            }
            else if (point == 1)
            {
                point = 2;
            }

            //ternary Operator
            bool val = true;
            point = val ? (val? 5: 9) : 6;

            //Switch statement
            switch (point)
            {
                case 0:
                {
                        point = 1;
                        break;
                }
                case 1:
                    point = 2;
                    break;
                default:
                    point = 3;
                    break;
            }
        }
    }
}
