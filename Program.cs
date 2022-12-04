// See https://aka.ms/new-console-template for more information
using MergeDuplicate;
using System;
using System.Text;

Console.WriteLine("Merging Scholarship & Admission Files!");

LetterService letterService= new LetterService();
string admissionDir = Environment.CurrentDirectory + @"\CombinedLetters\Input\Admission";
string scholarshipDir = Environment.CurrentDirectory + @"\CombinedLetters\Input\Scholarship";
string ouputDir = Environment.CurrentDirectory + @"\CombinedLetters\Output";
string archieveDir = Environment.CurrentDirectory + @"\CombinedLetters\Archive";

var currentDate = DateTime.Now;
Console.WriteLine(currentDate);

if (currentDate.Date.DayOfWeek != DayOfWeek.Saturday && currentDate.Date.DayOfWeek != DayOfWeek.Sunday)
{
    DirectoryInfo admissionDirectory = new DirectoryInfo(Path.GetFullPath(admissionDir));
    DirectoryInfo scholarshipDirectory = new DirectoryInfo(Path.GetFullPath(scholarshipDir));
    int noOfScholarships = 0;
    StringBuilder strStudentIdList=new StringBuilder();
    if (admissionDirectory != null && admissionDirectory.Exists && admissionDirectory.GetDirectories().Length > 0)
    {
        
        DirectoryInfo[] dirs = admissionDirectory.GetDirectories(DateTime.Now.Date.ToString("yyyyMMdd"));
        foreach (var admissionDatedirectory in dirs)
        {
            DirectoryInfo dirScholarship = scholarshipDirectory.GetDirectories(admissionDatedirectory.Name).FirstOrDefault();
            if (dirScholarship != null)
            {
                foreach (var item in admissionDatedirectory.GetFiles())
                {
                    string[] studentId = item.Name.Split("-");
                    if (studentId.Length > 0)
                    {
                        FileInfo fileInfo = dirScholarship.GetFiles("*"+studentId[1].Replace(".txt", "")+".*").FirstOrDefault();
                        if (fileInfo != null) 
                        {
                            // Found File in both Admission & Scholarship folder
                            letterService.CombineTwoLetters(item.FullName, fileInfo.FullName, ouputDir+@"\"+ admissionDatedirectory.Name + @"\Merged-" + studentId[1]);
                            // Move Files to Archieve Folder
                            letterService.ArchieveFiles(item.FullName, admissionDatedirectory.Name, archieveDir + @"\" + admissionDatedirectory.Name +@"\" +item.Name, archieveDir);
                            letterService.ArchieveFiles(fileInfo.FullName, admissionDatedirectory.Name, archieveDir + @"\" + admissionDatedirectory.Name + @"\"+ fileInfo.Name, archieveDir);
                            strStudentIdList.AppendLine(studentId[1].Replace(".txt", ""));
                            noOfScholarships += 1;
                        }
                    }
                }
            }
            // Move Files to directory
            if(noOfScholarships > 0)
            letterService.SaveOutputFile(strStudentIdList, noOfScholarships, ouputDir + @"\" + admissionDatedirectory.Name+ @"\Report-"+admissionDatedirectory.Name+".txt");

            Console.WriteLine("Merging Complete!!!");
        }
    }
}


