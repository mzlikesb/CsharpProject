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
        public const int MAX_STUDENT_CNT = 30;
        public const int MIN_STUDENT_CNT = 20;

        static void Main(string[] args)
        {

        }
    }
}
