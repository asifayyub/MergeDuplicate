using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeDuplicate
{
    public class LetterService : ILetterService
    {
        public void CombineTwoLetters(string inputFile1, string inputFile2, string resultFile)
        {
            if(!Directory.Exists(resultFile.Substring(0, resultFile.LastIndexOf(@"\"))))
                Directory.CreateDirectory(resultFile.Substring(0, resultFile.LastIndexOf(@"\")));

            MergeFiles(inputFile1, resultFile);
            MergeFiles(inputFile2, resultFile);

        }

        public void MergeFiles(string inputFile, string resultFile)
        {
            if(!File.Exists(resultFile))
                File.Create(resultFile).Close();

            using (StreamWriter sw = new StreamWriter(resultFile,true))
            {
                int blockSize = 1024 * 1024 * 8;
                char[] block = new char[blockSize];
                using (StreamReader sr = new StreamReader(inputFile))
                {
                    while (!sr.EndOfStream)
                    {
                        int chars = sr.Read(block, 0, blockSize);
                        sw.Write(block, 0, chars);
                    }
                }
            }

        }


        public void SaveOutputFile(StringBuilder strOutPutData,int NoOfCombinedLetters ,string destfile)
        {
            try
            {
               string strHeader = DateTime.Now.Date.ToString("MM/dd/yyyy") + "  Report\n" + "_____________________________________\n\n";
                strHeader += "Number Of Combined Letters: " + NoOfCombinedLetters+"\n";
                using (StreamWriter file = new StreamWriter(destfile))
                {
                    file.WriteLine(strHeader);
                    file.WriteLine(strOutPutData.ToString());
                }
            }
            catch (IOException exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        public void ArchieveFiles(string srcDir,string DirectoryName, string destDir,string archieveDirectoryPath)
        {
            try
            {
                if (!Directory.Exists(archieveDirectoryPath + @"\"+DirectoryName))
                    Directory.CreateDirectory(archieveDirectoryPath + @"\" + DirectoryName);

                File.Move(srcDir, destDir);
            }
            catch (IOException exp)
            {
                Console.WriteLine(exp.Message);
            }
        }


    }
}
