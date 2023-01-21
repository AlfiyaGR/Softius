namespace WebApplication1.Models
{
    public class TaskD 
    {
        public string? TaskData { get; set; }

        // Находит ответ для набора заданий
        // Из примера: "11 21 107" для первого набора
        private string GetAnswer(List<List<int>> new_arr)
        {
            int time = 0; 
            string result = "";
            for (int i = 0; i < new_arr.Count; i++)
            {
                if (new_arr[i][0] > time)
                {
                    time = new_arr[i][0] + new_arr[i][1];
                    result += time + " ";
                }
                else
                {
                    time += new_arr[i][1];
                    result += time + " ";
                }
            }
            return result;
        }

        // Основное решение 
        public void Solution()
        {
            if (TaskData != null)
            {
                List<int> arr = Splitter(TaskData); 
                List<string> res = new List<string>(); // массив строк с результатом для каждого набора
                try
                {
                    int nums = arr[0]; // Общее число наборов
                    int i = 1;
                    while (nums > 0)
                    {
                        int counts = arr[i]; // Количество заданий
                        List<List<int>> new_arr = new List<List<int>>();
                        int k = i + 1;
                        while (k < i + counts * 2 + 1)
                        {
                            new_arr.Add(new List<int>
                        {
                            arr[k],
                            arr[k + 1]
                        });
                            k += 2;
                        }
                        string s = GetAnswer(new_arr); // Строка-результат для набора
                        res.Add(s);
                        i += counts * 2 + 1;
                        nums -= 1;
                    }
                    foreach (string s in res)
                    {
                        Console.WriteLine(s);
                    }
                }
                catch
                {
                    Console.WriteLine("Что-то пошло не так. Попробуй снова!");
                }
            }
        }

        // Возвращает массив с числами, введенными в форму
        // Из примера: [4, 3, 1, 10, 5, 10...]
        private List<int> Splitter(string s)
        {
            string[] split = s.Split('\n'); 
            List<int> res = new List<int>();
            foreach (string s2 in split)
            {
                string[] split2 = s2.Split(' ');
                foreach (string num in split2)
                {
                    try
                    {
                        int ar = int.Parse(num);
                        res.Add(ar);
                    }
                    catch 
                    {
                        continue;
                    }
                }
            }
            return res;
        }
    }
}
