using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeDuplicate
{
    public interface ILetterService
    {
        void CombineTwoLetters(string inputFile1,string inputFile2,string resultFile);
        void ArchieveFiles(string srcDir, string DirectoryName, string destDir, string archieveDirectoryPath);
        void MergeFiles(string inputFile, string resultFile);
    }
}
