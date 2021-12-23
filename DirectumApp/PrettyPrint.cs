using System;
using System.Collections;
using System.Linq;

namespace DirectumTestApp
{
    class PrettyPrint
    {
        private const int cell_pad = 2;
        public static void print(ref ArrayList o, ref string[] col_name) 
        {
            if (o.Count == 0)
                return;

            int[] col_len = new int[col_name.Count()];

            for (int i = 0; i < col_name.Count(); i++)
                col_len[i] = col_name[i].Length;

            foreach (Object[] row in o)
            {
                for (int i = 0; i < row.Count(); i++) 
                {
                    Object col = row[i];
                    if (col_len[i] < col.ToString().Length)
                        col_len[i] = col.ToString().Length;
                }
            }

            _printTableLine(ref col_len);

            for (int i = 0; i < col_name.Count(); i++) 
                Console.Write(" | " + col_name[i]);
            Console.WriteLine(" | ");

            _printTableLine(ref col_len);

            foreach (Object[] row in o)
            {
                for (int i = 0; i < row.Count(); i++)
                {
                    Object col = row[i];
                    Console.Write( " | " + col.ToString().PadRight(col_len[i]) );
                }
                Console.WriteLine(" | ");
            }

            _printTableLine(ref col_len);
        }

        private static void _printTableLine(ref int[] col_len) 
        {
            Console.Write(" ");
            for (int i = 0; i < col_len.Count(); i++)
                Console.Write("+" + "".PadRight(col_len[i] + 2, '-'));
            Console.WriteLine("+");
        }
    }
}
