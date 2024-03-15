using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Assembly: ConsoleApp1
namespace ConsoleApp1
{
    public class Program
    {
        // internal 접근자가 지정된 변수, 클래스는 선언된 어셈블리 내에서만 접근이 가능하다.
        // 쉽게 말해 같은 프로젝트 파일에서 접근이 가능하다는 것

        // 어셈블리란?
        // NET 런타임 환경에서 실행할 수 있는 (사전 컴파일 된) 코드 덩어리이다.
        // NET 프로그램은 하나 이상의 어셈블리로 구성된다.
        // 어셈블리는 .net 응용 프로그램의 가장 작은 배포 단위이다.
        // dll 또는 exe 주로 두 가지 유형이 있다.

        // 개인 어셈블리
        // 한 응용 프로그램의 유일한 속성인 dll 또는 exe. 일반적으로 응용 프로그램 루트 폴더에 저장된다.

        // 공용 / 공유 어셈블리
        // 한 번에 여러 프로그램에서 사용할 수 있는 dll. 공유 어셈블리는 GAC, 즉 Gloabal Assembly Cache에 저장된다.

        // 왜 Main() 메소드는 static으로 되어 있는가?
        // C#에서 Main() 메소드를 실행할 때 CLR에서 실행 클래스의 객체가 생성되기 전에 접근해야 하기 때문에
        // static 멤버 메소드의 접근은 객체의 생성과 전혀 상관이 없다.
        // 만약, 해당 클래스가 Main() 메소드를 포함하고 있고 해당 클래스를 실행하면 CLR에서는 static Main() 메소드를 찾게된다.

        // CLR
        // Common Language Runtime, Microsoft의 .NET 프레임워크에서 사용되는 핵심 컴포넌트 중 하나.
        // CLR은 .NET 언어로 작성된 프로그램을 실행하고 관리하는 역할을 한다.
        // 주요기능은 가상머신(VM) 기능, 가비지 컬렉션을 통한 메모리 관리, 예외처리, 보안

        static void Main(string[] args)
        {
            // int 배열 선언
            int[] numbers = { 0, 1, 2, 3, 4, 5, 6 };

            var numQuery =
                from num in numbers
                where (num % 2) == 0
                select num;

            foreach (int num in numQuery)
            {
                // 각 요소 사이 한 칸의 공백 지정
                // Console.WriteLine("{0,1} ", num);
            }

            // Console.WriteLine(LinqSum(numbers));

            // LinqWhere(numbers);

            LinqDistinct();

            LinqOrderBy();

            LinqChaining();
        }

        static int LinqSum(int[] numbers)
        {
            // 배열 요소의 합
            int sum = numbers.Sum();

            return sum;
        }

        static void LinqWhere(IEnumerable<int> numbers)
        {
            // 3보다 큰 요소만 가져오기
            IEnumerable<int> newNumbers = numbers.Where(x => x > 3);

            foreach (int num in newNumbers)
            {
                Console.WriteLine(num);
            }
        }

        static void LinqSkipTake()
        {
            // 0부터 99까지의 정수 시퀀스 생성
            var data = Enumerable.Range(0, 100);

            // Skip() - 지정된 수만큼의 데이터를 제외
            // Take() - 지정된 수만큼의 데이터 가져오기
            var next = data.Skip(10).Take(5); // 10개 제외하고 5개 가져오기

            foreach (var n in next)
            {
                Console.WriteLine(n);
            }
        }

        static void LinqDistinct()
        {
            var data = Enumerable.Repeat(3, 5); // 3을 5개 저장
            var result = data.Distinct(); // 중복 제거

            foreach (var n in result)
            {
                Console.WriteLine("{0}\t", n);
            }
        }

        static void LinqOrderBy()
        {
            string[] colors = { "Red", "Green", "Blue" };

            // 데이터를 오름차순으로 정렬
            var sortedColorsAsc = colors.OrderBy(name => name);

            foreach (var color in sortedColorsAsc)
            {
                Console.WriteLine(color);
            }

            // 데이터를 내림차순으로 정렬
            var sortedColorDesc = colors.OrderByDescending(c => c);

            foreach (var color in sortedColorDesc)
            {
                Console.WriteLine(color);
            }
        }

        static void LinqChaining()
        {
            List<string> names = new List<string> { "노티드", "올드페리도넛", "퀸즈베리" };

            // 체이닝: 확장 메소드를 여러 개 사용하는 것
            var results = names.Where(name => name.Length > 3).OrderBy(n => n);

            foreach (var name in results)
            {
                Console.Write("{0,1} ", name); // 올드페리도넛, 퀸즈베리
            }
        }
    }
}
