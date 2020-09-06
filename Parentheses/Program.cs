using System;
using System.Collections;
using System.Collections.Generic;

namespace Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] datas = new string[]{"(())","(((())))","())())","((())))",")(())(","()()(())"};
            foreach (var data in datas)
            {
                Console.WriteLine(IsLegal(data));
            }
        }

        public static bool IsLegal(string parentheses)
        {
            if (parentheses.Length % 2 == 1)//如果是奇數一定剩一個沒人要的
                return false;
            
            Stack<char> parenthesesStack = new Stack<char>();

            for (int i = 0; i < parentheses.Length; i++)
            {
                if (parentheses[i] == '(')//遇到左括號將他們塞進queue(男人乖乖排隊)
                {
                    parenthesesStack.Push(parentheses[i]);
                }
                else if (parentheses[i] == ')')
                {
                    if (parenthesesStack.Count <= 0)//右括號找不到左括號配對(女人找不到可以配對的人)
                    {
                        return false;
                    }

                    parenthesesStack.Pop();//Pop出一個左括號去追求右括號(就是'()')
                }
                else
                {
                    return false;//這聯誼公司詐騙阿 拿不是括號的來聯誼
                }
            }

            if (parenthesesStack.Count != 0)//檢查有沒有剩下的人
            {
                return false;
            }
            return true;
        }
    }
}
