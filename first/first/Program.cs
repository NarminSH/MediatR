// See https://aka.ms/new-console-template for more information
//1st task
int[] nums = { 10, 20, 30, 40, 20, 30 };

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

//4th task
string sentence = "Together we can do so much!";
if (sentence.Contains("we") == true)
{
    Console.WriteLine("Word found!");
}

//5th task
int[] numbers = { 3, 4, 5, 6, 7 };
string[] cities = { "Baku", "Sum", "Shusha" };
foreach(int num in numbers)
{
    Console.WriteLine(num);
}

foreach (string city in cities)
{
    Console.WriteLine(city);
}

//6th task
int[] firstSet = { 1, 2, 4, 6, 7, 8,9,10,11};
int[] secondSet = { 3, 5, 6, 7, 8 };
int[] sameValues = new int[1];
int[] differentValues = new int[1];
for (int i =0; i < firstSet.Length; i++)
{
    if (secondSet.Contains(firstSet[i])){
        Console.WriteLine(firstSet[i] + "  first set");
        Array.Resize(ref sameValues, sameValues.Length + firstSet[i]);
        Console.WriteLine(sameValues.Length + "dmskvcndsjcvd");
        sameValues[i] = firstSet[i];
    }
    else
    {
        Array.Resize(ref differentValues, differentValues.Length + firstSet[i]);
        differentValues[i] = firstSet[i];
    }
}
for(int i = 0; i < sameValues.Length; i++)
{
    Console.WriteLine(sameValues[i]);
}
for (int i = 0; i < differentValues.Length; i++)
{
    Console.WriteLine(differentValues[i]);
}
