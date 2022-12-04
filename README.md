Inorder to test this application, you must have to add current date folder format (yyyyMMdd) in both Admission and Scholarship folder under Input folder.

inside that date format folder in both Admission & Scholarship need to add files with admission-********.txt and scholarship-********.txt respectively.

Application will look only for current date folder in admission and if found then will look for current date folder in scholarship folder.

However application will first check for days it wont run on Saturday and sunday.  



Task point 2
Estimated hours was between 5 to 6 hours but in actual it takes around 8 to 10 hours, because i have to check the process of directory and file reading & then took some time in order to get the student id and merging files is also a bit of challenge as i have to read and write at same time so.


Task point 3 (a)
I have assumed its a simple folder scan and file comparison task, but there are lot of things in it like playing with date formats, directory and files. Interface implementation, and file merging.


Task point 3 (b)
I have faced problem in dates format, searching in directories, mainly in merging files as have to read date from input file and then write in output files. I have solved reading by using StreamReader and Writer class and also thinks about the large file sizes for merging so read in block by block.


Task point 3 (c)
I have splitted code in different reuseable functions.
have implemented interface approach for all my new functions as well.
have used block size in file reading so big file sizes can be merged as well.
 
 
