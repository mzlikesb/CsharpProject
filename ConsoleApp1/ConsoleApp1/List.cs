using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    // 연결 정보를 저장하는 Node 클래스
    class Node<T>
    {
        public T info;
        public Node<T> link;

        public Node(T i)
        {
            info = i;
            link = null;
        }
    }

    // 단일 연결 리스트 클래스
    class SingleLinkedList<T> : IComparable
    {
        private Node<T> start;                      // head 역할
        private Node<T> end;                        // tail 역할 

        public SingleLinkedList()
        {
            start = null;
            end = null;
        }             // 리스트 기본값을 만드는 함수

        public Node<T> GetStart()
        {
            return start;
        }                // Start를 찾아오는 함수

        public T Get(int x)
        {
            Node<T> temp = start;
            for (int i = 0; i < x; i++)
            {
                temp = temp.link;
            }
            return temp.info;
        }                 // 노드의 정보를 가져오는 함수


        public Node<T> GetNode(int x)
        {
            Node<T> temp = start;
            for (int i = 0; i < x; i++)
            {
                temp = temp.link;
            }
            return temp;
        }            // 해당 번호의 노드를 가져오는 함수

        public void Add(T Data)
        {
            if (start == null)
            {
                start = new Node<T>(Data);
                end = start;
            }
            else
            {
                Node<T> A = new Node<T>(Data);
                end.link = A;
                end = A;
            }

        }                // 노드를 맨 뒤에 추가하는 함수

        public void Add(T Data, int x)         // 노드를 중간에 추가하는 함수
        {
            Node<T> temp1 = GetNode(x - 1).link;
            GetNode(x - 1).link = new Node<T>(Data);
            GetNode(x).link = temp1;
        }

        public void Del(int x)
        {
            if (Length() == x + 1)
            {
                end = GetNode(x - 1);
                GetNode(x - 1).link = null;
            }
            else
            {
                GetNode(x - 1).link = GetNode(x + 1);
            }

        }                // 인덱스 값을 넣어서 지우는 함수

        public void Del(Node<T> y)
        {
            if (start == y)
            {
                start = start.link;     // 스타트가 이제 기존의 스타트가 가리키던 얘를 가리킨다.
            }
            else
            {
                Node<T> temp1 = start;
                Node<T> temp2 = start.link;
                while (temp2 != y)
                {
                    temp1 = temp2;
                    temp2 = temp2.link;
                }
                temp1.link = temp2.link;
            }
        }               // 노드를 직접 넣어서 지우는 함수

        public int Length()
        {
            int count = 0;
            Node<T> temp = start;
            while (temp != end)
            {
                count += 1;
                temp = temp.link;
            }
            return count + 1;          // 마지막 위치의 NODE 포함
        }                    // 리스트의 길이를 구해주는 함수

        public void Show(int x)
        {
            Console.WriteLine(Get(x));
        }                // 해당 번호의 노드에 담긴 정보를 출력해주는 함수

        public int CompareTo(object obj)
        {
            return this.CompareTo(obj);
        }

        public T this[int x]
        {
            get { return Get(x); }
            set
            {
                Node<T> temp = start;
                for (int i = 0; i < x; i++)
                {
                    temp = temp.link;
                }
                temp.info = value;
            }


        }


    }
}