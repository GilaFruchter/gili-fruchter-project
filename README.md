שלום! 

זהו קובץ הסבר לפרוייקט שנעשה ע"י גילי פרוכטר.
בהמשך הקובץ יש תרגום לאנגלית למקרה הצורך.

הוראות:
הפרוייקט מכיל 2 קבצים בתוך תקיית הGITHUB בשמות: gili-fruchter-project, react-project.  יש לשים לב לשניהם.

הוראות התקנה:

תחלה יש לוודא שהתוכנות הבאות מופעלות על המחשב שלך:

א. .NET SDK 8.0

ב.SQL Server LocalDB / SQL Server Express

ג. Visual Studio 2022 

ד. Git (מותקן ומוגדר)


התקנה:

פתח טרמינל (כמובן עדיף Git Bash) ובחר:

א. כדי להוריד את קובץ הC# הקלד:git clone https://github.com/GilaFruchter/gili-fruchter-project.git

ב. כדי להוריד את קובץ הreact הקלד: git clone https://github.com/GilaFruchter/react-project.git


טכנולוגיות בשימוש:

א. Backend:

 א. C#

 ב.ASP.NET Core 8.0

 ג. Entity Framework Core 8.0

 ד. QL Server LocalDB / Express:

 ה. OpenAI GPT API

ב. Frontend:

 א. React

 ב.JavaScript 

 ג. HTML5 / CSS3

 ד. npm / Yarn

 ה. MUI
 

 מבנה פרוייקט: 

 החלק של C# מחולק לשלושה שכבות- DAL, BL וSERVICE שבכל אחד מהם יש שלוש תקיות- מודלים, ממשקים ושרתים.

 בחלק של React יש קומפוננטות שאותן מרנדרים בAPP וredux להגעה לנתונים מתוך מסד הנתונים.


 הנחות שנעשו:

 א. סביבת פיתוח (Windows)

 ב. זמינות פורטים 

 ג. תלות ה-Frontend ב-Backend

 ד. שימוש ב-SQL Server LocalDB

 ה. שימוש ב-SQL Server LocalDB

 ו. כיצד מוגדר ה-OPENAI_API_KEY


 כיצד להפעיל באופן מקומי: 

 יש לפתוח את תקיית הgili-fruchter-project, ההפעלה תתבצע דרך פרוייקט הC#, בתוכה יש קובץ בשם CS, אותו יש לפתח.

 לאחר מכן יש לפתח את קובץ הreact-project ובו להריץ בשורת הפקודה npm run dev. 

 מיד אמור להיפתח התוצאה (המרהיבה;). 

 כדאי לדעת שעל מנת להיכנס עם שם משתמש קיים ניתן לבחור Id =1 או להכניס Id חדש ולהיכנס בתור new user שכמובן יכנס למסד הנתונים.


 הערות: 

 א. כיוון שהיו כמה ימים ובעיקר היום האחרון שהKEY_API לא עבד אין לי ביטחון מוחלט לגבי התוצאות הסופיות- בהתחלה זה עבד ולכן יש כמה מקומות שכולי תקווה שהם באמת נכונים ועובדים, השתדלתי!.

 תודה רבה ובהצלחה!!!!!!!

Hello! 
This is an explanation file for a project done by Gili Fruchter.

Instructions:
The project contains 2 files inside the GITHUB folder named: gili-fruchter-project, react-project. Please pay attention to both of them.

Installation Instructions:
First, make sure the following software is running on your computer:
A. .NET SDK 8.0
B. SQL Server LocalDB / SQL Server Express
C. Visual Studio 2022 
D. Git (installed and configured)

Installation:
Open a terminal (Git Bash is of course preferred) and choose:
A. To download the C# file type: git clone https://github.com/GilaFruchter/gili-fruchter-project.git
B. To download the react file type: git clone https://github.com/GilaFruchter/react-project.git

Technologies Used:
A. Backend:
 A. C#
 B. ASP.NET Core 8.0
 C. Entity Framework Core 8.0
 D. SQL Server LocalDB / Express:
 E. OpenAI GPT API
B. Frontend:
 A. React
 B. JavaScript 
 C. HTML5 / CSS3
 D. npm / Yarn
 E. MUI

Project Structure: 
The C# part is divided into three layers - DAL, BL and SERVICE, each of which has three folders - models, interfaces and servers.
In the React part there are components that are rendered in the APP and Redux for accessing data from the database.

Assumptions Made:
A. Development environment (Windows)
B. Port availability 
C. Frontend-Backend dependency 
D. Use of SQL Server LocalDB
E. Use of SQL Server LocalDB
F. How the OPENAI_API_KEY is configured

How to run locally: 
You need to open the gili-fruchter-project folder, the operation will be done through the C# project, inside it there is a file named CS, which needs to be opened.
After that, you need to open the react-project file and run npm run dev in the command line. 
Immediately the result should open (the magnificent one;). 
It is worth noting that to log in with an existing user name, you can choose Id = 1 or enter a new Id and log in as a new user, which will of course enter the database.

Notes: 
A. Since there were several days, and especially the last day, that the KEY_API did not work, I am not completely sure about the final results - it worked initially, so I very much hope that some places are indeed correct and working, I tried my best!. 

Thank you very much and good luck!!!!!!!
