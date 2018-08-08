using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Registration
    {//수강신청 처리 클래스
        
        //	학생 정보 초기화
        public int CreateStudentList(StudentInfo[] studentList)
        {
            int i = 0;

	        for(i = 0; i < Program.MAX_STUDENT_CNT; i++)
	        {
                if (i < Program.MIN_STUDENT_CNT)
			        studentList[i].id = 1001 + i;
		        else
			        studentList[i].id = -1;
                studentList[i].classList = new SingleLinkedList<ClassInfo>();//*********
	        }
            //기본 학생정보 출력
            Console.WriteLine();
            Console.WriteLine("기등록 된 " + Program.MIN_STUDENT_CNT + "명의 학생 목록");

            DisplayAllInfo(studentList);

	        return i;
        }
        
        //	콘솔 메뉴 화면
        public void DisplayMenu()
        {
	        Console.WriteLine("========================================================");
	        Console.WriteLine("1. 모든 학생정보 출력. ");
	        Console.WriteLine("2. 학생 등록. ");
	        Console.WriteLine("3. 과목 추가. ");
	        Console.WriteLine("4. 과목 삭제. ");
	        Console.WriteLine("5. Exit program. ");
            Console.WriteLine("========================================================");
            Console.Write("선택 : ");
        }
        
        //	기능부
        public int RunFunction(int n, StudentInfo[] studentList)
        {
	        switch(n)
	        {
	        case 1 :
                DisplayAllInfo(studentList);
		        break;
	        case 2 :
                AddStudent(studentList);
		        break;
	        case 3 :
                AddClass(studentList);
		        break;
	        case 4:
                DropClass(studentList);
		        break;
	        case 5 :
		        Console.WriteLine("Exit program.");
		        return -1;
	        default :
                Console.WriteLine("잘못된 선택입니다.");
		        return 1;
	        }

	        return 0;
        }
        //	케이스 1 모든 학생정보 출력
        private void DisplayAllInfo(StudentInfo[] studentList)
        {
	        int i = 0;
	       
	        Console.WriteLine("========================================================");
	        Console.WriteLine("  번호  |  ID  |  과목 목록(과목명, 분반, 학점)");
            Console.WriteLine("========================================================");

	        for(i = 0; i < Program.MAX_STUDENT_CNT; i++)
	        {
		        if(studentList[i].id == -1)
			        continue;

                Console.Write("  {0,3}  | {1,4} |", i + 1, studentList[i].id);
                if (studentList[i].classList.GetStart() ==null)
                {
                    Console.WriteLine("");
                }
                else
                {
                    /*
                    for (int j = 0; j < studentList[i].classList.Length(); j++)
                    {
                        Console.Write("("+studentList[i].classList.Get(j).code + ", ");
                        Console.Write(studentList[i].classList.Get(j).section.ToString() + ", ");
                        Console.Write(studentList[i].classList.Get(j).credit.ToString()+") ");
                    }
                    */
                    
                    foreach (ClassInfo ci in studentList[i].classList)//**************
                    {

                        Console.Write("  (과목명: " + ci.code + ", " + ci.section.ToString() + "분반 , " +ci.credit.ToString() + "학점)");

                    }

                    Console.WriteLine("");
                }
            }
            Console.WriteLine("========================================================\n");
        }

        
        // 학생 등록
        private void AddStudent(StudentInfo[] studentList)
        {
	        int stuID;
	        int i = 0;

	        // 빈공간 체크
	        for(i = 0; i < Program.MAX_STUDENT_CNT; i++)
	        {
		        if(studentList[i].id == -1)
		        {
			        break;
		        }
	        }

	        if(i == Program.MAX_STUDENT_CNT)
	        {
		        Console.WriteLine("더 등록할 수 없습니다.\n");
		        return;
	        }

            // 등록시에 학생 ID 입력
            Console.Write("학번을 입력하세요 : ");
            try
            {
                stuID = Convert.ToInt32(Console.ReadLine());
                if (stuID > 1999 || stuID < 1011)
                {
                    Console.WriteLine("Error!! 올바른 학번이 아닙니다. [1011~1999]");
                    return;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error!! 올바른 학번이 아닙니다.");
                return;
            }
        	
            // 학생 등록
	        studentList[i].id = stuID;
            studentList[i].classList = new SingleLinkedList<ClassInfo>();//***********
            Console.WriteLine(stuID.ToString() + " 추가되었습니다.\n");
        }
        
        //	과목 등록
        private void AddClass(StudentInfo[] studentList)//***************
        {
	        int stuID = 0;
	        int index = -1;
	        int i = 0;
	        ClassInfo tempInfo;
        	
            // 과목 정보 등록할 특정 학생 ID 입력
	        Console.Write("학번을 입력하세요 : ");
	        try
            {
                stuID = Convert.ToInt32(Console.ReadLine());
                if (stuID > 1999 || stuID < 1001)
                {
                    Console.WriteLine("Error!! 올바른 학번이 아닙니다. [1001~1999]");
                    return;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error!! 올바른 학번이 아닙니다. [1001~1999]");
                return;
            }

	        for(i = 0; i < Program.MAX_STUDENT_CNT; i++)
	        {
		        if(studentList[i].id == stuID)
		        {
			        index = i;
			        break;
		        }
	        }

	        if(index == -1)
	        {
		        Console.WriteLine("해당 학생이 존재하지 않습니다.\n");
		        return;
	        }
        	
	        tempInfo = new ClassInfo();

            Console.Write("과목명 입력 : ");
            tempInfo.code = Console.ReadLine();
	            		
	        Console.Write("분반 입력 : ");            
            try
            {
                tempInfo.section = Convert.ToInt32(Console.ReadLine());               
            }
            catch (FormatException)
            {
                Console.WriteLine("Error! 정수만 입력가능.");
                return;
            }

	        Console.Write("학점 입력 : ");
            try
            {
                tempInfo.credit = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Error! 정수만 입력가능.");
                return;
            }

            // 학생정보에 과목등록
            studentList[index].classList.Add(tempInfo);

            Console.WriteLine("학번 : " + studentList[index].id.ToString() + ", 추가됨 (과목명: " +
                tempInfo.code + ", " + 
		        tempInfo.section.ToString() + "분반, " + tempInfo.credit.ToString() + "학점)\n");
            //Console.WriteLine(studentList[index].classList.GetStart().info.code);
        }
        
        //	수강포기
        private void DropClass(StudentInfo[] studentList)
        {
	        int stuID = 0;
	        int index = -1;
	        int i = 0;
            string dropCode;
	        int dropSection;

            Console.Write("학번을 입력하세요 : ");
            try
            {
                
                stuID = Convert.ToInt32(Console.ReadLine());
                if (stuID > 1999 || stuID < 1001)
                {
                    Console.WriteLine("Error!! 올바른 학번이 아닙니다. [1001~1999]");
                    return;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error!! 올바른 학번이 아닙니다. [1001~1999]");
                return;
            }

            // 해당학생 검색
	        for(i = 0; i < Program.MAX_STUDENT_CNT; i++)
	        {
		        if(studentList[i].id == stuID)
		        {
			        index = i;
			        break;
		        }
	        }

	        if(index == -1)
	        {
                Console.WriteLine("해당 학생이 존재하지 않습니다.\n");
                return;
	        }
            //수강과목이 없을경우
	        if(studentList[index].classList.Length() == 0)
	        {
                Console.WriteLine("현재 수강하고 있는 과목이 없습니다.\n");
		        return;
	        }

            // 현재 수강하고 있는 과목 목록 출력
            Console.WriteLine("현재 수강하고 있는 과목 목록");
	        Console.WriteLine("-------------------------------------------------");
	        Console.WriteLine(" 과목명              분반              학점 ");
            Console.WriteLine("-------------------------------------------------");
            int ii=1;
            foreach (ClassInfo ci in studentList[index].classList)
            {
                Console.WriteLine(" {0}. {1,-10}{2,12}{3,20}",ii++, ci.code, ci.section, ci.credit);
            }
            /*
            for (int j = 0; j < studentList[i].classList.Length(); j++)
            {
                Console.Write("(" + studentList[i].classList.Get(j).code + ", ");
                Console.Write(studentList[i].classList.Get(j).section.ToString() + ", ");
                Console.Write(studentList[i].classList.Get(j).credit.ToString() + ") ");
                Console.WriteLine("");
            }*/
            Console.WriteLine("-------------------------------------------------");

            // 드랍할 과목 정보 입력
            Console.WriteLine("어떤과목을 삭제할건가요? ");
	        Console.Write("삭제할 과목명 입력 : ");

            dropCode = Console.ReadLine();
	                	
	        Console.Write("삭제할 과목의 분반 입력: ");
            try
            {
                dropSection = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Error! 정수만 입력가능.\n");
                return;
            }
            
            for(int j = 0; j < studentList[index].classList.Length(); j++)
            {
                if (studentList[index].classList.Get(j).code == dropCode &&
                    studentList[index].classList.Get(j).section == dropSection)
                {
                    Console.WriteLine("과목명 : " + studentList[index].classList.Get(j).code + ", 분반 : " + 
                         studentList[index].classList.Get(j).section.ToString() + " 과목이 삭제되었습니다.\n");
                    
                    studentList[index].classList.Del(j);                    
                    return;
                }
            }

            Console.WriteLine("Error! 찾을 수 없습니다.\n");            
        }
    }
}