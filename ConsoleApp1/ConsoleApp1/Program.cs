using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{   // 메인 프로그램
    // 과목정보 구조 선언.
    public struct ClassInfo
    {
        public string code;
        public int section;
        public int credit;
    }

    // 학생정보 구조 선언
    struct StudentInfo
    {
        public int id;
        public SingleLinkedList<ClassInfo> classList;
    }

    class Program
    {   //기본 학생수 20명, 최대 학생수 30명;
        public const int MAX_STUDENT_CNT = 999;
        public const int MIN_STUDENT_CNT = 10;

        static void Main(string[] args)
        {
            Registration registor = new Registration();
            int nMenu = 0;

            // 최대 학생수로 배열크기를 정함.
            StudentInfo[] studentList = new StudentInfo[MAX_STUDENT_CNT];
            // 초기화
            registor.CreateStudentList(studentList);

            while (true)
            {
                Console.WriteLine("메뉴 번호를 입력후 Enter 키를 누르세요 : ");
                // 콘솔 메뉴
                registor.DisplayMenu();
                try
                {
                    // 선택입력받음
                    nMenu = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {   // 오류 예외처리
                    Console.WriteLine("Error! 1에서 5번까지의 숫자를 입력해주세요.\n");
                    continue;
                }

                if (registor.RunFunction(nMenu, studentList) == -1)
                    break;
            }
        }
    }
}
