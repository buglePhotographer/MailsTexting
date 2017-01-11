using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailsTexting
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter2 = 0;
            int counter = 0;
            int fileNumber = 0;
            bool flagFirstRecord = true;
            //System.IO.StreamReader file = new System.IO.StreamReader("C:\\Users\\gustavo.citati\\Desktop\\testtext.txt");
            //while((line = file.ReadLine()) != null)
            //{
            //    counter++;
            //    if (counter >= 900) {
            //        line = line.Substring(0,line.Length - 2) + " GO \n INSERT INTO PEOPLE20161409 VALUES ";
            //        counter = 0;
            //    }
            //}

            //file.Close();

            string[] readText = File.ReadAllLines("C:\\Users\\gustavo.citati\\Desktop\\laPosta.txt");
            string s1;
            StringBuilder sb = new StringBuilder();
            foreach (string s in readText)
            {
                counter++;
                counter2++;
                if (counter >= 900)
                {
                    s1 = s.Substring(0, s.Length - 1) + " \n GO \n INSERT INTO PEOPLE20161409 VALUES \n";
                    sb.Append(s1);
                    counter = 0;
                }
                else if (counter2 >= 48001)
                {
                    s1 = s + "\n";
                    sb.Append(s1);
                    counter2 = 0;
                    fileNumber++;
                    System.IO.StreamWriter file = new System.IO.StreamWriter("C:\\Users\\gustavo.citati\\Desktop\\final" + fileNumber.ToString() + ".sql");
                    file.WriteLine(sb.ToString()); // "sb" is the StringBuilder
                    file.Close();
                    sb = new StringBuilder();
                    //File.WriteAllLines("C:\\Users\\gustavo.citati\\Desktop\\final" + fileNumber.ToString() + ".txt", sb);
                }
                else {
                    s1 = s + "\n";
                    sb.Append(s1);
                }
            }

            fileNumber++;
            System.IO.StreamWriter file1 = new System.IO.StreamWriter("C:\\Users\\gustavo.citati\\Desktop\\final" + fileNumber.ToString() + ".sql");
            file1.WriteLine(sb.ToString()); // "sb" is the StringBuilder
            file1.Close();

        }
    }
}
