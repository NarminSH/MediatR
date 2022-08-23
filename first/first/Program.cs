// See https://aka.ms/new-console-template for more information
//1st task
int[] nums = { 10, 20, 30, 40, 20, 30 };

Dictionary<int, int> dict = new Dictionary<int, int>();

var temp = new HashSet<Int32>();

for (int i = 0; i < nums.Length; i++)
{
    if (temp.Contains(nums[i]))
    {
        Console.WriteLine(nums[i] + " is a duplicate");
    }
    else
    {
        temp.Add(nums[i]);
    }
}


// 2nd task
static bool checkName()
{
    string name = "kaman";
    string[] names = { "Narmin", "Leyla", "Arzu" };
    for (int i = 0; i < names.Length; i++)
    {
        if (names[i] == name)
        {
            return true;
        }
    }
    return false;
};

Console.WriteLine(checkName());

//3rd task
int[] arr = { 1, 2, 3, 4, 5, 6 };
Console.WriteLine(string.Join("\n", arr));

