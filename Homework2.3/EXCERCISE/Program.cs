using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXCERCISE
{
    class Employee
    {
        protected string name, gender, age, group; // 필드 값

        public virtual void employee(string name, string gender, string age, string group)
        {
            this.name = name;
            this.gender = gender;
            this.age = age;
            this.group = group;
        }
        public virtual void Print()
        {
            Console.WriteLine("직원입니다.");
        }
        public void Data()
        {
            Console.WriteLine();
            Console.WriteLine("이름 : {0}", name);
            Console.WriteLine("성별 : {0}", gender);
            Console.WriteLine("나이 : {0}", age);
            Console.WriteLine("부서 : {0}", group);
            this.Print(); // 기반클래스의 경우 "직원입니다."를 출력하고 파생클래스에서 오버라이딩하면 다른 값을 출력한다.
        }
    }
    class SalesPerson : Employee
    {
        public override void employee(string name, string gender, string age, string group) // 기반클래스의 메소드를 상속받아 기반클래스 필드 값 설정
        {
            base.name = name;
            base.gender = gender;
            base.age = age;
            base.group = group;
        }
        public override void Print()
        {
            Console.WriteLine("영업직원입니다."); // 기반클래스 Print()메소드에 덮어씌운다.
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee(); // 인스턴스 생성
            Employee spl = new SalesPerson(); // 인스턴스 생성
            string name, gender, age, group;
            Console.WriteLine("직원데이터를 입력하세요.");
            Console.WriteLine("(이름, 성별, 나이, 부서 순)\n");
            Console.Write("이름 > ");
            name = Console.ReadLine();
            Console.Write("성별 > ");
            gender = Console.ReadLine();
            Console.Write("나이 > "); // 나이 값을 정수형으로 사용하고싶으면 int.Parse()로 변환해서 사용하는 방법도 있다.
            age = Console.ReadLine();
            Console.Write("부서 > ");
            group = Console.ReadLine();
            emp.employee(name, gender, age, group);
            spl.employee(name, gender, age, group);
            emp.Data(); // 기반클래스 출력
            spl.Data(); // 파생클래스 출력
            Console.WriteLine();
        }
    }
}
