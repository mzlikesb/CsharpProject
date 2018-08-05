using System;
using System.Collections;
namespace ConsoleApp1
{   // 메인 프로그램
    // 과목정보 구조 선언.
    class ClassInfo : IComparable, IEnumerable
	{
		public string code;
		public int section;
		public int credit;

        public int CompareTo(object obj)
        {
            return code.CompareTo(obj);
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)code).GetEnumerator();
        }
    }

    // 학생정보 구조 선언
	class StudentInfo :IComparable
	{
		public int id;
        public SingleLinkedList<ClassInfo> classList;

        public int CompareTo(object obj)
        {
            return id.CompareTo(obj);
        }
    }

    class Program
    {
        //기본 학생수 20명, 최대 학생수 30명;
        public const int MAX_STUDENT_CNT = 30;
        public const int MIN_STUDENT_CNT = 20;

        static void Main(string[] args)
        {

            Registration registor = new Registration();
            int nMenu = 0;

            // 최대 학생수로 배열크기를 정함.
            //StudentInfo[] studentList = new StudentInfo[MAX_STUDENT_CNT];
            SingleLinkedList<StudentInfo> studentList = new SingleLinkedList<StudentInfo>();
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
                    nMenu = int.Parse(Console.ReadLine());
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
